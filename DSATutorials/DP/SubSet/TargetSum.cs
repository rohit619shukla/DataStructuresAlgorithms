//using System;

//// bascially same as Count partition with difference

//class Helper
//{
//    private int mod = (int)1e9 + 7;
//    // Recursion
//    // Time : O(2^index) , space : O(index)
//    //public int Solve(int[] arr, int index, int target)
//    //{
//    //    if (index == 0)
//    //    {
//    //        if (target == 0 && arr[0] == 0)
//    //        {
//    //            return 2;
//    //        }

//    //        if (target == 0 || arr[0] == target)
//    //        {
//    //            return 1;
//    //        }

//    //        return 0;
//    //    }

//    //    int notPickSum = Solve(arr, index - 1, target);

//    //    int pickSum = 0;

//    //    if (arr[index] <= target)
//    //    {
//    //        pickSum = Solve(arr, index - 1, target - arr[index]);
//    //    }

//    //    return pickSum + notPickSum;
//    //}

//    // Memoization
//    // Time : O(index * target) , space: O(index * target) + O(index)
//    //public int Solve(int[] arr, int index, int target, int[,] dp)
//    //{
//    //    if (index == 0)
//    //    {
//    //        if (target == 0 && arr[0] == 0)
//    //        {
//    //            return 2;
//    //        }

//    //        if (target == 0 || arr[0] == target)
//    //        {
//    //            return 1;
//    //        }

//    //        return 0;
//    //    }

//    //    if (dp[index, target] != -1)
//    //    {
//    //        return dp[index, target];
//    //    }

//    //    int notPickSum = Solve(arr, index - 1, target, dp);

//    //    int pickSum = 0;

//    //    if (arr[index] <= target)
//    //    {
//    //        pickSum = Solve(arr, index - 1, target - arr[index], dp);
//    //    }

//    //    return dp[index, target] = pickSum + notPickSum;
//    //}

//    // Tabulation
//    // Time : O(index * target) , space: O(index * target)
//    //public int Solve(int[] arr, int index, int target, int[,] dp)
//    //{
//    //    if (arr[0] == 0)
//    //    {
//    //        dp[0, 0] = 2;
//    //    }
//    //    else
//    //    {
//    //        dp[0, 0] = 1;
//    //    }

//    //    if (target != 0 && arr[0] <= target)
//    //    {
//    //        dp[0, arr[0]] = 1;
//    //    }

//    //    for (int i = 1; i <= index; i++)
//    //    {
//    //        for (int j = 0; j <= target; j++)
//    //        {
//    //            int notPickSum = dp[i - 1, j];

//    //            int pickSum = 0;

//    //            if (arr[i] <= j)
//    //            {
//    //                pickSum = dp[i - 1, j - arr[i]];
//    //            }

//    //            dp[i, j] = (pickSum + notPickSum) % mod;
//    //        }
//    //    }

//    //    return dp[index, target];
//    //}

//    // Tabulation
//    // Time : O(index * target) , space: O(index)
//    public int Solve(int[] arr, int index, int target, int[,] dp)
//    {
//        int[] prev = new int[target + 1];

//        if (arr[0] == 0)
//        {
//            prev[0] = 2;
//        }
//        else
//        {
//            prev[0] = 1;
//        }

//        if (target != 0 && arr[0] <= target)
//        {
//            prev[arr[0]] = 1;
//        }

//        for (int i = 1; i <= index; i++)
//        {
//            int[] curr = new int[target + 1];

//            for (int j = 0; j <= target; j++)
//            {
//                int notPickSum = prev[j];

//                int pickSum = 0;

//                if (arr[i] <= j)
//                {
//                    pickSum = prev[j - arr[i]];
//                }

//                curr[j] = (pickSum + notPickSum) % mod;
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
//        int[] arr = { 1, 2, 3, 1 };

//        int target = 3;

//        int totSum = 0;

//        for (int i = 0; i < arr.Length; i++)
//        {
//            totSum += arr[i];
//        }

//        if (totSum - target < 0)
//        {
//            return;
//        }

//        if ((totSum - target) % 2 != 0)
//        {
//            return;
//        }

//        int[,] dp = new int[arr.Length, totSum + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = 0;
//            }
//        }
//        Helper h = new Helper();

//        Console.WriteLine(h.Solve(arr, arr.Length - 1, totSum - target / 2, dp));
//    }
//}