# 🎯 System Design Interview Cracking Plan (2026)

## The MAANG-Proven Strategy

> **Core Principle:** Don't study topics in isolation for months. Learn the interview framework first,
> then let case studies drive your deep learning. You learn Kafka, sharding, and caching 10x better
> when you discover *why* you need them while designing WhatsApp.

---

## 📐 Phase 0: Master the Interview Framework (Week 1)

**This is the single highest-ROI activity.** Every MAANG system design interview follows this structure.
Practice this skeleton until it's muscle memory.

### The 5-Step Framework (45-minute interview)

```
┌─────────────────────────────────────────────────────────────────────┐
│                    SYSTEM DESIGN INTERVIEW FRAMEWORK                │
├─────────────────────────────────────────────────────────────────────┤
│                                                                     │
│  Step 1: REQUIREMENTS (5 min)                                       │
│  ├── Functional: What does the system DO?                           │
│  ├── Non-Functional: Scale, latency, availability, consistency      │
│  └── Out of Scope: What are we NOT building?                        │
│                                                                     │
│  Step 2: ESTIMATION (5 min)                                         │
│  ├── Users: DAU, peak concurrent                                    │
│  ├── Traffic: QPS (read vs write ratio)                             │
│  ├── Storage: How much data per day/year?                           │
│  └── Bandwidth: Data transfer per second                            │
│                                                                     │
│  Step 3: API DESIGN (5 min)                                         │
│  ├── Core endpoints (REST/gRPC)                                     │
│  ├── Request/Response schemas                                       │
│  └── Who calls what?                                                │
│                                                                     │
│  Step 4: HIGH-LEVEL DESIGN (15 min)                                 │
│  ├── Draw the architecture (client → LB → services → DB)           │
│  ├── Choose databases (SQL vs NoSQL, why?)                          │
│  ├── Identify core services                                         │
│  └── Data flow for main use cases                                   │
│                                                                     │
│  Step 5: DEEP DIVE (15 min)                                         │
│  ├── Interviewer picks areas to zoom into                           │
│  ├── Tradeoffs: Why X over Y?                                       │
│  ├── Handle failures, bottlenecks, edge cases                       │
│  └── Scale: What breaks at 10x, 100x, 1000x?                       │
│                                                                     │
└─────────────────────────────────────────────────────────────────────┘
```

### Back-of-Envelope Estimation Cheat Sheet

```
┌─────────────────────────────────────────────────┐
│            NUMBERS EVERY CANDIDATE MUST KNOW     │
├─────────────────────────────────────────────────┤
│                                                  │
│  Time:                                           │
│  ├── 1 day    = 86,400 sec  ≈ 100K sec          │
│  ├── 1 month  = 2.5M sec                        │
│  └── 1 year   = 30M sec                         │
│                                                  │
│  Storage:                                        │
│  ├── 1 char   = 1 byte (ASCII) / 2 bytes (UTF)  │
│  ├── 1 KB     = 1,000 bytes                     │
│  ├── 1 MB     = 1,000 KB                        │
│  ├── 1 GB     = 1,000 MB                        │
│  ├── 1 TB     = 1,000 GB                        │
│  └── 1 PB     = 1,000 TB                        │
│                                                  │
│  Typical sizes:                                  │
│  ├── Tweet/message   = 200 bytes - 1 KB         │
│  ├── Metadata/row    = 500 bytes - 1 KB         │
│  ├── Image (thumb)   = 50 KB                    │
│  ├── Image (full)    = 500 KB - 2 MB            │
│  ├── Video (1 min)   = 50 MB (compressed)       │
│  └── UUID/ID         = 36 bytes                 │
│                                                  │
│  Throughput:                                     │
│  ├── SQL DB (single)     = 1K-10K QPS           │
│  ├── NoSQL DB (single)   = 10K-100K QPS         │
│  ├── Cache (Redis)       = 100K-1M QPS          │
│  ├── MQ (Kafka)          = 1M+ msg/sec          │
│  └── CDN                 = practically unlimited │
│                                                  │
│  Quick formula:                                  │
│  QPS = DAU × avg_requests / 86,400              │
│  Peak QPS = QPS × 2 (or ×3 for spiky traffic)   │
│  Storage/year = daily_new_data × 365            │
│                                                  │
└─────────────────────────────────────────────────┘
```

