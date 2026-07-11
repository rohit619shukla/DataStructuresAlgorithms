# Apache Cassandra

## One-Line Answer (Say This First)

> **Cassandra** is a **distributed, wide-column NoSQL database** built for **massive write throughput, linear horizontal scale, and no single point of failure**. It's **masterless (peer-to-peer)** and **AP by default**, but consistency is **tunable per query**.

Use it for **write-heavy, always-on workloads** (time-series, logs, IoT, messaging, feeds) where you **design tables around your queries**.

---

## Cheat Sheet

| Dimension | Cassandra |
|-----------|-----------|
| **Type** | Wide-column NoSQL |
| **Architecture** | Masterless, peer-to-peer ring — every node equal |
| **CAP** | **AP**, tunable consistency |
| **Scaling** | Horizontal — add nodes for linear throughput |
| **Writes** | Extremely fast (append-only, LSM-tree) |
| **Query language** | **CQL** (SQL-like, no joins, limited WHERE) |
| **Best for** | Write-heavy, time-series, high availability |
| **Weak at** | Joins, aggregations, ad-hoc queries, strong consistency |
| **Origin** | Facebook → Apache; Dynamo (distribution) + Bigtable (data model) |

---

## Why It Exists

Relational DBs scale **vertically** with a **single master** → single point of failure + write bottleneck. Cassandra's answer: **no master** (every node accepts reads/writes), **data partitioned + replicated** across nodes, **losing a node doesn't stop the cluster**.

> **Interview line:** "Cassandra trades joins and strong consistency for **guaranteed availability and effortless horizontal scale**."

---

## Architecture — The Ring

Nodes form a **peer-to-peer ring** — no master, no slave.

- **Partitioner (consistent hashing):** hashes the **partition key** to pick which node owns a row. Adding/removing a node reshuffles only a small slice.
- **Replication Factor (RF):** number of copies per row. RF=3 is standard.
- **Coordinator node:** whichever node the client contacts; it routes the request to replicas. Any node can coordinate.
- **Gossip protocol:** every ~1s each node exchanges cluster state (who's alive, who owns what, schema version) with a few random peers. This decentralized membership + failure detection is what lets **any node coordinate** with no central authority.

> **Interview line:** "Gossip is Cassandra's decentralized membership and failure-detection protocol — nodes swap state with random peers so the masterless ring knows who's alive and who owns what."

---

## Tunable Consistency (Most Important Concept)

Choose a **consistency level (CL)** per query — how many replicas must ack:

| CL | Meaning |
|----|---------|
| `ONE` | 1 replica (fastest, least consistent) |
| `QUORUM` | Majority — `(RF/2)+1` |
| `LOCAL_QUORUM` | Quorum within local datacenter (avoids cross-DC latency) |
| `ALL` | Every replica (strongest, least available) |

### Golden Rule

> **If `R + W > RF`, you get strong (read-your-write) consistency.**

**Example (RF=3):** Write `QUORUM` (2) + Read `QUORUM` (2) → `2+2=4 > 3` ✅ strong. Write `ONE` + Read `ONE` → `1+1=2 < 3` ❌ eventual (fast, may be stale).

This is why Cassandra is **"AP but tunable toward CP."**

---

## Data Modeling — Query-First (Interview Favorite)

> **In SQL you model data, then query. In Cassandra you start from the queries, then design tables to serve them.**

- **One table per query pattern.** Denormalize; **duplicate data** instead of joining.
- **No joins, no aggregations at scale, no ad-hoc WHERE.**
- You can only efficiently filter on the **primary key**.

### Primary Key = Partition Key + Clustering Key

```
PRIMARY KEY ((partition_key), clustering_col)
                  │                 │
                  │                 └─ Sorts rows WITHIN a partition
                  └─ Decides WHICH NODE stores the row (via hashing)
```

- **Partition key** → data distribution (which node). Queries must supply it.
- **Clustering key** → sort order inside a partition (enables range scans like "last 10 messages").

### Example — messages by user

```sql
CREATE TABLE messages_by_user (
    user_id  UUID,
    msg_time TIMESTAMP,
    message  TEXT,
    PRIMARY KEY ((user_id), msg_time)
) WITH CLUSTERING ORDER BY (msg_time DESC);

SELECT * FROM messages_by_user WHERE user_id = ? LIMIT 20;  -- fast, pre-sorted
```

### Anti-patterns
- **Hot partition:** key funnels traffic to one node (e.g. `country='US'`). Pick a **high-cardinality, evenly-distributed** key.
- **Unbounded partition:** grows forever. Add a **time bucket** (`(sensor_id, day)`).
- **No partition key in query** → forces `ALLOW FILTERING` = full-cluster scan = don't.

---

## Write Path — Why Writes Are Fast

> **Every write is just an APPEND. Cassandra never overwrites in place — it writes a new version and cleans up later (LSM-tree).**

```
WRITE ──▶ Commit Log (append to disk — durability/crash recovery)
      ──▶ Memtable   (append in memory, sorted) ──▶ ACK to client
              │  (when full)
              ▼
          SSTable     (flushed as a NEW immutable file)
              │  (background)
              ▼
          Compaction  (merge SSTables, drop stale data)
```

- **Commit log** = durability only (replayed after a crash, never read normally).
- **Memtable** = latest writes in memory, serves reads. **Not a copy of disk** — it's the freshest layer not yet flushed.
- **SSTable** = immutable file flushed from memtable. **Never modified after write.**

Fast because: **no random seeks, no read-before-write** — just sequential appends.

### Immutable SSTables

| Operation | What happens |
|-----------|--------------|
| **Insert** | Append to memtable → flushed as new SSTable |
| **Update** | Append **new version** (newer timestamp) → new SSTable. Old value untouched |
| **Delete** | Append a **tombstone** marker → new SSTable. Data purged later by compaction |

### Tombstones (follow-up)
Deletes write a tombstone; real removal happens during compaction after `gc_grace_seconds`. **Too many tombstones slow reads** — avoid queue-like/delete-heavy workloads.

---

## Compaction

**Background** process that **merges many SSTables into fewer**, keeping the **newest version per row** and dropping stale versions + expired tombstones → reads stay fast, disk doesn't bloat.

Strategies (name-drop): **Size-Tiered** (write-heavy, default), **Leveled** (read-heavy), **Time-Window** (time-series/TTL).

---

## Read Path — Gather and Stitch

A row's data can live in the memtable **and** several SSTables (updates never overwrite). A read **gathers the pieces and stitches them by timestamp** — it does **not** modify disk (that's compaction).

