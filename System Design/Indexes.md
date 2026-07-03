# Database Indexes — From the Problem to B+ Trees to Clustered vs Non-Clustered

> **One-line answer:** An **index** is the *idea* of a shortcut that lets the DB jump straight to the rows you want instead of scanning the whole table; the **B+ Tree** is the actual *data structure* that makes that idea real.

This note is built in the exact order the concept clicks:
**the problem → index vs the structure behind it → B-Tree → why B+ Tree → clustered vs non-clustered → practical interview points.**

---

## 1. The Problem — why indexes exist

You have a `Users` table with **10 million rows** and you run:

```sql
SELECT * FROM Users WHERE email = 'carol@x.com';
```

The DB has two options:

1. **Full table scan** — read all 10M rows one by one, checking `email`. Painfully slow.
2. **Use a shortcut** — an **index** — to jump straight to the matching row.

> **Textbook analogy:** to find every page mentioning "Napoleon" in a 500-page book, you don't read all 500 pages — you flip to the **sorted index at the back**, find "Napoleon → p.12, 47, 203", and open just those pages. A database index is that back-of-book index.

**The core trade-off (say this in every interview):** an index makes **reads faster** but **writes slower** (every insert/update must also update the index) and it **costs extra storage**.

---

## 2. Index is the *concept*; B+ Tree is the *engine*

Keep these two words separate:

| | Term | Meaning |
|---|---|---|
| **WHAT** (logical) | **Index** | The *goal*: "a shortcut mapping a column value → the row's location." This is what you declare: `CREATE INDEX ...`. |
| **HOW** (physical) | **B+ Tree** | The actual *on-disk data structure* that implements the index — sorted keys, routing nodes, linked leaves. |

So "index" is the label; the **B+ Tree is the force doing the work.** A B+ Tree isn't the *only* possible engine (hash, GiST, LSM trees exist), but when someone says "index" with no other context, **assume B+ Tree** — right >90% of the time.

To understand the B+ Tree, you first have to understand its predecessor: the **B-Tree**.

---

## 3. The B-Tree — and why it wasn't good enough

### 3a. What a B-Tree node stores

In a **B-Tree, every node stores `(key, value)` pairs** — internal nodes included.

- **key** = the searchable value, e.g. `id = 25`.
- **value** = a **pointer to the actual row** in the table — a physical row locator, the **`tid`** (tuple id / RID).

So each entry is `key → tid`.

```
 B-TREE: (key -> tid) lives in EVERY node, even internal ones
                 +---------------------+
                 | 30->tid  |  60->tid |     <- internal node ALSO carries tids
                 +---------------------+
                /           |           \
       +-----------+  +-----------+  +-----------+
       |10->tid    |  |40->tid    |  |70->tid    |
       |20->tid    |  |50->tid    |  |80->tid    |
       +-----------+  +-----------+  +-----------+
```

**The routing rule** — a node with keys `[30 | 60]` has **three children** (N keys → N+1 children):

```
        +----+----+
        | 30 | 60 |
        +----+----+
       /     |     \
   (< 30) (30..60) (> 60)
```
`< 30` → left, `between 30 and 60` → middle, `> 60` → right.

### 3b. The limitations of a B-Tree (from the blog)

1. **Internal nodes are (mostly) wasted space — but not always dead.**
   In a B-Tree keys are **not duplicated** — each key exists in exactly one node. So a search *can* end at an internal node (an "early hit"), and that node's `tid` **is** used. **However**, because of high fan-out the *vast majority of keys live in the leaf level*, and **all range scans** go to leaves. So most of the time the `tid`s stored up in internal nodes are never read on the path — yet they still take space, which makes internal nodes **fat → fewer keys per page → lower fan-out → taller tree → more disk I/O.**

2. **Poor range scans.** For `id BETWEEN 4 AND 9`, a B-Tree has **no sequential path** — each key in the range may need a **fresh traversal from the root** to a different leaf, even if those rows sit next to each other.

3. **Scattered data.** Random inserts cause page splits, so logically-sequential rows land in **different branches** → extra I/O to read what *should* be a contiguous range.

> B-Trees are fine for **point lookups**, weak at **range scans**.

---

## 4. The B+ Tree — the fix (this is what real DBs use)

The B+ Tree makes **two changes** to the B-Tree:

**Change 1 — internal/root nodes store KEYS ONLY** (pure signposts, *no* `tid`s).
**Change 2 — `(key → tid)` lives ONLY in the leaves, and all leaves are LINKED** in a sorted chain.

