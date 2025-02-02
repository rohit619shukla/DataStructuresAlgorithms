

//class Graph
//{
//    public int v;
//    public List<int>[] adj;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new List<int>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int>();
//        }
//    }

//    public void AddEdge(int src, int dest)
//    {
//        adj[src].Add(dest);
//        adj[dest].Add(src);
//    }
//}

//public class Solution
//{
//    public bool IsBipartite(int[][] graph)
//    {
//        Graph g = new Graph(graph.Length);

//        int[] color = new int[g.v];

//        Array.Fill(color, -1);

//        // Add Edges
//        for (int i = 0; i < graph.Length; i++)
//        {
//            for (int j = 0; j < graph[i].Length; j++)
//            {
//                g.AddEdge(i, graph[i][j]);

//            }
//        }

//        for (int i = 0; i < g.v; i++)
//        {
//            if (color[i] == -1)
//            {
//                if (!BFS(color, i, g.adj))
//                {
//                    return false;
//                }
//            }
//        }

//        return true;
//    }

//    private bool BFS(int[] color, int node, List<int>[] adj)
//    {
//        Queue<int> q = new Queue<int>();
//        q.Enqueue(node);

//        color[node] = 0;

//        while (q.Count > 0)
//        {
//            int source = q.Dequeue();

//            foreach (var neigh in adj[source])
//            {
//                if (color[neigh] == -1)
//                {
//                    color[neigh] = (color[source] == 0) ? 1 : 0;
//                    q.Enqueue(neigh);
//                }
//                else if (color[neigh] == color[source])
//                {
//                    return false;
//                }
//            }
//        }

//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        int[][] graph = new int[][]
//        {
//                    new int[] {1, 2,3},
//                    new int[] {0,3,4},
//                    new int[] {0,3},
//                    new int[] {0,1,2},
//                     new int[] {0},

//        };

//        Console.WriteLine(s.IsBipartite(graph));
//    }
//}

//// Time : (V+E), space : O(V+E)