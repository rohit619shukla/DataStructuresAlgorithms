# Caching

## One-Line Answer

> **Caching stores copies of frequently accessed data in a fast, temporary layer so future requests are served quicker — trading a little memory (and some staleness risk) for a lot of speed and reduced load on slower backends.**

---

## Why Do We Cache?

| Problem | How Caching Helps |
|---------|-------------------|
| Slow database reads | Serve hot data from RAM instead of disk |
| High database load | Absorb repeated reads before they hit the DB |
| High latency | Data lives closer to the user (CDN, browser) |
| Expensive computation | Store the result once, reuse many times |
| Cost | Fewer DB/compute calls = cheaper to run |

**Rule of thumb:** Cache when reads >> writes and the same data is requested repeatedly.

---

## The Core Vocabulary (know these cold)

| Term | Meaning |
|------|---------|
| **Cache Hit** | Requested data is in the cache → fast return |
| **Cache Miss** | Data not in cache → fetch from source, then (usually) populate cache |
| **Hit Ratio** | hits / (hits + misses) — the #1 metric of cache effectiveness |
| **TTL (Time To Live)** | How long an entry stays valid before it expires |
| **Eviction** | Removing entries when the cache is full |
| **Invalidation** | Removing/updating entries because the source data changed |
| **Staleness** | Cache holds an outdated value vs. the source of truth |
| **Warm vs Cold cache** | Warm = pre-populated with hot data; Cold = empty, all misses |

> **Invalidation vs Eviction:** Eviction is "no room, kick something out." Invalidation is "this data changed, it's now wrong." Different triggers, same effect (entry gone).

---

## Where Can You Cache? (The Request Path)

```
Browser Cache → CDN → Load Balancer → App Server (local + distributed cache) → Database (buffer/query cache)
   client-side        edge              in-memory (Redis/Memcached)              server-side
```

| Layer | Example | Caches |
|-------|---------|--------|
| **Client / Browser** | HTTP cache, localStorage | Static assets, API responses |
| **DNS** | Resolver cache | Domain → IP mappings |
| **CDN (Edge)** | Cloudflare, Akamai, CloudFront | Images, JS/CSS, video, static pages |
| **Application** | Local (in-process) or Redis/Memcached | Query results, sessions, computed values |
| **Database** | Buffer pool, query cache | Frequently read pages/rows |

**Interview tip:** "Where do you cache?" → answer *multiple layers*, each solving a different bottleneck.

---

## Caching Strategies (Read & Write Patterns)

This is the **most commonly asked** caching topic. Know all five.

### Read Patterns

#### 1. Cache-Aside (Lazy Loading) — most common

The **application** manages the cache. Cache doesn't talk to the DB.

```
Read:
  1. App checks cache
  2. HIT  → return
  3. MISS → read DB → write to cache → return
```

- ✅ Only requested data is cached (memory-efficient)
- ✅ Cache failure ≠ system failure (DB still reachable)
- ❌ First request per key is always a miss (cold start)
- ❌ Risk of stale data if DB changes without invalidation
- **Used by:** most web apps with Redis/Memcached

#### 2. Read-Through

The **cache** sits inline and fetches from the DB on a miss (app only talks to the cache).

```
App → Cache → (miss) → Cache loads from DB → returns to App
```

- ✅ App code is simpler (cache library handles DB loads)
- ❌ Needs cache provider support; still cold-start misses

> **Cache-Aside vs Read-Through:** In cache-aside the *app* loads the DB on a miss. In read-through the *cache* loads the DB. Same result, different owner of the logic.

### Write Patterns

#### 3. Write-Through

Write to cache **and** DB synchronously, in the same operation.

```
Write → Cache (update) → DB (update) → ack
```

- ✅ Cache always consistent with DB (no stale reads)
- ❌ Higher write latency (two writes)
- ❌ Caches data that may never be read again

#### 4. Write-Back (Write-Behind)

Write to cache immediately; **flush to DB later** (async/batched).

```
Write → Cache (ack immediately) → ... later ... → DB (batched flush)
```

- ✅ Very fast writes, great for write-heavy workloads
- ✅ Batches reduce DB load
- ❌ **Data loss risk** if cache crashes before flush
- **Used by:** metrics, counters, logging pipelines

