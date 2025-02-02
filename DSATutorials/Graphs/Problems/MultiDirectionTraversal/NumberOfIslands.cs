// // Leetcode : 200 (Medium)
//public class Solution
//{
//    public int NumIslands(char[][] grid)
//    {
//        int rows = grid.Length;
//        int cols = grid[0].Length;
//        int[,] explored = new int[rows, cols];
//        int count = 0;

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (explored[i, j] == 0 && grid[i][j] == '1')
//                {
//                    DFS(i, j, explored, grid, rows, cols);
//                    count++;
//                }
//            }
//        }

//        return count;
//    }

//    private void DFS(int currentRowNode, int currentColNode, int[,] explored, char[][] grid, int rows, int cols)
//    {
//        explored[currentRowNode, currentColNode] = 1;

//        int[] deltaRows = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };

//        for (int i = 0; i < 4; i++)
//        {
//            int newRow = currentRowNode + deltaRows[i];
//            int newCol = currentColNode + deltaCols[i];

//            if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && explored[newRow, newCol] == 0 && grid[newRow][newCol] == '1')
//            {
//                DFS(newRow, newCol, explored, grid, rows, cols);
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        char[][] grid = new char[][] {
//            new char[] { '1','1','0','0','0'},
//            new char[] { '1','1','0','0','0'},
//            new char[] { '0','0','1','0','0'},
//            new char[] { '0','0','0','1','1'}

//        };

//        Solution s = new Solution();
//        Console.WriteLine(s.NumIslands(grid));
//    }
//}