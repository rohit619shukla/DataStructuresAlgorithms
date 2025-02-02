//using System;

////We are given an array ‘ARR’ with N positive integers and an integer K.
////We need to find the number of subsets whose sum is equal to K.
//class Helper
//{
//    // Recursion
//    // Time : O(2^n), space : O(n)
//    //public int Solve(int[] arr, int index, int target)
//    //{
//    //    if (target == 0)
//    //    {
//    //        return 1;
//    //    }

//    //    if (index == 0)
//    //    {
//    //        return (arr[0] == target ? 1 : 0);
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
//    // Time : O(index * target) ,space : O(index * target) + O(index), 
//    //public int Solve(int[] arr, int index, int target, int[,] dp)
//    //{
//    //    if (target == 0)
//    //    {
//    //        return 1;
//    //    }

//    //    if (index == 0)
//    //    {
//    //        return (arr[0] == target ? 1 : 0);
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
//    // Time : O(index * target) ,space : O(index * target)
//    public int Solve(int[] arr, int index, int target, int[,] dp)
//    {
//        // base cases
//        for (int i = 0; i < arr.Length; i++)
//        {
//            dp[i, 0] = 1;
//        }

//        dp[0, arr[0]] = 1;

//        // index   
//        for (int i = 1; i <= index; i++)
//        {
//            // target
//            for (int j = 0; j <= target; j++)
//            {
//                int notPickSum = dp[i - 1, j];

//                int pickSum = 0;

//                if (arr[i] <= j)
//                {
//                    pickSum = dp[i - 1, j - arr[i]];
//                }

//                dp[i, j] = pickSum + notPickSum;
//            }
//        }

//        return dp[index, target];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 1, 4, 5 };

//        int target = 5;

//        Helper h = new Helper();

//        int[,] dp = new int[arr.Length, target + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                //dp[i, j] = -1;  // for memoization

//                dp[i, j] = 0;   // for tabulation
//            }
//        }

//        Console.WriteLine(h.Solve(arr, arr.Length - 1, target, dp));
//    }
//}