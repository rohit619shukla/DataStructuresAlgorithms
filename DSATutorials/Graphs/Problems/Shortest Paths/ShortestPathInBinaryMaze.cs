//public class Solution
//{
//    public int ShortestPathBinaryMatrix(int[][] grid)
//    {
//        if (grid[0][0] != 0)
//        {
//            return -1;
//        }

//        int rows = grid.Length;
//        int cols = grid[0].Length;


//        // Create a visisted array. Dijiktsra with 2D matrix needs to keep track of visisted
//        bool[,] visited = new bool[rows, cols];

//        // create a distance matrix
//        int[,] distance = new int[rows, cols];

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                distance[i, j] = (int)1e9;
//            }
//        }

//        // mark the start node a visisted and set the intial distance
//        distance[0, 0] = 0;

//        visited[0, 0] = true;

//        // Since we have been asked shortest path, Dijikstra comes to mind.
//        // But there is a twist, here the path length will be +1 incremented, hence no need to a PQ
//        // We will create a pair to store the co-ordinates and the distance 
//        Queue<((int, int), int)> q = new Queue<((int, int), int)>();

//        q.Enqueue(((0, 0), 0));

//        // start Dijik in 8 directions
//        while (q.Count > 0)
//        {
//            ((int src, int dest), int cost) = q.Dequeue();

//            // Now explore in all 8 directions

//            for (int deltaRows = -1; deltaRows <= 1; deltaRows++)
//            {
//                for (int deltaCols = -1; deltaCols <= 1; deltaCols++)
//                {
//                    int newSrc = src + deltaRows;
//                    int newDst = dest + deltaCols;

//                    // check for validity
//                    if (newSrc >= 0 && newSrc < rows && newDst >= 0 && newDst < cols && visited[newSrc, newDst] == false && grid[newSrc][newDst] == 0)
//                    {
//                        if (distance[newSrc, newDst] > 1 + cost)
//                        {
//                            distance[newSrc, newDst] = 1 + cost;
//                            visited[newSrc, newDst] = true;
//                            q.Enqueue(((newSrc, newDst), distance[newSrc, newDst]));
//                        }
//                    }

//                }
//            }

//        }

//        if (distance[rows - 1, cols - 1] != (int)1e9)
//        {
//            return distance[rows - 1, cols - 1] + 1;
//        }

//        return -1;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] grid = {
//                    new int[] {0,0,0 },
//                    new int[] { 1,1,0},
//                    new int[] { 1,1,0},
//                };

//        Solution s = new Solution();

//        Console.WriteLine(s.ShortestPathBinaryMatrix(grid));
//    }
//}

//// Complexity : O(N*M)