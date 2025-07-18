//public class Solution
//{
//    public int ClimbStairs(int n)
//    {
//        int[] dp = new int[n + 1];

//        Array.Fill(dp, -1);

//        // return Solve(n);

//        return Solve(n);
//    }

//    // Time : O(2^n) , space :O(n)
//    //private int Solve(int index)
//    //{
//    //    if (index < 0)
//    //    {
//    //        // no way
//    //        return 0;
//    //    }

//    //    if (index == 0)
//    //    {
//    //        return 1;
//    //    }

//    //    return Solve(index - 1) + Solve(index - 2);
//    //}

//    // Time :O(n) , space :O(n) + O(n)
//    private int Solve(int index, int[] dp)
//    {
//        if (index < 0)
//        {
//            // no way
//            return 0;
//        }

//        if (index == 0)
//        {
//            return 1;
//        }

//        if (dp[index] != -1)
//        {
//            return dp[index];
//        }

//        return dp[index] = Solve(index - 1, dp) + Solve(index - 2, dp);
//    }


//    // Time : O(n) , space :O(n)
//    private int Solve(int n)
//    {
//        int[] dp = new int[n + 1];

//        dp[0] = 1;
//        dp[1] = 1;

//        for (int index = 2; index <= n; index++)
//        {
//            dp[index] = dp[index - 1] + dp[index - 2];
//        }

//        return dp[n];
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        int n = 3;

//        Solution s = new Solution();

//        Console.WriteLine(s.ClimbStairs(n));
//    }
//}

//// Wec an do same sapce optimization for O(1)