# SQL vs NoSQL

## The One-Line Answer (Say This First in an Interview)

> **SQL** databases are **relational, schema-on-write, and strongly consistent** — pick them when data is structured and relationships/transactions matter.
> **NoSQL** databases are **non-relational, schema-on-read, and horizontally scalable** — pick them when you need massive scale, flexible schemas, or high write throughput.

There is **no universally "better"** option. The interviewer wants to hear *trade-offs* and a *justified choice* for the given problem.

---

## Quick Comparison Table

| Dimension | SQL (Relational) | NoSQL (Non-Relational) |
|-----------|------------------|------------------------|
| **Data model** | Tables (rows & columns) | Document, Key-Value, Wide-Column, Graph |
| **Schema** | Fixed, schema-on-write | Flexible, schema-on-read |
| **Scaling** | Vertical (scale-up) primarily | Horizontal (scale-out) natively |
| **Consistency** | Strong (ACID) | Tunable (often eventual / BASE) |
| **Joins** | First-class, powerful | Limited or none (denormalize instead) |
| **Transactions** | Mature, multi-row ACID | Limited (improving — e.g. Mongo multi-doc) |
| **Query language** | SQL (standardized) | Varies per database |
| **Best for** | Structured data, complex queries | Big data, rapid iteration, high write load |
| **Examples** | PostgreSQL, MySQL, Oracle, SQL Server | MongoDB, Cassandra, DynamoDB, Redis, Neo4j |

---

## The Four Types of NoSQL Databases

This is a **very common follow-up** — "NoSQL" is not one thing.

```
┌──────────────────────────────────────────────────────────────────────┐
│                     NoSQL Database Types                              │
├──────────────────────────────────────────────────────────────────────┤
│                                                                      │
│  1. KEY-VALUE        key ──▶ value                                   │
│     Redis, DynamoDB  "user:123" ──▶ {blob}                           │
│     Use: caching, sessions, leaderboards                             │
│                                                                      │
│  2. DOCUMENT         JSON/BSON documents, nested fields              │
│     MongoDB, Couch   { _id, name, orders: [...] }                    │
│     Use: catalogs, user profiles, content mgmt                       │
│                                                                      │
│  3. WIDE-COLUMN      rows with dynamic columns, column families      │
│     Cassandra, HBase  partitioned by key, huge write throughput      │
│     Use: time-series, event logs, IoT, messaging                     │
│                                                                      │
│  4. GRAPH            nodes + edges (relationships are first-class)   │
│     Neo4j, Neptune    (User)-[FOLLOWS]->(User)                       │
│     Use: social networks, recommendations, fraud detection          │
│                                                                      │
└──────────────────────────────────────────────────────────────────────┘
```

| Type | Lookup pattern | Killer use case |
|------|---------------|-----------------|
| **Key-Value** | Get/Put by exact key | Cache, session store, feature flags |
| **Document** | Query by fields in a document | User profiles, product catalog |
| **Wide-Column** | Query by partition + clustering key | Time-series, write-heavy logs |
| **Graph** | Traverse relationships | Social graph, recommendations |

---

## ACID vs BASE

The core philosophical difference. Interviewers love this contrast.

```
ACID (typical SQL)                    BASE (typical NoSQL)
──────────────────                    ────────────────────
A - Atomicity                         BA - Basically Available
C - Consistency                       S  - Soft state
I - Isolation                         E  - Eventually consistent
D - Durability

"Correct or nothing.                  "Available and fast now,
 Strong guarantees."                   consistent soon."
```

| Property | ACID | BASE |
|----------|------|------|
| **Goal** | Correctness & reliability | Availability & scale |
| **Consistency** | Immediate / strong | Eventual |
| **On conflict** | Roll back, fail safely | Accept, reconcile later |
| **Typical DB** | PostgreSQL, MySQL | Cassandra, DynamoDB |

**ACID example:** A bank transfer — debit and credit must both succeed or both fail. Never leave money in limbo.
**BASE example:** A "like" counter on a post — being off by a few for a second is fine; availability matters more.

---

## ACID Properties (SQL — In Depth)

**ACID** is the set of guarantees a transactional (relational) database makes so that a group of operations behaves like a single, reliable unit of work — even under crashes, concurrency, and failures.

