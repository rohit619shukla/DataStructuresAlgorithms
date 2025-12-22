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

//        if (cost.Length == 2)
//        {
//            return Math.Min(cost[0], cost[1]);
//        }

//        // The questions states that you can start from either step 0 or step 1. So if you start from step 0 or step 1, the cost will be the cost of that step.
//        dp[0] = cost[0];
//        dp[1] = cost[1];

//        for (int i = 2; i < cost.Length; i++)
//        {
//            int one_Jump = cost[i] + dp[i - 1];
//            int two_Jump = cost[i] + dp[i - 2];

//            dp[i] = Math.Min(one_Jump, two_Jump);
//        }

//        // As i need to return the cost of top of the floor which comes after the last step, i will return the minimum cost of reaching either of the last two steps.
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