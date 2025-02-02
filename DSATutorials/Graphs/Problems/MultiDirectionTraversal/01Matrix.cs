//// Leetcode 542 (Medium)

//using System;

//class Graph
//{
//    public int[][] UpdateMatrix(int[][] mat)
//    {
//        int rows = mat.Length;
//        int cols = mat[0].Length;

//        // to store explored and final distance
//        int[,] explored = new int[rows, cols];
//        int[][] distance = new int[rows][];

//        for (int i = 0; i < rows; i++)
//        {
//            distance[i] = new int[cols];
//        }

//        // create multi source BFS queue
//        Queue<(int, int, int)> q = new Queue<(int, int, int)>();

//        // since we need to find nearest 0 we will find all 0 and store them in queue
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (mat[i][j] == 0)
//                {
//                    explored[i, j] = 1;
//                    q.Enqueue((i, j, 0));       // nearest 0 node from give,n 0 node will always be same (0)
//                }
//            }
//        }

//        int[] deltaRows = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };

//        // start multisource BFS
//        while (q.Count > 0)
//        {
//            (int sourceNode, int destNode, int dist) = q.Dequeue();

//            // update the distance array for the popped node
//            distance[sourceNode][destNode] = dist;

//            // explored in 4 directions
//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = sourceNode + deltaRows[i];
//                int newCol = destNode + deltaCols[i];

//                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && explored[newRow, newCol] == 0)
//                {
//                    explored[newRow, newCol] = 1;
//                    q.Enqueue((newRow, newCol, dist + 1));  // distance will always increase by 1 unit
//                }
//            }
//        }
//        return distance;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph();

//        int[][] mat = new int[][] {
//            new int[]  {0,0,0 },
//            new int[] { 0,1,0},
//            new int[]  { 1,1,1}
//        };

//        var result = g.UpdateMatrix(mat);

//        for (int i = 0; i < result.Length; i++)
//        {
//            for (int j = 0; j < result[0].Length; j++)
//            {
//                Console.Write($"{result[i][j]}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}


////Time Complexity: O(NxM + NxMx4) ~O(N x M)

////For the worst case, the BFS function will be called for (N x M) nodes, and for every node, we are traversing for 4 neighbors, so it will take O(N x M x 4) time.

////Space Complexity: O(N x M) + O(N x M) + O(N x M) ~O(N x M)

////O(N x M) for the visited array, distance matrix, and queue space takes up N x M locations at max.
