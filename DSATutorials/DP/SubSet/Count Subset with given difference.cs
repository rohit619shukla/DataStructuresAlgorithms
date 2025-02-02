//using System;
//using System.Runtime.Intrinsics.Arm;

//class Helper
//{
//    // Time : O(2^index), space :O(index)
//    //public int Solve(int[] arr, int index, int target)
//    //{

//    //    if (index == 0)
//    //    {
//    //        if (target == 0 && arr[0] == 0)
//    //        {
//    //            return 2;
//    //        }

//    //        if (target == arr[0] || target == 0)
//    //        {
//    //            return 1;
//    //        }
//    //    }

//    //    int notTake = Solve(arr, index - 1, target);

//    //    int take = 0;

//    //    if (target >= arr[index])
//    //    {
//    //        take = Solve(arr, index - 1, target - arr[index]);
//    //    }

//    //    return take + notTake;
//    //}

//    // Time : O(index * target), space :O(index * target)
//    //public int Solve(int[] arr, int index, int target, int[,] dp)
//    //{

//    //    if (index == 0)
//    //    {
//    //        if (target == 0 && arr[0] == 0)
//    //        {
//    //            return 2;
//    //        }

//    //        if (target == arr[0] || target == 0)
//    //        {
//    //            return 1;
//    //        }
//    //    }

//    //    if (dp[index, target] != -1)
//    //    {
//    //        return dp[index, target];
//    //    }
//    //    int notTake = Solve(arr, index - 1, target, dp);

//    //    int take = 0;

//    //    if (target >= arr[index])
//    //    {
//    //        take = Solve(arr, index - 1, target - arr[index], dp);
//    //    }

//    //    return dp[index, target] = take + notTake;
//    //}


//    // Time : O(index * target), space :O(index)
//    public int Solve(int[] arr, int index, int target)
//    {
//        int[,] dp = new int[arr.Length, target + 1];

//        if (arr[0] == 0)
//        {
//            dp[0, 0] = 2;
//        }
//        else
//        {
//            dp[0, 0] = 1;
//        }

//        if (arr[0] != 0 && arr[0] <= target)
//        {
//            dp[0, arr[0]] = 1;
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

//        return dp[index, target];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 5, 2, 6, 4 };

//        int diff = 3;

//        int totSum = 0;

//        for (int i = 0; i < arr.Length; i++)
//        {
//            totSum += arr[i];
//        }

//        // can't be zero
//        if (totSum - diff < 0)
//        {
//            return;
//        }

//        Helper h = new Helper();

//        int[,] dp = new int[arr.Length, ((totSum - diff) / 2) + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }

//        // we have modified  target
//        Console.WriteLine(h.Solve(arr, arr.Length - 1, (totSum - diff) / 2));
//    }
//}