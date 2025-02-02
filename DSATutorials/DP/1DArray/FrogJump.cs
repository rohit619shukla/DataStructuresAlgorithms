//using System;

//class Helper
//{
//    // Recursion
//    // Time : O(2^n) , space : O(n)
//    //public int Solve(int index, int[] heights)
//    //{
//    //    // base case

//    //    // A jump from 0 -> 0, energy consumed will be 0
//    //    if (index == 0)
//    //    {
//    //        return 0;
//    //    }

//    //    int firstJump = Solve(index - 1, heights) + Math.Abs(heights[index] - heights[index - 1]);

//    //    int secondJump = int.MaxValue;

//    //    // In case we are at 0 or 1 , a double jump will give is out of bound error
//    //    if (index > 1)
//    //    {
//    //        secondJump = Solve(index - 2, heights) + Math.Abs(heights[index] - heights[index - 2]);
//    //    }

//    //    return Math.Min(firstJump, secondJump);
//    //}

//    // memoization
//    // Time : O(n) , space: O(n)
//    //public int Solve(int index, int[] heights, int[] dp)
//    //{
//    //    // base case
//    //    // We cant go from 0 -> 0 step
//    //    if (index == 0)
//    //    {
//    //        return 0;
//    //    }

//    //    if (dp[index] != -1)
//    //    {
//    //        return dp[index];
//    //    }

//    //    int firstJump = Solve(index - 1, heights, dp) + Math.Abs(heights[index] - heights[index - 1]);

//    //    int secondJump = int.MaxValue;

//    //    if (index > 1)
//    //    {
//    //        secondJump = Solve(index - 2, heights, dp) + Math.Abs(heights[index] - heights[index - 2]);
//    //    }

//    //    return dp[index] = Math.Min(firstJump, secondJump); 
//    //}

//    // Tabulation
//    // Time : O(n), space : O(n)
//    //public int Solve(int index, int[] heights, int[] dp)
//    //{
//    //    dp[0] = 0;

//    //    for (int i = 1; i <= index; i++)
//    //    {
//    //        int firstJump = dp[i - 1] + Math.Abs(heights[i] - heights[i - 1]);

//    //        int secondJump = int.MaxValue;

//    //        if (i > 1)
//    //        {
//    //            secondJump = dp[i - 2] + Math.Abs(heights[i] - heights[i - 2]);
//    //        }

//    //        dp[i] = Math.Min(firstJump, secondJump);
//    //    }

//    //    return dp[index];
//    //}

//    // Tabulation using space optimization
//    // Time : O(n), space : O(1)
//    public int Solve(int index, int[] heights)
//    {
//        int prev1 = 0;
//        int prev2 = 0;

//        for (int i = 1; i <= index; i++)
//        {
//            int firstJump = prev1 + Math.Abs(heights[i] - heights[i - 1]);

//            int secondJump = int.MaxValue;

//            if (i > 1)
//            {
//                secondJump = prev2 + Math.Abs(heights[i] - heights[i - 2]);
//            }

//            int curr = Math.Min(firstJump, secondJump);

//            prev2 = prev1;
//            prev1 = curr;
//        }

//        return prev1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] heights = { 30, 10, 60, 10, 60, 50 };
//        int n = heights.Length;

//        int[] dp = new int[n + 1];

//        for (int i = 0; i < dp.Length; i++)
//        {
//            dp[i] = -1;
//        }

//        Helper h = new Helper();
//        //Console.WriteLine(h.Solve(n - 1, heights, dp));

//        Console.WriteLine(h.Solve(n - 1, heights));
//    }
//}