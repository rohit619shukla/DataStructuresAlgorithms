

//class Graph
//{
//    private int v;
//    private List<int>[] adj;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new List<int>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int>();
//        }
//    }

//    public void AddEdge(int source, int destination)
//    {
//        adj[source].Add(destination);
//        adj[destination].Add(source);
//    }

//    public bool Solve()
//    {
//        int[] explored = new int[v];
//        int[] parent = new int[v];

//        for (int i = 0; i < v; i++)
//        {
//            if (explored[i] == 0)
//            {
//                if (DFS(i, explored, parent))
//                {
//                    return true;
//                }
//            }

//        }

//        return false;
//    }

//    private bool DFS(int node, int[] explored, int[] parent)
//    {
//        explored[node] = 1;

//        foreach (var neigh in adj[node])
//        {
//            if (explored[neigh] == 0)
//            {
//                parent[neigh] = node;
//                if (DFS(neigh, explored, parent))
//                {
//                    return true;
//                }
//            }
//            else if (neigh != parent[node])
//            {
//                return true;
//            }
//        }

//        return false;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5);

//        g.AddEdge(1, 0);
//        g.AddEdge(0, 2);
//        g.AddEdge(2, 1);
//        g.AddEdge(0, 3);
//        g.AddEdge(3, 4);

//        if (g.Solve())
//        {
//            Console.WriteLine("contains cycle");
//        }
//        else
//        {
//            Console.WriteLine("does not contains cycle");
//        }
//    }
//}

//// Complexity : O(V+E)
