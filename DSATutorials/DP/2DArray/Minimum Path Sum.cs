//using System;
//using System.Data.Common;

//class Helper
//{
//    static int maxValue = 99999;

//    public int MinPathSum(int[][] grid)
//    {
//        int rows = grid.Length;
//        int columns = grid[0].Length;

//        int[,] dp = new int[rows + 1, columns + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }
//        return Solve(rows - 1, columns - 1, grid, dp);
//    }

//    // Recursion
//    // Time : O(2^n), space : O((m-1)+(n-1))
//    //private int Solve(int row, int column, int[][] grid)
//    //{
//    //    // base cases
//    //    if (row < 0 || column < 0)
//    //    {
//    //        return maxValue;
//    //    }

//    //    if (row == 0 && column == 0)
//    //    {
//    //        return grid[row][column];
//    //    }

//    //    int upSum = grid[row][column] + Solve(row - 1, column, grid);

//    //    int leftSum = grid[row][column] + Solve(row, column - 1, grid);

//    //    return Math.Min(upSum, leftSum);
//    //}

//    // Memoization
//    // Time : O(row*column) , space : O(row*column) + O((row-1)+(column-1))
//    //private int Solve(int row, int column, int[][] grid, int[,] dp)
//    //{
//    //    // base cases
//    //    if (row < 0 || column < 0)
//    //    {
//    //        return maxValue;
//    //    }

//    //    if (row == 0 && column == 0)
//    //    {
//    //        return grid[row][column];
//    //    }

//    //    if (dp[row, column] != -1)
//    //    {
//    //        return dp[row, column];
//    //    }

//    //    int upSum = grid[row][column] + Solve(row - 1, column, grid, dp);

//    //    int leftSum = grid[row][column] + Solve(row, column - 1, grid, dp);

//    //    return dp[row, column] = Math.Min(upSum, leftSum);
//    //}

//    // Tabulation
//    // Time : O(row * column), space : O(row * column)
//    //private int Solve(int row, int column, int[][] grid, int[,] dp)
//    //{
//    //    for (int i = 0; i <= row; i++)
//    //    {
//    //        for (int j = 0; j <= column; j++)
//    //        {
//    //            if (i == 0 && j == 0)
//    //            {
//    //                dp[i, j] = grid[i][j];
//    //                continue;
//    //            }

//    //            int upSum = int.MaxValue;
//    //            int leftSum = int.MaxValue;

//    //            if (i > 0)
//    //            {
//    //                upSum = grid[i][j] + dp[i - 1, j];
//    //            }

//    //            if (j > 0)
//    //            {
//    //                leftSum = grid[i][j] + dp[i, j - 1];
//    //            }

//    //            dp[i, j] = Math.Min(upSum, leftSum);
//    //        }
//    //    }

//    //    return dp[row, column];
//    //}

//    // Tabulation
//    // Time : O(row * column), space : O(n)
//    private int Solve(int row, int column, int[][] grid, int[,] dp)
//    {
//        int[] prev = new int[column + 1];

//        for (int i = 0; i <= row; i++)
//        {
//            int[] curr = new int[column + 1];

//            for (int j = 0; j <= column; j++)
//            {
//                if (i == 0 && j == 0)
//                {
//                    curr[j] = grid[i][j];
//                    continue;
//                }

//                int upSum = int.MaxValue;
//                int leftSum = int.MaxValue;

//                if (i > 0)
//                {
//                    upSum = grid[i][j] + prev[j];
//                }

//                if (j > 0)
//                {
//                    leftSum = grid[i][j] + curr[j - 1];
//                }

//                curr[j] = Math.Min(upSum, leftSum);
//            }

//            prev = curr;
//        }

//        return prev[column];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] arr = {
//            new int[] { 5,9,6},
//            new int[] { 11,5,2}
//        };

//        Helper h = new Helper();
//        Console.WriteLine(h.MinPathSum(arr));
//    }
//}