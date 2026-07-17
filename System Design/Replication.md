# Replication

## The One-Line Answer (Say This First in an Interview)

> **Replication** is **keeping copies of the same data on multiple machines (replicas)** so the system stays **available** if a node dies and can **serve more reads** by spreading load across copies.
> You replicate for **high availability, fault tolerance, read scaling, and lower latency** (place a copy near the user).

The interviewer wants to hear the **why** (availability + read scaling), the **topology** (leader-follower / multi-leader / leaderless), and the **trade-off you can't escape**: replication lag and consistency.

---

## Replication vs Sharding (Don't Confuse These)

| | **Replication** | **Sharding (Partitioning)** |
|---|---|---|
| **What it does** | Copies the *same* data to multiple nodes | Splits data into *disjoint* subsets |
| **Each node holds** | A *full copy* of the data | A *slice* of the data |
| **Primarily scales** | Read concurrency + availability | Writes + storage + targeted reads |
| **Analogy** | Photocopies of the same book | Different chapters in different books |

> **Interview soundbite:** Replication does **not** scale writes — every write still goes to (and must be applied by) every copy. It scales **reads and availability**. To scale writes you need **sharding**. Real systems do both: **shard the data, then replicate each shard.**

```
        Replication (copies)                 Sharding (splits)
   ┌────────┐  ┌────────┐  ┌────────┐   ┌────────┐ ┌────────┐ ┌────────┐
   │ FULL   │  │ FULL   │  │ FULL   │   │ users  │ │ users  │ │ users  │
   │ dataset│  │ dataset│  │ dataset│   │ A–H    │ │ I–P    │ │ Q–Z    │
   └────────┘  └────────┘  └────────┘   └────────┘ └────────┘ └────────┘
    same data everywhere                 disjoint slices per shard
```

---

## Why Replicate? (The 4 Reasons)

1. **High availability** — if one node dies, another copy serves traffic. No single point of failure.
2. **Read scalability** — spread read queries across many replicas (read-heavy systems love this).
3. **Lower latency** — put a replica geographically close to users (EU users hit the EU replica).
4. **Durability / backups** — more copies = less chance of data loss.

---

## Leader-Follower Replication (a.k.a. Primary-Replica / Master-Slave)

The **most common** model. One node is the **leader** (primary); the rest are **followers** (replicas).

```
              writes
                │
                ▼
          ┌──────────┐
          │  LEADER  │  ← the ONLY node that accepts writes
          └────┬─────┘
      replicate│ stream
     ┌─────────┼─────────┐
     ▼         ▼         ▼
 ┌────────┐┌────────┐┌────────┐
 │Follower││Follower││Follower│  ← serve READS only
 └────────┘└────────┘└────────┘
```

- **All writes** go to the leader. The leader streams its changes (its **replication log**) to followers.
- **Reads** can be served by the leader **or** any follower.
- **Failover:** if the leader dies, a follower is **promoted** to leader.

> **Interview soundbite:** Leader-follower is simple and avoids write conflicts (single writer), but the **leader is a write bottleneck and a failover risk**.

---

## Synchronous vs Asynchronous Replication (The Core Trade-off)

This is **the** question. When the leader gets a write, does it wait for followers before acking the client?

| | **Synchronous** | **Asynchronous** |
|---|---|---|
| **Leader waits for follower ack?** | ✅ Yes, before confirming write | ❌ No, confirms immediately |
| **Data loss on leader crash?** | ✅ No (follower has it) | ❌ Possible (unreplicated writes lost) |
| **Write latency** | ❌ Higher (wait for network + follower) | ✅ Low (fire and forget) |
| **Availability** | ❌ Write blocks if follower is down | ✅ Writes continue |
| **Consistency** | Strong (on the synced replica) | Eventual |

- **Fully synchronous** is rarely used — one slow/dead follower stalls *all* writes.
- **Fully asynchronous** is common (fast) but risks losing recently-acked writes if the leader dies before replicating.
- **Semi-synchronous (the practical middle)** — leader waits for **at least one** follower to ack, the rest are async. Guarantees the data survives on ≥2 nodes without waiting for everyone.

