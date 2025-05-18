

//class Helper
//{
//    public int Solve(int[,] mat, int rows, int columns)
//    {
//        int[,] dp = new int[rows + 1, columns + 1];
        
//        // store the first row to start DP
//        for (int i = 0; i < columns; i++)
//        {
//            dp[0, i] = mat[0, i];
//        }

//        for (int i = 1; i < rows; i++)
//        {

//            for (int j = 0; j < columns; j++)
//            {
//                int upPath = mat[i, j] + dp[i - 1, j];

//                int upLeftPath = (int)(1e9);

//                if (j - 1 >= 0)
//                {
//                    upLeftPath = mat[i, j] + dp[i - 1, j - 1];
//                }

//                int upRightPath = (int)(1e9);

//                if (j + 1 < columns)
//                {
//                    upRightPath = mat[i, j] + dp[i - 1, j + 1];
//                }

//                dp[i, j] = Math.Min(upPath, Math.Min(upLeftPath, upRightPath));

//            }
//        }

//        int minValue = int.MaxValue;

//        for (int i = 0; i < columns; i++)
//        {
//            minValue = Math.Min(minValue, dp[rows - 1, i]);
//        }

//        return minValue;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[,] mat = {
//                                {2,1,3},
//                                {6,5,4 },
//                                { 7,8,9}
//                };


//        Helper h = new Helper();

//        Console.WriteLine(h.Solve(mat, mat.GetLength(0), mat.GetLength(1)));
//    }
//}


////class Helper
////{
////    // Recursion
////    // Time : O(3^N) , space : O(n)
////    //public int Solve(int currentRow, int currentColumn, int[,] mat)
////    //{
////    //    // base case
////    //    // preventing overflow
////    //    if (currentColumn < 0 || currentColumn >= mat.GetLength(1))
////    //    {
////    //        return 0;
////    //    }

////    //    if (currentRow == 0)
////    //    {
////    //        return mat[currentRow, currentColumn];
////    //    }

////    //    int leftPath = mat[currentRow, currentColumn] + Solve(currentRow - 1, currentColumn - 1, mat);

////    //    int upPath = mat[currentRow, currentColumn] + Solve(currentRow - 1, currentColumn, mat);

////    //    int rightPath = mat[currentRow, currentColumn] + Solve(currentRow - 1, currentColumn + 1, mat);

////    //    return Math.Max(leftPath, Math.Max(upPath, rightPath));
////    //}

////    // Memoization
////    // Time : O(m*n) , space : O(m*n) + O(n)
////    //public int Solve(int currentRow, int currentColumn, int[,] mat, int[,] dp)
////    //{

////    //    if (currentColumn < 0 || currentColumn >= mat.GetLength(1))
////    //    {
////    //        return 0;
////    //    }

////    //    if (currentRow == 0)
////    //    {
////    //        return mat[currentRow, currentColumn];
////    //    }

////    //    if (dp[currentRow, currentColumn] != -1)
////    //    {
////    //        return dp[currentRow, currentColumn];
////    //    }

////    //    int leftPath = mat[currentRow, currentColumn] + Solve(currentRow - 1, currentColumn - 1, mat, dp);

////    //    int upPath = mat[currentRow, currentColumn] + Solve(currentRow - 1, currentColumn, mat, dp);

////    //    int rightPath = mat[currentRow, currentColumn] + Solve(currentRow - 1, currentColumn + 1, mat, dp);

////    //    return Math.Max(leftPath, Math.Max(upPath, rightPath));

////    //}

////    // Tabulation
////    // complexity : O(n*m), space : O(n*m)
////    //public void Solve(int rows, int columns, int[,] mat, int[,] dp)
////    //{

////    //    for (int i = 0; i <= rows; i++)
////    //    {
////    //        for (int j = 0; j <= columns; j++)
////    //        {
////    //            if (i == 0)
////    //            {
////    //                dp[i, j] = mat[i, j];
////    //                continue;
////    //            }

////    //            int leftPath = mat[i, j], rightPath = mat[i, j];

////    //            int upPath = mat[i, j] + dp[i - 1, j];

////    //            if (j - 1 >= 0)
////    //            {
////    //                leftPath += dp[i - 1, j - 1];
////    //            }

////    //            if (j + 1 < columns)
////    //            {
////    //                rightPath += dp[i - 1, j + 1];
////    //            }

////    //            dp[i, j] = Math.Max(leftPath, Math.Max(upPath, rightPath));
////    //        }
////    //    }
////    //}

////    // Tabulation
////    // complexity : O(n*m), space : O(n)
////    public int[] Solve(int rows, int columns, int[,] mat)
////    {

////        int[] prev = new int[columns + 1];

////        for (int i = 0; i <= rows; i++)
////        {
////            int[] cur = new int[columns + 1];

////            for (int j = 0; j <= columns; j++)
////            {
////                if (i == 0)
////                {
////                    cur[j] = mat[i, j];
////                    continue;
////                }

////                int leftPath = mat[i, j], rightPath = mat[i, j];

////                int upPath = mat[i, j] + prev[j];

////                if (j - 1 >= 0)
////                {
////                    leftPath += prev[j - 1];
////                }

////                if (j + 1 < columns)
////                {
////                    rightPath += prev[j + 1];
////                }

////                cur[j] = Math.Max(leftPath, Math.Max(upPath, rightPath));
////            }
////            prev = cur;
////        }

////        return prev;
////    }

////}
////class Program
////{
////    public static void Main()
////    {
////        Helper h = new Helper();

////        int[,] mat = {
////                        {1,2,10,4 },
////                        {100,3,2,1 },
////                        { 1,1,20,2},
////                        { 1,2,2,1}
////        };

////        int rows = mat.GetLength(0);
////        int cols = mat.GetLength(1);

////        int maxPath = int.MinValue;

////        int[,] dp = new int[rows, cols];

////        for (int i = 0; i < dp.GetLength(0); i++)
////        {
////            for (int j = 0; j < dp.GetLength(1); j++)
////            {
////                dp[i, j] = -1;
////            }
////        }
////        // for every cell starting from last row we will try to find a path
////        //for (int i = 0; i < cols; i++)
////        //{
////        //    maxPath = Math.Max(h.Solve(rows - 1, i, mat, dp), maxPath);
////        //}

////        /*h.Solve(rows - 1, cols - 1, mat, dp)*/;

////        int[] result = h.Solve(rows - 1, cols - 1, mat);

////        // one of the last row ceel contains our answer
////        for (int k = 0; k < result.Length; k++)
////        {
////            maxPath = Math.Max(maxPath, result[k]);
////        }

////        Console.WriteLine(maxPath);
////    }
////}