//class Solution
//{
//    public List<int> ShortestPath(int n, int m, int[][] edges)
//    {
//        // parent array for backtracking
//        int[] parent = new int[n + 1];
//        for (int i = 1; i <= n; i++) parent[i] = i;

//        // Adjacency List
//        List<int[]>[] adjList = new List<int[]>[n + 1];
//        for (int i = 0; i <= n; i++) adjList[i] = new List<int[]>();

//        foreach (var edge in edges)
//        {
//            adjList[edge[0]].Add(new int[] { edge[1], edge[2] });
//            adjList[edge[1]].Add(new int[] { edge[0], edge[2] });
//        }

//        int[] distance = new int[n + 1];
//        Array.Fill(distance, int.MaxValue);

//        distance[1] = 0;
//        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
//        pq.Enqueue(1, 0);

        
//        while (pq.Count > 0) // O(v)
//        {
//            pq.TryDequeue(out int currentNode, out int cost); // O(LogV)

//            if (cost > distance[currentNode]) continue;

//            foreach (int[] neighbor in adjList[currentNode])  // O(E)
//            {
//                int neighborNode = neighbor[0];
//                int weight = neighbor[1];

//                // Use long to prevent potential overflow if weights were larger, 
//                // though int is usually fine for these constraints.
//                if (distance[currentNode] + weight < distance[neighborNode])
//                {
//                    distance[neighborNode] = distance[currentNode] + weight;
//                    pq.Enqueue(neighborNode, distance[neighborNode]);  // O(LogV)
//                    parent[neighborNode] = currentNode;
//                }
//            }
//        }

//        List<int> result = new List<int>();

//        // Check if destination is unreachable
//        if (distance[n] == int.MaxValue)
//        {
//            result.Add(-1);
//            return result;
//        }

//        // Backtrack path from n to 1
//        int tempNode = n;
//        while (parent[tempNode] != tempNode)
//        {
//            result.Add(tempNode);
//            tempNode = parent[tempNode];
//        }
//        result.Add(1);

//        // IMPORTANT: GFG expects the weight as the first element
//        result.Add(distance[n]);

//        // Reverse to get [Weight, 1, ..., n]
//        result.Reverse();

//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] edges = {
//            new int[]{1,2,2 },
//             new int[]{ 2, 5, 5},
//              new int[]{ 2, 3, 4},
//               new int[]{ 1, 4, 1},
//                new int[]{ 4, 3, 3},
//                 new int[]{3, 5, 1 }
//        };

//        Solution s = new Solution();

//        var result = s.ShortestPath(5, 6, edges);

//        foreach (var node in result)
//        {
//            Console.Write($"{node}" + " ");
//        }
//    }
//}

//// Time : same as Dijikstra