> **Interview soundbite:** Most production systems use **semi-synchronous** replication — a balance of durability (data on ≥2 nodes) and performance (don't wait for every replica).

---

## Replication Lag & Its Consistency Problems

With asynchronous replication, the leader confirms a write immediately and copies it to the followers a moment later. During that short delay the followers are **slightly behind** the leader — this delay is called **replication lag**.

The problem: a user might **write** to the leader but then **read** from a follower that hasn't received that write yet. Because reads and writes can land on different machines that are momentarily out of sync, three classic anomalies appear.

### 1. Read-Your-Own-Writes (you can't see your own change)

**What happens, step by step:**
1. Priya posts a comment. The write goes to the **leader**, which saves it and confirms success.
2. Her browser immediately reloads the page. That read is routed to **Follower B**.
3. Follower B has not yet received the new comment from the leader (it is 200 ms behind).
4. Priya sees the page **without her own comment** and thinks the post failed — so she posts it again, creating a duplicate.

**Fix:** For a short window right after a user writes, serve *that user's own* reads from the **leader** (or from a follower already known to be caught up). Everyone else can still read from any follower.

### 2. Monotonic Reads (time appears to move backward)

**What happens, step by step:**
1. Priya refreshes her feed. The first read hits **Follower A**, which is up to date and shows **15 comments**.
2. She refreshes again a second later. This time the read hits **Follower B**, which is more behind and only knows about **12 comments**.
3. From Priya's point of view, **three comments just disappeared** — the data went backward in time.

**Fix:** Always send the same user to the **same follower** (for example, pick the replica using a hash of the user's ID). If she always reads from one replica, she can never jump to an older, more-lagged one.

> *Monotonic reads is a weaker promise than read-your-writes: it only guarantees you never see data go backward, not that you see the very latest value.*

### 3. Consistent Prefix Reads (you see the answer before the question)

This one appears in **sharded** systems where different pieces of data live on different partitions that replicate at different speeds.

**What happens, step by step:**
1. On a Q&A page, Mr. Ali writes a question: *"How far are you from the office?"* (stored on Partition 1).
2. Mrs. Ali replies: *"About ten minutes"* (stored on Partition 2).
3. An observer reads the conversation. Partition 2 (the answer) has already replicated, but Partition 1 (the question) is still lagging.
4. The observer sees the **answer "About ten minutes" before the question**, which makes no sense.

**Fix:** Make sure writes that are **causally related** (question and its answer) are written to the **same partition** or are given an ordering, so a reader can never see a later event before the earlier one it depends on.

> **Interview soundbite:** Asynchronous replication gives **eventual consistency** — every replica catches up *eventually*, but until then readers can see stale data. Being able to name **read-your-writes**, **monotonic reads**, and **consistent-prefix** anomalies with their fixes shows real depth.

---

## Multi-Leader Replication

Multiple nodes accept writes; each leader replicates to the others.

```
   ┌──────────┐          ┌──────────┐
   │ Leader A │ ◀──────▶ │ Leader B │   ← both accept writes,
   │  (US)    │  sync    │  (EU)    │     replicate to each other
   └──────────┘          └──────────┘
```

- ✅ **Great for multi-datacenter** (each region writes locally → low latency) and **offline clients** (write locally, sync later).
- ❌ **Write conflicts:** the same row edited on two leaders concurrently → must be resolved.

**Conflict resolution strategies:**
- **Last-Write-Wins (LWW)** — keep the write with the latest timestamp. Simple but **loses data**.
- **Application-defined merge** — custom logic (e.g. merge two shopping carts).
- **CRDTs** (Conflict-free Replicated Data Types) — data structures that merge automatically without conflict.

> Use multi-leader **only when you need multi-region writes or offline editing** — the conflict complexity is real.

---

## Leaderless Replication (Dynamo-style / Quorum)

**No leader.** The client (or a coordinator) writes to **and** reads from **multiple replicas directly**. Used by **Cassandra, DynamoDB, Riak**.

### Quorum Consistency: The W + R > N Rule

- **N** = number of replicas
- **W** = nodes that must acknowledge a **write**
- **R** = nodes that must respond to a **read**

> **If `W + R > N`, read and write sets overlap → every read is guaranteed to see the latest write** (strong-ish consistency).

```
   N = 3 replicas
   ┌────┐ ┌────┐ ┌────┐
   │ R1 │ │ R2 │ │ R3 │
   └────┘ └────┘ └────┘

   W = 2, R = 2  →  W + R = 4 > 3  ✅ overlap guaranteed
```

- **Common config:** `N=3, W=2, R=2` — tolerates one node down for both reads and writes.
- **Tune for read-heavy:** `W=3, R=1` → fast reads, slower writes.
- **Tune for write-heavy / high availability:** `W=1, R=3` → fast writes, but weaker durability.

**Fixing stale replicas:**
- **Read repair** — on a read, if the client sees a stale replica, it writes the fresh value back to it.
- **Anti-entropy / hinted handoff** — background process (and temporary storage of writes for down nodes) reconciles replicas over time.

> **Interview soundbite:** Leaderless with quorums (`W + R > N`) trades single-leader simplicity for **no failover step and tunable consistency** — you dial the consistency/latency knob per query.

---

## Failover: What Happens When the Leader Dies

Automatic failover promotes a follower to leader. **It's harder than it sounds:**

- **Detecting failure** — is the leader really dead or just slow/network-partitioned? (False positives cause chaos.)
- **Choosing a new leader** — pick the most up-to-date follower (least lag).
- **Split-brain** ⚠️ — the old leader comes back and *two* nodes think they're leader → conflicting writes. Prevented with **fencing / quorum-based election** (e.g. a majority must agree, using ZooKeeper/etcd/Raft).
- **Lost writes** — with async replication, writes not yet replicated when the leader died are **gone**.

> **Interview soundbite:** The scariest failover bug is **split-brain** — two leaders accepting writes. Prevent it with a **consensus-based election** requiring a quorum (Raft/Paxos, ZooKeeper, etcd).

---

## How Replication Data Is Shipped

- **Statement-based** — ship the SQL statements. Fragile: `NOW()`, `RAND()`, auto-increment behave differently per replica.
- **Write-Ahead Log (WAL) shipping** — ship the low-level storage-engine log. Tightly couples replicas to the storage format/version. (See `WAL.md`.)
- **Logical (row-based) replication** — ship the logical row changes (insert/update/delete). Decoupled from storage engine, version-tolerant — the **modern default** (e.g. Postgres logical replication, MySQL row-based binlog).

---

## How Replication Fits with Sharding (Real Architecture)

Production systems **combine both**: shard for write/storage scale, replicate each shard for availability + read scale.

```
   ┌──────────── Shard 1 ────────────┐   ┌──────────── Shard 2 ────────────┐
   │  Primary  →  Replica  →  Replica│   │  Primary  →  Replica  →  Replica│
   │  (writes)    (reads)    (reads) │   │  (writes)    (reads)    (reads) │
   └─────────────────────────────────┘   └─────────────────────────────────┘
       users A–M                              users N–Z
```

- Each **shard** has its own **primary + replicas**.
- **Sharding** handles write/storage scale; **replication** handles read concurrency + failover.

---

## Common Interview Questions

### Q1: What is replication and why do you use it?
Replication keeps **full copies of the data on multiple nodes**. You do it for **high availability** (survive node failure), **read scalability** (spread reads across copies), **lower latency** (place copies near users), and **durability**. It does **not** scale writes — that's sharding's job.

### Q2: Replication vs sharding?
**Replication copies the full dataset** to many nodes → scales **reads + availability**. **Sharding splits the data** into disjoint subsets → scales **writes + storage**. They're complementary: shard the data, then replicate each shard.

### Q3: Synchronous vs asynchronous replication?
**Synchronous** waits for follower acks → no data loss but higher latency and writes stall if a follower is down. **Asynchronous** acks immediately → fast but can lose recent writes on leader failure. Most systems use **semi-synchronous** (wait for at least one follower) as the balance.

### Q4: What is replication lag and what problems does it cause?
With async replication, followers trail the leader. This causes **read-your-writes** violations (you don't see your own write), **non-monotonic reads** (data appears to move backward), and **inconsistent prefix** anomalies. Fixes: read your own writes from the leader, pin users to one replica, order causally-related writes.

### Q5: Explain quorum consistency (W + R > N).
In leaderless replication with **N** replicas, requiring **W** write acks and **R** read responses where **W + R > N** guarantees the read and write sets **overlap**, so reads see the latest write. Common config: `N=3, W=2, R=2`. Tune W/R to favor read or write performance.

### Q6: What is split-brain and how do you prevent it?
**Split-brain** is when a network partition (or a recovered old leader) leaves **two nodes both acting as leader**, accepting conflicting writes. Prevent it with **quorum/consensus-based leader election** (Raft/Paxos via ZooKeeper or etcd) and **fencing tokens** so only one leader can commit.

### Q7: When would you use multi-leader replication?
When you need **writes in multiple regions** (low local latency per datacenter) or **offline clients** that write locally and sync later. The cost is **write conflicts**, resolved via last-write-wins, custom merge logic, or CRDTs.

### Q8: How does failover work and what can go wrong?
A follower (usually the most up-to-date one) is promoted to leader. Risks: **false failure detection**, **lost writes** (unreplicated async writes), and **split-brain**. Robust failover uses consensus and fencing.

### Q9: How is replication related to the CAP theorem?
Replication is where CAP bites: during a **network partition**, you must choose — keep serving (stay **Available** but risk **stale/inconsistent** reads) or reject requests to preserve **Consistency**. Sync/quorum leans CP; async leans AP. (See `CAP Theorem.md`.)

---

## Key Takeaways for Interviews

1. **Replication = full copies on multiple nodes** — for availability, read scaling, latency, durability.
2. **Replication scales reads + availability; sharding scales writes + storage** — use both together.
3. **Sync = durable but slow; Async = fast but can lose writes;** **semi-sync** is the practical middle.
4. **Async replication → replication lag → eventual consistency** (read-your-writes, monotonic reads).
5. **Leader-follower** (single writer, simple), **multi-leader** (multi-region, conflicts), **leaderless/quorum** (Dynamo-style, tunable).
6. **Quorum rule: `W + R > N`** guarantees reads see the latest write.
7. **Failover's worst bug is split-brain** — prevent with consensus (Raft/Paxos) + fencing.
8. **Logical (row-based) replication** is the modern default over statement- or WAL-shipping.
9. **Replication forces CAP choices** during partitions — consistency vs availability.

---

*Last Updated: 2026-07-12*