### A — Atomicity ("All or Nothing")
- A transaction is **indivisible**: either **every** operation commits, or **none** of them do.
- If any step fails, the database **rolls back** to the state before the transaction started — no partial writes are left behind.
- **Example:** Transferring ₹1000 = `debit account A` + `credit account B`. If the credit fails, the debit is rolled back so money is never lost or duplicated.
- **Enabled by:** write-ahead logs (WAL), undo logs, rollback segments.

### C — Consistency ("Valid State to Valid State")
- A transaction moves the database from **one valid state to another**, always preserving **all defined rules** — constraints, foreign keys, uniqueness, triggers, cascades.
- If a transaction would violate an invariant (e.g. a negative stock count or a duplicate primary key), it is **rejected**.
- **Note:** This is *database* consistency (integrity rules), which is different from the *distributed-systems* "C" in CAP (all nodes seeing the same data).
- **Example:** An order can never reference a `customer_id` that doesn't exist — the foreign key constraint enforces it.

### I — Isolation ("Concurrent = Serial")
- Concurrently running transactions don't **interfere** with each other; the result is **as if they ran one after another**.
- Controlled by **isolation levels**, trading correctness for performance:
  - **Read Uncommitted** → allows *dirty reads*
  - **Read Committed** → prevents dirty reads
  - **Repeatable Read** → prevents non-repeatable reads
  - **Serializable** → strongest; prevents *phantom reads*
- **Example:** Two people booking the **last seat** at the same time — isolation ensures only one succeeds, not both.
- **Enabled by:** locking (pessimistic) or MVCC / multi-version concurrency control (optimistic).

### D — Durability ("Once Committed, It Stays")
- Once a transaction is **committed**, its changes **survive** crashes, power loss, or restarts.
- Committed data is persisted to **non-volatile storage** before success is acknowledged.
- **Example:** After your payment confirmation screen, the record won't vanish even if the server crashes a second later.
- **Enabled by:** write-ahead logging, fsync to disk, replication.

---

## BASE Properties (NoSQL — In Depth)

**BASE** is the relaxed counterpart to ACID. To achieve **massive scale and high availability** in distributed systems, it deliberately **loosens consistency** guarantees. It is a direct consequence of the CAP theorem (choosing Availability over strong Consistency under partitions).

### BA — Basically Available
- The system **guarantees availability** — every request gets a **response**, even during partial failures or network partitions.
- The response might be **stale** or based on an **incomplete** view, but the system **never goes fully down**.
- **Example:** During a node outage, a shopping site still serves the product catalog (possibly slightly out of date) rather than returning an error.

### S — Soft State
- The state of the system **may change over time even without new input**, because replicas are **asynchronously converging** in the background.
- The data is **not guaranteed to be immediately consistent** across all nodes — it's "in flux."
- **Example:** A user's profile update propagates to replicas over a few seconds; different replicas may briefly hold different values.

### E — Eventually Consistent
- If no new updates are made, **all replicas eventually converge** to the same value — but **not instantly**.
- The system accepts **temporary inconsistency** in exchange for availability and performance, reconciling conflicts later (e.g. last-write-wins, vector clocks, CRDTs).
- **Example:** A "like" count or a social feed may show slightly different numbers across regions for a moment, then settle to the correct value.

### ACID vs BASE — Property-by-Property

| ACID (SQL) | BASE (NoSQL) | Trade-off |
|------------|--------------|-----------|
| **Atomicity** — all or nothing | **Basically Available** — always responds | Correctness vs uptime |
| **Consistency** — always valid state | **Soft State** — state may drift | Strict rules vs flexibility |
| **Isolation** — transactions don't interfere | (relaxed / limited) | Concurrency safety vs throughput |
| **Durability** — survives crashes | **Eventually Consistent** — converges over time | Immediate truth vs scale |

> **Interview soundbite:** ACID optimizes for **correctness**; BASE optimizes for **availability and scale**. ACID says *"be right, even if you have to wait or fail."* BASE says *"stay up and fast now, become right soon."*

---

## CAP Theorem (How It Drives the Choice)

> In a distributed system, during a **network partition (P)** you can only fully guarantee **two** of: **Consistency, Availability, Partition tolerance**. Since partitions are unavoidable at scale, the real trade-off is **C vs A**.

