# Google DSA Prep Sheet — Topic-Ordered

Pattern-first roadmap arranged in **your study sequence**. ~180 core problems give the coverage of 500+ LeetCode, because the rest are re-skins of the same templates. Goal: **recognize the pattern in ~30 seconds, then execute cleanly.**

**Two-pass method:** (1) Coverage — solve 2–3 per pattern, extract the template. (2) Depth — re-solve cold, add follow-ups + edge cases (the actual Google bar).

Priority: 🔴 Tier 1 (Google loves) · 🟡 Tier 2 (must be fluent) · 🟢 Tier 3 (know it, lower frequency).

---

## 1. BitManipulation

| Pattern | Problems | Pri |
|---------|----------|-----|
| Bit tricks (XOR, masks, count bits) | 136, 137, 191, 268, 338, 260 | 🟢 |

## 2. Array

| Pattern | Problems | Pri |
|---------|----------|-----|
| Two Pointers | 11, 15, 16, 42, 680, 167 | 🟡 |
| Sliding Window | 3, 76, 209, 424, 567, 992 | 🟡 |
| Prefix Sum / Running Sum | 303, 560, 974, 523, 930, 724 | 🟢 |
| Difference Array / Range Updates | 370, 1094, 1109, 1893, 2381, 1943 | 🟢 |

## 3. String

| Pattern | Problems | Pri |
|---------|----------|-----|
| Palindrome / Two-Pointer on strings | 5, 125, 647, 680, 28, 151 | 🟡 |
| Window on strings (anagram/substring) | 438, 76, 424, 567, 3, 30 | 🟡 |

## 4. Hashing

| Pattern | Problems | Pri |
|---------|----------|-----|
| Frequency Maps / Grouping | 1, 49, 128, 347, 242, 560 | 🟢 |

## 5. Searching

| Pattern | Problems | Pri |
|---------|----------|-----|
| Binary Search on Sorted Data | 33, 34, 153, 162, 4, 704 | 🟢 |
| Binary Search on Answer ("min/max feasible X") | 875, 1011, 410, 1231, 774, 1482 | 🔴 |

## 6. Sorting

| Pattern | Problems | Pri |
|---------|----------|-----|
| Intervals (merge/overlap) | 56, 57, 253, 435, 452, 1235 | 🔴 |
| Greedy Scheduling / Sorting | 45, 55, 621, 763, 134, 406 | 🟢 |

## 7. Stacks

| Pattern | Problems | Pri |
|---------|----------|-----|
| Monotonic Stack | 739, 84, 85, 496, 907, 402 | 🟡 |

## 8. Queues

| Pattern | Problems | Pri |
|---------|----------|-----|
| Monotonic Queue / Deque | 239, 862, 1425, 1696, 1499, 1438 | 🟡 |

## 9. Matrix

| Pattern | Problems | Pri |
|---------|----------|-----|
| Traversal (spiral/rotate/in-place) | 48, 54, 59, 73, 289, 361 | 🟡 |
| Grid BFS/DFS (flood-fill) → see Graph | 200, 695, 733, 994, 1091, 1254 | 🔴 |
| Grid DP → see DP | 62, 64, 221, 931, 174, 1277 | 🟡 |

## 10. LinkedList

| Pattern | Problems | Pri |
|---------|----------|-----|
| List Manipulation (reverse/merge/copy) | 21, 23, 25, 24, 138, 92 | 🟢 |
| Fast / Slow Pointers | 141, 142, 19, 234, 160, 287 | 🟢 |

## 11. Trees

| Pattern | Problems | Pri |
|---------|----------|-----|
| Tree DFS (path/recursion) | 104, 124, 543, 236, 113, 1372 | 🟡 |
| Tree BFS / Level Order | 102, 199, 116, 314, 987, 863 | 🟡 |
| BST Problems | 98, 230, 235, 99, 450, 700 | 🟢 |

## 12. Heaps

| Pattern | Problems | Pri |
|---------|----------|-----|
| Heap / Top-K / Merge | 215, 347, 692, 973, 295, 23 | 🟡 |

## 13. Tries

| Pattern | Problems | Pri |
|---------|----------|-----|
| Trie (prefix tree) | 208, 211, 212, 642, 648, 1268 | 🔴 |

## 14. Graph

| Pattern | Problems | Pri |
|---------|----------|-----|
| Graph BFS / DFS | 200, 695, 733, 994, 1091, 1254 | 🔴 |
| Topological Sort / DAG | 207, 210, 802, 269, 310, 2115 | 🔴 |
| Union Find / DSU | 547, 684, 721, 947, 990, 1202 | 🔴 |
| Shortest Path (Dijkstra/BFS) | 743, 787, 1631, 1102, 1368, 1976 | 🔴 |
| MST / Graph Greedy | 1584, 1135, 1168, 1489, 778, 1102 | 🟢 |

## 15. Recursion

| Pattern | Problems | Pri |
|---------|----------|-----|
| Backtracking Basics | 46, 47, 78, 39, 77, 90 | 🟡 |
| Backtracking with Constraints | 40, 17, 79, 131, 51, 212 | 🔴 |

## 16. DP

| Pattern | Problems | Pri |
|---------|----------|-----|
| 1D DP Basics | 70, 198, 300, 322, 91, 139 | 🟡 |
| Knapsack / Subset DP | 416, 494, 518, 474, 1049, 879 | 🔴 |
| Grid DP | 62, 64, 221, 931, 174, 1277 | 🟡 |
| String / Sequence DP | 1143, 72, 115, 97, 44, 10 | 🔴 |

---

## Google-specific extras (fit alongside above)

| Theme | Problems | Note |
|-------|----------|------|
| Design / Simulation | 146, 460, 155, 353, 359 | LRU/LFU asked often (Hashing + LinkedList) |
| Hard Graph/DP Combos | 329, 1349, 1483 | senior-level (Graph + DP) |
| Math / Geometry | 149, 356, 391, 843 | occasional but distinctive |

## How Google evaluates (beyond the sheet)

1. **Optimal from the start** + crisp Big-O for time *and* space.
2. **Follow-ups** — they mutate the problem ("now streaming", "now weighted"). Prep the *next* question per pattern.
3. **Clean, bug-free code** — they run/trace it. Practice on a plain doc, no autocomplete.
4. **Communication** — narrate approach → tradeoffs → code → test with edge cases.

> Rule of thumb: if you can name the pattern within ~30 seconds of reading a new problem, the sheet has done its job — no need for 500+.
