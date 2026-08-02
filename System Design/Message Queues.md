# Message Queues

## One-Line Answer (Say This First)

> A **message queue** is an asynchronous layer where producers publish messages and consumers process them independently. It **decouples services, absorbs traffic spikes, and enables retries**, at the cost of **eventual consistency, duplicates, and ordering complexity**.

In an interview, cover: **why** you need it, **what guarantees** the workflow needs, **how messages are partitioned/retried**, **how consumers stay idempotent**, and **what happens on failure**.

---

## Why Use a Message Queue?

Synchronous chain: `Client -> Order -> Payment -> Inventory -> Email -> Analytics`. The client waits for everything, one slow/down service breaks the request, and spikes hit every service at once.

With a queue, the order service persists the order, publishes an event, and responds immediately.

| Problem | How Messaging Helps |
|---|---|
| Tight coupling | Producer doesn't know/need consumers |
| Traffic spikes | Broker buffers until consumers catch up |
| Slow operations | Run asynchronously in the background |
| Temporary failures | Retry instead of losing work |
| Scaling | Add consumers without scaling producers |
| Fan-out | Many subscribers react to one event |

> **Soundbite:** A queue doesn't make work disappear; it moves it from request latency into a backlog you must monitor and drain.

---

## Core Components

```text
Producer --publish--> Broker/Queue --consume--> Consumer
                     (persists, routes, redelivers)
```

- **Producer / Consumer** - publish / process messages.
- **Broker** - stores and routes.
- **Ack / Nack** - confirm success / failure.
- **Offset** - consumer's position in an ordered log.
- **DLQ** - holds messages that repeatedly fail.

Keep messages small: store large files in object storage, send the ID/URL. Include a unique **event ID** (for dedup), event type/version, timestamp, entity ID (partition key), and trace ID.

---

## Queue vs Pub/Sub vs Stream

| | Work Queue | Pub/Sub | Event Stream |
|---|---|---|---|
| Delivery | One worker per message | Each subscription gets a copy | Each consumer group reads the log |
| Retention | Removed after ack | Broker-dependent | Kept by time/size |
| Replay | Limited | Broker-dependent | First-class |
| Use for | Distribute jobs | Notify many systems | Replay + ordered history |

> **Soundbite:** Work queue = distribute jobs, pub/sub = notify multiple systems, stream = replay and ordered history.

**Common trap:** If email, inventory, and analytics all consume from the *same queue as competing consumers*, only one gets each message. When all must react, use **one topic with separate consumer groups** (compete *within* a group, copy *across* groups).

---

## Delivery Guarantees

| Guarantee | Lose? | Duplicate? | Use |
|---|---|---|---|
| At-most-once | Yes | No | Non-critical telemetry |
| At-least-once | No | Yes | **Most workflows** |
| Exactly-once | No | No effect | Payments (via idempotency + transactions) |

True end-to-end exactly-once across a broker, DB, and external API is not automatic. Some platforms offer it within a limited boundary (e.g. Kafka topic-to-topic).

> **Soundbite:** Prefer **at-least-once + idempotent consumers**. If asked for exactly-once, clarify the boundary.

---

## Idempotency (Most Important Consumer Requirement)

Repeating the operation gives the same result as doing it once.

**Deduplication table** - insert the event ID and apply the business change in the **same DB transaction**; skip if the ID already exists.

```sql
CREATE TABLE ProcessedEvents (
    consumer_name VARCHAR(100),
    event_id VARCHAR(100),
    PRIMARY KEY (consumer_name, event_id)
);
```

Other techniques: unique DB constraints, idempotency keys with payment APIs, setting absolute state (`status = 'PAID'`) instead of relative (`attempts += 1`).

> **Soundbite:** The broker guarantees delivery; only the consumer can guarantee duplicate delivery != duplicate effect.

---

## Ack, Retry, and DLQ

**Ack only after the business effect commits.** Acking first then crashing loses the message; committing first then crashing causes a safe redelivery (handled by idempotency). For long jobs, extend the visibility timeout so the broker doesn't hand the job to another worker.

**Retry only transient failures** (timeouts, rate limits, brief outages). Don't retry permanent ones (bad schema, missing fields, validation failures).

**Exponential backoff with jitter:** `1s -> 2s -> 4s -> 8s...` + random jitter so a fleet doesn't retry in sync after an outage.

**Dead-Letter Queue** - after N attempts, move the message (with payload, error, attempt count) to a DLQ. A DLQ needs **alerts, diagnosis, and safe replay tooling** - it's not a fix by itself.

**Poison message / head-of-line blocking:** a message that always fails blocks a strictly ordered queue. Send it to the DLQ, or pause only the affected partition instead of the whole fleet.

---

## Ordering, Partitions, and Consumer Groups

Global ordering is expensive and usually unnecessary. Kafka preserves order **within a partition**, not across a topic.

```text
partition = hash(orderId) % partitionCount
Order A -> Partition 1: Created -> Paid -> Shipped
```

Partitioning by `orderId` keeps each order's events ordered while parallelizing across orders. **Ask what scope of ordering is actually required** - usually per-entity, not global.

