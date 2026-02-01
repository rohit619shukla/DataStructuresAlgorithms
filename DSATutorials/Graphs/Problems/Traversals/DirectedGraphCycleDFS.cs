//class Solution
//{
//    public bool isCyclic(int V, int[,] edges)
//    {
//        int[] visited = new int[V];
//        int[] pathVisited = new int[V];

//        List<int>[] adj = new List<int>[V];

//        for (int i = 0; i < V; i++)
//        {
//            adj[i] = new List<int>();
//        }

//        for (int i = 0; i < edges.GetLength(0); i++)
//        {
//            AddEdges(edges[i, 0], edges[i, 1], adj);
//        }

//        // Apply DFS
//        for (int i = 0; i < V; i++)
//        {
//            if (visited[i] == 0)
//            {
//                if (DFS(i, visited, pathVisited, adj))
//                {
//                    return true;
//                }
//            }
//        }

//        return false;
//    }

//    private bool DFS(int startNode, int[] visited, int[] pathVisisted, List<int>[] adj)
//    {
//        visited[startNode] = 1;

//        pathVisisted[startNode] = 1;

//        foreach (int neigh in adj[startNode])
//        {
//            if (visited[neigh] == 0)
//            {
//                if (DFS(neigh, visited, pathVisisted, adj))
//                {
//                    return true;
//                }
//            }
//            else if (pathVisisted[neigh] == 1)
//            {
//                return true;
//            }
//        }

//        pathVisisted[startNode] = 0;

//        return false;
//    }

//    private void AddEdges(int source, int dest, List<int>[] adj)
//    {
//        adj[source].Add(dest);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[,] edges = {
//            { 0,1},
//            { 1,2},
//            { 2,0},
//            { 2,3}
//        };

//        Solution s = new Solution();

//        Console.WriteLine($"{s.isCyclic(4, edges)}");
//    }
//}

//// Complexity : O(V+E)