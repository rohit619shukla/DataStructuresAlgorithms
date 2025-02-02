
//class Graph
//{
//    private int v;
//    private List<int[]>[] adj;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new List<int[]>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int[]>();
//        }
//    }

//    public void AddEdge(int source, int destination, int weight)
//    {
//        adj[source].Add(new int[] { destination, weight });
//        adj[destination].Add(new int[] { source, weight });
//    }

//    public void Solve(int startNode)
//    {
//        int[] parent = new int[v];
//        int[] distance = new int[v];

//        for (int i = 0; i < v; i++)
//        {
//            parent[i] = -1;
//            distance[i] = int.MaxValue;
//        }

//        SortedSet<int[]> pq = new SortedSet<int[]>(new DistanceComparer());

//        pq.Add(new int[] { startNode, 0 });
//        distance[startNode] = 0;

//        while (pq.Count > 0)
//        {
//            int[] nodeArr = pq.Min;
//            int currNode = nodeArr[0];

//            pq.Remove(nodeArr);

//            foreach (var neigh in adj[currNode])
//            {
//                int destNode = neigh[0];
//                int destWeight = neigh[1];

//                if (distance[currNode] + destWeight < distance[destNode])
//                {
//                    distance[destNode] = distance[currNode] + destWeight;
//                    parent[destNode] = currNode;
//                    pq.Add(new int[] { destNode, distance[destNode] });
//                }
//            }

//        }

//        for (int i = 0; i < v; i++)
//        {
//            Console.WriteLine($"From {startNode} to {i}  the cost is : {distance[i]}");
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
//        g.AddEdge(1, 2, 2);
//        g.AddEdge(1, 3, 5);
//        g.AddEdge(2, 3, 5);
//        g.AddEdge(2, 4, 9);
//        g.AddEdge(3, 4, 4);

//        g.Solve(0);
//    }
//}


//// Complexity : O(VLogV + OELogV) = > O((V+E) LogV)