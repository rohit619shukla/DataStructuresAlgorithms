//public class Solution
//{
//    public int FindTheCity(int n, int[][] edges, int distanceThreshold)
//    {
//        // The idea is to find shortest path to every vertex from every vertex
//        // Create a input matrix for Floyd warshall
//        int[,] matrix = new int[n, n];

//        // Assign them to infinity
//        for (int i = 0; i < n; i++)
//        {
//            for (int j = 0; j < n; j++)
//            {
//                if (i != j)
//                {
//                    matrix[i, j] = (int)1e9;
//                }

//            }
//        }

//        // Now fill the cells with provided weight
//        foreach (int[] edge in edges)
//        {
//            int u = edge[0];
//            int v = edge[1];
//            int cost = edge[2];

//            matrix[u, v] = cost;
//            matrix[v, u] = cost;
//        }

        
//        // Now apply Floyd warshall
//        for (int k = 0; k < n; k++)
//        {
//            for (int i = 0; i < n; i++)
//            {
//                for (int j = 0; j < n; j++)
//                {
//                    matrix[i, j] = Math.Min(matrix[i, j], matrix[i, k] + matrix[k, j]);
//                }
//            }
//        }

//        int currentCity = -1;
//        int minCitiesReachable = int.MaxValue;

//        // Find the results
//        for (int i = 0; i < n; i++)
//        {
//            int reachableCities = 0;

//            for (int j = 0; j < n; j++)
//            {
//                // Exclue self node and include those nodes who are under threshold
//                if (i != j && matrix[i, j] <= distanceThreshold)
//                {
//                    reachableCities++;
//                }
//            }

//            // Return the city with min cost reachable cities, since everything is under the loop we dont need to worry much about the max number as it is already in increasing sequence
//            if (minCitiesReachable >= reachableCities)
//            {
//                minCitiesReachable = reachableCities;
//                currentCity = i;
//            }
//        }

//        return currentCity;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int[][] edges = new int[][] {
//                            new int[] {0,1,3 },
//                            new int[] {1,2,1},
//                            new int[] { 1,3,4 },
//                            new int[] { 2,3,1 }
//                        };

//        int n = 4;
//        int distanceThreshold = 4;

//        Solution s = new Solution();

//        Console.WriteLine($"{s.FindTheCity(n, edges, distanceThreshold)}");
//    }
//}
//// Same like floyd warshall