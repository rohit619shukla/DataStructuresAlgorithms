
//class Solution
//{
//    public int CombinationSum4(int[] nums, int target)
//    {
//        // Recursion:
//        //return Solve(nums, 0, target);

//        // Memoization with 2D DP
//        //int[,] dp = new int[nums.Length + 1, target + 1];

//        //for (int i = 0; i < dp.GetLength(0); i++)
//        //{
//        //    for (int j = 0; j < dp.GetLength(1); j++)
//        //    {
//        //        dp[i, j] = -1;
//        //    }
//        //}


//        // Memiozation with 1D DP
//        int[] dp = new int[target + 1];
//        Array.Fill(dp, -1);

//        //return Solve(nums, target, dp);

//        return Solve(nums, target);
//    }

//    // Time :  O(2^n) , space : O(n)
//    private int Solve(int[] nums, int idx, int target)
//    {
//        // base case
//        // 1. Target achieved
//        if (target == 0)
//        {
//            return 1;
//        }

//        // 2. If the target or idx goes over or under bound
//        if (idx >= nums.Length || target < 0)
//        {
//            return 0;
//        }

//        // We will jump back to first index to start over (special case)
//        int take = Solve(nums, 0, target - nums[idx]);

//        int notTake = Solve(nums, idx + 1, target);

//        return take + notTake;
//    }

//    // Memoized with 2D Dp
//    private int Solve(int[] nums, int idx, int target, int[,] dp)
//    {
//        // base case
//        // 1. Target achieved
//        if (target == 0)
//        {
//            return 1;
//        }

//        // 2. If the target or idx goes over or under bound
//        if (idx >= nums.Length || target < 0)
//        {
//            return 0;
//        }

//        if (dp[idx, target] != -1)
//        {
//            return dp[idx, target];
//        }

//        // We will jump back to first index to start over (special case)
//        int take = Solve(nums, 0, target - nums[idx], dp);

//        int notTake = Solve(nums, idx + 1, target, dp);

//        return dp[idx, target] = take + notTake;
//    }

//    // Memoized with 1D Dp
//    // Create a recursion tree and it will be super simple for you to understand
//    private int Solve(int[] nums, int target, int[] dp)
//    {
//        // base case
//        if (target == 0)
//        {
//            return 1;
//        }

//        if (target < 0)
//        {
//            return 0;
//        }

//        if (dp[target] != -1)
//        {
//            return dp[target];
//        }

//        int ways = 0;
//        foreach (int num in nums)
//        {
//            ways += Solve(nums, target - nums[num], dp);
//        }

//        return ways;
//    }

//    // Tabulation , time  : O(n*m) , space :O(target)
//    private int Solve(int[] nums, int target)
//    {
//        int[] dp = new int[target + 1];

//        dp[0] = 1;

//        for (int tar = 1; tar <= target; tar++)
//        {
//            int ways = 0;
//            foreach (int idx in nums)
//            {
//                if (tar - idx >= 0)
//                {
//                    ways += dp[tar - idx];
//                }
//            }
//            dp[tar] = ways;
//        }

//        return dp[target];
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] nums = { 1, 2, 3 };
//        int target = 4;

//        Solution s = new Solution();
//        Console.WriteLine(s.CombinationSum4(nums, target));
//    }
//}