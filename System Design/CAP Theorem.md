# CAP Theorem

## The One-Line Answer (Say This First in an Interview)

> In a **distributed system**, when a **network partition** happens, you can only guarantee **two of three** properties — **Consistency**, **Availability**, and **Partition tolerance** — never all three at once.

Since network partitions are **unavoidable** in any real distributed system, **P is not optional**. So the *real* choice is always: **when a partition occurs, do you sacrifice Consistency (choose AP) or Availability (choose CP)?**

---

## The Three Properties

```
┌──────────────────────────────────────────────────────────────────────┐
│                          CAP Theorem                                  │
├──────────────────────────────────────────────────────────────────────┤
│                                                                      │
│   C - Consistency        Every read sees the most recent write       │
│                          (or an error) — all nodes agree.            │
│                                                                      │
│   A - Availability       Every request gets a (non-error) response,  │
│                          even if it may be stale.                    │
│                                                                      │
│   P - Partition          The system keeps working even when the      │
│       Tolerance          network drops/delays messages between nodes.│
│                                                                      │
│              Pick 2 (and P is mandatory in practice)                 │
│                                                                      │
└──────────────────────────────────────────────────────────────────────┘
```

| Property | Meaning | Question it answers |
|----------|---------|---------------------|
| **Consistency (C)** | Every read returns the latest write, or fails | "Is the data I read correct & up to date?" |
| **Availability (A)** | Every request gets a non-error response | "Will I always get an answer?" |
| **Partition Tolerance (P)** | System survives dropped/delayed network links | "Does it keep working when the network splits?" |

> ⚠️ **CAP's "Consistency" ≠ ACID's "Consistency".** CAP's C means *linearizability* (all nodes see the same latest value). ACID's C means *integrity constraints are preserved*. Different concepts — don't conflate them.

---

## What Actually Counts as a "Partition"?

A **partition = loss of communication between nodes** — whatever the cause. From a surviving node's point of view it can't tell *why*; it only knows *"I can't reach the other node."*

- **Cable broke / packets dropped / network split** → both nodes may still be **alive and serving their own side**. This is the dangerous case → risk of **split-brain** (two sides accepting conflicting writes). This is the classic scenario "P" is really about.
- **A node itself is down** → only **one side is alive**. Simpler — no split-brain, just reduced redundancy/capacity.

```
Partition = "nodes can't talk"
   ├── Both up, link broken   → split-brain risk   (the hard CAP case)
   └── One node down           → simpler failure
```

The *both-up* version is what forces the tough **CP-vs-AP** decision: do I let each side keep writing, or block to stay consistent?

---

## Why You Can't Have All Three

The core insight is a simple thought experiment:

```
        Network Partition (link broken)
   Node A  ✗───────✗  Node B
     │                   │
  write X=2          read X ?

  Choice 1 (CP): Node B refuses/blocks the read → NOT Available
  Choice 2 (AP): Node B returns stale X=1       → NOT Consistent
```

- A client writes `X=2` to **Node A**.
- The network between A and B is **partitioned** — B never hears about it.
- A client now reads `X` from **Node B**. Two options:
  - **Stay Consistent (CP):** B must **refuse or block** until it can confirm the latest value → you lost **Availability**.
  - **Stay Available (AP):** B **returns the old value** `X=1` → you lost **Consistency**.

You cannot be both correct *and* responsive while the nodes can't talk. **That's the whole theorem.**

---

## The Three Combinations

| Combo | Sacrifices | Behavior on partition | Examples |
|-------|-----------|-----------------------|----------|
| **CP** (Consistency + Partition tolerance) | **Availability** | Rejects/blocks requests it can't confirm (via quorum) | HBase, MongoDB (default), ZooKeeper, etcd, Redis (single-primary), Spanner |
| **AP** (Availability + Partition tolerance) | **Consistency** | Any reachable node responds, may return stale data, reconciles later | Cassandra, DynamoDB, Riak, CouchDB, DNS |
| **CA** (Consistency + Availability) | **Partition tolerance** | Only works if network *never* partitions — i.e. single node / not truly distributed | Single-node PostgreSQL / MySQL |

> **CA is largely theoretical for distributed systems.** The moment you have more than one node communicating over a network, partitions *can* happen, so you *must* tolerate P. CA effectively means "a single machine."

---

## CP vs AP — The Real Trade-off

