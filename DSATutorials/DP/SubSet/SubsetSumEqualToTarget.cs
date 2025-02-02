//using System;

////We are given an array ‘ARR’ with N positive integers.
////We need to find if there is a subset in “ARR” with a sum equal to K. If there is, return true else return false.
//class Helper
//{
//    // Recursion
//    // Time : O(2^n), space : O(n)
//    //public bool Solve(int[] arr, int index, int target)
//    //{
//    //    // base case
//    //    // Target dont exist anymore
//    //    if (target == 0)
//    //    {
//    //        return true;
//    //    }

//    //    // we just have 1 element left, check if it is the target itself
//    //    if (index == 0)
//    //    {
//    //        return (arr[index] == target);
//    //    }

//    //    bool pickSum = false;

//    //    if (target >= arr[index])
//    //    {
//    //        pickSum = Solve(arr, index - 1, target - arr[index]);
//    //    }

//    //    bool notPickSum = Solve(arr, index - 1, target);

//    //    return pickSum || notPickSum;
//    //}

//    // Memoization
//    // Time : O(index * target), space : O(index *target) + O(index)
//    //public bool Solve(int[] arr, int index, int target, int[,] dp)
//    //{

//    //    if (target == 0)
//    //    {
//    //        return true;
//    //    }

//    //    if (index == 0)
//    //    {
//    //        return (arr[index] == target);
//    //    }

//    //    if (dp[index, target] != -1)
//    //    {
//    //        return (dp[index, target] == 1 ? true : false);
//    //    }

//    //    bool pickSum = false;

//    //    if (target >= arr[index])
//    //    {
//    //        pickSum = Solve(arr, index - 1, target - arr[index], dp);
//    //    }

//    //    bool notPickSum = Solve(arr, index - 1, target, dp);

//    //    dp[index, target] = (pickSum || notPickSum == true ? 1 : 0);

//    //    return (dp[index, target] == 1 ? true : false);
//    //}

//    // Tabulation
//    // Time : O(index * target), space : O(index *target) 
//    //public bool Solve(int[] arr, int index, int target, bool[,] dp)
//    //{
//    //    // base case

//    //    // target can be tru for any index
//    //    for (int i = 0; i < arr.Length; i++)
//    //    {
//    //        dp[i, 0] = true;
//    //    }

//    //    if (arr[0] <= target)
//    //    {
//    //        dp[0, arr[0]] = true;
//    //    }

//    //    // index
//    //    for (int i = 1; i < index; i++)
//    //    {
//    //        // target
//    //        for (int j = 1; j <= target; j++)
//    //        {
//    //            bool pickSum = false;

//    //            if (j >= arr[i])
//    //            {
//    //                pickSum = dp[i - 1, j - arr[i]];
//    //            }

//    //            bool notPickSum = dp[i - 1, j];

//    //            dp[i, j] = (pickSum || notPickSum);
//    //        }
//    //    }
//    //    return dp[index, target];          // result will be stored in last cell
//    //}

//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 2, 3, 1, 1 };

//        Helper h = new Helper();

//        int target = 9;

//        //int[,] dp = new int[arr.Length, target + 1];

//        //for (int i = 0; i < dp.GetLength(0); i++)
//        //{
//        //    for (int j = 0; j < dp.GetLength(1); j++)
//        //    {
//        //        dp[i, j] = -1;
//        //    }
//        //}

//        bool[,] dp = new bool[arr.Length, target + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = false;
//            }
//        }

//        //Console.WriteLine(h.Solve(arr, arr.Length - 1, target, dp));

//    }
//}