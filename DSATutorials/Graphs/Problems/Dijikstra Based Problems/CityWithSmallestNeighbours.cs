
//class Graph
//{
//    public int v;
//    public List<int[]>[] adj;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new List<int[]>[vertices];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int[]>();
//        }
//    }

//    public void AddEdge(int source, int dest, int cost)
//    {
//        adj[source].Add(new int[] { dest, cost });
//        adj[dest].Add(new int[] { source, cost });
//    }

//    public int Solve(int[][] edges, int k)
//    {
//        // Add edges
//        for (int i = 0; i < edges.Length; i++)
//        {
//            AddEdge(edges[i][0], edges[i][1], edges[i][2]);
//        }

//        // Apply Dijikstra on every node
//        int minCostCity = -1;
//        int minCount = int.MaxValue;

//        for (int i = 0; i < v; i++)
//        {
//            Dijikstra(i, ref minCostCity, k, ref minCount);
//        }

//        return minCostCity;
//    }

//    private void Dijikstra(int startNode, ref int minCostCity, int k, ref int minCount)
//    {
//        SortedSet<int[]> pq = new SortedSet<int[]>(new DistanceComparer());

//        // Add start node to pq (node,cost)
//        pq.Add(new int[] { startNode, 0 });

//        int[] weightArray = new int[v];

//        Array.Fill(weightArray, int.MaxValue);

//        weightArray[startNode] = 0;

//        while (pq.Count > 0)
//        {
//            int[] temp = pq.Min;

//            int currentNode = temp[0];
//            int currentCost = temp[1];

//            pq.Remove(temp);

//            foreach (var item in adj[currentNode])
//            {
//                int destNode = item[0];
//                int destCost = item[1];

//                if (currentCost + destCost < weightArray[destNode])
//                {
//                    weightArray[destNode] = currentCost + destCost;

//                    pq.Add(new int[] { destNode, weightArray[destNode] });
//                }
//            }
//        }

//        int count = 0;
//        for (int i = 0; i < v; i++)
//        {
//            if (startNode != i)
//            {
//                if (weightArray[i] <= k)
//                {
//                    count++;
//                }
//            }
//        }

//        if (count < minCount)
//        {
//            minCostCity = startNode;
//            minCount = count;
//        }
//        else if (count == minCount)
//        {
//            if (minCostCity < startNode)
//            {
//                minCostCity = startNode;
//                minCount = count;
//            }
//        }
//    }
//}

//internal class DistanceComparer : IComparer<int[]>
//{
//    public int Compare(int[] n1, int[] n2)
//    {
//        if (n1[1] != n2[1])
//        {
//            return n1[1] - n2[1];
//        }
//        else
//        {
//            return n1[0] - n2[0];
//        }
//    }
//}

//public class Solution
//{
//    public int FindTheCity(int n, int[][] edges, int distanceThreshold)
//    {
//        Graph g = new Graph(n);

//        return g.Solve(edges, distanceThreshold);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] edges = new int[][] {
//                    new int[] {0,1,10 },
//                    new int[] {0,2,1},
//                    new int[] { 2,3,1 },
//                    new int[] { 1,3,1 },
//                     new int[] { 1,4,1 },
//                      new int[] { 4, 5, 10 }
//                };

//        int n = 6;
//        int distanceThreshold = 20;

//        Solution s = new Solution();
//        Console.WriteLine(s.FindTheCity(n, edges, distanceThreshold));
//    }
//}

//// Time : O(n * (V + E) log V) + O(n^2) 
//// the inner loop is overshadowed by Dijikstra