```
                    CAP Theorem
                        ▲
                   Consistency
                   /          \
                  /            \
                 /   Pick 2     \
                /                \
       Availability ──────── Partition Tolerance

   CP systems: refuse requests to stay consistent
       → MongoDB (default), HBase, Spanner
   AP systems: stay available, reconcile later
       → Cassandra, DynamoDB, CouchDB
```

- **CP** (Consistency + Partition tolerance): rejects/blocks during partitions to avoid stale data. *Good for money, inventory.*
- **AP** (Availability + Partition tolerance): always answers, may return stale data. *Good for feeds, carts, metrics.*

> Most SQL on a single node is "CA" — but that's not a distributed-systems answer. The moment you replicate/shard, you face C vs A.

---

## When to Choose SQL

Choose SQL when **any** of these are true:

- ✅ Data is **structured** and the schema is stable
- ✅ You need **complex queries, joins, aggregations**
- ✅ You need **multi-row ACID transactions** (banking, payments, inventory, bookings)
- ✅ **Data integrity** and constraints (foreign keys, uniqueness) are critical
- ✅ Reporting / analytics with ad-hoc queries
- ✅ The relationships between entities are rich and matter

**Classic SQL systems:** banking, e-commerce orders/payments, ERP, ticketing/booking, anything financial.

---

## When to Choose NoSQL

Choose NoSQL when **any** of these are true:

- ✅ **Massive scale** / horizontal scaling out of the box
- ✅ **High write throughput** (logs, events, IoT, telemetry)
- ✅ **Flexible / evolving schema** (rapid product iteration)
- ✅ **Simple access patterns** known in advance (key-based lookups)
- ✅ Data is naturally **hierarchical/document-shaped** (profiles, catalogs)
- ✅ **Low-latency** reads/writes at scale (caching, sessions)
- ✅ Graph traversals (social, recommendations) → graph DB

**Classic NoSQL systems:** social feeds, messaging, caching layers, recommendation engines, time-series/IoT, real-time analytics.

---

## Decision Flow

```
            ┌─────────────────────────────────────────┐
            │  Do you need multi-row ACID transactions │
            │  or strong data integrity (money, etc.)? │
            └───────────────┬─────────────────────────┘
                  YES        │         NO
            ┌────────────────┘────────────────┐
            ▼                                  ▼
        Use SQL                ┌───────────────────────────────┐
                               │ Is the schema flexible OR do  │
                               │ you need massive horizontal   │
                               │ scale / high write volume?    │
                               └──────────────┬────────────────┘
                                     YES       │        NO
                               ┌───────────────┘────────────┐
                               ▼                             ▼
                          Use NoSQL                  SQL is fine
                     (pick type by access pattern)  (default safe choice)
```

> **Interview tip:** When unsure, SQL is the safe default. Justify NoSQL by pointing at a *specific* scale or schema requirement.

---

## Scaling: The Real Differentiator

```
SQL — Vertical Scaling (Scale UP)        NoSQL — Horizontal Scaling (Scale OUT)
────────────────────────────────        ──────────────────────────────────────
   ┌──────────┐                          ┌────┐ ┌────┐ ┌────┐ ┌────┐
   │  Bigger  │  add CPU/RAM/SSD         │ N1 │ │ N2 │ │ N3 │ │ N4 │  add nodes
   │  Server  │  to one machine          └────┘ └────┘ └────┘ └────┘
   └──────────┘                          data sharded across nodes

   Hits a hardware ceiling.              Near-linear scale, but
   Simpler, fewer consistency issues.    harder consistency & joins.
```

- **SQL can scale horizontally too** — via **read replicas** (read scaling) and **sharding** (write scaling) — but sharding SQL is **operationally hard** (cross-shard joins/transactions break down).
- **NoSQL is built for sharding** from day one — partition key decides data placement.

---

## Polyglot Persistence (The Mature Answer)

Real systems rarely pick just one. **Use the right store per workload:**

```
   ┌─────────────────────────────────────────────────────────┐
   │                  E-Commerce Example                      │
   ├─────────────────────────────────────────────────────────┤
   │  Orders / Payments     →  PostgreSQL   (ACID)            │
   │  Product Catalog       →  MongoDB      (flexible docs)   │
   │  Shopping Cart/Session →  Redis        (fast key-value)  │
   │  Product Search        →  Elasticsearch(full-text)       │
   │  Recommendations       →  Neo4j        (graph)           │
   │  Activity / Event Logs →  Cassandra    (write-heavy)     │
   └─────────────────────────────────────────────────────────┘
```

