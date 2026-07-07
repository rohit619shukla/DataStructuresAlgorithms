# Apache Cassandra

## The One-Line Answer (Say This First in an Interview)

> **Cassandra** is a **distributed, wide-column NoSQL database** built for **massive write throughput, linear horizontal scalability, and no single point of failure**.
> It achieves this by being **masterless (peer-to-peer)** and **AP by default** in CAP terms — it favors **availability and partition tolerance** over strong consistency, though consistency is **tunable per query**.

Reach for Cassandra when you have **write-heavy, always-on workloads at scale** (time-series, event logs, IoT, messaging, feeds) and you can **design your tables around your queries**.

---

## Quick Facts (Cheat Sheet)

| Dimension | Cassandra |
|-----------|-----------|
| **Type** | Wide-column NoSQL |
| **Architecture** | Masterless, peer-to-peer ring — every node is equal |
| **CAP** | **AP** (Available + Partition-tolerant), tunable consistency |
| **Consistency model** | Eventual by default; **tunable per read/write** |
| **Scaling** | Horizontal — add nodes for linear throughput gain |
| **Write path** | Extremely fast (append-only, LSM-tree based) |
| **Query language** | **CQL** (SQL-like, but no joins, limited WHERE) |
| **Best for** | Write-heavy, time-series, high-availability workloads |
| **Weak at** | Ad-hoc queries, joins, aggregations, strong consistency |
| **Origin** | Facebook (inbox search) → Apache; inspired by Amazon Dynamo (distribution) + Google Bigtable (data model) |

---

## Why Cassandra Exists — The Problem It Solves

Traditional relational databases scale **vertically** (bigger machine) and use a **single master** for writes. This creates two problems at internet scale:

1. **A single point of failure** — if the master dies, writes stop.
2. **A write bottleneck** — one machine can only absorb so many writes.

Cassandra's answer:
- **No master.** Every node can accept reads *and* writes.
- **Data is partitioned and replicated** across many commodity nodes.
- **Losing a node doesn't stop the cluster** — replicas keep serving.

> **Interview line:** "Cassandra trades the convenience of joins and strong consistency for **guaranteed availability and effortless horizontal scale**."

---

## Architecture — The Ring

Cassandra nodes form a **ring**. There is **no master and no slave** — this is *peer-to-peer*.

```
                 ┌──────────┐
            ┌────│  Node A  │────┐
            │    └──────────┘    │
      ┌──────────┐          ┌──────────┐
      │  Node F  │          │  Node B  │
      └──────────┘          └──────────┘
            │                    │
      ┌──────────┐          ┌──────────┐
      │  Node E  │          │  Node C  │
      └──────────┘          └──────────┘
            │    ┌──────────┐    │
            └────│  Node D  │────┘
                 └──────────┘

  • Every node is identical (peer-to-peer)
  • A row's placement is decided by hashing its PARTITION KEY
  • Data is REPLICATED to N nodes (Replication Factor)
  • Nodes gossip to share cluster state
```

### Key mechanisms
- **Partitioner (consistent hashing):** hashes the **partition key** to decide which node owns the data. Consistent hashing means adding/removing a node only reshuffles a small slice of data.
- **Replication Factor (RF):** how many copies of each row exist. RF=3 is standard.
- **Gossip protocol:** nodes periodically exchange state ("who's alive, who owns what") — no central coordinator.
- **Coordinator node:** the node a client contacts becomes the *coordinator* for that request and routes it to the replicas. Any node can coordinate.

---

## Tunable Consistency (The Most Important Concept)

Cassandra lets you **trade consistency for latency/availability per query** by choosing a **consistency level (CL)** — the number of replicas that must acknowledge.

| Consistency Level | Meaning |
|-------------------|---------|
| `ONE` | 1 replica must respond (fastest, least consistent) |
| `QUORUM` | Majority of replicas — `(RF/2) + 1` |
| `LOCAL_QUORUM` | Quorum within the local datacenter (avoids cross-DC latency) |
| `ALL` | Every replica must respond (strongest, least available) |

### The Golden Rule — Strong Consistency Formula

> **If `R + W > RF`, you get strong (read-your-write) consistency.**

