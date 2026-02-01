
//class Solution
//{

//    public bool isCycle(int v, int[,] edges)
//    {
//        int[] visited = new int[v];
//        int[] parent = new int[v];

//        for (int i = 0; i < v; i++)
//        {
//            parent[i] = i;
//        }

//        List<int>[] adj = new List<int>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int>();
//        }

//        for (int i = 0; i < edges.GetLength(0); i++)
//        {
//            AddEdges(edges[i, 0], edges[i, 1], adj);
//        }

//        for (int i = 0; i < v; i++)
//        {
//            // For discosnnected components
//            if (visited[i] == 0)
//            {
//                if (BFS(i, visited, parent, adj))
//                {
//                    return true;
//                }
//            }
//        }

//        return false;
//    }

//    private bool BFS(int startNode, int[] visited, int[] parent, List<int>[] adj)
//    {
//        Queue<int> q = new Queue<int>();
//        q.Enqueue(startNode);
//        visited[startNode] = 1;

//        while (q.Count > 0)
//        {
//            int node = q.Dequeue();

//            foreach (var neigh in adj[node])
//            {
//                if (visited[neigh] == 0)
//                {
//                    q.Enqueue(neigh);
//                    visited[neigh] = 1;
//                    parent[neigh] = node;
//                }
//                else if (parent[node] != neigh)
//                {
//                    return true;
//                }
//            }
//        }
//        return false;
//    }

//    private void AddEdges(int source, int dest, List<int>[] adj)
//    {
//        adj[source].Add(dest);
//        adj[dest].Add(source);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[,] adj = {
//            {0,1 },
//            { 0,2},
//            { 1,2},
//            { 2,3}
//        };

//        Solution s = new Solution();

//        Console.WriteLine($"{s.isCycle(4, adj)}");
//    }
//}

//// Complexity : O(V+E)