### ✅ Phase 0 Deliverable
- [ ] Can explain the 5-step framework from memory
- [ ] Can do estimation for any system in under 5 minutes
- [ ] Practiced framework on URL Shortener (dry run)

---

## 🧱 Phase 1: Building Blocks Vocabulary (Week 2)

> **Goal:** Know what each building block DOES and WHEN to use it — not how to build it.
> Spend ~30 min per block. Your existing notes on API Gateway, Load Balancing, SSL/TLS already cover some of this.

### Networking & Traffic Management
| Block | What to Know | You Have Notes? |
|-------|-------------|-----------------|
| DNS & GeoDNS | Domain resolution, geo-routing | ❌ |
| L4 vs L7 Load Balancers | When TCP vs HTTP-aware balancing | ✅ Done |
| API Gateway | Routing, auth, rate limiting, BFF pattern | ✅ Done |
| CDN | Static content, edge caching, cache invalidation | ❌ |
| TLS/SSL | Handshake, termination, mTLS | ✅ Done |
| Reverse Proxy | vs LB vs API Gateway differences | ✅ (in API Gateway notes) |

### Communication Protocols
| Block | What to Know | Priority |
|-------|-------------|----------|
| REST vs gRPC | When to use each, pros/cons | 🔴 High |
| WebSockets | Persistent connections, when to use | 🔴 High (in progress) |
| Long Polling vs SSE | Tradeoffs, use cases | 🟡 Medium |
| GraphQL | When it helps, N+1 problem | 🟢 Low (mention-level) |

### Databases
| Block | What to Know | Priority |
|-------|-------------|----------|
| SQL (PostgreSQL/MySQL) | ACID, indexing, B-tree, joins | 🔴 High |
| NoSQL (MongoDB, Cassandra, DynamoDB) | When to choose, data models | 🔴 High |
| CAP Theorem | CP vs AP systems, real examples | 🔴 High |
| Redis | Cache + data structure store | 🔴 High |

### Scaling & Storage
| Block | What to Know | Priority |
|-------|-------------|----------|
| Horizontal vs Vertical Scaling | When each applies | 🔴 High |
| Sharding | Hash-based, range-based, consistent hashing | 🔴 High |
| Consistent Hashing | How it works, virtual nodes | 🔴 High |
| Object Storage (S3) | Blob storage for media | 🟡 Medium |
| Replication | Leader-follower, multi-leader, quorum | 🔴 High |

### Caching
| Block | What to Know | Priority |
|-------|-------------|----------|
| Cache strategies | Write-through, write-back, write-around | 🔴 High |
| Eviction policies | LRU, LFU | 🟡 Medium |
| Cache invalidation | TTL, event-based, cache-aside pattern | 🔴 High |
| CDN caching | Edge vs origin | 🟡 Medium |

### Messaging & Async
| Block | What to Know | Priority |
|-------|-------------|----------|
| Message Queues | Kafka vs RabbitMQ, when to use | 🔴 High |
| Pub/Sub | Fan-out, topic-based routing | 🔴 High |
| Event-Driven Architecture | CQRS, event sourcing (high level) | 🟡 Medium |
| Task Queues | Background jobs, idempotency | 🟡 Medium |

### Resilience
| Block | What to Know | Priority |
|-------|-------------|----------|
| Circuit Breakers | States, when to use | 🟡 Medium |
| Retries with Jitter | Exponential backoff, why jitter | 🟡 Medium |
| Rate Limiting | Token bucket, sliding window | 🔴 High |
| Idempotency | Why it matters for payments/retries | 🔴 High |

### Observability & Security
| Block | What to Know | Priority |
|-------|-------------|----------|
| Logging + Metrics + Tracing | Three pillars, OpenTelemetry | 🟡 Medium |
| Auth (OAuth2/JWT) | Token-based auth flow | 🟡 Medium |
| Encryption at rest/transit | When to mention in designs | 🟢 Low |

