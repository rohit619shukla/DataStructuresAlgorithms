
//using System;

//public class Solution
//{
//    public int FindTargetSumWays(int[] arr, int target)
//    {
//        int totSum = 0;

//        foreach (int num in arr)
//        {
//            totSum += num;
//        }

//        if (totSum - target < 0)
//        {
//            return 0;
//        }

//        if ((totSum - target) % 2 != 0)
//        {
//            return 0;
//        }


//        int[,] dp = new int[arr.Length, (totSum - target) / 2 + 1];

//        return Solve(arr, arr.Length - 1, (totSum - target) / 2);
//    }

//    // Tabulation
//    // Time : O(index * target) , space: O(index * target)
//    private int Solve(int[] arr, int index, int target)
//    {
//        int[,] dp = new int[arr.Length, target + 1];

//        if (arr[0] == 0)
//        {
//            dp[0, 0] = 2;
//        }
//        else
//        {
//            dp[0, 0] = 1; //target == 0  (not pick)

//            if (target >= arr[0]) // target == arr[0] (pick)
//            {
//                dp[0, arr[0]] = 1;
//            }
//        }

//        for (int i = 1; i < arr.Length; i++)
//        {
//            for (int j = 0; j <= target; j++)
//            {
//                int notTake = dp[i - 1, j];

//                int take = 0;

//                if (j >= arr[i])
//                {
//                    take = dp[i - 1, j - arr[i]];
//                }

//                dp[i, j] = take + notTake;
//            }
//        }
//        return dp[arr.Length - 1, target];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1};

//        int target = 1;

//        Solution s = new Solution();

//        Console.WriteLine(s.FindTargetSumWays(arr, target));
//    }
//}