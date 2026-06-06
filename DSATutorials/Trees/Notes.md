# Tree Data Structure Notes for Interview Preparation

## FUNDAMENTALS

1. Binary Tree Basics:
   - Each node has at most two children (left and right).
   - A node with no children is called a leaf node.
   - The topmost node is called the root.
   - Height of tree = longest path from root to leaf.
   - Number of nodes in complete binary tree of height h: 2^(h+1) - 1.

2. Binary Search Tree (BST):
   - Left subtree contains nodes with values LESS than the parent.
   - Right subtree contains nodes with values GREATER than the parent.
   - Inorder traversal of BST gives SORTED order (this is key for many BST problems).
   - Balanced BST: height = O(log n), unbalanced: height = O(n).

3. Tree Traversals:
   - Inorder (Left, Root, Right) — gives sorted order for BST.
   - Preorder (Root, Left, Right) — used for serialization, tree construction.
   - Postorder (Left, Right, Root) — used for deletion, bottom-up computation.
   - Level Order (BFS using queue) — for level-wise problems.
   - Morris Traversal — O(1) space using threaded binary tree concept.

## KEY PATTERN: HEIGHT OF BINARY TREE (Foundation for Many Problems)

4. The height calculation pattern is a foundational building block reused across problems:
   - Core idea: recursively compute max(leftHeight, rightHeight) + 1
   - Diameter of Tree → left height + right height at each node, track max.
   - Check Balanced Binary Tree → if abs(leftH - rightH) > 1 at any node, return false.
   - Minimum Depth → min(leftH, rightH) + 1 (handle single-child nodes carefully!).
   - Maximum Width / Level Order → height helps determine total levels.
   - Bottom View / Top View → height/level used for vertical distance tracking.
   - Pattern: Compute height BUT also carry extra info (diameter, balance flag, etc.) during the same traversal. This avoids O(n^2) by not recomputing height at each node.

## INTERVIEW PATTERNS & TECHNIQUES

5. DFS Patterns (Recursion/Stack):
   - Top-Down: pass information FROM root TO leaves (e.g., path sum, root-to-leaf paths).
   - Bottom-Up: return information FROM leaves TO root (e.g., height, diameter, balanced).
   - Key insight: If you need info from children first → bottom-up. If parent info needed → top-down.

6. BFS Pattern (Queue):
   - Level Order: process nodes level by level using queue size.
   - Multi-source BFS: e.g., Infect Binary Tree (start BFS from target node).
   - Zigzag: alternate left-to-right and right-to-left at each level.

7. BST Property Exploitation:
   - Always think of Morris Traversal for BST-based problems — it gives O(1) space by leveraging the BST's inorder predecessor threading, avoiding recursion stack overhead.
   - Validate BST: pass min/max range down the tree.
   - Floor/Ceil: go left if current > target, go right if current < target.
   - Kth Smallest: inorder traversal with counter (stop at k).
   - BST Iterator: controlled inorder using explicit stack.
   - Two Sum in BST: BST Iterator (forward + backward) like two-pointer.

8. Lowest Common Ancestor (LCA):
   - Binary Tree: if left and right both return non-null → current node is LCA.
   - BST: if both values < current → go left; both > current → go right; else → current is LCA.
   - Time: O(n) for BT, O(h) for BST.

9. Tree Views (Top/Bottom/Left/Right):
   - Use vertical distance (horizontal distance) and level tracking.
   - Top View: first node at each horizontal distance (BFS preferred).
   - Bottom View: last node at each horizontal distance.
   - Right View: last node at each level in level-order traversal.

10. Serialize/Deserialize:
    - Use preorder with null markers for full binary tree reconstruction.
    - BST: preorder alone is sufficient (BST property defines structure).

## COMMON INTERVIEW TRICKS

11. When to use what:

| Problem Type | Approach |
| --- | --- |
| Height/Depth/Diameter/Balanced | Bottom-up DFS (postorder) |
| Path Sum / Root-to-Leaf | Top-down DFS (preorder) |
| Level-wise problems | BFS with queue |
| View problems | BFS + HashMap (HD/level) |
| BST search/insert/delete | Exploit BST property O(h) |
| Construction from traversals | Preorder + Inorder / Postorder |