Where `R` = read CL, `W` = write CL, `RF` = replication factor.

**Example (RF = 3):**
- Write with `QUORUM` (W=2) + Read with `QUORUM` (R=2) → `2 + 2 = 4 > 3` ✅ strongly consistent.
- Write `ONE` (1) + Read `ONE` (1) → `1 + 1 = 2 < 3` ❌ eventual consistency (fast, may read stale data).

This is why people say Cassandra is **"AP but tunable toward CP."**

---

## Data Modeling — Query-First (Interview Favorite)

This is the **biggest mindset shift** from SQL and a very common interview probe.

> **In relational DBs you model data, then write queries.**
> **In Cassandra you start from the queries, then design tables to serve them.**

Rules:
- **One table per query pattern.** Denormalize freely; **duplicate data** across tables instead of joining.
- **No joins. No `GROUP BY`/aggregations at scale. No ad-hoc `WHERE`.**
- You can only efficiently filter on the **primary key** (partition key + clustering columns).

### Primary Key = Partition Key + Clustering Key

```
PRIMARY KEY ((partition_key), clustering_col1, clustering_col2)
                  │                    │
                  │                    └─ Sorts rows WITHIN a partition
                  └─ Decides WHICH NODE stores the row (via hashing)
```

- **Partition key** → determines data distribution (which node). Queries must supply it.
- **Clustering key** → determines **sort order inside** a partition (enables range scans like "last 10 messages").

### Example — messages by user

```sql
CREATE TABLE messages_by_user (
    user_id     UUID,
    msg_time    TIMESTAMP,
    message     TEXT,
    PRIMARY KEY ((user_id), msg_time)
) WITH CLUSTERING ORDER BY (msg_time DESC);

-- Efficient: partition key supplied, results pre-sorted
SELECT * FROM messages_by_user WHERE user_id = ? LIMIT 20;
```

### Anti-patterns to mention
- **Hot partitions:** a partition key that funnels most traffic to one node (e.g. partitioning by `country='US'`). Pick a **high-cardinality, evenly-distributed** key.
- **Unbounded partitions:** a partition that grows forever (e.g. all events under one key). Add a **time bucket** to the partition key (`(sensor_id, day)`).
- **Querying without the partition key** → forces `ALLOW FILTERING` = full-cluster scan = don't.

---

## The Write Path — Why Writes Are So Fast

Cassandra uses an **LSM-tree (Log-Structured Merge tree)** design — writes are **append-only**, never in-place updates.

```
WRITE ──▶ 1. Commit Log   (append to disk — durability)
      ──▶ 2. Memtable     (in-memory, sorted)
              │  (when full / flushed)
              ▼
          3. SSTable       (immutable, on-disk file)
```

- **Commit Log:** sequential append → crash recovery.
- **Memtable:** in-memory write buffer.
- **SSTable:** immutable sorted files flushed from the memtable. Never modified after write.
- **Compaction:** a background process merges SSTables, discards overwritten/expired data.

Because there are **no random disk seeks and no read-before-write**, writes are extremely cheap → Cassandra's superpower.

### Tombstones (common follow-up)
Deletes don't remove data immediately — they write a **tombstone** marker. The data is purged later during compaction (after `gc_grace_seconds`). **Too many tombstones slow reads** — beware delete-heavy / queue-like workloads.

---

## The Read Path (Briefly)

A read may have to merge data from multiple places:
1. Check **Memtable** (newest data).
2. Check **Row Cache / Bloom filter** (bloom filter = "is this key possibly in this SSTable?" — avoids useless disk reads).
3. Read relevant **SSTables** and **merge by timestamp** (latest wins).

Reads are inherently **more expensive than writes** (multiple SSTables + merge). This is the fundamental Cassandra trade-off: **cheap writes, pricier reads.**

---

## Replication & Multi-Datacenter

- **Replication strategy:** `NetworkTopologyStrategy` (production) places replicas across **racks and datacenters** for fault isolation.
- **Multi-DC** is first-class — great for **geo-distributed, low-latency global apps** and **disaster recovery**.
- **Read repair** and **hinted handoff** heal inconsistencies:
  - **Hinted handoff:** if a replica is down, the coordinator stores a "hint" and replays the write when it recovers.
  - **Read repair:** on reads, mismatched replicas are updated to the latest value in the background.
  - **Anti-entropy repair (`nodetool repair`):** periodic full reconciliation using Merkle trees.

