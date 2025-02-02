
//public class Solution
//{
//    public int NumEnclaves(int[][] grid)
//    {
//        int rows = grid.Length;
//        int cols = grid[0].Length;

//        int count = 0;

//        // Create a multisource BFS
//        Queue<(int, int)> q = new Queue<(int, int)>();

//        int[,] visited = new int[rows, cols];


//        // Add all boundary 1's to the queue
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (i == 0 || i == rows - 1 || j == 0 || j == cols - 1)
//                {
//                    if (grid[i][j] == 1)
//                    {
//                        visited[i, j] = 1;
//                        q.Enqueue((i, j));
//                    }
//                }
//            }
//        }

//        int[] deltaRows = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };

//        while (q.Count > 0)
//        {
//            (int curRow, int curCol) = q.Dequeue();

//            // Explore adjacent nodes
//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = deltaRows[i] + curRow;
//                int newCol = deltaCols[i] + curCol;

//                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1 && visited[newRow, newCol] == 0)
//                {
//                    visited[newRow, newCol] = 1;
//                    q.Enqueue((newRow, newCol));
//                }
//            }

//        }

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (grid[i][j] == 1 && visited[i, j] == 0)
//                {
//                    count++;
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
//                new int[] { 0, 0, 0, 0 },
//                new int[] { 1, 0, 1, 0},
//                new int[] {0, 1, 1, 0 },
//                new int[] { 0, 0, 0, 0 }
//            };

//        Solution s = new Solution();

//        Console.WriteLine(s.NumEnclaves(grid));
//    }
//}

////Time Complexity: O(N * M)
////Auxiliary Space: O(N * M)