

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
//    }


//    public void TopologicalSort()
//    {
//        Queue<int> q = new Queue<int>();

//        // Create an indegree array
//        int[] indegree = new int[v];

//        for (int i = 0; i < v; i++)
//        {
//            foreach (var neigh in adj[i])
//            {
//                indegree[neigh]++;
//            }
//        }

//        // put all nodes with indegree 0 in queue
//        for (int i = 0; i < indegree.Length; i++)
//        {
//            if (indegree[i] == 0)
//            {
//                q.Enqueue(i);
//            }
//        }

//        // start BFS for all nodes with indegree 0 and present in queue

//        while (q.Count > 0)
//        {
//            int node = q.Dequeue();

//            Console.Write($"{node}" + " ");
//            // Explore its adjacent edges
//            foreach (var neigh in adj[node])
//            {
//                indegree[neigh]--;

//                if (indegree[neigh] == 0)
//                {
//                    q.Enqueue(neigh);
//                }
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(6);
//        g.AddEdge(5, 2);
//        g.AddEdge(5, 0);
//        g.AddEdge(4, 0);
//        g.AddEdge(4, 1);
//        g.AddEdge(2, 3);
//        g.AddEdge(3, 1);

//        Console.WriteLine(
//          "Following is a Topological Sort of");
//        g.TopologicalSort();
//    }
//}

////Time Complexity: O(V + E).