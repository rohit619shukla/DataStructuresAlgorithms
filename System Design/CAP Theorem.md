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
| **CP** (Consistency + Partition tolerance) | **Availability** | Rejects/blocks requests to avoid stale data | HBase, MongoDB (default), ZooKeeper, etcd, Redis (single-primary), Spanner* |
| **AP** (Availability + Partition tolerance) | **Consistency** | Always responds, may return stale data, reconciles later | Cassandra, DynamoDB, Riak, CouchDB, DNS |
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
  Reject writes/   Accept writes/
  reads that       reads on both
  can't be         sides, merge
  confirmed        later
      │                │
  Some downtime,   Always up,
  never wrong      sometimes stale
```

| Dimension | CP (pick Consistency) | AP (pick Availability) |
|-----------|-----------------------|------------------------|
| **On partition** | Some nodes stop serving | All nodes keep serving |
| **Risk** | Downtime / errors | Stale / conflicting reads |
| **Reconciliation** | Not needed (always consistent) | Needs conflict resolution (LWW, vector clocks, CRDTs) |
| **Good for** | Money, inventory, locks, config | Feeds, carts, likes, catalogs, telemetry |

**CP example:** A banking ledger — better to reject a transfer than to allow a double-spend.
**AP example:** A social feed or "like" count — better to show slightly stale data than an error page.

---

## Bonus Points: PACELC (One-Liner)

If you want to sound sharp, mention PACELC — CAP only covers *partition* time; PACELC adds the normal case:

> **If Partition → Availability vs Consistency. Else → Latency vs Consistency.**

The takeaway: even with **no** partition, keeping replicas consistent costs **latency**. One line is enough — don't go deeper unless asked.

---

## Bonus Points: Tunable Consistency (Quorums)

Good to mention that AP/CP isn't always fixed — systems like **Cassandra / DynamoDB** let you tune it **per request**:

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

1. **State that P is mandatory** — real networks partition, so the choice is CP vs AP.
2. **Tie the choice to the data, not the whole system.** Different features can pick differently:
   - Payments / inventory / auth → **CP** (correctness wins).
   - Feeds / carts / recommendations / metrics → **AP** (availability wins).
3. **Mention reconciliation** for AP: last-write-wins, vector clocks, or CRDTs.
4. **Bonus:** mention **PACELC** (latency-vs-consistency even without partitions) and **tunable consistency (R+W>N)** to show it's a spectrum — one line each, don't overdo it.

---

## Common Interview Questions (Q&A)

**Q: Can a system be CA?**
A: Only if it's effectively single-node (no network between replicas). Any truly distributed system must tolerate partitions, so real choices are **CP or AP**.

**Q: Does CP mean the system is always down during a partition?**
A: No — only the nodes that can't guarantee correctness stop serving (or serve errors). The majority/leader side can often keep working.

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
- **P is not optional** in distributed systems → the real decision is **CP vs AP**.
- **CP** = correct but may be unavailable; **AP** = always up but may be stale.
- **CA** ≈ a single node — not a real distributed choice.
- **PACELC** completes the picture: even without partitions, it's **Latency vs Consistency**.
- Consistency is often **tunable** (`R + W > N` → strong; else eventual).
- In interviews, **apply CAP per feature/data type**, not to the whole system.

---

*Last Updated: 2026-07-06*
