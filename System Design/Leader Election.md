# Leader Election

## One-Line Answer

Leader election is how a distributed system picks **one node as the coordinator** (leader) among equal nodes, so there's a single decision-maker — and automatically picks a new one if the leader dies.

**Used for:** primary DB replica, running a cron job exactly once, Kafka partition leaders, Kubernetes controllers, distributed locks.

---

## Why Needed

| Problem | Leader Solves It |
|---------|------------------|
| Multiple nodes writing → conflicts | Leader serializes all writes |
| Duplicate work (same job twice) | Only leader runs it |
| No source of truth | Leader is the authority |
| Coordinator dies | Followers auto-elect a new one |

**Goal:** at most **one** leader at a time (safety) + eventually **some** leader exists (liveness).

---

## In Databases: Leader = Primary (Writes + Replication)

Your assumption is exactly the **primary-replica** (leader-follower) model, the most common interview framing:

- **Leader (primary)** = the **only** node that accepts **writes**.
- **Followers (replicas)** = copy the leader's changes and serve **reads** (scales read traffic).

```
        writes            ┌──────────┐   reads
   Client ───────────────▶│  LEADER  │◀───────── (optional reads)
                          │(primary) │
                          └────┬─────┘
              replicate changes│(WAL/binlog stream)
                 ┌─────────────┼─────────────┐
                 ▼             ▼             ▼
            ┌────────┐   ┌────────┐   ┌────────┐
            │Replica1│   │Replica2│   │Replica3│  ◀── reads
            └────────┘   └────────┘   └────────┘
```

**Why one writer?** Serializing all writes through a single leader avoids conflicts and gives a consistent ordering.

**Failover:** if the leader dies, a **new leader is elected** from the replicas (via quorum/Raft), and clients redirect writes to it. This is exactly where leader election plugs in.

| Concern | Note |
|---------|------|
| **Replication lag** | Async replicas may serve slightly stale reads (eventual consistency) |
| **Split brain** | Two primaries both accepting writes = data corruption → need **quorum** + **fencing tokens** |
| **Sync vs async** | Sync = no data loss but slower; async = fast but may lose recent writes on failover |

**Real systems:** PostgreSQL (Patroni + etcd), MySQL (group replication / Orchestrator), MongoDB replica sets (Raft-like), Redis Sentinel.

---

---

## The #1 Danger: Split Brain

A network partition can make **two nodes both think they're leader** → conflicting writes.

```
   [ N1  N2 ]  │  [ N3  N4  N5 ]
    2 nodes    │    3 nodes
   NO majority │  HAS majority (3 > 5/2)
   → no leader │  → elects leader ✅
```

**Fix = Quorum:** a node becomes leader only with votes from a **majority**. Only one side of a partition can hold a majority → only one leader. Use **odd-sized clusters (3, 5, 7)** for a clear majority.

---

## Algorithms (know Raft; mention the others)

Setup for all examples: 5 nodes **N1–N5**, higher ID = higher priority, leader **N5 just died 💀**.

### Bully — "highest alive ID wins"

A node that notices the leader is gone shouts up to all **higher** IDs. Whoever is highest-and-alive becomes leader.

**3 messages:** `ELECTION` (to higher IDs) · `OK` ("I'm alive, back off") · `COORDINATOR` ("I'm leader", to all).

```
 STEP 1 — N2 notices leader dead, sends ELECTION to HIGHER ids:
   N2 ─ELECTION─▶ N3, N4, N5(💀 no reply)

 STEP 2 — Alive higher nodes reply OK, so N2 stands down:
   N3 ─OK─▶ N2      N4 ─OK─▶ N2

 STEP 3 — Each "OK" sender now runs its own election upward:
   N3 ─ELECTION─▶ N4  → N4 replies OK → N3 stands down
   N4 ─ELECTION─▶ N5  → 💀 silence

 STEP 4 — N4 got no reply from anyone higher → N4 wins:
   N4 ─COORDINATOR "I am leader"─▶ N1, N2, N3 ✅
```
Winner = highest alive ID. Simple but **chatty** (O(n²) messages).

### Ring — "pass a ballot around the circle"

Nodes form a logical ring; each knows only its next neighbor. A dead node is skipped.

```
 Ring:  N1 ▶ N2 ▶ N3 ▶ N4 ▶ N5 ▶ (back to N1)

 PHASE 1 — ELECTION ballot circulates, each node appends its id
           (N5 dead → skipped):
   N2:[2] ▶ N3:[2,3] ▶ N4:[2,3,4] ▶ (skip N5) ▶ N1:[2,3,4,1] ▶ back to N2
   N2 sees [2,3,4,1] → highest = 4 → N4 is leader

 PHASE 2 — COORDINATOR(leader=N4) circles once so all nodes learn it ✅
```
Fewer messages than Bully (2 laps), but slower — hop by hop.

