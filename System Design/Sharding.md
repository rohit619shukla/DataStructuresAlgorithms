# Sharding

## The One-Line Answer (Say This First in an Interview)

> **Sharding** is **horizontal partitioning of data across multiple independent databases (shards)**, where each shard holds a **subset of the rows** and no single machine holds the whole dataset.
> You shard when **one database can no longer handle the data volume, write throughput, or working-set size** — sharding scales **writes and storage**, which read replicas alone cannot.

The interviewer wants to hear **why** you shard, **how you pick the shard key**, and the **trade-offs you accept** (cross-shard joins, rebalancing, hotspots).

---

## Partitioning vs Replication (Don't Confuse These)

| | **Sharding (Partitioning)** | **Replication** |
|---|---|---|
| **What it does** | Splits data into disjoint subsets | Copies the same data to multiple nodes |
| **Each node holds** | A *slice* of the data | A *full copy* of the data |
| **Primarily scales** | Writes + storage | Reads + availability |
| **Analogy** | Different chapters in different books | Photocopies of the same book |

> **Interview soundbite:** Replication is for **read scaling & availability**; sharding is for **write scaling & storage**. Real systems use **both** — shard the data, then replicate each shard.

```
        Replication (copies)                 Sharding (splits)
   ┌────────┐  ┌────────┐  ┌────────┐   ┌────────┐ ┌────────┐ ┌────────┐
   │ FULL   │  │ FULL   │  │ FULL   │   │ users  │ │ users  │ │ users  │
   │ dataset│  │ dataset│  │ dataset│   │ A–H    │ │ I–P    │ │ Q–Z    │
   └────────┘  └────────┘  └────────┘   └────────┘ └────────┘ └────────┘
    same data everywhere                 disjoint slices per shard
```

---

## Vertical vs Horizontal Partitioning

- **Horizontal partitioning (= sharding):** split by **rows**. Shard 1 has users 1–1M, shard 2 has users 1M–2M. Same schema, different rows.
- **Vertical partitioning:** split by **columns/features**. Put `user_profile` in one store and `user_photos` (large blobs) in another. Different schema per partition.

> When people say "sharding" they almost always mean **horizontal** partitioning.

---

## Sharding Strategies (The Core Interview Topic)

### 1. Range-Based Sharding

Rows are assigned to shards by **ranges of the shard key**.

```
  key 0–1000   → Shard A
  key 1001–2000 → Shard B
  key 2001–3000 → Shard C
```

- ✅ **Simple**; efficient **range queries** (e.g. "all orders from Jan–Mar").
- ❌ **Hotspots**: sequential keys (auto-increment IDs, timestamps) all hit the **newest** shard. Uneven data distribution.
- **Used by:** HBase, MongoDB (ranged).

### 2. Hash-Based Sharding

Apply a **hash function to the shard key**, then map the hash to a shard: `shard = hash(key) % N`.

```
  hash("user:42")  % 4 → Shard 2
  hash("user:99")  % 4 → Shard 3
```

- ✅ **Even distribution**; avoids hotspots.
- ❌ **Kills range queries** (adjacent keys scatter everywhere).
- ❌ **Naive `% N` is fragile** — adding/removing a shard remaps *almost everything*. (→ solved by **consistent hashing**.)
- **Used by:** Cassandra, DynamoDB, many key-value stores.

### 3. Directory / Lookup-Based Sharding

A **lookup table (directory service)** maps each key (or key range) to a shard.

```
  ┌──────────── Lookup Table ────────────┐
  │  region=US    → Shard A              │
  │  region=EU    → Shard B              │
  │  region=APAC  → Shard C              │
  └───────────────────────────────────────┘
```

- ✅ **Maximum flexibility** — rebalance by editing the map; can group related data.
- ❌ The **directory is a single point of failure / bottleneck** and an extra lookup hop.
- **Used by:** systems needing custom placement (e.g. tenant-based multi-tenancy).

### 4. Geo / Entity-Based Sharding

Shard by a **business dimension** — geography, tenant, or customer — so related data lives together.

- ✅ **Data locality** (EU users on EU shards → low latency, GDPR compliance).
- ❌ Uneven load if one region/tenant is much larger ("whale" tenants).

### Strategy Comparison

