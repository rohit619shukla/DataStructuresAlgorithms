//using Newtonsoft.Json.Linq;
//using System;
//using System.Reflection;

//public class Solution
//{
//    public bool CanPartition(int[] nums)
//    {
//        int sum = 0;

//        foreach (int num in nums)
//        {
//            sum += num;
//        }
//        if (sum % 2 != 0)
//            return false;
//        int target = sum / 2;

//        bool[,] dp = new bool[nums.Length, target + 1];

//        return Solve(nums, target);
//    }

//    // Time : O(2^n) , space :O(n)
//    //private bool Solve(int[] nums, int index, int target)
//    //{
//    //    // base case
//    //    if (target == 0)
//    //    {
//    //        return true;
//    //    }

//    //    if (index == 0)
//    //    {
//    //        return (nums[index] == target) ? true : false;
//    //    }

//    //    bool notTake = Solve(nums, index - 1, target);
//    //    bool take = false;

//    //    if (target >= nums[index])
//    //    {
//    //        take = Solve(nums, index - 1, target - nums[index]);
//    //    }

//    //    return take || notTake;
//    //}

//    // Time :(n*m) , space : (n*m) + O(n)
//    //private bool Solve(int[] nums, int index, int target, bool?[,] dp)
//    //{
//    //    // base case
//    //    if (target == 0)
//    //    {
//    //        return true;
//    //    }

//    //    if (index == 0)
//    //    {
//    //        return (nums[index] == target) ? true : false;
//    //    }

//    //    if (dp[index, target].HasValue)
//    //    {
//    //        return dp[index, target].Value;
//    //    }

//    //    bool notTake = Solve(nums, index - 1, target, dp);
//    //    bool take = false;

//    //    if (target >= nums[index])
//    //    {
//    //        take = Solve(nums, index - 1, target - nums[index], dp);
//    //    }

//    //    return (dp[index, target] = take || notTake).Value;
//    //}

//    // Time : O(n*m) , space :O(n*m)
//    //private bool Solve(int[] nums, int target, bool[,] dp)
//    //{
//    //    for (int i = 0; i < nums.Length; i++)
//    //    {
//    //        dp[i, 0] = true;
//    //    }

//    //    dp[0, nums[0]] = true;

//    //    for (int i = 1; i < nums.Length; i++)
//    //    {
//    //        for (int j = 1; j <= target; j++)
//    //        {
//    //            bool notTake = dp[i - 1, j];
//    //            bool take = false;

//    //            if (j >= nums[i])
//    //            {
//    //                take = dp[i - 1, j - nums[i]];
//    //            }

//    //            dp[i, j] = take || notTake;
//    //        }
//    //    }

//    //    return dp[nums.Length - 1, target];
//    //}

//    // Time : O(n*m) , space :(n+m)
//    private bool Solve(int[] nums, int target)
//    {
//        bool[] prev = new bool[target+1];

//        prev[0] = true;

//        if (target >= nums[0])
//            prev[nums[0]] = true;

//        for (int i = 1; i < nums.Length; i++)
//        {
//            bool[] curr = new bool[target+1];
//            curr[0] = true;

//            for (int j = 1; j <= target; j++)
//            {
//                bool notTake = prev[j];
//                bool take = false;

//                if (j >= nums[i])
//                {
//                    take = prev[j - nums[i]];
//                }

//                curr[j] = take || notTake;
//            }
//            prev = curr;
//        }

//        return prev[target];
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        int[] nums = { 2, 2, 3, 5 };

//        Solution s = new Solution();

//        Console.WriteLine(s.CanPartition(nums));
//    }
//}