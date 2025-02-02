

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

//    public bool IsCyclic()
//    {
//        int[] explored = new int[v];

//        // We dont know where the cycle will start
//        for (int i = 0; i < v; i++)
//        {
//            // if the node has not been visited yet
//            if (explored[i] == 0)
//            {
//                if (BFS(i, explored))
//                {
//                    return true;
//                }
//            }
//        }

//        return false;
//    }

//    private bool BFS(int node, int[] explored)
//    {
//        // We will store the node and its parent
//        Queue<(int, int)> q = new Queue<(int, int)>();

//        explored[node] = 1;
//        q.Enqueue((node, -1));


//        while (q.Count > 0)
//        {
//            (int currNode, int nodesParent) = q.Dequeue();

//            // start exploring the adjacent nodes
//            foreach (var neigh in adj[currNode])
//            {
//                if (explored[neigh] == 0)
//                {
//                    explored[neigh] = 1;
//                    q.Enqueue((neigh, currNode));
//                }
//                else if (neigh != nodesParent)
//                {
//                    // if the node is visited but is not the parent of the given node we have a cycle
//                    return true;
//                }
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

//        if (g.IsCyclic())
//        {
//            Console.WriteLine("Graph contains cycle");
//        }
//        else
//        {
//            Console.WriteLine("Graph does not contains cycle");
//        }
//    }
//}

//// Complexity : O(V+E)