```
        PARTITION HAPPENS
              │
      ┌───────┴────────┐
      ▼                ▼
   CP system        AP system
   ─────────        ─────────
  "Be correct"     "Be online"
  Reject requests  Serve from any
  it can't         reachable node,
  confirm via      merge conflicts
  quorum           later
      │                │
  Some downtime,   Always up,
  never wrong      sometimes stale
```

| Dimension | CP (pick Consistency) | AP (pick Availability) |
|-----------|-----------------------|------------------------|
| **On failure/partition** | Only the side without quorum stops serving | Any reachable node keeps serving |
| **Latency** | Higher — waits for a quorum to ACK | Lower — replies immediately from local copy |
| **Risk** | Downtime / errors when quorum is lost | Stale / conflicting reads |
| **Complexity is…** | **Up front** — coordinate *before* serving | **After** — reconcile conflicts *later* |
| **Reconciliation** | Not needed (always consistent) | Needs conflict resolution (LWW, vector clocks, CRDTs) |
| **Good for** | Money, inventory, locks, config | Feeds, carts, likes, catalogs, telemetry |

**CP example:** A banking ledger — better to reject a transfer than to allow a double-spend.
**AP example:** A social feed or "like" count — better to show slightly stale data than an error page.

---

## The Heart of CP: Quorum (Majority)

A common misconception is that a CP system goes **fully down** the moment any node fails. It doesn't — and this is where **quorum** comes in. CP does **not** blindly return an error when one node drops; it first checks: *"do I still have a majority that agrees on the latest data?"*

A **quorum** = a **majority of nodes must agree** before a read/write is accepted. With `N` replicas, quorum = `(N/2) + 1`.

```
3 nodes (A, B, C), quorum = 2

  B down:  A ✅  B ❌  C ✅
           A + C = 2 = MAJORITY  → they agree on latest data
           → keep serving, CONSISTENT + available  (still CP, system stays UP)

  2 down:  A ✅  B ❌  C ❌
           A alone = 1 = MINORITY → can't confirm it has the latest write
           → REFUSES requests  → unavailable  (chose Consistency over Availability)
```

- **The trigger for unavailability is NOT "a node died" — it's "quorum lost."** As long as a majority agrees, CP keeps serving *and* stays consistent.
- **Why it's still CP, not AP:** the majority side is **not** serving stale data — it holds and can confirm the latest committed writes. It only blocks when it **can't guarantee correctness**.
- **On a partition** `[A] | [B, C]`: the **majority `[B,C]` keeps serving** consistently; the **minority `[A]` goes dark**. Only the minority is unavailable, not the whole system. (This is also how CP avoids **split-brain** — the minority refuses to accept writes.)
- **The real rule for CP:** *serve while a majority can agree; block only the side that can't confirm it has the latest data.* Taking the whole system down on a single node failure would be bad design.

### CP's Hidden Cost: Latency

Consistency isn't free — a CP write (and often a strongly-consistent read) must **wait for a quorum to acknowledge** before responding. Those extra round-trips **add latency**, even when nothing is broken.

```
CP write (quorum = 2 of 3):

  Client → Node A ──┬──▶ Node B  ⏳ wait for ACK
                    └──▶ Node C  ⏳ wait for ACK
                         │
              majority (2) confirmed
                         │
  Client ◀── OK   (only NOW does it return)
```

This is exactly the **"ELC" half of PACELC** below: *even without a partition*, CP trades **Latency for Consistency**.

---

## The Heart of AP: Serve Anyone, Reconcile Later

AP is conceptually simpler: **serve the request as long as at least one node is reachable.** No majority check, no blocking.

- **Serving is easy** — every node accepts reads/writes independently, no coordination → this is why AP systems (Cassandra, DynamoDB) scale so well and stay low-latency.
- **The hard part moves to *after*** — because two sides can accept **conflicting writes** during a partition (split-brain), AP needs **conflict resolution** to reconcile later:
  - **Last-Write-Wins (LWW)** — newest timestamp wins (simple, can silently lose data)
  - **Vector clocks** — detect and flag conflicts for the app to resolve
  - **CRDTs** — data types that merge automatically without conflict

```
CP:  complexity is UP FRONT   → quorum before serving (stay correct)
AP:  complexity is AFTER      → serve freely, reconcile conflicts later
```

---

## Bonus Points: PACELC (One-Liner)