### ✅ Phase 1 Deliverable
- [ ] Can explain each 🔴 High block in 2-3 sentences
- [ ] Know when to pick SQL vs NoSQL
- [ ] Know when to add a cache, queue, or CDN
- [ ] Can draw the standard architecture: Client → CDN → LB → API GW → Services → DB/Cache

---

## 🏗️ Phase 2: Case Study Designs — Tier 1 (Weeks 3-4)

> **Strategy:** Start with the most commonly asked systems. For each one:
> 1. Design it yourself FIRST (30 min, pen & paper)
> 2. Then watch/read a solution and compare
> 3. Note which building blocks you missed — go learn those
> 4. Redo the design incorporating what you learned

### System 1: URL Shortener (Easy — warm up)
```
Key concepts you'll practice:
├── Hashing (base62, MD5/SHA)
├── Database schema design
├── Read-heavy system (caching)
├── Estimation (how many URLs per day?)
├── 301 vs 302 redirects
└── Analytics (counting clicks)
```
**Time: 1 day to learn, 1 day to practice**

### System 2: Rate Limiter (Easy-Medium)
```
Key concepts you'll practice:
├── Token bucket / Sliding window algorithms
├── Distributed rate limiting (Redis)
├── API Gateway integration
├── Race conditions in distributed systems
└── HTTP 429 responses
```
**Time: 1 day to learn, 1 day to practice**

### System 3: Twitter/X Feed (Medium — most asked!)
```
Key concepts you'll practice:
├── Fan-out on write vs fan-out on read
├── Social graph (followers/following)
├── Timeline generation
├── Caching (pre-computed feeds)
├── Pub/Sub for real-time updates
├── Sharding user data
├── Celebrity problem (hybrid approach)
└── Ranking / Algorithm (mention-level)
```
**Time: 2 days to learn, 1 day to practice**

### System 4: Chat System / WhatsApp (Medium — very common)
```
Key concepts you'll practice:
├── WebSockets (persistent connections)
├── Message delivery guarantees (sent/delivered/read)
├── Online presence / Heartbeats
├── Group chat fan-out
├── Message storage (Cassandra — write-heavy)
├── End-to-end encryption (mention-level)
├── Push notifications
└── Message ordering
```
**Time: 2 days to learn, 1 day to practice**

### ✅ Phase 2 Deliverable
- [ ] Can design each system end-to-end in 35-40 minutes
- [ ] Can explain tradeoffs for every decision
- [ ] Filled knowledge gaps discovered during designs

---

## 🏗️ Phase 3: Case Study Designs — Tier 2 (Weeks 5-6)

### System 5: YouTube / Netflix (Media streaming)
```
Key concepts you'll practice:
├── Video upload & processing pipeline (transcoding)
├── CDN for video delivery
├── Adaptive bitrate streaming (HLS/DASH)
├── Object storage (S3)
├── Recommendation system (mention-level)
├── View counting at scale
├── Task queues for async processing
└── Thumbnail generation
```
**Time: 2 days to learn, 1 day to practice**

### System 6: Uber / Ride-sharing (Geo/proximity)
```
Key concepts you'll practice:
├── Geospatial indexing (Quad-tree, Geohash)
├── Location tracking (WebSocket/SSE)
├── Matching algorithm
├── ETA calculation
├── Surge pricing (mention-level)
├── Sharding by geography
└── Real-time updates to riders & drivers
```
**Time: 2 days to learn, 1 day to practice**

### System 7: Google Drive / Dropbox (File storage & sync)
```
Key concepts you'll practice:
├── Chunked file upload (resumable)
├── File deduplication (content hashing)
├── Sync conflict resolution
├── Object storage + metadata DB
├── Versioning
├── Notification service (file changes)
├── Offline support & sync queue
└── Sharing & permissions (ACL)
```
**Time: 2 days to learn, 1 day to practice**

