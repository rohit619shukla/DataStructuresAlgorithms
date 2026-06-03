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
