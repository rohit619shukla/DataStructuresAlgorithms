# Message Queues — Interview Cheat Sheet

## What / Why
- Infra sitting between **producer** (creates work) and **consumer** (does work). Producer writes a message and moves on; consumer reads it later.
- Core idea: **decouple in time** → producer & consumer don't need to be up/fast at the same moment.
- Buys you: **resilience** (consumer down → message waits), **elasticity** (spikes buffer, drain gradually), **independent scaling** (add consumers only).
- Cost: **async / eventually consistent**, possible **duplicates**, possible **out-of-order**.

**Opener:** "A queue lets producers hand off work async → services decoupled, spikes absorbed, failures retried. Cost is eventual consistency + duplicates + ordering. The real design work is idempotency, retries, ordering."

## Why not just call the service directly?
Synchronous chain (`Order→Payment→Inventory→Email→Analytics`) problems:
- Client waits for the slowest step.
- One failure fails everything.
- Spikes hit every service at once.
- Tightly coupled — new step = edit producer.

Queue fix: do essential work sync (validate+save), publish `OrderCreated`, return orderId. Rest consumes in background.
> A queue doesn't make work disappear — it moves work out of user latency into a backlog you must monitor & drain.

## Core vocabulary
- **Producer / Consumer / Broker** (Kafka, RabbitMQ, SQS).
- **Message/Event** — small JSON.
- **Ack/Nack** — done → drop; failed → redeliver.
- **DLQ** — parking lot for messages that failed too many times.

**Message design:** keep small (big blob → put in S3, pass URL). Include: unique **event ID** (dedup), **type + version**, **timestamp**, **entity ID** (partition key), **trace/correlation ID**.

## Three flavors (don't mix these up)
| | Work Queue | Pub/Sub | Event Stream (log) |
|---|---|---|---|
| Who gets a msg | ONE worker | Every subscriber | Every consumer group reads whole log |
| After processing | Removed on ack | Removed per sub | Kept until retention expires |
| Replay? | No | Limited | Yes (first-class) |
| Use for | Spread jobs | Fan-out event | Replay, audit, ordered history |
| Example | Image resize | order→pay/inv/email | Kafka → warehouse |

**Trap:** email+inventory+analytics as competing consumers on ONE queue → each msg goes to only one → wrong. Fix: **pub/sub = one topic, separate consumer group per service.**

## Delivery guarantees
| Guarantee | Lose? | Duplicate? | When |
|---|---|---|---|
| At-most-once | Yes | No | Non-critical telemetry |
| **At-least-once** | No | Yes | **Almost everything** |
| Exactly-once | No | No net effect | Payments — via idempotency, within a boundary |

**Say this:** "At-least-once + idempotent consumers = never lose a msg, duplicates never harm = exactly-once *behavior*. True exactly-once across broker+DB+external API isn't automatic — ask which boundary they mean."