| Strategy | Even Distribution | Range Queries | Rebalancing | Hotspot Risk |
|----------|-------------------|---------------|-------------|--------------|
| **Range** | ❌ Poor | ✅ Excellent | Medium | ⚠️ High |
| **Hash** | ✅ Excellent | ❌ Poor | Hard (naive) / Easy (consistent) | ✅ Low |
| **Directory** | ✅ Tunable | ⚠️ Depends | ✅ Easy | ⚠️ Depends |
| **Geo/Entity** | ⚠️ Uneven | ✅ Within region | Medium | ⚠️ Whale tenants |

---

## Consistent Hashing (Almost Always a Follow-Up)

**Problem with `hash(key) % N`:** if `N` changes (add/remove a shard), **nearly every key remaps**, causing a massive data reshuffle and cache-miss storm.

**Consistent hashing** places both **shards and keys on a hash ring**. A key belongs to the **next shard clockwise**. Adding/removing a shard only moves the keys in **one arc** — roughly **1/N of the data**, not all of it.

```
              0/360°
                │
        Shard C │        Shard A
           ●────┼────●
          /     │     \
         /      │      \
    key ●       │       ● key
         \      │      /
          \     │     /
           ●────┼────●
        (arc)   │   Shard B
                │
   Key → walk clockwise → first shard found owns it.
   Add a shard → only the arc before it is remapped.
```

- **Virtual nodes (vnodes):** each physical shard is placed at **many points** on the ring → smoother distribution and no big gaps.
- **Used by:** Cassandra, DynamoDB, Riak, and consistent-hash load balancers.

> **Interview soundbite:** Consistent hashing minimizes data movement when the cluster scales — only ~1/N of keys move instead of nearly all.

---

## The Shard Key: The Most Important Decision

Everything hinges on choosing a good **shard key** (a.k.a. partition key).

**A good shard key is:**
- **High cardinality** — many distinct values (so data spreads across shards).
- **Evenly distributed** — no single value dominates.
- **Aligned with query patterns** — most queries should target a **single shard**.
- **Rarely changing** — changing the key means moving the row to another shard.

**Bad shard keys:**
- **Low cardinality** (e.g. `country` for a US-only app, `boolean` flags) → few crowded shards.
- **Monotonically increasing** (auto-increment ID, timestamp) → all writes hit the newest shard (**hotspot**).
- **Keys mismatched with queries** → every query becomes a **scatter-gather** across all shards.

> **Composite keys** help: e.g. shard by `hash(user_id)` but cluster by `timestamp` within the shard — even distribution *and* efficient per-user range scans.

---

## Hotspots (The "Celebrity" / "Hot Partition" Problem)