### Example — read user #1

```
Memtable  → user1: city = "Pune"          (today)
SSTable-2 → user1: age  = 30              (Tue)
SSTable-1 → user1: name = "Rohit", age=20 (Mon)
```

1. Check **memtable** → `city="Pune"`.
2. **Bloom filters** on each SSTable ("has user1?") → skip files that say no (avoids useless disk reads).
3. Read matching SSTables → `name="Rohit", age=20` and `age=30`.
4. **Merge by timestamp (newest per column wins):** name=Rohit, age=**30**, city=Pune.
5. Return `{user1, Rohit, 30, Pune}`.

Reads are **pricier than writes** (a write is one append; a read gathers + merges across files). **Cheap writes, pricier reads.**

> **Interview line:** "A read checks the memtable, uses bloom filters to skip irrelevant SSTables, then stitches the rest by timestamp — latest value per column wins. It never rewrites disk; that's compaction."

---

## Replication & Multi-DC

- **NetworkTopologyStrategy** (production) spreads replicas across racks/datacenters.
- **Multi-DC is first-class** — geo-distributed low-latency + disaster recovery.
- Healing: **Hinted handoff** (store write for a down replica, replay later), **read repair** (fix stale replicas on read), **`nodetool repair`** (periodic full reconciliation).

---

## When to Use ✅ vs Avoid ❌

| Use when... | Avoid when... |
|-------------|---------------|
| Write-heavy (logs, events, IoT, metrics) | Complex joins / ad-hoc queries |
| Time-series data | ACID multi-row transactions |
| Always-on availability | Small data (over-engineering) |
| Massive scale across datacenters | Strong consistency mandatory (bank ledger) |
| Known query patterns | Unpredictable / analytical queries |

**Users:** Netflix, Discord, Instagram, Apple, Uber.

---

## Cassandra vs Others

| | Cassandra | MongoDB | DynamoDB | PostgreSQL |
|---|-----------|---------|----------|------------|
| **Model** | Wide-column | Document | Key-value/wide-column | Relational |
| **Architecture** | Masterless P2P | Primary-secondary | Managed masterless | Single primary |
| **Consistency** | Tunable (AP) | CP-leaning | Tunable | Strong (CP) |
| **Best at** | Write-heavy at scale | Flexible docs | Serverless AWS | Transactions & joins |

> **DynamoDB vs Cassandra:** same Dynamo-inspired distribution. DynamoDB = fully managed AWS; Cassandra = open-source, self-hosted/multi-cloud.

---

## Interview Q&A

**Is Cassandra CP or AP?** AP by default; tunable per query — `R+W>RF` gives strong consistency.

**Why are writes fast?** Every write is an append (commit log + memtable), no read-before-write, no random seeks. SSTables are immutable.

**How does a read work across memtable + SSTables?** Gathers the row's pieces (bloom filters skip irrelevant SSTables), stitches by timestamp (newest per column). Doesn't rewrite disk.

**What is compaction?** Background merge of SSTables → keeps newest version, drops stale data + tombstones. Strategies: Size-Tiered (write), Leveled (read), Time-Window (time-series).

**Partition key vs clustering key?** Partition key → which node (distribution). Clustering key → sort order within a partition.

**Hot partition — how to avoid?** Key that concentrates traffic on one node. Use high-cardinality keys + bucketing (e.g. time buckets).

**How does Cassandra handle deletes?** Tombstones; purged during compaction after `gc_grace_seconds`.

**Query-first modeling?** One table per query, denormalize/duplicate — schema shaped by how you read, not entity relationships.

**Coordinator node?** Any node a client connects to; routes the request to replicas. Per-request role.

**Gossip protocol?** Decentralized membership + failure detection — nodes swap cluster state (liveness, ownership, schema) with random peers every ~1s.

---

## Key Takeaways

- Masterless, wide-column, **AP-by-default** — for write-heavy, highly-available, scalable workloads.
- **Tunable consistency:** `R + W > RF` → strong.
- **Query-first modeling:** one table per query, denormalize, no joins.
- **Primary key = partition key (placement) + clustering key (sort).**
- **Fast writes** via LSM-tree — every write is an append (commit log → memtable → immutable SSTable → compaction).
- **Reads gather & stitch** across memtable + SSTables by timestamp; compaction keeps them fast.
- Watch out for **hot/unbounded partitions and tombstones**.

---

*Last Updated: 2026-07-11*