#### 5. Write-Around

Write **directly to the DB**, skip the cache. Cache populated only on read (via cache-aside).

```
Write → DB only.   Read → cache-aside populates on miss.
```

- ✅ Avoids flooding cache with write-once data
- ❌ Recently written data is a guaranteed miss on first read

### Quick Comparison

| Strategy | Write Speed | Consistency | Data Loss Risk | Best For |
|----------|-------------|-------------|----------------|----------|
| Cache-Aside | N/A (read) | Eventual | None | General read-heavy |
| Read-Through | N/A (read) | Eventual | None | Simpler app code |
| Write-Through | Slower | Strong | None | Read-after-write correctness |
| Write-Back | Fastest | Weak (until flush) | **Yes** | Write-heavy, tolerant of loss |
| Write-Around | Normal | Eventual | None | Write-once/rarely-read data |

**Common pairing:** *Cache-Aside (read) + Write-Through (write)* is a solid default answer.

---

## Eviction Policies (When the Cache Is Full)

| Policy | Evicts | Best For |
|--------|--------|----------|
| **LRU** (Least Recently Used) | Item unused for longest | General purpose — **most common** |
| **LFU** (Least Frequently Used) | Item accessed fewest times | Stable popularity patterns |
| **FIFO** (First In First Out) | Oldest inserted | Simple, order-based |
| **TTL-based** | Whatever expired | Time-sensitive data |

> **Default answer: LRU.** It's cheap to implement (hashmap + doubly linked list — a classic DSA problem) and matches real access patterns well.

---

## TTL & Invalidation — "The Second Hard Problem"

> *"There are only two hard things in Computer Science: cache invalidation and naming things."*

**Ways to keep the cache from serving stale data:**

1. **TTL expiry** — set a lifetime; entry auto-expires. Simple, but data can be stale up to TTL.
2. **Write-through / explicit update** — update cache when DB updates.
3. **Explicit delete on write** — delete the key on write; next read repopulates (cache-aside).
4. **Event-based invalidation** — DB change events (CDC) push invalidations.

