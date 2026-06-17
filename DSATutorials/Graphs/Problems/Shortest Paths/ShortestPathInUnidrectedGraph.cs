//class Solution
//{
//    public int[] shortestPath(int V, int[,] edges, int src)
//    {
//        // Since this is a 1 unit distance between 2 vertices, we will uses standard BFS with queue


//        // Lets create an adjList
//        List<int>[] adjList = new List<int>[V];
//        for (int i = 0; i < V; i++)
//        {
//            adjList[i] = new List<int>();
//        }


//        for (int i = 0; i < edges.GetLength(0); i++)
//        {
//            AddEdge(edges[i, 0], edges[i, 1], adjList);
//        }

//        int[] distance = new int[V];
//        Array.Fill(distance, int.MaxValue);

//        distance[src] = 0;

//        Queue<int> q = new Queue<int>();
//        q.Enqueue(src);

//        while (q.Count > 0) // O(V)
//        {
//            int srcNode = q.Dequeue(); // O(1)

//            foreach (int neighBors in adjList[srcNode]) // O(E) total across all iterations
//            {
//                if (distance[srcNode] + 1 < distance[neighBors])
//                {
//                    distance[neighBors] = distance[srcNode] + 1;
//                    q.Enqueue((neighBors)); // O(1)
//                }
//            }
//        }

//        return distance;
//    }

//    private void AddEdge(int src, int dest, List<int>[] adjList)
//    {
//        adjList[src].Add(dest);
//        adjList[dest].Add(src);
//    }
//}

//// Time Complexity: O(V + E) - BFS visits each vertex once and each edge once
//// Space Complexity: O(V + E) - Adjacency list O(V+E), Distance array O(V), Queue O(V)

//class Program
//{
//    public static void Main()
//    {
//        int V = 9;
//        int[,] edges = {
//            {0, 1},
//            {0, 3},
//            {1, 2},
//            {1, 3},
//            {3, 4},
//            {4, 5},
//            {2, 6},
//            {5, 6},
//            {6, 7},
//            {6, 8},
//            {7, 8}
//        };
//        int src = 0;

//        Solution s = new Solution();
//        int[] result = s.shortestPath(V, edges, src);

//        for (int i = 0; i < result.Length; i++)
//        {
//            Console.Write($"{result[i]} ");
//        }
//    }
//}