Even with hashing, one **single key** can be extremely popular (a celebrity's profile, a viral tweet, a Black-Friday product) and overload its shard.

**Mitigations:**
- **Key salting** — append a random/bucketed suffix (`celebrity_id#0..9`) to spread one hot key across multiple partitions, then merge on read.
- **Dedicated cache** in front of hot keys (Redis/CDN).
- **Split the hot partition** into finer sub-shards.

---

## Challenges & Trade-offs of Sharding

Sharding is **powerful but expensive in complexity**. Call these out to show maturity.

| Challenge | Why It Hurts | Mitigation |
|-----------|--------------|------------|
| **Cross-shard joins** | Data on different nodes — joins need scatter-gather | Denormalize; keep related data co-located |
| **Cross-shard transactions** | No single-node ACID | Avoid; or use 2PC / Saga pattern (eventual consistency) |
| **Rebalancing / resharding** | Adding shards moves data & risks downtime | Consistent hashing; pre-split; online migration tools |
| **Hotspots** | One shard overloaded | Better shard key; salting; caching |
| **Operational complexity** | Backups, monitoring, failover per shard | Automation, managed services (Vitess, Citus) |
| **Fan-out queries** | Non-shard-key queries hit every shard | Secondary indexes; design queries around shard key |

> **Rule of thumb:** **Don't shard until you have to.** First exhaust **vertical scaling**, **read replicas**, **caching**, and **indexing**. Sharding is a **one-way door** that adds permanent complexity.

---

## Scatter-Gather (Fan-out Queries)

When a query **doesn't include the shard key**, the router must query **all shards** and merge results.

```
                 ┌──────────┐
   query ───────▶│  Router  │
                 └────┬─────┘
        ┌────────────┼────────────┐
        ▼            ▼            ▼
    Shard A      Shard B      Shard C     ← every shard queried
        └────────────┼────────────┘
                     ▼
             merge + sort results
```

- ❌ Slow (bounded by the **slowest** shard), expensive, doesn't scale.
- ✅ **Design queries around the shard key** so most requests hit **one** shard.

---

## How Sharding Fits with Replication (Real Architecture)

Production systems **combine both**: shard for scale, replicate each shard for availability.

```
   ┌──────────── Shard 1 ────────────┐   ┌──────────── Shard 2 ────────────┐
   │  Primary  →  Replica  →  Replica│   │  Primary  →  Replica  →  Replica│
   │  (writes)    (reads)    (reads) │   │  (writes)    (reads)    (reads) │
   └─────────────────────────────────┘   └─────────────────────────────────┘
       users A–M                              users N–Z
```

- Each shard has its **own primary + replicas**.
- Sharding handles **write/storage scale**; replication handles **read scale + failover**.

---

## Common Interview Questions

### Q1: What is sharding and when would you use it?
Sharding is **horizontal partitioning** — splitting rows across multiple databases so each holds a subset. Use it when a **single DB can't handle the write throughput, data size, or working set**, and after you've already tried vertical scaling, read replicas, and caching. It scales **writes and storage**, which replicas cannot.

### Q2: Sharding vs replication — what's the difference?
**Replication copies the full dataset** to multiple nodes (scales **reads** + availability). **Sharding splits the data** into disjoint subsets (scales **writes** + storage). They're complementary — production systems shard, then replicate each shard.

### Q3: How do you choose a shard key?
Pick a key with **high cardinality, even distribution, alignment with query patterns, and stability**. Avoid monotonic keys (auto-increment IDs, timestamps → hotspots) and low-cardinality keys. Ideally most queries target a **single shard** to avoid scatter-gather.

### Q4: What's wrong with `hash(key) % N` and how does consistent hashing fix it?
With modulo hashing, **changing N remaps almost all keys**, causing huge data movement. **Consistent hashing** puts shards and keys on a ring so adding/removing a shard only moves **~1/N of keys** (one arc). Virtual nodes smooth out the distribution.

### Q5: Range-based vs hash-based sharding?
**Range** keeps ordering → great for **range queries**, but risks **hotspots** with sequential keys. **Hash** gives **even distribution** but **destroys range queries**. Choose based on whether you need range scans or uniform load.

### Q6: How do you handle a hotspot / celebrity problem?
A single hot key overloads its shard. Mitigate with **key salting** (spread one key across buckets), a **dedicated cache** in front, or **splitting the partition**. Fundamentally it's a shard-key/distribution problem.

### Q7: What are the downsides of sharding?
**Cross-shard joins and transactions become hard/expensive**, **rebalancing** is risky, **hotspots** can appear, and **operational complexity** multiplies (backups, monitoring, failover per shard). Non-shard-key queries turn into **scatter-gather**. Only shard when you must.

### Q8: How do cross-shard transactions work?
There's no cheap distributed ACID. Options: **avoid them by co-locating related data**, use **two-phase commit (2PC)** (correct but slow, blocking), or use the **Saga pattern** (a sequence of local transactions with compensating actions → eventual consistency). Most designs favor avoiding cross-shard transactions entirely.

### Q9: How do you reshard a live system without downtime?
Use **consistent hashing** to minimize moved data, **pre-split** shards ahead of growth, and perform an **online migration** (double-write to old+new, backfill, then cut over reads). Managed layers like **Vitess** (MySQL) or **Citus** (Postgres) automate much of this.

---

## Key Takeaways for Interviews

1. **Sharding = horizontal partitioning** — disjoint row subsets across nodes.
2. **Shard to scale writes + storage; replicate to scale reads + availability** — use both.
3. **Don't shard prematurely** — exhaust vertical scaling, replicas, caching, indexing first.
4. **The shard key is the #1 decision** — high cardinality, even, query-aligned, stable.
5. **Range = range queries but hotspots; Hash = even but no range queries.**
6. **Consistent hashing** minimizes data movement on resharding (~1/N moved).
7. **Hotspots (celebrity problem)** → salting, caching, splitting partitions.
8. **Cross-shard joins/transactions are the main pain** → denormalize, Saga, avoid.
9. **Non-shard-key queries → scatter-gather** — design queries around the shard key.
10. **Tools:** Vitess (MySQL), Citus (Postgres), Cassandra/DynamoDB (native).

---

*Last Updated: 2026-07-11*
