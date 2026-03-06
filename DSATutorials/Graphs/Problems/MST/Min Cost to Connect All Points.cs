//public class Solution
//{
//    public int MinCostConnectPoints(int[][] points)
//    {
//        // Hint : Since we have been asked to connect all points in plane with minimum cost, hence this is MST problem

//        // Step 1 : Create Adjacency list to store the edegs and weights
//        int n = points.Length;

//        List<int[]>[] adjList = new List<int[]>[n];

//        for (int i = 0; i < n; i++)
//        {
//            adjList[i] = new List<int[]>();
//        }

//        // Step 2 : start filling them 

//        for (int i = 0; i < n; i++)
//        {
//            for (int j = i + 1; j < n; j++)
//            {
//                int x1 = points[i][0];
//                int y1 = points[i][1];

//                int x2 = points[j][0];
//                int y2 = points[j][1];

//                int weight = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);

//                // Step 3 : Create undirected graph
//                AddEdge(i, j, weight, adjList);
//            }
//        }

//        // Step 4 : Apply Prims Algorithm
//        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

//        bool[] visited = new bool[n];

//        int result = 0;

//        pq.Enqueue(0, 0);

//        while (pq.Count > 0)
//        {
//            pq.TryDequeue(out int currentNode, out int weight);

//            if (visited[currentNode] == true)
//            {
//                continue;
//            }

//            visited[currentNode] = true;
//            result += weight;

//            foreach (var neighbors in adjList[currentNode])
//            {
//                if (visited[neighbors[0]] == false)
//                {
//                    pq.Enqueue(neighbors[0], neighbors[1]);
//                }
//            }
//        }

//        return result;
//    }

//    private void AddEdge(int src, int dest, int weight, List<int[]>[] adjList)
//    {
//        adjList[src].Add(new int[] { dest, weight });
//        adjList[dest].Add(new int[] { src, weight });
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int[][] points = {
//            new int[] { 0,0},
//            new int[] { 2,2},
//            new int[] { 3,10},
//            new int[] { 5,2},
//            new int[]{ 7,0}
//        };

//        Solution s = new Solution();

//        Console.WriteLine(s.MinCostConnectPoints(points));
//    }
//}


//// Time : O(V^2 + ELogV) , space :  O(V+E)