A consequence of Change 1: since every real lookup must reach a **leaf** (that's the only place a `tid` exists), **every key must also appear in the leaf level**. So separator keys are **duplicated** — a key can appear as a signpost in an internal node *and* again in a leaf. That duplication is the **defining property** of a B+ Tree.

```
 B+ TREE: internal = KEYS ONLY (signposts); (key->tid) only in LEAVES; leaves LINKED (->)
                 +-----------------+
   INTERNAL      |   30   |   60   |     <- keys only, NO tids (just routing)
   (signposts)   +-----------------+
                /         |         \
       +-----------+ +-----------+ +-----------+
   LEAVES  |10->tid| |30->tid   | |60->tid    |
   (tids   |20->tid|→|50->tid   |→|80->tid    |   <- tids ONLY here, leaves LINKED (->)
    here)  +-----------+ +-----------+ +-----------+
              ^--------- walk the chain for ranges ---------^
```

**How each B-Tree problem disappears:**

| B-Tree problem | B+ Tree fix |
|---|---|
| Fat internal nodes | Internal nodes hold **keys only** → many more keys per page → higher fan-out → **shorter tree, fewer I/Os** |
| Poor range scans | Leaves are **linked** → find the start leaf, then **walk the chain** — no re-descending from root |
| Scattered range reads | Leaves are **sorted + linked** → a range is one contiguous walk |

**Range example (`id BETWEEN 4 AND 9`):** descend **once** to the leaf holding `4`, then **follow the leaf chain** rightward until you pass `9`. One descent + a sequential walk.

### Walk-through — find `id = 57`

```
                          +---------+
   LEVEL 1 (root)         |   50    |            <- 57 > 50 -> go RIGHT
                          +----+----+
                    left /          \ right
                        /            \
   LEVEL 2      +---------+       +----+----+
   (signposts)  | 20 | 35 |       | 70 | 90 |    <- 57 < 70 -> take LEFT door
                +---------+       +----+----+
                                 /    |     \
   LEVEL 3      ...       +----------+ ...   ...
   (leaves =            | 55->tid  |               <- FOUND 57's leaf; use its tid
    key->tid,          | 57->tid  |
    linked)            +----------+
                chain: ...50-55-57 <-> 60-65-70...  (leaves linked -> cheap ranges)
```
`57 > 50` → right → `57 < 70` → left door → leaf `[55 57]` → use `tid`. **3 steps.**

### Why it also beats a binary tree
Disk reads happen in **pages** (e.g. 8KB). A B+ Tree node is sized to **one page**, so a single read yields a node with *hundreds* of keys (hundreds of doors). High fan-out → only **3–4 levels deep even for billions of rows** → a lookup is **3–4 page reads**. A binary tree (2 doors/node) would be dozens of levels tall.

> **Say it out loud:** "A B-Tree stores the `tid` in every node and can't range-scan well. A B+ Tree keeps `tid`s only in the leaves — so internal nodes pack more keys and the tree is shorter — duplicates keys down to the leaves, and links the leaves so ranges just walk the chain. That's why every real database uses B+ Trees."

---

## 5. Clustered vs Non-Clustered Index

Both are B+ Trees. **The only difference is what sits in the leaf:**

- **Non-clustered** = the **classic B+ Tree** from Section 4 — leaf holds **`key → pointer`** (with keys duplicated across internal + leaf).
- **Clustered** = the leaf holds **the actual full row itself** (the table *is* the tree).

### Setup for the examples

```sql
CREATE TABLE Users (
  id    INT PRIMARY KEY,         -- id becomes the CLUSTERED index
  name  VARCHAR(50),
  email VARCHAR(100)
);
CREATE INDEX idx_email ON Users (email);   -- a NON-CLUSTERED index on email
```

```
Users table
+-----+-------+-----------+
| id  | name  | email     |
+-----+-------+-----------+
| 10  | Alice | a@x.com   |
| 20  | Bob   | b@x.com   |
| 25  | Carol | c@x.com   |
| 30  | Dave  | d@x.com   |
| 40  | Erin  | e@x.com   |
+-----+-------+-----------+
```

### 🟢 CLUSTERED B+ TREE (on `id`) — leaf = the FULL ROW

```sql
SELECT * FROM Users WHERE id = 25;
```
```
                       +---------+
   INTERNAL            | 25 | 40 |            keys only: <25 | 25..40 | >=40
   (keys only)         +----+----+
              <25     /    25..40   \    >=40
                     v       v       v
   LEAVES     +-----------+   +-----------+   +-----------+
   (leaf =    |10 Alice   | → |25 Carol   | → |40 Erin    |   <- the ACTUAL ROW is here
    FULL ROW, |   a@x.com |   |   c@x.com |   |   e@x.com |
    linked →) |20 Bob     |   |30 Dave    |   |           |
              |   b@x.com |   |   d@x.com |   |           |
              +-----------+   +-----------+   +-----------+
                     ^------- leaves linked -> range scans -------^
```
Walk: root → `25` is in `25..40` → middle leaf → **the whole row is right there.**
✅ **1 tree walk. Done.**

### 🔵 NON-CLUSTERED B+ TREE (on `email`) — leaf = key + POINTER

```sql
SELECT * FROM Users WHERE email = 'c@x.com';
```
```
                       +-------------------+
   INTERNAL            | c@x.com | e@x.com |     keys only, routed by email
   (keys only)         +---------+---------+
           <c@x.com   /    c..e     \   >=e@x.com
                     v       v        v
   LEAVES     +-----------+   +-----------+   +-----------+
   (leaf =    |a@x.com→10 | → |c@x.com→25 | → |e@x.com→40 |   <- leaf = email + POINTER
    key +     |b@x.com→20 |   |d@x.com→30 |   |           |      (no name, no full row)
    pointer)  +-----------+   +-----------+   +-----------+
                                    |
                                    | leaf gives id:25, but SELECT * needs 'name'
                                    v
   KEY LOOKUP: feed id:25 into the CLUSTERED (id) tree and walk it
                       +---------+
                       | 25 | 40 |    (25 in 25..40 -> middle leaf)
                       +----+----+
                            v
                  +---------------------+
                  | 25 Carol c@x.com    |    now we have the full row
                  +---------------------+
```
Walk 1: email tree → leaf → you get **`id:25` (a pointer), not the row.**
Walk 2 (**key lookup**): feed `id:25` into the clustered tree → fetch the full row.
⚠️ **2 tree walks** → why non-clustered is a bit slower.

### Important nuance — what is that "pointer"?

It depends on the engine:

| Engine style | Non-clustered leaf pointer is… | Fetching the row costs… |
|---|---|---|
| **Clustered / index-organized** (MySQL **InnoDB**, SQL Server w/ clustered PK) | the **primary key value** (e.g. `id:25`) | a **second B+ Tree walk** into the clustered index (the "key lookup") — *the diagrams above model this* |
| **Heap-based** (PostgreSQL always; SQL Server *heap* table) | a **physical row address** (`tid` / `RID` = file, page, slot) | a **single direct jump** to that disk location — no second tree walk |

### Summary table

| | Clustered | Non-Clustered |
|---|---|---|
| Structure | B+ Tree | B+ Tree |
| **Leaf holds** | **the full row** | **key + pointer** (PK in InnoDB, `tid` in a heap) |
| Count per table | **1** (data can be physically sorted one way) | **many** |
| Extra lookup for `SELECT *`? | No | Yes (key lookup, in InnoDB) |
| Defines physical row order? | Yes | No |

> **Say it out loud:** "Both are B+ Trees. A clustered index's leaf *is* the row, so one walk finds it — and there's only one per table because rows can be physically ordered one way. A non-clustered index's leaf holds a pointer, so `SELECT *` needs a second walk (in InnoDB, into the clustered index by primary key) — the 'key lookup' — which is why it's slightly slower."

---

## 6. Covering index — removing the second walk (senior signal)

The extra key lookup only happens when the query needs a column the index leaf **doesn't** have. Two ways to avoid it:

1. **Select only indexed columns** — the leaf already has them:
   ```sql
   SELECT email FROM Users WHERE email = 'c@x.com';   -- answered from idx_email alone
   ```
2. **Covering index** — stuff the needed column into the index so its leaf carries everything:
   ```sql
   CREATE INDEX idx_email_cover ON Users (email) INCLUDE (name);
   -- SELECT name, email WHERE email = ... is now answered from the index alone, no 2nd walk
   ```

> **Covering index** = an index containing *all* columns a query needs, so the engine answers it **from the index alone** without touching the table. Fastest case.

---

## 7. Composite (multi-column) index & the leftmost-prefix rule

An index on `(a, b, c)` is sorted by `a`, then `b`, then `c` — like a phone book sorted by (last, first). It can serve filters on:

- ✅ `a`
- ✅ `a, b`
- ✅ `a, b, c`
- ❌ `b` alone, or `c` alone, or `b, c` — because you can't use the sort without the leftmost key.

```sql
CREATE INDEX idx ON Orders (customer_id, order_date);

SELECT * FROM Orders WHERE customer_id = 5;                       -- ✅ uses index
SELECT * FROM Orders WHERE customer_id = 5 AND order_date > '..'; -- ✅ uses index
SELECT * FROM Orders WHERE order_date > '..';                     -- ❌ index NOT used
```

**Rule of thumb:** put the **most-selective / most-frequently-filtered equality column first**, and **range columns last** (a range stops the index being usable for any column after it).

---

## 8. The Trade-offs (always mention these)

**Pros**
- Dramatically faster reads: `WHERE`, `JOIN`, `ORDER BY`, `GROUP BY`.
- Enforce **uniqueness** (a unique index backs `UNIQUE` / `PRIMARY KEY`).

**Cons**
- **Slower writes** — every `INSERT`/`UPDATE`/`DELETE` must update every affected index.
- **Extra storage** — indexes consume real disk space.
- **Maintenance** — over-indexing hurts; unused indexes are pure overhead.

> One-liner: *"An index trades write speed and storage for read speed."*

---

## 9. When to add an index (and when not to)

**Add when:**
- The column is frequently in `WHERE`, `JOIN ... ON`, `ORDER BY`, or `GROUP BY`.
- The column has **high cardinality** (many distinct values — e.g. email, user_id).
- The workload is read-heavy.

**Avoid / reconsider when:**
- The table is **small** (a full scan is already cheap).
- The column has **low cardinality** (boolean, 2–3 value enum) — a scan is often just as fast.
- The table is extremely **write-heavy** and the index isn't needed for reads.
- The column is rarely queried.

> **Cardinality / selectivity** = how many distinct values a column has. High cardinality = great index candidate; low cardinality = often useless.

---

## 10. Why an existing index gets ignored ("index not used")

- **Function on the column:** `WHERE YEAR(created_at) = 2024` → index on `created_at` unused. Rewrite as a range (`created_at >= '2024-01-01' AND < '2025-01-01'`).
- **Leading wildcard:** `LIKE '%abc'` can't use sorted order. `LIKE 'abc%'` is fine.
- **Implicit type conversion** (string column compared to a number).
- **Low selectivity** — the optimizer decides a full scan is cheaper.
- **Non-leftmost composite column** — filtering on `b` alone of `(a, b)`.

---

## 11. Common Interview Questions (Q&A)

- **What is an index?** The *concept* of a sorted shortcut mapping column value → row location, avoiding full scans. Implemented (by default) as a B+ Tree.
- **B-Tree vs B+ Tree?** B-Tree stores `key→tid` in *every* node (keys not duplicated, search can end early at an internal node) but has fat internals and bad range scans. B+ Tree stores `tid`s **only in leaves**, keeps internals as keys-only signposts (higher fan-out, shorter tree), **duplicates keys down to leaves**, and **links leaves** for cheap ranges.
- **B-Tree/B+ Tree vs Hash?** B-Tree/B+ Tree → equality **+** ranges + sorting. Hash → equality only, O(1), no ranges.
- **Why B+ Tree over a binary tree on disk?** Page-sized nodes → high fan-out → 3–4 levels for billions of rows → few page I/Os.
- **Clustered vs non-clustered?** Clustered: leaf = full row, one per table, defines physical order. Non-clustered: leaf = key + pointer, many per table, may need a key lookup.
- **Why is non-clustered slower?** In InnoDB the leaf stores the **primary key**, so `SELECT *` needs a **second B+ Tree walk** (key lookup) into the clustered index.
- **Covering index?** An index containing all columns a query needs → answered from the index alone, no key lookup.
- **Composite index order?** Leftmost-prefix rule: most-selective equality column first, range columns last.
- **Downside of indexes?** Slower writes, more storage, maintenance.
- **Why won't my index be used?** Function on the column, leading `%`, type mismatch, low selectivity, or non-leftmost composite column.

---

## Key Takeaways

- **Index = concept, B+ Tree = the engine.** Assume B+ Tree unless told otherwise.
- **B-Tree → B+ Tree:** move `tid`s to leaves only, make internals keys-only signposts, duplicate keys down, link the leaves. Result: shorter tree + fast range scans.
- **Clustered:** leaf *is* the row, 1 per table, defines physical order. **Non-clustered:** leaf = key + pointer, many per table, extra key lookup (InnoDB) or direct `tid` jump (heap).
- **Covering index** removes the second lookup.
- **Composite = leftmost-prefix**; equality columns first, ranges last.
- **The trade-off:** faster reads for slower writes + more storage. High-cardinality, read-heavy columns are the best candidates.

---

*Last Updated: 2026-07-03*
