
//class Graph
//{
//    public int v;
//    public List<int[]>[] adj;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new List<int[]>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int[]>();
//        }
//    }

//    public void AddEdge(int source, int dest, int cost)
//    {
//        adj[source].Add(new int[] { dest, cost });
//    }
//    public int Solve(int[][] flights, int src, int dst, int k)
//    {
//        for (int i = 0; i < v; i++)
//        {
//            AddEdge(flights[i][0], flights[i][1], flights[i][2]);
//        }

//        Queue<(int, int, int)> q = new Queue<(int, int, int)>();

//        q.Enqueue((src, 0, 0));

//        int[] weightArray = new int[v];

//        Array.Fill(weightArray, int.MaxValue);

//        weightArray[src] = 0;

//        while (q.Count > 0)
//        {
//            (int currentNode, int currentCost, int currentHops) = q.Dequeue();

//            if (currentHops > k)
//            {
//                continue;
//            }

//            foreach (var item in adj[currentNode])
//            {
//                int destNode = item[0];
//                int destCost = item[1];

//                if (currentCost + destCost < weightArray[destNode])
//                {
//                    weightArray[destNode] = weightArray[currentNode] + destCost;
//                    q.Enqueue((destNode, destCost, currentHops + 1));
//                }
//            }
//        }

//        return weightArray[dst] != int.MaxValue ? weightArray[dst] : -1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] flights = new int[][] {
//                                    new int[] { 0,1,100},
//                                    new int[] {1,2,100 },
//                                    new int[] {2,0,100},
//                                    new int[] {1,3,600},
//                                    new int[] {2,3,200}
//        };

//        int n = 4;
//        int src = 0;
//        int dst = 3;
//        int k = 1;

//        Graph g = new Graph(n);

//        Console.WriteLine(g.Solve(flights, src, dst, k));
//    }
//}

//// Time : O(V+E)
//// We are not using PQ with Dij becoz, with that we might get less cost path but with more hops,
//// while with non PQ rather going by queue we may find path with bit more cost but with controlled hops
//// The reason why we are not adding visited array here is due to fact we may arrive at a node multiple time with less hops and cost