---

## When to Use Cassandra ✅ vs Avoid ❌

| Use Cassandra when... | Avoid Cassandra when... |
|-----------------------|-------------------------|
| Write-heavy workloads (logs, events, IoT, metrics) | You need complex joins / ad-hoc queries |
| Time-series data | You need ACID multi-row transactions |
| Need always-on availability (no downtime) | Data volume is small (over-engineering) |
| Massive horizontal scale across datacenters | Strong consistency is mandatory (banking core ledger) |
| Query patterns are known in advance | Query patterns are unpredictable / analytical |

**Real-world users:** Netflix, Discord, Instagram, Apple, Uber.

---

## Cassandra vs Other Databases

| | Cassandra | MongoDB | DynamoDB | PostgreSQL |
|---|-----------|---------|----------|------------|
| **Model** | Wide-column | Document | Key-value / wide-column | Relational |
| **Architecture** | Masterless P2P | Primary-secondary | Managed, masterless | Single primary |
| **Consistency** | Tunable (AP) | Strong-ish (CP-leaning) | Tunable | Strong (CP) |
| **Best at** | Write-heavy at scale | Flexible documents | Serverless AWS scale | Transactions & joins |
| **Ops** | Self-managed (heavier) | Moderate | Fully managed | Moderate |

> **DynamoDB vs Cassandra:** very similar distribution model (both Dynamo-inspired). DynamoDB is **fully managed/serverless (AWS)**; Cassandra is **open-source, self-hosted / multi-cloud** (or use managed **ScyllaDB / DataStax Astra**).

---

## Common Interview Questions (Q&A)

**Q: Is Cassandra CP or AP?**
A: **AP by default** — it prioritizes availability and partition tolerance. But consistency is **tunable per query**; with `R + W > RF` you can achieve strong consistency at the cost of some availability.

**Q: Why are Cassandra writes so fast?**
A: LSM-tree design — writes are an **append to the commit log + an in-memory memtable write**, with **no read-before-write and no random disk seeks**. SSTables are immutable and flushed sequentially.

**Q: What's the difference between partition key and clustering key?**
A: The **partition key** decides *which node* stores the row (via hashing → distribution). The **clustering key** decides the *sort order of rows within* that partition (enables range queries).

**Q: What is a hot partition and how do you avoid it?**
A: A partition key that concentrates traffic/data on one node. Avoid by choosing a **high-cardinality, evenly distributed** key and adding **bucketing** (e.g. time buckets) to bound partition size.

**Q: How does Cassandra handle deletes?**
A: With **tombstones** — a delete writes a marker; actual removal happens later during **compaction** after `gc_grace_seconds`. Excessive tombstones degrade read performance.

**Q: What does "query-first data modeling" mean?**
A: You design **one table per query pattern** and denormalize/duplicate data, rather than normalizing and joining. Cassandra has no joins, so the schema is shaped by *how you read*, not by entity relationships.

**Q: How does Cassandra stay available when a node fails?**
A: Data is replicated (RF copies). Reads/writes succeed as long as the required **consistency level** of replicas responds. **Hinted handoff** and **read repair** heal the down node when it returns.

**Q: What is the coordinator node?**
A: Any node a client connects to for a request; it routes the operation to the correct replicas and returns the result. There's no fixed coordinator — the role is per-request.

---

## Key Takeaways

- Cassandra = **masterless, wide-column, AP-by-default** database for **write-heavy, highly-available, scalable** workloads.
- **Tunable consistency:** `R + W > RF` → strong consistency.
- **Query-first modeling:** one table per query, denormalize, **no joins**.
- **Primary key = partition key (placement) + clustering key (sort within partition).**
- **Fast writes** thanks to **LSM-tree** (commit log → memtable → SSTable → compaction).
- Watch out for **hot partitions, unbounded partitions, and tombstones**.
- Choose it for **time-series, logging, IoT, messaging, feeds** — not for joins, transactions, or ad-hoc analytics.

---

*Last Updated: 2026-07-07*
