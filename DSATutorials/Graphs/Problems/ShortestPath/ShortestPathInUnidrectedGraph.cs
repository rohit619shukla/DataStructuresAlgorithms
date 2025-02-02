
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

//    public void AddEdge(int source, int dest)
//    {
//        adj[source].Add(dest);
//        adj[dest].Add(source);
//    }

//    public void Solve(int source)
//    {
//        // Here we will only apply simple BFS with Dijkstra algorithm
//        Queue<(int, int)> q = new Queue<(int, int)>();

//        int[] distance = new int[v];

//        // Initial configuration
//        Array.Fill(distance, int.MaxValue);

//        distance[source] = 0;

//        q.Enqueue((source, 0));

//        while (q.Count > 0)
//        {
//            (int currNode, int dist) = q.Dequeue();

//            foreach (var neigh in adj[currNode])
//            {
//                if (dist + 1 < distance[neigh])
//                {
//                    distance[neigh] = dist + 1;
//                    q.Enqueue((neigh, distance[neigh]));
//                }
//            }
//        }

//        for (int i = 0; i < v; i++)
//        {
//            Console.WriteLine($" From souce :{source} to destination is: {distance[i]}");
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(9);

//        g.AddEdge(0, 1);
//        g.AddEdge(0, 3);
//        g.AddEdge(3, 4);
//        g.AddEdge(4, 5);
//        g.AddEdge(5, 6);
//        g.AddEdge(1, 2);
//        g.AddEdge(2, 6);
//        g.AddEdge(6, 7);
//        g.AddEdge(7, 8);
//        g.AddEdge(6, 8);

//        g.Solve(0);
//    }
//}

//// Time : O(V+E)