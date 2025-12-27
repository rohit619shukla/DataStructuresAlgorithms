//using System;


//class Helper
//{
//    // Recursion
//    // Time : O(2^n), space : O(index)
//    //public int Solve(int[] wt, int[] val, int W, int index)
//    //{
//    //    // always think of bas case from 0th perspective
//    //    if (index == 0)
//    //    {
//    //        if (wt[0] <= W)
//    //        {
//    //            return val[0];
//    //        }
//    //        else
//    //        {
//    //            return 0;
//    //        }
//    //    }

//    //    int notPickSum = 0 + Solve(wt, val, W, index - 1);

//    //    int pickSum = int.MinValue;

//    //    if (wt[index] <= W)
//    //    {
//    //        pickSum = val[index] + Solve(wt, val, W - wt[index], index - 1);
//    //    }

//    //    return Math.Max(pickSum, notPickSum);
//    //}

//    // Memoization
//    // Time : O(index * W), space : O(index * W) + O(index)
//    //public int Solve(int[] wt, int[] val, int W, int index, int[,] dp)
//    //{
//    //    // always think of bas case from 0th perspective
//    //    if (index == 0)
//    //    {
//    //        if (wt[0] <= W)
//    //        {
//    //            return val[0];
//    //        }
//    //        else
//    //        {
//    //            return 0;
//    //        }
//    //    }

//    //    if (dp[index, W] != -1)
//    //    {
//    //        return dp[index, W];
//    //    }

//    //    int notPickSum = 0 + Solve(wt, val, W, index - 1, dp);

//    //    int pickSum = int.MinValue;

//    //    if (wt[index] <= W)
//    //    {
//    //        pickSum = val[index] + Solve(wt, val, W - wt[index], index - 1, dp);
//    //    }

//    //    return dp[index, W] = Math.Max(pickSum, notPickSum);
//    //}

//    // Tabulation
//    // Time : O(index* W) , space : O(index * W)
//    //public int Solve(int[] wt, int[] val, int W, int index, int[,] dp)
//    //{
//    //    for (int i = wt[0]; i <= W; i++)
//    //    {
//    //        dp[0, i] = val[0];
//    //    }

//    //    for (int i = 1; i <= index; i++)
//    //    {
//    //        for (int j = 0; j <= W; j++)
//    //        {
//    //            int notPickSum = 0 + dp[i - 1, j];

//    //            int pickSum = 0;

//    //            if (wt[i] <= j)
//    //            {
//    //                pickSum = val[i] + dp[i - 1, j - wt[i]];
//    //            }

//    //            dp[i, j] = Math.Max(pickSum, notPickSum);
//    //        }
//    //    }
//    //    return dp[index, W];
//    //}

//    // Tabulation
//    // Time : O(index* W) , space : O(index)
//    //public int Solve(int[] wt, int[] val, int W, int index)
//    //{
//    //    int[] prev = new int[W + 1];


//    //    for (int i = wt[0]; i <= W; i++)
//    //    {
//    //        prev[i] = val[0];
//    //    }

//    //    for (int i = 1; i <= index; i++)
//    //    {
//    //        int[] curr = new int[W + 1];
//    //        for (int j = 0; j <= W; j++)
//    //        {
//    //            int notPickSum = 0 + prev[j];

//    //            int pickSum = 0;

//    //            if (wt[i] <= j)
//    //            {
//    //                pickSum = val[i] + prev[W - wt[i]];
//    //            }

//    //            curr[j] = Math.Max(pickSum, notPickSum);
//    //        }
//    //        prev = curr;
//    //    }
//    //    return prev[W];
//    //}

//    // Tabulation : space optimization  with 1 array
//    // Time : O(index* W) , space : O(index)
//    public int Solve(int[] wt, int[] val, int W, int index)
//    {
//        int[] prev = new int[W + 1];

//        for (int i = 0; i <= W; i++)
//        {
//            prev[i] = val[0];
//        }

//        for (int i = 1; i <= index; i++)
//        {
//            for (int j = 0; j <= W; j++)
//            {
//                int notPickSum = 0 + prev[j];

//                int pickSum = 0;

//                if (wt[i] <= j)
//                {
//                    pickSum = val[i] + prev[W - wt[i]];
//                }

//                prev[j] = Math.Max(pickSum, notPickSum);
//            }
//        }
//        return prev[W];
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        int[] wt = { 1, 2, 4, 5 };
//        int[] val = { 5, 4, 8, 6 };
//        int W = 5;

//        int[,] dp = new int[wt.Length, W + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }
//        Helper h = new Helper();

//        //Console.WriteLine(h.Solve(wt, val, W, wt.Length - 1, dp));

//        Console.WriteLine(h.Solve(wt, val, W, wt.Length - 1));
//    }
//}