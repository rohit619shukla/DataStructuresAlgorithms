# SQL Joins (The 4 Core Types)

## The One-Line Answer (Say This First in an Interview)

> A **JOIN** combines rows from two or more tables based on a related column between them.
> The four core joins differ only in **which non-matching rows they keep**:
> **INNER** keeps only matches, **LEFT** keeps all left rows, **RIGHT** keeps all right rows, and **FULL** keeps everything from both sides.

Everything else (CROSS JOIN, SELF JOIN, etc.) is just a variation or special case of these.

---

## Quick Comparison Table

| Join Type | Keeps Matching Rows | Keeps Unmatched LEFT | Keeps Unmatched RIGHT | NULLs Introduced? |
|-----------|:-------------------:|:--------------------:|:---------------------:|:-----------------:|
| **INNER JOIN** | ✅ | ❌ | ❌ | No |
| **LEFT (OUTER) JOIN** | ✅ | ✅ | ❌ | Yes (right cols) |
| **RIGHT (OUTER) JOIN** | ✅ | ❌ | ✅ | Yes (left cols) |
| **FULL (OUTER) JOIN** | ✅ | ✅ | ✅ | Yes (both sides) |

> 💡 `OUTER` is optional — `LEFT JOIN` ≡ `LEFT OUTER JOIN`.

---

## Visualizing With Venn Diagrams

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

## Sample Data (Used in All Examples Below)

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

## 1. INNER JOIN

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

## 2. LEFT (OUTER) JOIN

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

## 3. RIGHT (OUTER) JOIN

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

## 4. FULL (OUTER) JOIN

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

## Bonus Joins (Common Follow-Ups)

### CROSS JOIN — Cartesian product
Every row of A paired with every row of B (no `ON` clause). `m × n` rows.

```sql
SELECT e.name, d.dept_name
FROM employees e
CROSS JOIN departments d;   -- 4 × 3 = 12 rows
```
**Use:** generating combinations (e.g. all sizes × all colors).

### SELF JOIN — a table joined to itself
Used for hierarchical/related rows within one table (e.g. employee → manager).

```sql
SELECT e.name AS employee, m.name AS manager
FROM employees e
LEFT JOIN employees m
  ON e.manager_id = m.emp_id;
```

---

## INNER vs OUTER — The Mental Model

```
INNER  = intersection            (∩) — strict, only matches
OUTER  = preserve unmatched rows  — LEFT, RIGHT, or FULL decides which side(s)
```

- **LEFT/RIGHT/FULL** are all **OUTER** joins (the keyword is optional).
- The word **OUTER** literally means "keep the rows on the *outside* of the overlap."

---

## `WHERE` vs `ON` — A Classic Gotcha

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

## Common Interview Questions

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

## Key Takeaways

- **4 core joins**: INNER (matches only), LEFT (all left), RIGHT (all right), FULL (everything).
- **OUTER** = "keep unmatched rows"; the keyword is optional.
- Outer joins introduce **`NULL`s** for the unmatched side.
- The **anti-join** (`LEFT JOIN ... WHERE right.key IS NULL`) finds orphan records.
- Beware the **`ON` vs `WHERE`** trap — a right-table filter in `WHERE` cancels an outer join.
- **CROSS JOIN** = Cartesian product; **SELF JOIN** = a table joined to itself.
- **MySQL** lacks `FULL OUTER JOIN` — emulate with `UNION`.

---

*Last Updated: 2026-06-28*
