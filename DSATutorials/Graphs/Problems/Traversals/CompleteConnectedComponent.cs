//using System.Xml.Linq;

//class Solution
//{
//    public int CountCompleteComponents(int n, int[][] edges)
//    {
//        // Step 1 : Create a visited array
//        bool[] visited = new bool[n];

//        // Step 2 : Create adj list
//        List<int>[] adjList = new List<int>[n];

//        for (int i = 0; i < n; i++)
//        {
//            adjList[i] = new List<int>();
//        }

//        // Step 3 : Add to list
//        foreach (var edge in edges)
//        {
//            AddEdge(edge[0], edge[1], adjList);
//        }


//        int count = 0;

//        // Step 4 : A complete connected component means every node is connected to every other node.
//        // For n nodes, each node connects to (n-1) others = n*(n-1) connections.
//        // Since each edge is shared by 2 nodes, unique edges = n*(n-1)/2 (this is nC2 - choosing 2 nodes from n).
//        // Example: 3 nodes need 3*2/2 = 3 edges (0-1, 0-2, 1-2) to be complete.
//        // We use DFS to find actual nodeCount and edgeCount per component, then verify against this formula.

//        for (int i = 0; i < n; i++)
//        {
//            if (visited[i] == false)
//            {
//                int edgeCount = 0;
//                int nodeCount = 0;
//                DFS(i, visited, adjList, ref edgeCount, ref nodeCount);

//                // edgeCount is divided by 2 because in an undirected adjacency list, each edge is stored twice (A->B and B->A)
//                if ((nodeCount * (nodeCount - 1)) / 2 == edgeCount / 2)
//                {
//                    count++;
//                }
//            }
//        }

//        return count;
//    }

//    private void AddEdge(int src, int dest, List<int>[] adjList)
//    {
//        adjList[src].Add(dest);
//        adjList[dest].Add(src);
//    }
//    private void DFS(int node, bool[] visited, List<int>[] adjList, ref int edgeCount, ref int nodeCount)
//    {
//        visited[node] = true;
//        edgeCount += adjList[node].Count;
//        nodeCount += 1;

//        foreach (var neighbors in adjList[node])
//        {
//            if (visited[neighbors] == false)
//            {
//                DFS(neighbors, visited, adjList, ref edgeCount, ref nodeCount);
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int n = 6;

//        int[][] edges = {
//            new int[] { 0,1},
//            new int[] { 0,2},
//            new int[] { 1,2},
//            new int[] { 3,4},
//            //new int[] { 3,5}
//        };

//        Solution s = new Solution();

//        Console.WriteLine($"{s.CountCompleteComponents(n, edges)}");
//    }
//}

////O(V + E)