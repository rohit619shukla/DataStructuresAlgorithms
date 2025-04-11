//using System;

//class Helper
//{
//    // Recursion
//    // Time : O(index ^ K), for every index(step) we can k jumps, space : O(index)
//public int Solve(int[] heights, int index, int k)
//{
//    if (index == 0)
//    {
//        return 0;
//    }

//    int minJumpEnergy = int.MaxValue;

//    // we will assume to start from 1 jump only
//    for (int i = 1; i <= k; i++)
//    {
//        // Making sure it does not go lesser than 0
//        if (index - i >= 0)
//        {
//            int jumpCost = Solve(heights, index - i, k) + Math.Abs(heights[index] - heights[index - i]);

//            minJumpEnergy = Math.Min(jumpCost, minJumpEnergy);

//        }
//    }

//    return minJumpEnergy;
//    //}

//    // Memoization
//    // Time : O(index * k) for every step (index) we are jumping k steps , space : O(index)
//    //public int Solve(int[] heights, int index, int k, int[] dp)
//    //{
//    //    if (index == 0)
//    //    {
//    //        return 0;
//    //    }

//    //    if (dp[index] != -1)
//    //    {
//    //        return dp[index];
//    //    }

//    //    int minjumpCost = int.MaxValue;

//    //    for (int i = 1; i <= k; i++)
//    //    {
//    //        if (index - i >= 0)
//    //        {
//    //            int currentMinJumpCost = Solve(heights, index - i, k, dp) + Math.Abs(heights[index] - heights[index - i]);

//    //            minjumpCost = Math.Min(minjumpCost, currentMinJumpCost);
//    //        }
//    //    }
//    //    return dp[index] = minjumpCost;
//    //}

//    // Tabulation
//    // Time : O(index * k) for every step (index) we are jumping k steps , space : O(index)
//    public int Solve(int[] heights, int index, int k, int[] dp)
//    {
//        dp[0] = 0;

//        // for every step we will process
//        for (int i = 1; i <= index; i++)
//        {
//            int minjumpCost = int.MaxValue;

//            // for every k jump
//            for (int j = 1; j <= k; j++)
//            {
//                if (i - j >= 0)
//                {
//                    int currentCost = dp[i - j] + Math.Abs(heights[i] - heights[i - j]);

//                    minjumpCost = Math.Min(minjumpCost, currentCost);

//                }
//            }

//            dp[i] = minjumpCost;
//        }

//        return dp[index];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] heights = { 30, 10, 60, 10, 60, 50 };

//        int n = heights.Length;

//        int k = 2;

//        Helper h = new Helper();
//        int[] dp = new int[n + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            dp[i] = -1;
//        }
//        Console.WriteLine(h.Solve(heights, n - 1, k, dp));
//    }
//}