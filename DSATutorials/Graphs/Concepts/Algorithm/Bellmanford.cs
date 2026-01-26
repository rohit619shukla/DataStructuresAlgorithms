

//class Solution
//{
//    public int[] BellManFord(int v, int[,] edges, int src)
//    {
//        // create a result array 
//        int[] distance = new int[v];

//        // Assign max value to all initially
//        for (int i = 0; i < v; i++)
//        {
//            distance[i] = (int)1e9;
//        }

//        // the source node will have distance as 0
//        distance[src] = 0;

//        int ed = edges.GetLength(0);

//        // The core algorithm idea is to relax the the edges V-1 times, as longest possible path between 2 nodes without revisitng the ndoes contains V-1 edges 
//        for (int i = 0; i < v; i++)
//        {
//            // Lets pick 1 edge at a time and relax
//            for (int j = 0; j < ed; j++)
//            {
//                int source = edges[j, 0];
//                int dest = edges[j, 1];
//                int weight = edges[j, 2];

//                // relax
//                if (distance[source] != (int)1e9 && distance[dest] > distance[source] + weight)
//                {
//                    distance[dest] = distance[source] + weight;
//                }
//            }
//        }

//        // relax 1 more time to check for a cycle
//        // Lets pick 1 edge at a time and relax
//        for (int j = 0; j < ed; j++)
//        {
//            int source = edges[j, 0];
//            int dest = edges[j, 1];
//            int weight = edges[j, 2];

//            // relax
//            if (distance[dest] > distance[source] + weight)
//            {
//                return new int[] { -1 };
//            }
//        }

//        return distance;
//    }
//}

//class Program
//{
//    public static void Main()
//    {

//        Solution s = new Solution();

//        // Number of vertices in the graph
//        int V = 5;

//        // Edge list: each row represents {source, destination, weight}
//        int[,] edges = {
//            { 1, 3, 2 },
//            { 4, 3, -1 },
//            { 2, 4, 1 },
//            { 1, 2, 1 },
//            { 0, 1, 5 }
//        };

//        // Source vertex
//        int src = 0;

//        // Call Bellman-Ford and store the result
//        int[] ans = s.BellManFord(V, edges, src);

//        // Print the shortest distances from source to all vertices
//        foreach (int d in ans)
//            Console.Write(d + " ");
//    }
//}


//// Time : O(V*E), space : O(V) Aux