### System 8: Web Crawler (Data pipeline)
```
Key concepts you'll practice:
├── BFS/DFS crawling strategy
├── URL frontier (priority queue)
├── Politeness (robots.txt, rate limiting per domain)
├── Deduplication (Bloom filters, content hashing)
├── Distributed crawling (partitioning URLs)
├── DNS resolver caching
├── Handling traps (infinite loops, dynamic pages)
└── Storage (raw HTML → parsed → indexed)
```
**Time: 1.5 days to learn, 0.5 day to practice**

### ✅ Phase 3 Deliverable
- [ ] Can design each system end-to-end in 35-40 minutes
- [ ] Comfortable with geo-spatial, streaming, and file sync patterns
- [ ] Can handle "what happens at 100x scale?" questions

---

## 🏗️ Phase 4: Bonus Systems & Gap Filling (Week 7)

> Only if you have time. Pick 2-3 based on your target companies.

### Pick from these based on target company:

| System | Company Bias | Key New Concepts |
|--------|-------------|-----------------|
| Notification System | Meta, Amazon | Priority queues, multi-channel delivery, templates |
| Search Autocomplete | Google, Amazon | Trie data structure, ranking, pre-computation |
| Distributed Cache | All MAANG | Consistent hashing deep-dive, cache coherence |
| Payment System | Stripe, Amazon | Idempotency, exactly-once, saga pattern, ledger |
| Ticket Booking (BookMyShow) | Any | Seat locking, distributed locks, eventual consistency |
| Instagram/Photo Sharing | Meta | Image processing pipeline, CDN, news feed |
| Metrics/Monitoring (Datadog) | Infrastructure roles | Time-series DB, aggregation, alerting |

### Fill Gaps Checklist
Go through this list. If you can't explain any item in 2 sentences, study it:

- [ ] Consistent Hashing (with virtual nodes)
- [ ] Bloom Filters
- [ ] CQRS (Command Query Responsibility Segregation)
- [ ] Saga Pattern (distributed transactions)
- [ ] Idempotency keys
- [ ] Leader Election
- [ ] Gossip Protocol
- [ ] SSTable / LSM Tree (how Cassandra writes)
- [ ] Data Partitioning (hash vs range)
- [ ] Read Replicas vs Multi-master

---

## 🎤 Phase 5: Mock Interviews & Refinement (Week 8)

### Mock Interview Protocol