**Consumer groups:** one partition -> at most one consumer in a group; adding consumers helps only up to the partition count (extra consumers sit idle).

**Hot partition:** a low-cardinality key (e.g. `country`) overloads one partition. Use a high-cardinality key (user/order ID).

**What breaks ordering:** retrying one message while others proceed, changing the partition key, adding partitions, concurrent processing within a partition.

---

## Backpressure and Monitoring

If producers outpace consumers, the backlog grows. Handle it by scaling consumers (up to partition count), adding partitions, batching, optimizing downstream, or rate-limiting producers.

**Key metrics:**
- **Age of oldest unprocessed message** - tells you if users are actually delayed.
- Consumer lag per partition, queue depth, produce/consume rates, DLQ rate, broker disk.

> **Soundbite:** Queue depth isn't enough - the **age of the oldest message** tells you whether users are waiting.

---

## Transactional Outbox (Dual-Write Problem)

An order service must save the order **and** publish `OrderCreated` - two systems, no shared transaction. If one succeeds and the other fails, state and events diverge.

**Fix:** write the business row and an outbox row in **one local transaction**, then a relay/CDC publishes the outbox to the broker.

```text
BEGIN TRANSACTION
  INSERT INTO Orders ...
  INSERT INTO OutboxEvents ...
COMMIT
Outbox Relay/CDC -> Broker -> Consumers
```

The relay can still publish twice (crash after publish, before marking done), so consumers still need idempotency.

> **Soundbite:** Outbox atomically persists state + intent to publish; idempotent consumers handle the relay's possible duplicates.

---

## Saga (Multi-Service Workflows)

A transaction can't span microservices. A **saga** = local transactions + compensating actions.

- **Choreography** - services react to each other's events. Simple, loosely coupled, but hard to follow as it grows.
- **Orchestration** - a central orchestrator sends commands and tracks state. Better visibility, but a stateful component.

> **Soundbite:** A saga gives eventual consistency via compensation - not an ACID rollback across services.

---

## Kafka vs RabbitMQ vs Managed Cloud

| | Kafka | RabbitMQ | SQS / Service Bus / Pub-Sub |
|---|---|---|---|
| Model | Distributed log | Broker with queues/exchanges | Managed service |
| Replay | Excellent | Limited | Service-dependent |
| Retention | Time/size, independent of consumption | Removed after ack | Configurable |
| Best fit | Streaming, CDC, replay, many consumer groups | Task queues, rich routing | Operational simplicity |

> **Soundbite:** Kafka = replayable log, RabbitMQ = flexible broker, managed = less ops for standard semantics.

---

## Message Queue vs Direct Call

Use a **queue** when the caller doesn't need an immediate result, traffic is bursty, consumers scale independently, or many systems react to an event. Use a **direct call** when the result is needed to respond.

**Hybrid:** respond synchronously with the order ID, publish an event for secondary work (payment, email, analytics).

---

## Interview Case Study: Order Processing

```text
Client -> Order API --tx--> Orders DB (+ Outbox)
                \-- return orderId
Outbox CDC -> Orders Topic (key = orderId)
   |-> Payment CG      |-> Inventory CG
   |-> Notification CG  \-> Analytics CG
```

**Key decisions:** at-least-once delivery, idempotent payment (`orderId` as provider idempotency key), transactional outbox, partition by `orderId`, retry with backoff, DLQ, saga for compensation, monitor oldest-message age.

**Failures:**
- *Payment consumer crashes after charging* -> redelivered; same idempotency key -> provider returns original result, no double charge.
- *Broker publish times out* -> relay retries; consumers dedup by event ID.
- *Inventory unavailable* -> backoff; on exhaustion, saga compensates (refund).

---

## Interview Checklist (Cheat Sheet)

**Present a queue in this order:**
1. **Why** - state the problem it solves (don't add one blindly).
2. **Model** - work queue vs pub/sub; command vs event.
3. **Guarantees** - at-least-once? ordering scope? retention?
4. **Failures** - ack after commit, idempotency, backoff, DLQ, outbox.
5. **Scaling** - partition key, partition count, consumer groups, lag.

**Common mistakes to avoid:**
- Claiming exactly-once without a boundary.
- Acking before the DB commit.
- Forgetting idempotency under at-least-once.
- One competing-consumer queue when every service needs the event.
- Requiring global ordering when per-entity is enough.
- Retrying permanent failures forever.
- DLQ with no monitoring/replay.
- Ignoring the dual-write problem.
- Low-cardinality partition key (hot partition).
- Monitoring queue size but not oldest-message age.

## 30-Second Summary

> Queues decouple producers/consumers, absorb bursts, and add resilience via async processing. I'd use at-least-once delivery, ack only after the business transaction commits, and make consumers idempotent via event IDs or unique constraints. Partition keys give per-entity ordering and parallelism; retries use exponential backoff + jitter; a monitored DLQ handles poison messages; a transactional outbox solves the DB-and-broker dual write. Kafka fits replayable streams, RabbitMQ fits flexible routing, managed queues cut ops.