**Trade-off:** Short TTL = fresher data but lower hit ratio + more DB load. Long TTL = higher hit ratio but staler data. Tune per data type (a stock price ≠ a user's profile photo).

---

## Distributed Caching (Scaling Beyond One Node)

When one cache server isn't enough, shard data across many.

### Consistent Hashing

Naive `hash(key) % N` **breaks badly** when N changes — nearly every key remaps. **Consistent hashing** maps keys and nodes onto a ring so adding/removing a node only remaps a small slice of keys.

```
        Node A
       /       \
  key3           key1
    |     ring     |
  Node C         Node B
       \        /
        key2  ...
```

- ✅ Minimal key movement on scale up/down
- ✅ Used by Redis Cluster, Memcached clients, DynamoDB, Cassandra

### Replication

Copy data across nodes for **availability** and read scaling (primary-replica). Trade-off: replication lag → possible stale reads.

---

## Redis vs Memcached (classic interview compare)

| Feature | Redis | Memcached |
|---------|-------|-----------|
| Data structures | Strings, lists, sets, hashes, sorted sets, streams | Strings only (key-value) |
| Persistence | Yes (RDB snapshots, AOF) | No (pure in-memory) |
| Replication / HA | Yes (replicas, Sentinel, Cluster) | No native |
| Eviction | Multiple policies | LRU |
| Multi-threading | Mostly single-threaded (core) | Multi-threaded |
| Pub/Sub, Lua, transactions | Yes | No |
| **Pick when** | You need rich types, persistence, HA | Simple, huge, pure key-value cache |

**Short answer:** Redis is the default choice today; reach for Memcached only for a very simple, memory-heavy key-value cache.

---

## Why Is Redis Blazing Fast?

A common surprise: Redis is (at its core) **single-threaded**, yet it handles hundreds of thousands of requests per second. Speed comes from **RAM storage + a single-threaded event loop driven by OS I/O multiplexing (`epoll`)**, not from lots of threads.

### The Three Pillars

| Pillar | Why It's Fast |
|--------|---------------|
| **In-memory (RAM)** | No disk seeks — RAM access is ~100,000× faster than disk |
| **Single-threaded core** | No locks, no context switches, no race conditions on the data |
| **I/O multiplexing (`epoll`)** | One thread watches thousands of connections; only processes the ones that are *ready* |

> **Single-threaded is a feature, not a limitation.** Because only one thread ever touches the data, Redis needs **zero locking**. Every command is effectively atomic. The bottleneck is network/memory, not CPU — so more threads wouldn't help the core.

### The Event Loop — Step by Step

This is the heart of it. The single Redis thread never blocks waiting on any one client; it only ever works on connections the kernel says are **100% ready**.

```
┌──────────────────────────────────────────────────────────────┐
│  Users A, B, C send requests over TCP                        │
└──────────────────────────────────────────────────────────────┘
        │            │            │
        ▼            ▼            ▼
   ┌───────────────────────────────────┐
   │   OS Kernel (tracks + buffers)    │  A ✅ done   B ⏳ partial   C ✅ done
   └───────────────────────────────────┘
        │  epoll: "who is ready?"
        ▼
   ┌───────────────────────────────────┐
   │   Redis Event Queue: [A, C]       │   ← B is skipped (not ready yet)
   └───────────────────────────────────┘
        │  process at RAM speed
        ▼
   Redis thread runs A → then C → queue empty → loop back to epoll
```

1. **TCP packets arrive (OS-managed).** Users A, B, and C send requests. Their packets stream in over the network. The OS **kernel** silently tracks all three connections, buffering data as it arrives.

2. **The Redis thread asks the kernel (the system call).** Having finished its previous work, the thread calls `epoll` and asks: *"Who is 100% ready?"* The kernel sees A and C have fully arrived, but **B is still missing some packets**.

3. **Populating the event queue (the to-do list).** The kernel hands back a list of just `[A, C]`. Redis drops these into its internal **event queue**.

4. **Rapid execution (RAM speed).** The thread processes A's request, then immediately C's — straight from memory. It **ignores B entirely** because B isn't in the queue.

5. **The loop repeats (next tick).** The queue is now empty, so the thread loops back to Step 2 and asks the kernel again. By now B's remaining packets have arrived, so the kernel hands over B, and the cycle continues.

**Key insight:** The thread never *waits* on a slow/incomplete client. Slow clients (like B) simply aren't in the ready-list, so they cost nothing until their data is fully there. This is **non-blocking I/O** — one thread stays busy doing useful work instead of sitting idle on any single connection.

> **`epoll` vs old `select`:** Redis uses `epoll` (Linux) / `kqueue` (BSD) which scale to huge numbers of connections efficiently. The older `select`/`poll` had to scan *every* connection each tick — O(n) — whereas `epoll` returns only the ready ones.

### But Isn't Single-Threaded a Bottleneck?

- The **data-access core** is single-threaded (keeps it lock-free and atomic).
- Modern Redis (6.0+) added **multi-threaded I/O** for *reading/writing network buffers only* — command execution on the data stays single-threaded.
- To use more CPU cores, you scale **horizontally** with **Redis Cluster** (sharding) or run multiple instances.

### Why This Matters in an Interview

- Explains why Redis commands are **atomic** (no partial state visible) without you writing locks.
- Explains why **one slow/expensive command blocks everyone** — e.g., a `KEYS *` on a huge dataset stalls the whole loop. Use `SCAN` instead.
- Explains why Redis is **CPU-light but network/memory-bound**, and why adding threads to the core wouldn't help.

---

## Cache Failure Modes (the "gotcha" questions)

These distinguish a strong candidate. Know the name, cause, and fix.

### 1. Cache Stampede / Thundering Herd
- **Problem:** A hot key expires → thousands of concurrent misses all hit the DB at once.
- **Fixes:** Lock/mutex so only one request rebuilds the key (others wait); **early/probabilistic recomputation** before expiry; **request coalescing** (single-flight); stagger TTLs (add jitter).

### 2. Cache Penetration
- **Problem:** Requests for keys that **don't exist** anywhere → every request bypasses cache and hammers the DB (often malicious).
- **Fixes:** Cache the "not found" result (with short TTL); use a **Bloom filter** to reject keys that definitely don't exist.

### 3. Cache Avalanche
- **Problem:** Many keys expire at the **same time** (or the whole cache restarts) → mass misses overload the DB.
- **Fixes:** Add **random jitter** to TTLs; multi-level caching; warm the cache before going live; rate-limit/DB circuit breaker.

### 4. Hot Key
- **Problem:** One key is so popular it overwhelms a single cache node.
- **Fixes:** Replicate the hot key across nodes; add a local (in-process) cache in front; split the key.

---

## Consistency: The Fundamental Trade-off

Caching almost always means **eventual consistency** — for a window, the cache and DB may disagree.

| You want... | Then... |
|-------------|---------|
| Strong consistency | Write-through + read from cache, or don't cache that data |
| Freshness | Short TTL + explicit invalidation |
| Max performance | Longer TTL, accept some staleness |

**Interview line:** *"Caching trades consistency for latency and load. The right TTL/strategy depends on how much staleness the feature can tolerate."*

---

## How to Approach a "Add Caching" Interview Prompt

1. **Clarify the access pattern** — read-heavy? write-heavy? hot keys?
2. **Pick a layer** — CDN for static, Redis for dynamic/app data, etc.
3. **Pick a strategy** — usually cache-aside read + write-through/invalidate.
4. **Set eviction + TTL** — LRU + a TTL tuned to staleness tolerance.
5. **Address failure modes** — stampede, penetration, avalanche, hot keys.
6. **State the consistency trade-off** — call out eventual consistency explicitly.
7. **Mention metrics** — track hit ratio; a low hit ratio means the cache isn't earning its keep.

---

## Common Interview Questions

**Q: What's the difference between cache-aside and read-through?**
Both serve reads. In cache-aside the *application* loads from the DB on a miss; in read-through the *cache* itself loads from the DB. Cache-aside keeps cache logic in app code; read-through pushes it into the cache layer.

**Q: Write-through vs write-back — when would you pick each?**
Write-through for correctness (cache and DB always agree, read-after-write safe) at the cost of write latency. Write-back for write-heavy, latency-sensitive workloads that can tolerate potential data loss on a crash (e.g., counters, metrics).

**Q: How do you keep a cache consistent with the database?**
You usually can't get strong consistency for free — accept eventual consistency. Use TTLs, delete-on-write (cache-aside), write-through, or event-based invalidation. Match the approach to how stale the data is allowed to be.

**Q: What's cache stampede and how do you prevent it?**
Many concurrent requests miss on the same expired hot key and all hit the DB. Prevent with a rebuild lock/single-flight so only one request repopulates, probabilistic early recomputation, and TTL jitter.

**Q: Why is `hash(key) % N` bad for a distributed cache?**
Changing N (adding/removing a node) remaps almost all keys, causing a mass cache miss. Consistent hashing remaps only a small fraction of keys.

**Q: Which eviction policy would you use and why?**
LRU by default — it approximates real access patterns and is cheap (hashmap + doubly linked list). LFU if popularity is stable over time.

**Q: Redis or Memcached?**
Redis for rich data structures, persistence, and HA (the common default). Memcached for a simple, multi-threaded, pure key-value cache at scale.

**Q: What metric tells you if your cache is effective?**
Hit ratio. A low hit ratio means you're paying the cache cost without the benefit — revisit what/how you cache.

**Q: How do you cache data that doesn't exist to stop penetration attacks?**
Cache the negative ("not found") result with a short TTL, and/or front the cache with a Bloom filter to reject impossible keys early.

---

## Key Takeaways

- **Cache when reads >> writes** and the same data is requested repeatedly; measure success by **hit ratio**.
- **5 strategies:** Cache-Aside & Read-Through (reads); Write-Through, Write-Back, Write-Around (writes). Default: **cache-aside + write-through/invalidate**.
- **LRU** is the go-to eviction policy; add **TTL** for time-sensitivity.
- **Invalidation is hard** — TTL vs freshness is a tuning knob per data type.
- **Distributed caching** needs **consistent hashing** to survive node changes.
- **Redis** is the modern default; Memcached for simple key-value at scale.
- **Redis is fast** because of RAM + a **single-threaded, lock-free event loop** using `epoll` I/O multiplexing — it only processes connections the kernel reports as ready.
- Name and fix the **failure modes**: stampede, penetration, avalanche, hot keys.
- Caching = **trading consistency for latency and load** — always state that trade-off.

---

*Last Updated: 2026-07-19*