12. Edge Cases to Always Consider:
   - Empty tree (null root).
   - Single node tree.
   - Skewed tree (essentially a linked list).
   - All same values (for BST problems).
   - Negative values in path sum problems.

## COMPLEXITY QUICK REFERENCE

13. Most tree operations: O(n) time, O(h) space where h = height.
    - Balanced tree: h = O(log n) → space = O(log n).
    - Skewed tree: h = O(n) → space = O(n).
    - Morris Traversal: O(n) time, O(1) space.
    - BST operations (balanced): O(log n) time.

## REVISION ORDER (By Pattern — Each Phase Builds on the Previous)

### Phase 1: Foundations (Recursion on Trees)
*Learn to think recursively on tree structures first.*

| # | Problem | Folder |
|---|---------|--------|
| 1 | Height of Binary Tree | BinaryTreeProperties |
| 2 | Minimum Depth of Binary Tree | BinaryTreeProperties |
| 3 | Check Balanced Binary Tree | BinaryTreeProperties |
| 4 | Diameter of Tree | BinaryTreeProperties |
| 5 | Check If Two Trees Are Identical | BinaryTreeProperties |
| 6 | Check If Symmetric Tree | BinaryTreeProperties |
| 7 | Invert Binary Tree | BinaryTreeProperties |

### Phase 2: BFS / Level-Order Traversal
*Master the queue-based BFS template — used in 40%+ of tree problems.*

| # | Problem | Folder |
|---|---------|--------|
| 8 | Print Levels in Binary Tree | Traversals |
| 9 | Average of Levels in Binary Tree | Traversals |
| 10 | Largest Value in Each Row | Traversals |
| 11 | ZigZag Traversal | Traversals |
| 12 | Right View | TreeViews |
| 13 | Bottom Left Value of Tree | TreeViews |
| 14 | Top View of Tree | TreeViews |
| 15 | Bottom View of Tree | TreeViews |
| 16 | Vertical Traversal | Traversals |
| 17 | Boundary Level Traversal | Traversals |

### Phase 3: DFS Path Problems
*Builds on Phase 1 recursion — now track paths & accumulate values.*

| # | Problem | Folder |
|---|---------|--------|
| 18 | Root Equals Sum of Children | PathProblems |
| 19 | Print Root to Leaf Paths | PathProblems |
| 20 | Sum Root to Leaf Numbers | PathProblems |
| 21 | Maximum Sum Path in Binary Tree | PathProblems |

### Phase 4: BST Basics
*Exploit the left < root < right property.*

| # | Problem | Folder |
|---|---------|--------|
| 22 | Search in BST | BSTOperations |
| 23 | Insert in BST | BSTOperations |
| 24 | Floor in BST | BSTOperations |
| 25 | Ceil in BST | BSTOperations |
| 26 | Delete Node in BST | BSTOperations |
| 27 | Check If Tree is BST | BSTOperations |
| 28 | LCA in BST | LowestCommonAncestor |

### Phase 5: Inorder = Sorted (BST Tricks)
*Key insight: inorder traversal of BST gives sorted order.*

| # | Problem | Folder |
|---|---------|--------|
| 29 | Kth Smallest Element | BSTOperations |
| 30 | BST Iterator | BSTOperations |
| 31 | Two Sum in BST | BSTOperations |

### Phase 6: Tree Construction & Conversion
*Build trees from scratch — needs solid recursion skills from earlier phases.*

| # | Problem | Folder |
|---|---------|--------|
| 32 | Convert Sorted Array to BST | TreeConversions |
| 33 | Construct BST from Preorder | TreeConversions |
| 34 | Construct BT from Pre + Inorder | TreeConversions |
| 35 | Construct BT from In + Postorder | TreeConversions |
| 36 | Convert BST to DLL | TreeConversions |
| 37 | Convert DLL to BST | TreeConversions |
| 38 | Serialize & Deserialize | TreeConversions |

### Phase 7: Advanced (Graph-on-Tree + Indexing)
*Hardest problems — combine multiple patterns.*

| # | Problem | Folder |
|---|---------|--------|
| 39 | LCA in Binary Tree | LowestCommonAncestor |
| 40 | Nodes at Distance K | Advanced |
| 41 | Infect Binary Tree | Advanced |
| 42 | Max Width Without Nulls | Advanced |
| 43 | Max Width With Nulls | Advanced |
