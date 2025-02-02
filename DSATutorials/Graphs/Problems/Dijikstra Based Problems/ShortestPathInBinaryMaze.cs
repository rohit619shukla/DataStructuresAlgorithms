
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

//        // Creata a distance matrix
//        int[,] distance = new int[rows, cols];

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                distance[i, j] = int.MaxValue;
//            }
//        }

//        distance[0, 0] = 1;
//        // Create Queue for Dijikstra
//        Queue<(int, int, int)> q = new Queue<(int, int, int)>();

//        // Add start node to queue
//        q.Enqueue((0, 0, 1));

//        // Start Dijikstra
//        while (q.Count > 0)
//        {
//            (int currRow, int currCol, int currCost) = q.Dequeue();

//            // Traverse in 8 directions
//            for (int deltaRows = -1; deltaRows <= 1; deltaRows++)
//            {
//                for (int deltaCols = -1; deltaCols <= 1; deltaCols++)
//                {
//                    int newRow = deltaRows + currRow;
//                    int newCol = deltaCols + currCol;

//                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 0)
//                    {
//                        if (distance[newRow, newCol] > currCost + 1)
//                        {
//                            distance[newRow, newCol] = currCost + 1;
//                            q.Enqueue((newRow, newCol, distance[newRow, newCol]));
//                        }
//                    }
//                }
//            }
//        }

//        return distance[rows - 1, cols - 1] != int.MaxValue ? distance[rows - 1, cols - 1] : -1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] grid = new int[][] {
//            new int[] {0,0,0 },
//            new int[] { 1,1,0},
//            new int[] { 1,1,0},
//        };

//        Solution s = new Solution();

//        Console.WriteLine($"{s.ShortestPathBinaryMatrix(grid)}");
//    }
//}
//// Complexity : O(N*M)
