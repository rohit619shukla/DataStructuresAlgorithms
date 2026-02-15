//public class Solution
//{
//    public int NetworkDelayTime(int[][] times, int n, int k)
//    {
//        int[] distance = new int[n + 1];

//        Array.Fill(distance, int.MaxValue);

//        distance[k] = 0;

//        List<int[]>[] adjList = new List<int[]>[n + 1];

//        for (int i = 1; i <= n; i++)
//        {
//            adjList[i] = new List<int[]>();
//        }

//        foreach (int[] edge in times)
//        {
//            AddEdge(edge[0], edge[1], edge[2], adjList);
//        }

//        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

//        pq.Enqueue(k, 0);

//        int minTime = int.MinValue;

//        while (pq.Count > 0)
//        {
//            pq.TryDequeue(out int currentNode, out int cost);

//            if (cost > distance[currentNode]) continue;

//            foreach (int[] neighbor in adjList[currentNode])
//            {
//                if (cost + neighbor[1] < distance[neighbor[0]])
//                {
//                    distance[neighbor[0]] = cost + neighbor[1];
//                    pq.Enqueue(neighbor[0], distance[neighbor[0]]);
//                }
//            }
//        }


//        // Here  is the crux of the question
//        // You might be thingking in first place that we could have applied BFS , but weights wary. Hence we dont
//        // What dijikstra tends to help here is what is maxtime time among all nodes to receive signal. 
//        // Dijikstra is designed for this pupose, it helps detemine what is needed here
//        for (int i = 1; i < distance.Length; i++)
//        {
//            if (distance[i] == int.MaxValue)
//            {
//                return -1;
//            }

//            minTime = Math.Max(distance[i] , minTime);
//        }

//        return minTime;
//    }

//    private void AddEdge(int src, int dest, int cost, List<int[]>[] adjList)
//    {
//        adjList[src].Add(new int[] { dest, cost });
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] times = {
//            new int[]{ 2,1,1},
//            new int[] {2,3,1 },
//            new int[] {3,4,1 }
//        };

//        int n = 4;
//        int k = 2;

//        Solution s = new Solution();

//        Console.WriteLine($"{s.NetworkDelayTime(times, n, k)}");
//    }
//}

//// Time : Same as Dijikstra