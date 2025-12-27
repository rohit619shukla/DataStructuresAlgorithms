//using System;

//class Helper
//{
//    // Recursion
//    // Time : O(2^n) , space : O(m-1) + O(n-1) based on path length
//    //public int UniquePaths(int currentRow, int currentColumn)
//    //{
//    //we went below the bounds
//       //    if (currentRow == -1 || currentColumn == -1)
//       //    {
//       //        return 0;
//       //    }
//       //have reached dest cell
//    //    if (currentRow == 0 && currentColumn == 0)
//    //    {
//    //        return 1;
//    //    }

//    //    int upPath = UniquePaths(currentRow - 1, currentColumn);

//    //    int leftPath = UniquePaths(currentRow, currentColumn - 1);


//    //    return leftPath + upPath;
//    //}

//    public int UniquePaths(int m, int n)
//    {
//        int[,] dp = new int[m + 1, n + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }

//        return Solve(m, n);
//    }

//    // Memoization
//    // Time: O(m*n) , space : O(m*n) + (O(m-1) + O(n-1))
//    //private int Solve(int currentRow, int currentColumn, int[,] dp)
//    //{

//    //    if (currentRow == -1 || currentColumn == -1)
//    //    {
//    //        return 0;
//    //    }

//    //    if (currentColumn == 0 && currentRow == 0)
//    //    {
//    //        return 1;
//    //    }

//    //    if (dp[currentRow, currentColumn] != -1)
//    //    {
//    //        return dp[currentRow, currentColumn];
//    //    }

//    //    int upPathSum = Solve(currentRow - 1, currentColumn, dp);

//    //    int leftPathSum = Solve(currentRow, currentColumn - 1, dp);

//    //    return dp[currentRow, currentColumn] = upPathSum + leftPathSum;
//    //}

//    // Tabulation
//    // Time : O(rows*columns) , space : O(rows*column)
//    //private int Solve(int rows, int columns, int[,] dp)
//    //{
//    //    for (int i = 0; i < rows; i++)
//    //    {
//    //        for (int j = 0; j < columns; j++)
//    //        {

//    //            if (i == 0 && j == 0)
//    //            {
//    //                dp[i, j] = 1;
//    //            }
//    //            else
//    //            {
//    //                int upPathSum = 0;

//    //                if (i > 0)
//    //                {
//    //                    upPathSum = dp[i - 1, j];

//    //                }

//    //                int leftPathSum = 0;

//    //                if (j > 0)
//    //                {
//    //                    leftPathSum = dp[i, j - 1];

//    //                }

//    //                dp[i, j] = upPathSum + leftPathSum;

//    //            }
//    //        }
//    //    }

//    //    return dp[rows - 1, columns - 1];
//    //}

//    // Tabulation : space opti
//    // Time : O(m*n), space: O(n)
//    private int Solve(int rows, int columns)
//    {
//        // Create a dummy previous row to store 0 by default 
//        int[] prev = new int[columns];

//        for (int i = 0; i < rows; i++)
//        {
//            // create a dummy current or to store current row comouted value
//            int[] current = new int[columns];

//            for (int j = 0; j < columns; j++)
//            {
//                if (i == 0 && j == 0)
//                {
//                    current[j] = 1;
//                    continue;
//                }
//                else
//                {
//                    // previous row

//                    int upPathSum = prev[j];
//                    int leftPathSum = 0;

//                    if (j > 0)
//                    {
//                        // current row's previous column
//                        leftPathSum = current[j - 1];

//                    }

//                    // we are computing current row
//                    current[j] = upPathSum + leftPathSum;
//                }
//            }
//            prev = current;
//        }

//        return prev[columns - 1];

//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int m = 3;
//        int n = 7;

//        Helper h = new Helper();

//        Console.WriteLine(h.UniquePaths(m, n));
//    }
//}