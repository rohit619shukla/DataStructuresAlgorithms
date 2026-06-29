# Database Indexes — Explained From Scratch

> **Read this top to bottom. No prior knowledge needed.** Part A tells the idea as a simple story. Part B ("Going Deeper") is the precise, technically-correct model for interviews. Both say the same thing — Part B just adds detail.

---

# PART A — The Idea (Beginner Story)

## 1. The Problem (in plain words)

You have a table with **10 million rows**. Someone asks:

> "Give me the user whose email is `alice@example.com`."

The database has two choices:

1. **Read every single row**, one by one, and check if the email matches. This is called a **full table scan**. With 10 million rows, that's painfully slow.
2. **Look it up instantly** using a shortcut — an **index**.

An **index is that shortcut.** It is a separate, sorted data structure that lets the database *jump straight* to the rows you want instead of reading everything.

---

## 2. The Textbook Story 📖

Imagine a **500-page history textbook**. You want every page that mentions *"Napoleon"*.

### ❌ The slow way (no index)
Start at page 1, read every line of every page looking for "Napoleon". That's 500 pages of reading. This is a **full table scan**.

### ✅ The smart way (use the index)
Flip to the **index at the back of the book**. It's alphabetically sorted:

```
Napoleon ............ 12, 47, 203
Newton .............. 88
```

You jump to "N", find "Napoleon", and it tells you *exactly* which pages to open: 12, 47, 203. You read 3 pages instead of 500.

**That back-of-the-book index is exactly what a database index is.**

Key insights from this story that carry over to databases:

- The index is **sorted** — that's what makes lookups fast.
- The index is **separate** from the actual content (the pages).
- The index stores the **search term + a pointer** (the page number), not the whole page.
- The index takes up **extra space** (those index pages at the back).
- If you **add a new chapter**, someone has to **update the index too** — extra work on writes.

That last point is the central trade-off: **indexes make reads faster but writes slower, and they cost storage.**

---

# PART B — Going Deeper (Interview-Ready)

## 3. What an index actually is

An index is an **auxiliary data structure** that maps **column value(s) → location of the matching row(s)**. Without one, the engine does a sequential scan; with one, it does an efficient lookup.

The two data structures you must know:

| Structure | Used for | Good at | Bad at |
|---|---|---|---|
| **B-Tree (B+ Tree)** | Default index in almost every relational DB | Equality (`=`) **and** range queries (`<`, `>`, `BETWEEN`, `ORDER BY`, prefix `LIKE 'abc%'`) | — |
| **Hash index** | Some engines (Postgres, MySQL MEMORY) | Pure equality (`=`) — O(1) | Cannot do ranges or sorting |

> **Default answer in interviews: "B+ Tree."** It's the workhorse because it handles both equality and ranges, and keeps data sorted.

---

## 4. The B+ Tree (the one that matters)

A **B+ Tree** is a balanced tree, kept shallow on purpose:

- **Internal nodes** store only keys + child pointers (act as a "guide").
- **Leaf nodes** store the actual indexed keys (sorted) + pointers to the rows.
- **Leaf nodes are linked together** in a doubly-linked list → makes range scans and `ORDER BY` extremely cheap (just walk the leaves).
- It stays **balanced** and **shallow** — typically 3–4 levels deep even for billions of rows. Each level ≈ one disk page read, so a lookup is only a handful of I/Os.

```
                 [ M ]                 <- internal
              /         \
        [ D  G ]      [ T  W ]         <- internal
        /  |  \        /  |  \
     [A B][D E][G..] ...  leaves (sorted, linked) -> -> ->
```

**Why a B+ Tree and not a binary tree?** Disk reads happen in **pages/blocks**. A B+ Tree node is sized to one page and holds *many* keys (high fan-out), so the tree is short and you do few disk reads. A binary tree would be tall and cause far more I/O.

---

## 5. Clustered vs Non-Clustered Index (very common interview question)

### Clustered Index
- Determines the **physical order** of the rows on disk. The table data *is* the leaf level of this B+ Tree.
- There can be **only ONE** per table (data can only be physically sorted one way).
- In **MySQL/InnoDB the PRIMARY KEY is the clustered index** automatically.
- Lookups by the clustered key are very fast — once you reach the leaf, the row is *right there*.

### Non-Clustered (Secondary) Index
- A **separate** structure. Its leaves store the indexed value + a pointer back to the actual row.
- You can have **many** per table.
- A lookup may require an extra step to fetch the full row (see "covering index" below).

