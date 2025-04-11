//using System;

//class Helper
//{
//    public int MinimumTotal(IList<IList<int>> triangle)
//    {
//        int rows = triangle.Count;
//        int columns = triangle[triangle.Count - 1].Count;

//        int[,] dp = new int[rows, columns];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }

//        //return Solve(triangle, 0, 0, dp);

//        //return Solve(triangle, rows, columns, dp);
//        return Solve(triangle, rows, columns);
//    }

//    // Recursion
//    // Time : O(2^ N*M), space : O(N)
//    //private int Solve(IList<IList<int>> triangle, int row, int column)
//    //{
//    //    // We will only check for row, as we need to find minimum path length in last row. If we reach last row we simply return value
//    //    if (row == triangle.Count - 1)
//    //    {
//    //        return triangle[row][column];
//    //    }

//    //    int bottomSum = triangle[row][column] + Solve(triangle, row + 1, column);

//    //    int rightSum = triangle[row][column] + Solve(triangle, row + 1, column + 1);

//    //    return Math.Min(rightSum, bottomSum);
//    //}

//    // Memoization
//    // Time : O(m*n) , space : O(m*n) + O(n)
//    //private int Solve(IList<IList<int>> triangle, int row, int column, int[,] dp)
//    //{
//    //    if (row == triangle.Count - 1)
//    //    {
//    //        return triangle[row][column];
//    //    }

//    //    if (dp[row, column] != -1)
//    //    {
//    //        return dp[row, column];
//    //    }

//    //    int bottomSum = triangle[row][column] + Solve(triangle, row + 1, column, dp);

//    //    int rightSum = triangle[row][column] + Solve(triangle, row + 1, column + 1, dp);

//    //    return dp[row, column] = Math.Min(bottomSum, rightSum);
//    //}

//    // Tabulation
//    // Time : O(m*n) , space : O(m*n)
//    //private int Solve(IList<IList<int>> triangle, int rows, int columns, int[,] dp)
//    //{
//    //    // unlike other tabulation case of going from top to bottom, this will be bottom to up

//    //    // store last row completely in dp array

//    //    for (int i = 0; i < columns; i++)
//    //    {
//    //        dp[rows - 1, i] = triangle[rows - 1][i];
//    //    }

//    //    // since last row is already stored, now we start from second last row
//    //    for (int i = rows - 2; i >= 0; i--)
//    //    {
//    //        // since its a triangle we will have number of elements in triangle same as row number
//    //        for (int j = i; j >= 0; j--)
//    //        {
//    //            int bottomSum = triangle[i][j] + dp[i + 1, j];

//    //            int rightSum = triangle[i][j] + dp[i + 1, j + 1];

//    //            dp[i, j] = Math.Min(bottomSum, rightSum);
//    //        }
//    //    }

//    //    return dp[0, 0];
//    //}

//    // Tabulation
//    // Time : O(m*n) , space : O(m)
//    private int Solve(IList<IList<int>> triangle, int rows, int columns)
//    {
            //int rows = triangle.Count;
            //int cols = triangle[rows - 1].Count;

            //int[,] dp = new int[rows + 1, cols + 1];

            //int[] next = new int[cols + 1];
            //for (int i = rows - 1; i >= 0; i--)
            //{
            //    int[] curr = new int[cols + 1];

            //    for (int j = i; j >= 0; j--)
            //    {
            //        int downPath = triangle[i][j] + next[j];

            //        int diagPath = triangle[i][j] + next[j + 1];

            //        curr[j] = Math.Min(downPath, diagPath);
            //    }
            //    next = curr;
            //}

            //return next[0];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        IList<IList<int>> lst = new List<IList<int>>();
//        lst.Add(new List<int> { 1 });
//        lst.Add(new List<int> { 2, 3 });
//        lst.Add(new List<int> { 3, 6, 7 });
//        lst.Add(new List<int> { 	 });

//        Helper h = new Helper();
//        Console.WriteLine(h.MinimumTotal(lst));

//    }
//}