//public class Solution
//{
//    public int MinCostClimbingStairs(int[] cost)
//    {
//        int[] dp = new int[cost.Length];

//        Array.Fill(dp, -1);
//        //return Math.Min(Solve(cost, 0), Solve(cost, 1));
//        //return Math.Min(Solve(cost, 0, dp), Solve(cost, 1, dp));

//        return Solve(cost);
//    }

//    // Time : O(2^n) , space :O(n)
//    private int Solve(int[] cost, int index)
//    {
//        // Base case
//        if (index >= cost.Length)
//        {
//            return 0;
//        }

//        int oneJump = cost[index] + Solve(cost, index + 1);

//        int twoJump = cost[index] + Solve(cost, index + 2);

//        return Math.Min(oneJump, twoJump);
//    }


//    // Time :O(n) , space :O(n) + O(n)
//    private int Solve(int[] cost, int index, int[] dp)
//    {
//        // Base case
//        if (index >= cost.Length)
//        {
//            return 0;
//        }

//        if (dp[index] != -1)
//        {
//            return dp[index];
//        }

//        int oneJump = cost[index] + Solve(cost, index + 1, dp);

//        int twoJump = cost[index] + Solve(cost, index + 2, dp);

//        return dp[index] = Math.Min(oneJump, twoJump);
//    }

//    // Time :O(n) , space O(n)
//    private int Solve(int[] cost)
//    {
//        int[] dp = new int[cost.Length + 1];

//        // base case : As per leetcode requirement
//        if (cost.Length == 2)
//        {
//            // Try with recursion tree and you will arrive here.
//            return Math.Min(cost[0], cost[1]);
//        }

//        dp[0] = cost[0];
//        dp[1] = cost[1];

//        for (int index = 2; index < cost.Length; index++)
//        {
//            dp[index] = cost[index] + Math.Min(dp[index - 1], dp[index - 2]);
//        }

//        // We are required top of the floor : ek kadam zyada
//        return Math.Min(dp[cost.Length - 1], dp[cost.Length - 2]);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        int[] cost = { 10, 15, 20 };

//        Console.WriteLine(s.MinCostClimbingStairs(cost));
//    }
//}