| | Clustered | Non-Clustered |
|---|---|---|
| Count per table | 1 | Many |
| Stores actual rows? | Yes (rows = leaves) | No (pointer to rows) |
| Physical order | Defines it | Independent |
| Extra lookup to get row | No | Often yes |

> **Analogy:** A clustered index is a phone book sorted by last name — the data *is* the order. A non-clustered index is the back-of-book index that points to a page.

---

## 6. Key terms interviewers love

- **Covering index** — an index that contains *all* the columns a query needs, so the engine answers the query **from the index alone** without touching the table. Fastest case.
- **Composite (multi-column) index** — an index on `(a, b, c)`. Order matters! It can serve queries filtering on `a`, `a,b`, or `a,b,c` — a **leftmost prefix**. It does **not** help a query that filters only on `b` or `c`.
- **Cardinality / selectivity** — how many distinct values a column has. **High cardinality** (e.g., email, user_id) = great index candidate. **Low cardinality** (e.g., `gender`, `is_active` boolean) = index often useless; a scan may be just as fast.
- **Index-only scan** = covering index in action.
- **Bookmark / key lookup** — the extra hop from a non-clustered index leaf to the actual row.

---

## 7. The Trade-offs (always mention these)

Indexes are **not free**. State this explicitly in an interview:

**Pros**
- Dramatically faster reads / `WHERE`, `JOIN`, `ORDER BY`, `GROUP BY`.
- Enforce **uniqueness** (a unique index backs a `UNIQUE` / `PRIMARY KEY` constraint).

**Cons**
- **Slower writes** — every `INSERT`/`UPDATE`/`DELETE` must also update every affected index.
- **Extra storage** — indexes can take significant disk space.
- **Maintenance** — over-indexing hurts; unused indexes are pure overhead.

> One-liner: *"An index trades write speed and storage for read speed."*

---

## 8. When to add an index (and when not to)

**Add an index when:**
- The column is frequently used in `WHERE`, `JOIN ... ON`, `ORDER BY`, or `GROUP BY`.
- The column has **high cardinality** (many distinct values).
- The query is read-heavy.

**Avoid / reconsider when:**
- The table is small (a full scan is already cheap).
- The column has **low cardinality** (boolean, enum with 2–3 values).
- The table is extremely **write-heavy** and the index isn't needed for reads.
- The column is rarely queried.

**Composite index rule of thumb:** put the **most selective / most-frequently-filtered, equality column first**, range columns last (because a range stops the index from being usable for columns after it).

---

## 9. Things that silently kill an index ("index not used")

Even if an index exists, the query may ignore it if:

- You apply a **function** to the column: `WHERE YEAR(created_at) = 2024` → index on `created_at` unused. Rewrite as a range instead.
- **Leading wildcard** `LIKE '%abc'` → can't use the sorted order. `LIKE 'abc%'` is fine.
- **Implicit type conversion** (comparing a string column to a number).
- **Low selectivity** — the optimizer decides a scan is cheaper.
- You filter on a **non-leftmost** column of a composite index.

---

## 10. Quick-fire interview answers

- **What is an index?** A sorted auxiliary structure mapping column values to row locations, enabling fast lookups instead of full scans.
- **Default data structure?** B+ Tree.
- **B-Tree vs Hash?** B-Tree → equality + ranges + sorting. Hash → only equality, O(1).
- **Clustered vs non-clustered?** Clustered defines physical row order (one per table, rows live in the leaves); non-clustered is separate and points to rows (many allowed).
- **Downside of indexes?** Slower writes, more storage, maintenance cost.
- **Covering index?** An index containing all columns a query needs, answered without touching the table.
- **Composite index order?** Leftmost-prefix rule; most selective / equality columns first, range columns last.
- **Why B+ Tree over binary tree for disks?** High fan-out → shallow tree → fewer page I/Os.
- **Why won't my index get used?** Function on the column, leading `%` wildcard, type mismatch, low selectivity, or non-leftmost composite column.

---

## TL;DR

An **index** is a sorted shortcut (usually a **B+ Tree**) that turns a slow full-table scan into a fast targeted lookup. You get **faster reads** in exchange for **slower writes and extra storage**. Know **B+ Tree vs Hash**, **clustered vs non-clustered**, **composite leftmost-prefix**, **covering indexes**, and **selectivity** — that covers ~90% of interview questions.