## Idempotency (most important consumer property)
Processing a msg twice = same result as once. (Don't charge $50 twice → $100.)
- **Dedup table** (best): apply change + mark event ID processed **in same DB transaction**. Already recorded → skip. Scope per consumer.
- **Unique DB constraint** — duplicate insert rejected.
- **Idempotency key with external API** (Stripe) — reuse order ID as key.
- **Design naturally idempotent** — set absolute state ("mark paid") not relative ("increment counter").

> Broker guarantees *delivery*; only your consumer prevents duplicate *effect*.

## Ack, retries, DLQ
- **Order: process → commit → ack.** Ack first then crash = data loss. Commit then crash before ack = safe redelivery (idempotency skips it).
- Long jobs: extend **visibility timeout** so slow ≠ double-processed.
- **Retry only transient** failures (timeouts, rate limits, brief outages). **Don't retry** permanent ones (bad schema, validation) → straight to DLQ.
- **Exponential backoff + jitter** (1s,2s,4s,8s + random) → avoids thundering herd.
- **DLQ** = parking lot, not a fix. Needs **alerting + diagnosis + replay tooling**. Unwatched DLQ = where data silently dies.
- **Poison message / head-of-line blocking:** in a strictly ordered queue, one always-failing msg blocks everything behind it. Fix: move to DLQ, or pause only the affected partition.

## Ordering & parallelism
- You almost never need **global order** (kills parallelism). You need **per-entity order**.
- Order #5's events must be Created→Paid→Shipped; #5 vs #99 are independent.
- Mechanism: **partition by key** (order ID) — same key stays ordered, different keys run parallel.
- **Quietly breaks ordering:** retrying one msg while others proceed; changing partition key; concurrent processing within one stream.

## Kafka (comes up in almost every interview)
Think **distributed, append-only, replayable log** — not a queue.

- **Topic** = stream, split into **partitions**. **Order is preserved within a partition, never across the topic.**
- `partition = hash(key) % partitionCount`. Partition count = unit of parallelism.
- **Hot partition:** low-cardinality key (country) floods one partition → pick high-cardinality key (user/order ID).
- **Adding partitions later** changes key→partition mapping → breaks ordering. Size generously up front.
- **Offset** = position in partition. Replay by resetting offset backward. Commit offset *after* processing = at-least-once.
- **Consumer group:** each partition → at most one consumer in the group.
  - Parallelism capped by partition count (6 consumers, 4 partitions → 2 idle).
  - Different groups each get the FULL stream → this is pub/sub fan-out.
  - Join/leave → **rebalance** (briefly pauses); flapping hurts throughput.
- **Consumer lag** = latest offset − committed offset. Primary health metric.
- **Retention** = keep msgs by time/size regardless of consumption → enables replay & new consumers reading history.
- **Exactly-once**: only Kafka→Kafka (idempotent producers + transactions). Does NOT extend to external APIs/DBs.

## Backpressure & monitoring
Producers > consumers → backlog grows. Options:
- Scale consumers (Kafka: only up to partition count) · add partitions · batch · optimize downstream · rate-limit producer (last resort).

**Top metric: age of the oldest unprocessed message.** Queue depth = backlog size; oldest-age = whether users are actually suffering. (1M msgs seconds old = fine; 1K msgs an hour old = pain.)
Also watch: consumer lag/partition, produce vs consume rate, DLQ rate, broker disk usage.

## Dual-write problem → Transactional Outbox
- Order service must **save order** AND **publish event** — two systems, no shared transaction. If one succeeds and the other fails → state & events diverge. Naive `save(); publish();` has this bug.
- **Fix:** write business row + an **outbox row** in **one DB transaction** (both commit or neither). A **relay / CDC** reads unpublished outbox rows and publishes them.

```
Order DB (Order row + Outbox row, one txn) → Outbox Relay/CDC → Broker → Consumers
```
- Event published **iff** order saved. Relay may still double-publish on crash → fine, consumers are idempotent. Outbox solves *atomicity*; idempotency handles *duplicates*.

## Choosing a broker
| | Kafka | RabbitMQ | Managed (SQS/Service Bus/Pub-Sub) |
|---|---|---|---|
| Model | Append-only log | Broker + queues/exchanges | Fully managed |
| Replay | Excellent | Limited | Varies |
| Retention | Time/size, independent of consumption | Removed after ack | Configurable |
| Best fit | Streaming, CDC, replay, many groups | Task queues, complex routing | Standard semantics, minimal ops |

**Heuristic:** Kafka = replayable ordered log + many consumers · RabbitMQ = flexible routing / task queues · Managed = semantics without running infra.

## Queue vs direct call
- **Queue** when: caller doesn't need result now · bursty traffic · consumers scale independently · many systems react to one event.
- **Direct call** when: caller needs the result to respond (fetch profile to render page).
- **Best = hybrid:** essential work sync + return, publish event for the rest.

## Putting it together — order processing
```
Client → POST /orders → Order API ─(one txn)→ Orders DB + Outbox
   → returns orderId immediately
Outbox Relay/CDC → "Orders" topic (key = orderId)
   → Payment | Inventory | Notification | Analytics groups
```
Decisions: at-least-once · transactional outbox · partition by orderId · idempotent consumers · backoff+jitter retries · monitored DLQ · alert on oldest-age + lag.

**Failure walk-through (interviewers love this):**
- Payment crashes after charging, before committing offset → redelivered → idempotency key → no double charge.
- Outbox relay times out publishing → retries → consumers dedup by event ID → no effect.
- Inventory temporarily down → retry w/ backoff → exhausts → DLQ → investigate/refund.
