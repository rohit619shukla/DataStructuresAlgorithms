

//class ClimbingStairsHelper
//{
//    // Recursion
//    // Time : O(2^n), space : O(n)
//    //public int GetNumberOfWaysToClimbStairs(int n)
//    //{
//    //    if (n == 0 || n == 1)
//    //    {
//    //        return 1;
//    //    }

//    //    return GetNumberOfWaysToClimbStairs(n - 1) + GetNumberOfWaysToClimbStairs(n - 2);
//    //}

//    //Memoization
//    // TIme : O(n), space : O(n)
//    //public int GetNumberOfWaysToClimbStairs(int n, int[] dp)
//    //{
//    //    if (n == 0 || n == 1)
//    //    {
//    //        return 1;
//    //    }

//    //    if (dp[n] != -1)
//    //    {
//    //        return dp[n];
//    //    }

//    //    return dp[n] = GetNumberOfWaysToClimbStairs(n - 1, dp) + GetNumberOfWaysToClimbStairs(n - 2, dp);
//    //}

//    // Tabulation
//    // Time :O(n), spcae :O(n)
//    //public int GetNumberOfWaysToClimbStairs(int n, int[] dp)
//    //{
//    //    dp[0] = 1;
//    //    dp[1] = 1;

//    //    for (int i = 2; i <= n; i++)
//    //    {
//    //        dp[i] = dp[i - 1] + dp[i - 2];
//    //    }

//    //    return dp[n];
//    //}

//    // Tabulation : space optimization
//    // Time : O(n), O(1)
//    public int GetNumberOfWaysToClimbStairs(int n)
//    {
//        int prev2 = 1;
//        int prev1 = 1;

//        for (int i = 2; i <= n; i++)
//        {
//            int current = prev1 + prev2;
//            prev2 = prev1;
//            prev1 = current;
//        }

//        return prev1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int n = 6;

//        int[] dp = new int[n + 1];

//        for (int i = 0; i < dp.Length; i++)
//        {
//            dp[i] = -1;
//        }

//        ClimbingStairsHelper c = new ClimbingStairsHelper();
//        //Console.WriteLine($"{c.GetNumberOfWaysToClimbStairs(n, dp)}");
//        Console.WriteLine($"{c.GetNumberOfWaysToClimbStairs(n)}");
//    }
//}