```
┌────────────────────────────────────────────────────────────┐
│                   MOCK INTERVIEW CHECKLIST                  │
├────────────────────────────────────────────────────────────┤
│                                                            │
│  Setup:                                                    │
│  ├── Timer: 45 minutes strict                              │
│  ├── Whiteboard or draw.io / excalidraw                    │
│  ├── Talk out loud (even if alone)                         │
│  └── Record yourself (review later)                        │
│                                                            │
│  Scoring (grade yourself):                                 │
│  ├── Requirements: Did I clarify before jumping in?   /5   │
│  ├── Estimation: Were my numbers reasonable?           /5   │
│  ├── API Design: Clean, complete endpoints?            /5   │
│  ├── High-Level: Clear architecture, right components? /10  │
│  ├── Deep Dive: Handled scale, failures, tradeoffs?    /10  │
│  ├── Communication: Did I explain clearly?             /5   │
│  └── Total                                             /40  │
│                                                            │
│  Target: 30+ / 40 = interview ready                        │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

### Practice Schedule (Week 8)
| Day | Activity |
|-----|----------|
| Mon | Mock: Random Tier 1 system (timed) |
| Tue | Review recording, fix weak areas |
| Wed | Mock: Random Tier 2 system (timed) |
| Thu | Review recording, fix weak areas |
| Fri | Mock: Completely new system you haven't studied |
| Sat | Review all designs, build your "go-to patterns" sheet |
| Sun | REST — you're ready |

---

## 🧠 Patterns Cheat Sheet (Build this as you go)

> These are reusable patterns that appear across many designs.

```
┌──────────────────────────────────────────────────────────────────┐
│               REUSABLE SYSTEM DESIGN PATTERNS                    │
├──────────────────────────────────────────────────────────────────┤
│                                                                  │
│  Read-Heavy System?                                              │
│  → Add caching (Redis), CDN, read replicas                      │
│                                                                  │
│  Write-Heavy System?                                             │
│  → Message queue (Kafka), async processing, LSM-tree DB         │
│                                                                  │
│  Real-time Updates?                                              │
│  → WebSockets, SSE, pub/sub                                     │
│                                                                  │
│  Large Files / Media?                                            │
│  → Object storage (S3), CDN, chunked uploads, transcoding       │
│                                                                  │
│  Global Scale?                                                   │
│  → Multi-region, GeoDNS, eventual consistency, CDN              │
│                                                                  │
│  Search?                                                         │
│  → Elasticsearch, inverted index, typeahead trie                │
│                                                                  │
│  Analytics / Counting?                                           │
│  → Event streaming (Kafka), batch processing, time-series DB    │
│                                                                  │
│  Distributed Transactions?                                       │
│  → Saga pattern, 2PC (avoid if possible), idempotency           │
│                                                                  │
│  Location / Proximity?                                           │
│  → Geohash, Quad-tree, PostGIS, shard by region                 │
│                                                                  │
│  Notification / Fan-out?                                         │
│  → Push: fan-out on write | Pull: fan-out on read | Hybrid      │
│                                                                  │
└──────────────────────────────────────────────────────────────────┘
```

---

## 📅 Weekly Schedule Summary

| Week | Phase | Focus | Hours/Week |
|------|-------|-------|------------|
| 1 | Phase 0 | Framework + Estimation + First dry run | 8-10 hrs |
| 2 | Phase 1 | Building blocks vocabulary (all 🔴 High items) | 10-12 hrs |
| 3 | Phase 2 | URL Shortener + Rate Limiter + Twitter Feed | 10-12 hrs |
| 4 | Phase 2 | WhatsApp + Revise Tier 1 designs | 10-12 hrs |
| 5 | Phase 3 | YouTube + Uber | 10-12 hrs |
| 6 | Phase 3 | Google Drive + Web Crawler | 10-12 hrs |
| 7 | Phase 4 | 2-3 Bonus systems + Gap filling | 10-12 hrs |
| 8 | Phase 5 | Mock interviews + Final refinement | 8-10 hrs |

**Total: ~8 weeks, ~10 hrs/week = ~80 hours**

---

## 🚫 Common Mistakes to Avoid

1. **Jumping to solution** — Always spend 5 min on requirements first
2. **Not doing estimation** — Shows you can think about scale
3. **One-size-fits-all DB** — Always justify SQL vs NoSQL choice
4. **Ignoring failures** — "What if this service goes down?" is guaranteed
5. **Over-engineering** — Don't add Kafka to a system that does 10 QPS
6. **Not communicating** — Narrate your thought process, don't draw silently
7. **Studying topics without practicing designs** — The #1 time waster
8. **Memorizing architectures** — Interviewers test your THINKING, not memory

---

## 📚 Recommended Resources (Pick ONE from each)

### Video Courses (pick one)
- **Alex Xu's System Design Interview** book (Vol 1 & 2) — gold standard
- **Gaurav Sen** YouTube channel — excellent visual explanations
- **System Design Primer** (GitHub) — free, comprehensive reference

### For Practice
- **Excalidraw** or **draw.io** — practice drawing architectures
- **Pramp / Interviewing.io** — free mock interviews with peers
- **Record yourself** — best self-review tool

---

## ✨ Your Current Progress

```
✅ Completed:  API Gateway, Load Balancing, SSL/TLS (Phase 1 — Networking)
🔄 In Progress: WebSockets (Phase 1 — Communication)
⬜ Remaining:   ~85% of the plan

Recommendation: Finish WebSockets, then quickly cover remaining
Phase 1 blocks (1-2 days) → Jump to Phase 2 case studies.
Don't write 25-page notes for every block — save depth for
when a case study demands it.
```

---

*Created: 2026-06-02 | Strategy: Case-study-driven learning with framework-first approach*