> Mentioning **polyglot persistence** signals senior-level thinking — you're matching storage to access patterns, not forcing one DB everywhere.

---

## Common Interview Questions

### Q1: SQL vs NoSQL — how do you choose?
Start with requirements, not technology. Need **ACID transactions, joins, strong integrity** → SQL. Need **horizontal scale, flexible schema, high write throughput, simple access patterns** → NoSQL. When in doubt, SQL is the safe default; justify NoSQL with a concrete scale/schema requirement.

### Q2: Is NoSQL "schemaless"? Does it have no schema at all?
No — it's **schema-on-read**, not schema-free. The structure still exists; it's just **enforced by the application** at read time rather than by the database at write time. This gives flexibility but pushes the burden of consistency onto your code.

### Q3: Can NoSQL do transactions / can SQL scale horizontally?
Both lines are blurring. Modern NoSQL (MongoDB multi-document transactions, DynamoDB transactions) added ACID features; "NewSQL" databases (Google Spanner, CockroachDB, Vitess) give SQL + horizontal scale. So the answer is **"increasingly yes, with caveats."**

### Q4: Why are joins discouraged in NoSQL? How do you model relationships?
NoSQL data is **sharded across nodes**, so joins would require expensive cross-node coordination. Instead you **denormalize** — duplicate data and embed related entities in one document, or design tables around your **query/access patterns** (especially in Cassandra/DynamoDB). You trade storage and write complexity for fast reads.

### Q5: Explain ACID vs BASE with an example.
**ACID** = strong correctness (bank transfer: debit + credit both succeed or both fail). **BASE** = availability over immediate consistency (a "like" count can be briefly stale). SQL leans ACID, NoSQL leans BASE — but it's tunable.

### Q6: What is eventual consistency? When is it acceptable?
After a write, replicas **converge to the same value over time**, not instantly. Acceptable when **stale reads are harmless**: social feeds, view counts, product recommendations, DNS. **Not acceptable** for money, inventory decrements, or unique-username checks.

### Q7: How does CAP theorem influence the database choice?
Under a network partition you choose **Consistency or Availability**. Money/inventory → **CP** (reject rather than serve stale). Feeds/carts/metrics → **AP** (stay available, reconcile later).

### Q8: Give a system that uses both SQL and NoSQL.
E-commerce: **PostgreSQL** for orders/payments (ACID), **Redis** for cart/session (speed), **MongoDB** for catalog (flexible schema), **Cassandra** for activity logs (write-heavy), **Elasticsearch** for search. This is **polyglot persistence**.

---

## Key Takeaways for Interviews

1. **Lead with trade-offs, not "X is better"** — the choice depends on requirements.
2. **SQL = structure + ACID + joins; NoSQL = scale + flexibility + high writes.**
3. **NoSQL is 4 families** — key-value, document, wide-column, graph. Know one use case each.
4. **ACID vs BASE** and **CAP (C vs A under partition)** are the core mental models.
5. **NoSQL is schema-on-read, not schema-free** — the schema lives in your app.
6. **Joins are discouraged in NoSQL → denormalize / model by access pattern.**
7. **SQL scales vertically (easy) and horizontally (hard); NoSQL shards natively.**
8. **The lines are blurring** — NewSQL (Spanner, CockroachDB) and NoSQL transactions.
9. **Polyglot persistence is the senior answer** — right store per workload.
10. **Default to SQL; justify NoSQL with a concrete scale or schema need.**

---

## SQL Joins (The 4 Core Types)

### The One-Line Answer (Say This First in an Interview)

> A **JOIN** combines rows from two or more tables based on a related column between them.
> The four core joins differ only in **which non-matching rows they keep**:
> **INNER** keeps only matches, **LEFT** keeps all left rows, **RIGHT** keeps all right rows, and **FULL** keeps everything from both sides.

Everything else (CROSS JOIN, SELF JOIN, etc.) is just a variation or special case of these.

---

### Quick Comparison Table

