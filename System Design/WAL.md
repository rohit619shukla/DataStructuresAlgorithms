# Write-Ahead Log (WAL) — Explained From Scratch

> **Read this top to bottom. No prior knowledge needed.** Part A tells the idea as a simple story. Part B ("Going Deeper") is the precise, technically-correct model for interviews. Both say the same thing — Part B just adds detail.

---

# PART A — The Idea (Beginner Story)

## 1. The Problem (in plain words)

A database has to do two things that fight each other:

1. **Be fast** — when you save something, you don't want to wait.
2. **Never lose your data** — even if the power suddenly goes out.

The trouble is: **saving data permanently to a disk is slow.** WAL is the clever trick databases use to be *fast* AND *safe* at the same time.

Let's understand it with a story first. Forget databases for now.

---

## 2. The Bank Counter Story 🏦

Imagine **you are a bank clerk** sitting at a counter.

- Across the room, on a high shelf, sits a **huge, heavy ledger book**. It holds the official balance of every single customer. To update it you must: walk across the room, find the right page, write the new balance, and walk back. **This takes 2 whole minutes every time.**
  - 👉 This big book = the **real database stored on the disk**. Slow to reach.

- On your desk sits a small **notepad** and a pen. Scribbling one line takes **2 seconds**.
  - 👉 This notepad = the **log** (this is the "WAL").

### A customer arrives

Customer: *"Please add ₹500 to my account."*

#### ❌ The slow way (no notepad)
You get up, walk to the shelf, find the page, update the big ledger (2 min), walk back, and say "Done."
The customer **waited 2 minutes**. Now picture 100 customers in line. Total chaos.

#### ✅ The smart way (use the notepad first)
1. You quickly jot on your **notepad**: *"Account 7: add ₹500."* — **2 seconds.**
2. You immediately tell the customer **"Done!"** ✅ and call the next person.
3. **Later**, when the line dies down, you take your whole notepad to the shelf and update the big ledger for everybody **in one relaxed trip**.

The customer heard "Done!" in **2 seconds instead of 2 minutes**.

**That is the entire core idea of WAL: write a quick note now, update the real heavy book later.**

---

## 3. "But wait — what if the power goes out?" ⚡

Here's the worry: in the smart way, you said *"Done!"* but the **big ledger isn't updated yet**. What if the building loses power *right now*, before you walk to the shelf?

This is the genius part. Your **notepad is real ink on real paper.** It does **not** vanish when the lights go out.

So when power comes back:
1. You pick up your **notepad**.
2. You read every line you hadn't transferred yet (*"Account 7: add ₹500"*).
3. You finish updating the big ledger.

✅ **Nothing a customer was promised is ever lost.** Every "Done!" still comes true.

That "read the notepad after a power cut and finish the leftover work" step is called **crash recovery**.

---

## 4. Why is the notepad fast but the big book slow?

Both are "writing," so why is one fast?

- The **notepad** sits right in front of you, and you just write the **next line at the bottom**. You never flip around looking for a spot. Always one quick motion. (Computers call this a **sequential write** — fast.)
- The **big ledger** needs you to **walk across the room and hunt for the exact page** — a different far-away page for every customer. All that walking and searching is the slow part. (Computers call this a **random write** — slow, because the disk has to physically seek to scattered spots.)

> 🔑 **The whole win of WAL:** the thing you do *while the customer waits* is the fast "add a line to the notepad." The slow "walk to the shelf" is pushed to **later**, when nobody is waiting.

---

## 5. The Story → Real Database Names

| In the story | In a real database | What it really is |
|---|---|---|
| You, the clerk | The database engine | The program doing the work |
| The small **notepad** | The **WAL / log file** | A file on disk you only ever *add lines to the end of* |
| Saying **"Done!"** fast | **Commit** returns success | The user gets their confirmation |
| The huge **ledger book** | The **data files** | Where the real tables actually live on disk |
| Walking to the shelf **later** | **Checkpoint** (background) | Quietly moving the changed data into the real data files |
| Reading the notepad after a power cut | **Crash recovery** | Replaying the log to finish unsaved work |

---

# PART B — Going Deeper (The Precise Model)

This is the technically-correct version. Every point below is something people commonly get wrong — get these right and you understand WAL properly.