### Raft — quorum-based, the interview favorite ⭐

Guarantees safety even during partitions. **This is the one to explain in depth** (below).

---

## Raft in a Nutshell

**3 states:** Follower → *(timeout)* → Candidate → *(wins majority)* → Leader.

```
   ┌──────────┐ no heartbeat  ┌───────────┐ majority   ┌────────┐
   │ FOLLOWER │──before───────▶│ CANDIDATE │──votes────▶│ LEADER │
   │          │  timeout      │(asks votes)│           │(heart- │
   └──────────┘◀──────────────┴───────────┘           │ beats) │
        ▲  sees valid leader / higher term             └───┬────┘
        └──────────────────────────────────────────────────┘
```

**Key ideas:**
- **Term** = a numbered election round; ≤ 1 leader per term.
- **Heartbeat** = leader's "I'm alive" ping every ~50ms.
- **Election timeout** = each follower waits a **random** 150–300ms; no heartbeat → it starts an election.
- **One vote per node per term.**

**Walkthrough — leader N5 dies (electing term 5):**
```
 Random timers since last heartbeat:
   N1=280ms   N2=170ms ◀fires first   N3=250ms   N4=300ms

 STEP 1 — N2 times out first → CANDIDATE: term 4→5, votes for itself,
          RequestVote(term=5) ─▶ N1, N3, N4  (N5 💀 no reply)

 STEP 2 — None voted yet in term 5, so each says YES:
          N1─YES─▶N2   N3─YES─▶N2   N4─YES─▶N2

 STEP 3 — Votes = N2 + N1 + N3 + N4 = 4/5 ≥ majority(3) → N2 WINS 👑
          N2 becomes LEADER, sends heartbeats → others stay followers ✅
```

**Why random timeouts?** If all followers timed out together they'd each vote for themselves → split vote → no majority → retry forever. Random timers mean one node almost always fires first and wins in one round. A rare tie just retries next term with new random timers.

---

## The Practical Answer: Don't Build It Yourself

In real designs, **delegate election to a proven service** using leases/locks:

| Tool | Used By |
|------|---------|
| **ZooKeeper** | Kafka, Hadoop |
| **etcd** | Kubernetes |
| **Consul** | HashiCorp stack |
| **Redis (Redlock)** | Simple locks (use carefully) |

**Lease-based lock pattern:**
```
 SET leader = "node-1" NX EX 10   (only if not set)
 Winner renews the lease (heartbeat) before it expires.
 Leader dies → lease expires → someone else grabs it → new leader.
```

**Fencing tokens:** each new leader gets a higher token number; storage rejects writes with an old token. Stops a **paused/stale old leader** from corrupting data after a new one takes over.
```
 Leader A (token 33) freezes → Leader B (token 34) elected
 A wakes, writes with token 33 → REJECTED (34 > 33) ✅
```

---

## Common Interview Questions

**Q1: What is leader election and why?**
Pick one coordinator among equal nodes for a single decision-maker (serialize writes, avoid duplicate work), with automatic failover when the leader dies.

**Q2: What is split brain and how do you prevent it?**
A partition makes two nodes both act as leader → conflicting writes. Prevent with **quorum** (majority vote — only one partition side can win) and **fencing tokens** to reject stale-leader writes.

**Q3: How does Raft elect a leader?**
Followers wait a **random** timeout; if no heartbeat, one becomes a **candidate**, bumps the **term**, votes for itself, and requests votes. With a **majority**, it becomes leader and sends heartbeats. Random timeouts avoid split votes.

**Q4: Why an odd number of nodes?**
Clear majority and best fault tolerance per node — a 5-node cluster tolerates 2 failures (needs 3), same as 6 nodes, so the extra even node adds cost without extra resilience.

**Q5: Would you implement it yourself?**
Usually no — use **ZooKeeper/etcd/Consul** leases. Rolling your own consensus is error-prone.

**Q6: What happens to availability during an election?**
Briefly no leader → writes pause for a short window (a **CP** trade-off). Fast random timeouts keep it small.

---

## Key Takeaways

1. **One leader, agreed by all** — with automatic failover.
2. **Quorum prevents split brain** — majority wins; use **odd** cluster sizes.
3. **Raft is the go-to answer** — terms, heartbeats, random timeouts, majority votes.
4. **Don't reinvent it** — use ZooKeeper / etcd / Consul.
5. **Fencing tokens** stop stale leaders from corrupting data.
6. **Elections pause writes briefly** — safety over availability (CP).

---

*Last Updated: 2026-07-18*