| Join Type | Keeps Matching Rows | Keeps Unmatched LEFT | Keeps Unmatched RIGHT | NULLs Introduced? |
|-----------|:-------------------:|:--------------------:|:---------------------:|:-----------------:|
| **INNER JOIN** | ✅ | ❌ | ❌ | No |
| **LEFT (OUTER) JOIN** | ✅ | ✅ | ❌ | Yes (right cols) |
| **RIGHT (OUTER) JOIN** | ✅ | ❌ | ✅ | Yes (left cols) |
| **FULL (OUTER) JOIN** | ✅ | ✅ | ✅ | Yes (both sides) |

> 💡 `OUTER` is optional — `LEFT JOIN` ≡ `LEFT OUTER JOIN`.

---

### Visualizing With Venn Diagrams

```
      INNER JOIN                          LEFT JOIN
   (only the overlap)              (all of A + the overlap)

       A         B                     A         B
     .---.     .---.                 .---.     .---.
    /     \   /     \               /█████\   /     \
   |     ██|██|      |             |█████ █|██|      |
   |     ██|██|      |             |█████ █|██|      |
    \     / \ \     /               \█████/ \ \     /
     '---'     '---'                 '---'     '---'


      RIGHT JOIN                          FULL JOIN
   (all of B + overlap)           (everything from A and B)

       A         B                     A         B
     .---.     .---.                 .---.     .---.
    /     \   /█████\               /█████\   /█████\
   |      |██|█ █████|             |█████ █|██|█ █████|
   |      |██|█ █████|             |█████ █|██|█ █████|
    \     / \ \█████/               \█████/ \ \█████/
     '---'     '---'                 '---'     '---'
```

---

### Sample Data (Used in All Examples Below)

**`employees`**

| emp_id | name    | dept_id |
|:------:|---------|:-------:|
| 1      | Alice   | 10      |
| 2      | Bob     | 20      |
| 3      | Charlie | 30      |
| 4      | Diana   | NULL    |

**`departments`**

| dept_id | dept_name   |
|:-------:|-------------|
| 10      | Engineering |
| 20      | Sales       |
| 40      | Marketing   |

> Note: `dept_id = 30` (Charlie) and Diana's `NULL` have **no** matching department.
> `dept_id = 40` (Marketing) has **no** matching employee.

---

### 1. INNER JOIN

Returns **only the rows that have a match in both tables**.

```sql
SELECT e.name, d.dept_name
FROM employees e
INNER JOIN departments d
  ON e.dept_id = d.dept_id;
```

**Result:**

| name  | dept_name   |
|-------|-------------|
| Alice | Engineering |
| Bob   | Sales       |

➡️ Charlie, Diana (no dept), and Marketing (no employee) are all **dropped**.

**Use when:** you only care about records that exist on both sides (e.g. orders that have a valid customer).

---

### 2. LEFT (OUTER) JOIN

Returns **all rows from the left table**, plus matched rows from the right. Unmatched right columns become `NULL`.

```sql
SELECT e.name, d.dept_name
FROM employees e
LEFT JOIN departments d
  ON e.dept_id = d.dept_id;
```

**Result:**

| name    | dept_name   |
|---------|-------------|
| Alice   | Engineering |
| Bob     | Sales       |
| Charlie | NULL        |
| Diana   | NULL        |

➡️ Every employee is kept; those without a department show `NULL`.

**Use when:** you want all records from the primary table and optionally their related data (e.g. **all** users and their orders, even users with zero orders).

**Trick — "find the orphans":**

```sql
SELECT e.name
FROM employees e
LEFT JOIN departments d ON e.dept_id = d.dept_id
WHERE d.dept_id IS NULL;   -- employees with no matching department
```

---

### 3. RIGHT (OUTER) JOIN

Mirror image of LEFT — returns **all rows from the right table**, plus matched left rows.

```sql
SELECT e.name, d.dept_name
FROM employees e
RIGHT JOIN departments d
  ON e.dept_id = d.dept_id;
```

**Result:**

| name  | dept_name   |
|-------|-------------|
| Alice | Engineering |
| Bob   | Sales       |
| NULL  | Marketing   |

➡️ Every department is kept; Marketing has no employee so `name` is `NULL`.

**Use when:** rarely used in practice — most engineers just flip the table order and use a LEFT JOIN for readability.

---

### 4. FULL (OUTER) JOIN

Returns **all rows from both tables**, matching where possible and filling `NULL` elsewhere.

```sql
SELECT e.name, d.dept_name
FROM employees e
FULL OUTER JOIN departments d
  ON e.dept_id = d.dept_id;
```