## 6. What actually lives in memory

- The DB does **NOT** load the whole database file into memory. It loads only the specific **page(s)** — fixed-size blocks (e.g. **8 KB** in PostgreSQL, **16 KB** in InnoDB) — that contain the row you're touching.
- These pages live in the **buffer pool** (a.k.a. shared_buffers / page cache) in RAM.
- The buffer pool is a **limited cache of the hottest pages — NOT the whole database.** A database can be 2 TB while RAM is 64 GB.

```
   DISK (data files) — the WHOLE database, e.g. 2 TB
   ┌───────────────────────────────────────────────┐
   │ page1  page2  page3  page4  ... millions ...   │
   └───────────────────────────────────────────────┘
                      ▲   │
            load page │   │ evict page (kick out)
                      │   ▼
   RAM (buffer pool) — only a SLICE, e.g. 64 GB
   ┌──────────────────────────┐
   │ page17  page4  page988   │   ← only the "currently useful" pages
   └──────────────────────────┘
```

- **Cache miss** (page not in RAM) → load it from disk.
- **Buffer pool full** → **evict** a least-recently-used page. If that page is **dirty** (changed in RAM, not yet on disk) it must be **flushed first**; a clean page can just be dropped.

## 7. Validation happens ONLY in memory, up front

The on-disk data file is **dumb storage** — it never checks anything. **100% of validation happens in memory, before the change is ever logged.**

```
1. Parse / syntax check     → on the SQL text itself (before any page is touched)
2. Resolve names            → does this table/column exist? (checks the catalog)
3. Load the page(s) into RAM (if not already cached)
4. Execute the change IN MEMORY, checking as it goes:
      • data types valid?     • NOT NULL satisfied?
      • UNIQUE / PK ok?        • FOREIGN KEY target exists?    • CHECK constraints pass?
   → if ANY check fails, reject NOW, in memory. No log record, no ack — customer gets an error.
5. Only if everything passed → write the LOG record → fsync → ACK
6. Later → flush the (already-valid) dirty page to disk
```

> Because validation is fully done in step 4, the log only ever holds **valid, already-checked** changes. The disk flush and the crash-recovery replay are pure byte copies — they trust the data blindly.

## 8. The log stores the CHANGE, not the SQL query

The WAL/redo log does **NOT** store your `UPDATE ... WHERE ...` text. It stores the **effect** — the physical change to the page:

> *"On page X, at offset Y, bytes changed from `300` to `500`."*

So on recovery the DB just **re-stamps the bytes** onto the page. It does **not** re-parse, re-run `WHERE`, or re-check constraints. That's what makes replay fast and deterministic.

## 9. The log is WRITTEN always, but READ almost never

There are two separate actions on the log:

| Action | When | How often |
|---|---|---|
| **Write to the log** | Every single insert/update/delete (then fsync on commit) | **Always** |
| **Read the log back** to rebuild data | **Only on crash recovery** | **Rarely** |

In normal running, nobody reads the log, because the freshest data is already in the **dirty page in memory** — every reader and the background flush use that RAM page. The log is **write-only** on the happy path.

> Think of the log as **insurance**: you pay the premium every write; you only make a claim (read it) when disaster (a crash) strikes.

*(Honesty note: real systems also read the log for **replication** and **point-in-time backups** — but for understanding WAL itself, the rule "always written, rarely read" holds.)*

## 10. The background worker flushes DIRTY PAGES, it does NOT read the log

This is the single most common misconception. In **normal** operation:

- The change is already in the **dirty page in RAM**.
- The background worker (**checkpointer / background writer** in PostgreSQL, **page cleaner** in InnoDB) flushes that **dirty page from RAM straight into the data file**.
- It does **NOT** read the WAL to do this.

| Situation | Who updates the data files? | Is the WAL read? |
|---|---|---|
| **Normal running** | Background flush of **dirty pages from RAM** → data files | ❌ No |
| **After a crash** | **Recovery replays the WAL** from disk onto the pages | ✅ Yes |

Also note: writing those pages to the data files is **random I/O** (each page to its own scattered home location). The **log** is the sequential one; the **data-file** writes are the random ones.

## 11. "Dirty" means the in-memory page, not the on-disk table

