//using System;

//public class Solution
//{
//    //public int PaintWalls(int[] cost, int[] time)
//    //{
//    //    int[,] dp = new int[cost.Length + 1, cost.Length + 1];
//    //    for (int i = 0; i < dp.GetLength(0); i++)
//    //    {
//    //        for (int j = 0; j < dp.GetLength(1); j++)
//    //        {
//    //            dp[i, j] = -1;
//    //        }
//    //    }
//    //    return Solve(cost, time, cost.Length - 1, cost.Length, dp);
//    //}

//    ////Time : O(N^2), space :O(n* m) + O(n)
//    //private int Solve(int[] cost, int[] time, int index, int wallsRemain, int[,] dp)
//    //{
//    //    // base case 
//    //    //Both painters simultaneously working completed their job and no more walls are remaining.
//    //    //Hence no more job pending and cost can be 0.
//    //    if (wallsRemain <= 0)
//    //    {
//    //        return 0;
//    //    }

//    //    // No way to paint the remaining walls.
//    //    if (index < 0)
//    //    {
//    //        return (int)1e9;
//    //    }


//    //    if (dp[index, wallsRemain] != -1)
//    //    {
//    //        return dp[index, wallsRemain];
//    //    }

//    //    int notPick = Solve(cost, time, index - 1, wallsRemain, dp);

//    //    int pick = cost[index] + Solve(cost, time, index - 1, wallsRemain - 1 - time[index], dp);

//    //    return dp[index, wallsRemain] = Math.Min(pick, notPick);
//    //}

//    // Time : O(n*m) , space :O(n*m)
//    public int PaintWalls(int[] cost, int[] time)
//    {
//        int n = cost.Length;
//        int[,] dp = new int[n + 1, n + 1];

//        for (int i = 0; i <= n; i++)
//        {
//            for (int j = 0; j <= n; j++)
//            {
//                dp[i, j] = (int)1e9;
//            }
//        }

//        dp[0, 0] = 0;

//        for (int index = 1; index <= n; index++)
//        {
//            for (int wallsRemain = 0; wallsRemain <= n; wallsRemain++)
//            {
//                int notPick = dp[index - 1, wallsRemain];

//                // Will keep index-1 instead of index as in memo to avpid oob
//                int pick = cost[index - 1] + dp[index - 1, Math.Max(0, wallsRemain - 1 - time[index - 1])];

//                dp[index, wallsRemain] = Math.Min(pick, notPick);
//            }
//        }

//        return dp[n, n];
//    }


//}

//class Program
//{
//    public static void Main()
//    {
//        int[] cost = { 1, 2, 3, 2 };

//        int[] time = { 1, 2, 3, 2 };

//        Solution s = new Solution();

//        Console.WriteLine(s.PaintWalls(cost, time));
//    }
//}