**Result:**

| name    | dept_name   |
|---------|-------------|
| Alice   | Engineering |
| Bob     | Sales       |
| Charlie | NULL        |
| Diana   | NULL        |
| NULL    | Marketing   |

➡️ Union of LEFT and RIGHT — nothing is dropped.

**Use when:** reconciling two datasets to find mismatches on **either** side (e.g. comparing two systems to find records missing in one).

> ⚠️ **MySQL has no `FULL OUTER JOIN`.** Emulate it with `LEFT JOIN ... UNION ... RIGHT JOIN`.

---

### Bonus Joins (Common Follow-Ups)

#### CROSS JOIN — Cartesian product
Every row of A paired with every row of B (no `ON` clause). `m × n` rows.

```sql
SELECT e.name, d.dept_name
FROM employees e
CROSS JOIN departments d;   -- 4 × 3 = 12 rows
```
**Use:** generating combinations (e.g. all sizes × all colors).

#### SELF JOIN — a table joined to itself
Used for hierarchical/related rows within one table (e.g. employee → manager).

```sql
SELECT e.name AS employee, m.name AS manager
FROM employees e
LEFT JOIN employees m
  ON e.manager_id = m.emp_id;
```

---

### INNER vs OUTER — The Mental Model

```
INNER  = intersection            (∩) — strict, only matches
OUTER  = preserve unmatched rows  — LEFT, RIGHT, or FULL decides which side(s)
```

- **LEFT/RIGHT/FULL** are all **OUTER** joins (the keyword is optional).
- The word **OUTER** literally means "keep the rows on the *outside* of the overlap."

---

### `WHERE` vs `ON` — A Classic Gotcha

With outer joins, **where you put the filter changes the result**:

```sql
-- Keeps ALL employees; non-Sales depts just show NULL
SELECT e.name, d.dept_name
FROM employees e
LEFT JOIN departments d
  ON e.dept_id = d.dept_id AND d.dept_name = 'Sales';

-- Turns the LEFT JOIN back into an INNER JOIN (NULLs filtered out!)
SELECT e.name, d.dept_name
FROM employees e
LEFT JOIN departments d
  ON e.dept_id = d.dept_id
WHERE d.dept_name = 'Sales';
```

➡️ Conditions in **`ON`** affect *matching*; conditions in **`WHERE`** filter the *final result* and can silently cancel an outer join.

---

### Common Interview Questions

**Q: What's the difference between INNER and LEFT JOIN?**
INNER returns only matching rows; LEFT returns all left-table rows plus matches, filling `NULL` for missing right-side data.

**Q: Are LEFT JOIN and RIGHT JOIN interchangeable?**
Yes — `A LEFT JOIN B` ≡ `B RIGHT JOIN A`. LEFT is preferred for readability.

**Q: How do you find rows in table A that have no match in table B?**
`LEFT JOIN B ... WHERE B.key IS NULL` (the "anti-join" pattern).

**Q: Does MySQL support FULL OUTER JOIN?**
No. Emulate with `LEFT JOIN ... UNION ... RIGHT JOIN`.

**Q: What's the difference between a CROSS JOIN and an INNER JOIN with no condition?**
They're equivalent — both produce a Cartesian product.

**Q: Why might a LEFT JOIN return fewer rows than expected?**
A condition in the `WHERE` clause referencing the right table filters out the `NULL` rows, effectively converting it to an INNER JOIN.

**Q: Can a JOIN produce more rows than either table?**
Yes — if the join key isn't unique (one-to-many or many-to-many), rows multiply.

---

### Key Takeaways

- **4 core joins**: INNER (matches only), LEFT (all left), RIGHT (all right), FULL (everything).
- **OUTER** = "keep unmatched rows"; the keyword is optional.
- Outer joins introduce **`NULL`s** for the unmatched side.
- The **anti-join** (`LEFT JOIN ... WHERE right.key IS NULL`) finds orphan records.
- Beware the **`ON` vs `WHERE`** trap — a right-table filter in `WHERE` cancels an outer join.
- **CROSS JOIN** = Cartesian product; **SELF JOIN** = a table joined to itself.
- **MySQL** lacks `FULL OUTER JOIN` — emulate with `UNION`.

---

*Last Updated: 2026-07-05*