> **Dirty page = a page in memory whose contents were modified but not yet written back to the data file** (RAM copy is *newer* than the disk copy).

The on-disk table isn't "dirty" — it's just **stale/old** until the checkpoint flushes the page.

---

## 12. The Full Correct Lifecycle (one write, then many)

```
1st write:  validate in RAM → load page (disk→RAM) → change in RAM (dirty) → LOG + fsync → ACK
2nd write:  validate in RAM → page already in RAM    → change in RAM (dirty) → LOG + fsync → ACK
3rd write:  validate in RAM → page already in RAM    → change in RAM (dirty) → LOG + fsync → ACK
   ...
later:      background checkpoint: dirty page (RAM) ──────────────────────────► data file (disk)
            (random I/O, off the critical path; old log can then recycle)

CRASH before the flush?
   → On restart, RECOVERY reads the WAL from disk and REPLAYS the changes onto the pages.
     (The ONLY time the data files get updated *from the log*.)
```

One dirty page can absorb **many** writes in memory and be flushed **once**, later. That batching is part of why WAL is efficient.

### The key asymmetries
- **Log = written on every change. Data page = flushed lazily, once for many changes.**
- **Log = fast sequential append. Data-file writes = slow random I/O (deferred).**
- **Validation = only in memory, up front.** Everything downstream trusts it blindly.
- **Log = always written, almost never read** (read back only on crash recovery / replication / backups).
- **"Dirty" = the in-memory page**, not the on-disk table.

---

## 13. The Same Trick, Different Names

| Database | Name for the "notepad" (log) |
|---|---|
| **PostgreSQL** | Write-Ahead Log (WAL) |
| **MySQL / InnoDB** | Redo log |
| **SQL Server** | Transaction log |
| **SQLite** | WAL file |
| **MongoDB** | Journal |
| **Cassandra** | Commit log |

That's why WAL comes up for **both SQL and NoSQL** — almost all of them rely on this same idea to stay fast and safe.

---

## 14. Common Interview Questions

**Q: What is a Write-Ahead Log in one sentence?**
A: Before changing the real data files, the database writes the change to a fast append-only log and fsyncs it, so it can confirm success quickly and still recover everything after a crash.

**Q: Why is it faster if you end up writing twice (log + data)?**
A: The user only *waits* for the fast write — a sequential append to the log. The slow random write to the data files happens later in the background, when no one is waiting.

**Q: After "commit" the data file is still stale. How is that safe?**
A: The change was already fsync'd to the **log on disk** before we said "done." On crash, we replay the log. Nothing committed is lost.

**Q: Does the background worker read the log to update the tables?**
A: No. In normal running it flushes **dirty pages from memory** to the data files. The log is read **only on crash recovery**.

**Q: Does the log store my SQL query?**
A: No — it stores the **physical change** ("page X, bytes 300→500"), not the query text. Recovery re-stamps bytes; it doesn't re-run the SQL.

**Q: Is the whole database kept in memory?**
A: No. The buffer pool is a **limited cache of hot pages**; pages are loaded on demand and evicted when full (dirty ones flushed first).

**Q: What does "dirty page" mean?**
A: A page modified in memory but not yet written to the data file — the RAM copy is newer than disk.

---

## 15. Remember Just This

- **Validate in memory → change the in-memory page (now dirty) → write the log + fsync → ack.**
- **Real data files are updated later** by a background flush of **dirty pages** (not by reading the log).
- **The log is always written, almost never read** — read back only on **crash recovery**.
- **The log holds the change, not the query.** The buffer pool is a **cache, not the whole DB**.
- Everything else (PostgreSQL WAL, InnoDB redo log, ARIES, replication) is this same idea with more detail.

---

## Sources

- **PostgreSQL** — *Reliability and the Write-Ahead Log* (official docs, Ch. 30) & *WAL Configuration* (checkpointer/background writer flush dirty buffers; WAL records describe page changes).
- **SQLite** — *Write-Ahead Logging* (sqlite.org/wal.html).
- **MySQL / InnoDB** — *Redo Log* (physical change records; page-cleaner threads).
- **ARIES** — Mohan et al., *"ARIES: A Transaction Recovery Method..."*, ACM TODS, 1992 (redo-from-log on recovery).

---

*Last Updated: 2026-06-28*
