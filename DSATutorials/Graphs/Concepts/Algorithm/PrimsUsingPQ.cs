

//class Graph
//{
//    private int v;
//    private List<(int, int)>[] adj;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new List<(int, int)>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<(int, int)>();
//        }
//    }

//    public void AddEdge(int source, int destination, int weight)
//    {
//        adj[source].Add((destination, weight));
//        adj[destination].Add((source, weight));
//    }


//    public void Solve(int startNode)
//    {
//        int[] parent = new int[v];
//        int[] weight = new int[v];
//        int[] visited = new int[v];

//        for (int i = 0; i < v; i++)
//        {
//            weight[i] = int.MaxValue;
//        }

//        weight[startNode] = 0;

//        // Create a min heap
//        SortedSet<int[]> pq = new SortedSet<int[]>(new DistanceComparer());

//        // Add start node to heap
//        pq.Add(new int[] { startNode, 0 });

//        // V
//        while (pq.Count > 0)
//        {
//            int[] nodeArr = pq.Min;

//            // get the min node
//            int node = nodeArr[0];

//            // Log E
//            pq.Remove(nodeArr);

//            if (visited[node] == 1)
//            {
//                continue;
//            }

//            // mark the node as visited
//            visited[node] = 1;

//            // explore adjacent nodes
//            // E Log E
//            foreach (var neigh in adj[node])
//            {
//                int destNode = neigh.Item1;
//                int destCost = neigh.Item2;

//                if (visited[destNode] == 0)
//                {
//                    if (destCost < weight[destNode])
//                    {
//                        weight[destNode] = destCost;
//                        parent[destNode] = node;
//                        pq.Add(new int[] { destNode, weight[destNode] });
//                    }
//                }
//            }
//        }

//        for (int i = 0; i < v; i++)
//        {
//            Console.WriteLine($"{parent[i]} to {i} : {weight[i]}");
//        }
//    }
//}

//internal class DistanceComparer : IComparer<int[]>
//{
//    public int Compare(int[] x, int[] y)
//    {
//        return x[1] - y[1];
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5);

//        g.AddEdge(0, 1, 4);
//        g.AddEdge(0, 2, 8);
//        g.AddEdge(1, 3, 6);
//        g.AddEdge(1, 2, 2);
//        g.AddEdge(2, 3, 3);
//        g.AddEdge(2, 4, 9);
//        g.AddEdge(3, 4, 5);

//        g.Solve(0);
//    }
//}

//// Complexity : O(v LogE + E LogE) => O(V+E)LogE