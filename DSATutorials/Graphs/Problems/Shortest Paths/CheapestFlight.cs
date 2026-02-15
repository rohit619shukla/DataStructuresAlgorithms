//public class Solution
//{
//    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
//    {
//        List<int[]>[] adjList = new List<int[]>[n];

//        for (int i = 0; i < n; i++)
//        {
//            adjList[i] = new List<int[]>();
//        }

//        for (int i = 0; i < flights.Length; i++)
//        {
//            AddEdges(flights[i][0], flights[i][1], flights[i][2], adjList);
//        }


//        int[] distance = new int[n];

//        Array.Fill(distance, int.MaxValue);

//        Queue<(int, int, int)> q = new Queue<(int, int, int)>();
//        q.Enqueue((src, 0, 0));
//        distance[src] = 0;

//        while (q.Count > 0)
//        {
//            (int currentNode, int cost, int hops) = q.Dequeue();

//            if (hops > k)
//            {
//                continue;
//            }

//            foreach (int[] neighbors in adjList[currentNode])
//            {

//                if (cost + neighbors[1] < distance[neighbors[0]])
//                {
//                    distance[neighbors[0]] = cost + neighbors[1];
//                    q.Enqueue((neighbors[0], distance[neighbors[0]], hops + 1));
//                }
//            }
//        }

//        return distance[dst] == int.MaxValue ? -1 : distance[dst];
//    }

//    private void AddEdges(int src, int dest, int cost, List<int[]>[] adjList)
//    {
//        adjList[src].Add(new int[] { dest, cost });
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] flights = new int[][] {
//                                    new int[] { 1,0,5}

//        };

//        int n = 2;
//        int src = 0;
//        int dst = 1;
//        int k = 1;

//        Solution g = new Solution();

//        Console.WriteLine(g.FindCheapestPrice(n, flights, src, dst, k));

//    }
//}


//// Time : O(V+E)
//// We are not using PQ with Dij becoz, with that we might get less cost path but with more hops,
//// while with non PQ rather going by queue we may find path with bit more cost but with controlled hops
//// The reason why we are not adding visited array here is due to fact we may arrive at a node multiple time with less hops and cost