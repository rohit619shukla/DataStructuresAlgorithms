//class Solution
//{
//    public int CountPaths(int n, int[][] roads)
//    {
//        int mod = (int)1e9 + 7;
//        List<int[]>[] adjList = new List<int[]>[n];

//        for (int i = 0; i < n; i++)
//        {
//            adjList[i] = new List<int[]>();
//        }


//        foreach (var edge in roads)
//        {
//            int src = edge[0];
//            int dest = edge[1];
//            int cost = edge[2];

//            AddEdge(src, dest, cost, adjList);
//        }

//        long[] distance = new long[n];
//        long[] count = new long[n];

//        Array.Fill(distance, long.MaxValue);

//        distance[0] = 0;

//        // Number of ways to reach 0 will 1be 1 by default
//        count[0] = 1;

//        PriorityQueue<int, long> pq = new PriorityQueue<int, long>();

//        pq.Enqueue(0, 0);

//        while (pq.Count > 0)
//        {
//            pq.TryDequeue(out int currentNode, out long cost);

//            if (cost > distance[currentNode])
//            {
//                continue;
//            }

//            foreach (int[] neighbor in adjList[currentNode])
//            {

//                if (cost + neighbor[1] < distance[neighbor[0]])
//                {
//                    distance[neighbor[0]] = cost + neighbor[1];
//                    count[neighbor[0]] = count[currentNode] % mod;
//                    pq.Enqueue(neighbor[0], distance[neighbor[0]]);
//                }
//                else if (cost + neighbor[1] == distance[neighbor[0]])
//                {
//                    // We do this because the current node's source node may also have been arrived themselves by some ways
//                    // Hence we should involve those ways too in the current path
//                    count[neighbor[0]] = (count[neighbor[0]] + count[currentNode]) % mod;
//                }
//            }
//        }

//        return (int)count[n - 1];
//    }

//    private void AddEdge(int src, int dest, int cost, List<int[]>[] adjList)
//    {
//        adjList[src].Add(new int[] { dest, cost });
//        adjList[dest].Add(new int[] { src, cost });
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        int[][] roads = new int[][] {
//        new int[] { 0,6,7},
//        new int[] {0,1,2 },
//        new int[] {1,2,3 },
//        new int[] {1,3,3 },
//        new int[] { 6,3,3},
//        new int[] {3,5,1 },
//        new int[] { 6,5,1},
//        new int[] {2,5,1},
//        new int[] {0,4,5},
//        new int[] {4,6,2}
//        };

//        int n = 7;

//        Console.WriteLine(s.CountPaths(n, roads));

//    }
//}

//// Time : Same as dijikstra