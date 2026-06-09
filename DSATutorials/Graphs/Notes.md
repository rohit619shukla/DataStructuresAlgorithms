# Graph Notes for Interview Preparation

## ALGORITHM NOTES

1. Dijkstra's Algorithm:
   - If a -ve edge is there we may lose the O(ELogV) time and might turn into exponential.
     It will see a -ve edge node and start processing again which is not efficient.
   - Uses: Priority Queue (Min-Heap) + Relaxation.
   - Cannot handle negative weights → use Bellman-Ford instead.

2. Bellman-Ford:
   - Does not matter if a -ve edge is there or how many, it will only work for V-1 iterations.
   - Detects negative weight cycles (if relaxation possible after V-1 iterations → cycle exists).
   - Time: O(V*E).

3. Prim's (MST):
   - The moment you pop a node, mark it visited — we are trying to be absolutely connected to its neighbors.
   - Greedy approach: always pick minimum weight edge connecting visited to unvisited.
   - Time: O(ELogV) with priority queue.

4. Kruskal's (MST):
   - Sort all edges by weight, then consider only V-1 edges using Union-Find to ensure no cycle.
   - Time: O(ELogE) for sorting + O(E * α(V)) for union-find.

5. Topological Sort:
   - Given directed graph with edges u → v, means u always comes before v.
   - BFS (Kahn's): If no node has indegree 0 → cycle exists. Or if count of processed nodes ≠ total nodes → cycle.
   - DFS: Use visited + path-visited arrays; push to stack on backtrack.

## INTERVIEW PATTERNS & TRICKS

6. Keyword "Shortest" → Dijkstra is likely hidden somewhere.
   - Unweighted graph shortest path → BFS is sufficient.
   - Weighted graph → Dijkstra.
   - Negative weights → Bellman-Ford.
   - Limited stops/edges → Bellman-Ford (e.g., Cheapest Flight with K stops).

7. Complete Connected Components: DFS with n*(n-1)/2 == edges/2.

8. Cycle Detection:
   - Undirected: BFS/DFS — if neighbor is visited and not parent → cycle.
   - Directed: DFS with path-visited array — if node is in current path → cycle.
   - Directed (BFS): Kahn's algorithm — if topo sort doesn't include all nodes → cycle.

9. Multi-source BFS Pattern:
   - Push ALL sources into queue at once (e.g., Rotten Oranges, 01 Matrix, Number of Enclaves).
   - Think of it as "fire spreading from multiple points simultaneously."

10. Disjoint Set (Union-Find):
    - Use for: connected components, redundant connections, account merge, stones removal.
    - Always implement with Path Compression + Union by Rank for near O(1) operations.
    - Key insight: If two nodes share same parent → adding edge between them creates a cycle.

11. Bridges & Articulation Points (Low-High / Tarjan's):
    - Track discovery time and lowest reachable ancestor.
    - Bridge: edge (u,v) where low[v] > disc[u] (no back edge bypasses this edge).
    - Articulation Point: node u where low[v] >= disc[u] for any child v.
    - Used in: network reliability, critical connections problems.

12. Strongly Connected Components (Kosaraju's):
    - Step 1: DFS and push to stack by finish time.
    - Step 2: Transpose the graph.
    - Step 3: DFS on transposed graph in stack order → each DFS gives one SCC.

## COMMON INTERVIEW QUESTIONS BY CATEGORY

13. Traversal-based: Number of Islands, Flood Fill, Surrounded Regions, Max Area of Island.
14. Topo Sort-based: Course Schedule I & II, Alien Dictionary.
15. Shortest Path: Network Delay, Path with Min Effort, Shortest in Binary Maze.
16. Union-Find: Redundant Connections, Account Merge, Max Stones Removal.
17. Advanced: Word Ladder (BFS + level tracking), Bipartite Graph (2-coloring with BFS).

## COMPLEXITY QUICK REFERENCE

18. BFS/DFS: O(V + E) time, O(V) space.
    Dijkstra: O(ELogV) time, O(V) space.
    Bellman-Ford: O(V*E) time, O(V) space.
    Floyd-Warshall: O(V^3) time, O(V^2) space.
    Prim's: O(ELogV), Kruskal's: O(ELogE).

## REVISION ORDER (By Pattern — Each Phase Builds on the Previous)

### Phase 1: Foundations (Graph Representation & Basic Traversals)
*Learn how graphs are stored and master BFS/DFS — every graph problem uses them.*

| # | Problem | Folder |
|---|---------|--------|
| 1 | Adjacency List Representation | Concepts |
| 2 | Adjacency Matrix Representation | Concepts |
| 3 | BFS Traversal | Concepts/Algorithm |
| 4 | DFS Traversal | Concepts/Algorithm |

### Phase 2: BFS/DFS on Grids & Connected Components
*Apply traversal templates to grid-based and component problems — most common interview category.*

| # | Problem | Folder |
|---|---------|--------|
| 5 | Flood Fill | Problems/Traversals |
| 6 | Number of Islands | Problems/Traversals |
| 7 | Max Area of Island | Problems/Traversals |
| 8 | Number of Provinces | Problems/Traversals |
| 9 | Connected Components in Undirected Graph | Problems/Traversals |
| 10 | Complete Connected Component | Problems/Traversals |
| 11 | Surrounded Regions | Problems/Traversals |
| 12 | Clone Graph | Problems |

### Phase 3: Multi-Source BFS
*Push all sources at once — "fire spreading from multiple points" pattern.*

| # | Problem | Folder |
|---|---------|--------|
| 13 | Rotten Oranges | Problems/MultiDirectionTraversal |
| 14 | 01 Matrix | Problems/MultiDirectionTraversal |
| 15 | Number of Enclaves | Problems/MultiDirectionTraversal |

### Phase 4: Cycle Detection & Graph Coloring
*Detect cycles in directed/undirected graphs and learn 2-coloring (bipartite) technique.*

| # | Problem | Folder |
|---|---------|--------|
| 16 | Undirected Graph Cycle (BFS) | Problems/Traversals |
| 17 | Undirected Graph Cycle (DFS) | Problems/Traversals |
| 18 | Directed Graph Cycle (DFS) | Problems/Traversals |
| 19 | Eventual Safe States | Problems |
| 20 | Bipartite Graph (BFS) | Problems/Traversals |

### Phase 5: Topological Ordering
*Directed acyclic graphs — prerequisite/dependency ordering problems.*

| # | Problem | Folder |
|---|---------|--------|
| 21 | Topological Ordering (BFS - Kahn's) | Problems/TopoOrdering |
| 22 | Topological Ordering (DFS) | Problems/TopoOrdering |
| 23 | Course Schedule I | Problems/TopoOrdering |
| 24 | Course Schedule II | Problems/TopoOrdering |
| 25 | Alien Dictionary | Problems/TopoOrdering |

### Phase 6: Shortest Path Algorithms
*Keyword "shortest" → Dijkstra is likely hidden. Negative weights → Bellman-Ford.*

| # | Problem | Folder |
|---|---------|--------|
| 26 | Dijkstra Using Adjacency Matrix | Concepts/Algorithm |
| 27 | Dijkstra Using Priority Queue | Concepts/Algorithm |
| 28 | Bellman-Ford | Concepts/Algorithm |
| 29 | Floyd-Warshall | Concepts/Algorithm |
| 30 | Shortest Path in Undirected Graph | Problems/Shortest Paths |
| 31 | Shortest Path in Binary Maze | Problems/Shortest Paths |
| 32 | Path with Minimum Effort | Problems/Shortest Paths |
| 33 | Network Delay Time | Problems/Shortest Paths |
| 34 | Cheapest Flight within K Stops | Problems/Shortest Paths |
| 35 | City with Smallest Number of Neighbours | Problems/Shortest Paths |
| 36 | Number of Ways to Reach Destination | Problems/Shortest Paths |
| 37 | Word Ladder I | Problems/Traversals |
| 38 | Word Ladder II | Problems/Traversals |

### Phase 7: Disjoint Set (Union-Find)
*Connected components without full traversal — near O(1) with path compression + union by rank.*

| # | Problem | Folder |
|---|---------|--------|
| 39 | Disjoint Set Implementation | Problems/DisjointSet |
| 40 | Number of Provinces (Union-Find) | Problems/DisjointSet |
| 41 | Number of Operations to Make Graph Connected | Problems/DisjointSet |
| 42 | Redundant Connections | Problems/DisjointSet |
| 43 | Max Stones Removal | Problems/DisjointSet |
| 44 | Account Merge | Problems/DisjointSet |

### Phase 8: Minimum Spanning Tree
*Greedy edge/node selection — Prim's and Kruskal's.*

| # | Problem | Folder |
|---|---------|--------|
| 45 | Prim's Using Adjacency Matrix | Concepts/Algorithm |
| 46 | Prim's Using Priority Queue | Concepts/Algorithm |
| 47 | Kruskal's Algorithm | Concepts/Algorithm |
| 48 | Min Cost to Connect All Points | Problems/MST |

### Phase 9: Advanced (Tarjan's / Low-High Concept + SCC)
*Hardest problems — bridges, articulation points, and strongly connected components.*

| # | Problem | Folder |
|---|---------|--------|
| 49 | Bridges (Critical Connections) | Problems/LowHighConcept |
| 50 | Articulation Points | Problems/LowHighConcept |
| 51 | Strongly Connected Components (Kosaraju's) | Problems/LowHighConcept |
