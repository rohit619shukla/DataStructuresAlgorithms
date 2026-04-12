

//using System.Runtime.InteropServices;

//public class Solution
//{
//    public int NumIslands(char[][] grid)
//    {
//        int rows = grid.Length;
//        int cols = grid[0].Length;

//        int count = 0;

//        bool[,] visited = new bool[rows, cols];
//        int[] deltaRows = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (grid[i][j] == '1' && visited[i, j] == false)
//                {
//                    BFS(i, j, visited, grid, deltaRows, deltaCols, rows, cols);
//                    count++;
//                }
//            }
//        }

//        return count;
//    }

//    private void BFS(int sr, int sc, bool[,] visited, char[][] grid, int[] deltaRows, int[] deltaCols, int rows, int cols)
//    {
//        Queue<(int, int)> q = new Queue<(int, int)>();

//        q.Enqueue((sr, sc));
//        visited[sr, sc] = true;

//        while (q.Count > 0)
//        {
//            (int currRow, int currCol) = q.Dequeue();

//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = currRow + deltaRows[i];
//                int newCol = currCol + deltaCols[i];

//                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && visited[newRow, newCol] == false && grid[newRow][newCol] == '1')
//                {
//                    q.Enqueue((newRow, newCol));
//                    visited[newRow, newCol] = true;
//                }
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        char[][] grid = {
//                        new char[] { '1','1','0','0','0'},
//            new char[] { '1','1','0','0','0'},
//            new char[] { '0','0','1','0','0'},
//            new char[] { '0','0','0','1','1'}

//        };

//        Solution s = new Solution();

//        Console.WriteLine($"{s.NumIslands(grid)}");
//    }
//}