If you want to sound sharp, mention PACELC — CAP only covers *partition* time; PACELC adds the normal case:

> **If Partition → Availability vs Consistency. Else → Latency vs Consistency.**

The takeaway: even with **no** partition, keeping replicas consistent costs **latency** (the quorum wait above). One line is enough — don't go deeper unless asked.

---

## Bonus Points: Tunable Consistency (Quorums)

Good to mention that AP/CP isn't always a fixed, per-database choice — systems like **Cassandra / DynamoDB** let you tune it **per request** using read/write quorums:

```
   R = replicas that must respond to a read
   W = replicas that must ACK a write
   N = total copies

   R + W > N  →  strong consistency (leans CP)
   R + W ≤ N  →  eventual consistency, faster (leans AP)
```

Higher R/W = more consistent but slower; lower = more available and faster.

---

## How to Use CAP in a System Design Interview

1. **State that P is mandatory** — real networks partition (cable *or* node down), so the choice is CP vs AP.
2. **Tie the choice to the data, not the whole system.** Different features can pick differently:
   - Payments / inventory / auth → **CP** (correctness wins).
   - Feeds / carts / recommendations / metrics → **AP** (availability wins).
3. **Explain CP via quorum** — it stays up while a majority agrees, and only errors when *quorum is lost* (not on any single failure). Call out the **latency cost** of that quorum wait.
4. **Explain AP via reconciliation** — serve from any reachable node, then merge conflicts with LWW / vector clocks / CRDTs.
5. **Bonus:** mention **PACELC** (latency-vs-consistency even without partitions) and **tunable consistency (R+W>N)** to show it's a spectrum — one line each, don't overdo it.

---

## Common Interview Questions (Q&A)

**Q: Can a system be CA?**
A: Only if it's effectively single-node (no network between replicas). Any truly distributed system must tolerate partitions, so real choices are **CP or AP**.

**Q: Does CP mean the whole system goes down when a node fails?**
A: No. CP uses **quorum** — it keeps serving as long as a **majority** of nodes agree, and only becomes unavailable when it **loses quorum** and can't confirm the latest data. Only the minority side stops serving.

**Q: What actually triggers unavailability in a CP system?**
A: **Loss of quorum**, not the death of any single node. One node down out of three still leaves a majority, so it stays up and consistent.

**Q: Does CP add latency?**
A: Yes — writes/strong reads wait for a **quorum to acknowledge** before responding. That's the "else favor Consistency over Latency" (ELC) part of PACELC, and it applies even with no partition.

**Q: Why is AP considered "simpler" to serve?**
A: Any reachable node answers from its local copy — no coordination. The complexity moves *after* the fact: reconciling conflicting writes (LWW, vector clocks, CRDTs).

**Q: Is MongoDB CP or AP?**
A: With its default single-primary replica set it's **CP** — on partition, the minority side steps down and rejects writes to avoid split-brain.

**Q: How does Cassandra stay AP?**
A: Masterless, every node accepts reads/writes; it uses tunable consistency + conflict resolution (last-write-wins timestamps) to reconcile later.

**Q: What's the difference between CAP's C and ACID's C?**
A: CAP's C = linearizability (all replicas agree on the latest value). ACID's C = integrity constraints stay valid within a transaction. Different problems.

**Q: What's better than CAP for reasoning about real systems?**
A: **PACELC** — it also captures the latency-vs-consistency trade during normal (non-partition) operation.

---

## Key Takeaways

- **CAP = pick 2 of {Consistency, Availability, Partition tolerance}** during a partition.
- A **partition = loss of communication** between nodes (cable broke *or* node down). **P is not optional** → the real decision is **CP vs AP**.
- **CP = correct, may be unavailable.** Its heart is **quorum**: serve while a majority agrees, error only when **quorum is lost** — and pay a **latency cost** for the quorum wait.
- **AP = always up, may be stale.** Serving is simple (any reachable node); the work moves to **reconciling conflicts** (LWW / vector clocks / CRDTs).
- **CA** ≈ a single node — not a real distributed choice.
- **PACELC** completes the picture: even without partitions, it's **Latency vs Consistency**.
- Consistency is often **tunable** (`R + W > N` → strong; else eventual).
- In interviews, **apply CAP per feature/data type**, not to the whole system.

---

*Last Updated: 2026-07-06 (reworked around quorum, latency, and reconciliation per discussion)*
