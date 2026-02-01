//public class Solution
//{
//    public int NumEnclaves(int[][] grid)
//    {
//        int rows = grid.Length;
//        int cols = grid[0].Length;

//        bool[,] visited = new bool[rows, cols];

//        Queue<(int, int)> q = new Queue<(int, int)>();

//        // Add all boundary 1's to the queue
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if ((grid[i][j] == 1) && (i == 0 || i == rows - 1 || j == 0 || j == cols - 1))
//                {
//                    q.Enqueue((i, j));
//                    visited[i, j] = true;
//                }
//            }
//        }

//        int[] deltaRows = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };

//        while (q.Count > 0)
//        {
//            (int sr, int sc) = q.Dequeue();

//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = sr + deltaRows[i];
//                int newCol = sc + deltaCols[i];

//                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1 && visited[newRow, newCol] == false)
//                {
//                    q.Enqueue((newRow, newCol));
//                    visited[newRow, newCol] = true;
//                }
//            }
//        }

//        // Whatever remains unvsisted is our answer
//        int count = 0;

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (grid[i][j] == 1 && visited[i, j] == false)
//                {
//                    count += 1;
//                }
//            }
//        }
//        return count;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] grid = new int[][]
//            {
//                        new int[] { 0, 0, 0, 0 },
//                        new int[] { 1, 0, 1, 0},
//                        new int[] {0, 1, 1, 0 },
//                        new int[] { 0, 0, 0, 0 }
//            };

//        Solution s = new Solution();

//        Console.WriteLine(s.NumEnclaves(grid));
//    }
//}

////Time Complexity: O(N * M)
////Auxiliary Space: O(N * M)