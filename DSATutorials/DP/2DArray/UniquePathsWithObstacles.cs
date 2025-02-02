//using System;
//using System.Data.Common;

//class Helper
//{
//    public int UniquePathsWithObstacles(int[][] obstacleGrid)
//    {
//        int rows = obstacleGrid.Length;
//        int columns = obstacleGrid[0].Length;

//        //int[,] dp = new int[rows, columns];

//        //for (int i = 0; i < rows; i++)
//        //{
//        //    for (int j = 0; j < columns; j++)
//        //    {
//        //        dp[i, j] = -1;
//        //    }
//        //}
//        return Solve(rows - 1, columns - 1, obstacleGrid);
//    }

//    // Recursion
//    // Time : O(2^n), space : O((m-1)+(n-1))
//    //private int Solve(int rows, int columns, int[][] arr)
//    //{
//    //    if (rows < 0 || columns < 0)
//    //    {
//    //        return 0;
//    //    }

//    //    if (arr[rows][columns] == -1)
//    //    {
//    //        return 0;
//    //    }

//    //    if (rows == 0 && columns == 0)
//    //    {
//    //        if (arr[rows][columns] == 0)
//    //        {
//    //            return 1;
//    //        }
//    //        else
//    //        {
//    //            return 0;
//    //        }
//    //    }

//    //    int upSum = Solve(rows - 1, columns, arr);

//    //    int leftSum = Solve(rows, columns - 1, arr);

//    //    return upSum + leftSum;
//    //}

//    // Memoization
//    // Time : O(m*n), space : O(n*m) +O((m-1)+(n-1))
//    //private int Solve(int rows, int columns, int[][] arr, int[,] dp)
//    //{
//    //    if (rows < 0 || columns < 0)
//    //    {
//    //        return 0;
//    //    }

//    //    if (arr[rows][columns] == -1)
//    //    {
//    //        return 0;
//    //    }

//    //    if (dp[rows, columns] != -1)
//    //    {
//    //        return dp[rows, columns];
//    //    }
//    //    if (rows == 0 && columns == 0)
//    //    {
//    //        if (arr[rows][columns] == 0)
//    //        {
//    //            return 1;
//    //        }
//    //        else
//    //        {
//    //            return 0;
//    //        }
//    //    }

//    //    int upSum = Solve(rows - 1, columns, arr, dp);

//    //    int leftSum = Solve(rows, columns - 1, arr, dp);

//    //    return dp[rows, columns] = upSum + leftSum;
//    //}

//    // Tabulation
//    // Time : O(m*n), space : O(m*n)
//    //private int Solve(int rows, int columns, int[][] arr, int[,] dp)
//    //{

//    //    for (int i = 0; i <= rows; i++)
//    //    {
//    //        for (int j = 0; j <= columns; j++)
//    //        {
//    //            if (i == 0 && j == 0)
//    //            {
//    //                if (arr[i][j] == 0)
//    //                {
//    //                    dp[i, j] = 1;
//    //                    continue;
//    //                }
//    //            }

//    //            if (arr[i][j] != 0)
//    //            {
//    //                dp[i, j] = 0;
//    //            }

//    //            else
//    //            {
//    //                int upSum = 0;
//    //                int leftSum = 0;

//    //                if (i > 0)
//    //                {
//    //                    upSum = dp[i - 1, j];

//    //                }

//    //                if (j > 0)
//    //                {
//    //                    leftSum = dp[i, j - 1];
//    //                }

//    //                dp[i, j] = upSum + leftSum;
//    //            }
//    //        }
//    //    }

//    //    return dp[rows, columns];
//    //}

//    // Tabulation : Space opti
//    // Time : O(n*m) , space : O(n)
//    private int Solve(int rows, int columns, int[][] arr)
//    {
//        int[] prev = new int[columns + 1];

//        for (int i = 0; i <= rows; i++)
//        {
//            int[] curr = new int[columns + 1];

//            for (int j = 0; j <= columns; j++)
//            {
//                if (i == 0 && j == 0)
//                {
//                    if (arr[i][j] == 0)
//                    {
//                        curr[j] = 1;
//                        continue;
//                    }
//                }

//                if (arr[i][j] != 0)
//                {
//                    curr[j] = 0;
//                }

//                else
//                {
//                    int leftSum = 0;

//                    int upSum = prev[j];

//                    if (j > 0)
//                    {
//                        leftSum = curr[j - 1];
//                    }

//                    curr[j] = upSum + leftSum;
//                }
//            }
//            prev = curr;
//        }

//        return prev[columns];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] arr = {
//            new int[] { 0, 0, 0 },
//            new int[] { 0, -1, 0},
//            new int[] { 0, 0, 0 }
//        };

//        Helper h = new Helper();
//        Console.WriteLine(h.UniquePathsWithObstacles(arr));
//    }
//}