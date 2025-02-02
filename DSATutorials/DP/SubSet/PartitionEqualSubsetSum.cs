//using System;

//class Helper
//{
//    // Recursion
//    // Time : O(2^n), space : O(n)
//    //public bool Solve(int[] arr, int index, int target)
//    //{
//    //    if (target == 0)
//    //    {
//    //        return true;
//    //    }

//    //    if (index == 0)
//    //    {
//    //        return (arr[0] == target);
//    //    }

//    //    bool pickSum = false;

//    //    if (arr[index] <= target)
//    //    {
//    //        pickSum = Solve(arr, index - 1, target - arr[index]);
//    //    }

//    //    bool notPickSum = Solve(arr, index - 1, target);

//    //    return (pickSum || notPickSum);
//    //}

//    //public bool Solve(int[] arr, int index, int target, int[,] dp)
//    //{
//    //    if (target == 0)
//    //    {
//    //        return true;
//    //    }

//    //    if (index == 0)
//    //    {
//    //        return (arr[0] == target);
//    //    }

//    //    if (dp[index, target] != -1)
//    //    {
//    //        return (dp[index, target] == 1 ? true : false);
//    //    }
//    //    bool pickSum = false;

//    //    if (arr[index] <= target)
//    //    {
//    //        pickSum = Solve(arr, index - 1, target - arr[index], dp);
//    //    }

//    //    bool notPickSum = Solve(arr, index - 1, target, dp);

//    //    dp[index, target] = (pickSum || notPickSum == true ? 1 : 0);

//    //    return dp[index, target] == 1 ? true : false;
//    //}

//    //    // Tabulation
//    //    // Complexity : O(n*m), space : O(n*m)
//    //    public bool Solve(int[] arr, int index, int target, bool[,] dp)
//    //    {
//    //        for (int i = 0; i < arr.Length; i++)
//    //        {
//    //            dp[i, 0] = true;
//    //        }

//    //        if (arr[0] <= target)
//    //        {
//    //            dp[0, arr[0]] = true;
//    //        }

//    //        for (int i = 1; i < index; i++)
//    //        {
//    //            for (int j = 1; j <= target; j++)
//    //            {
//    //                bool pickSum = false;

//    //                if (j >= arr[i])
//    //                {
//    //                    pickSum = dp[i - 1, j - arr[i]];
//    //                }

//    //                bool notPickSum = dp[i - 1, j];

//    //                dp[i, j] = pickSum || notPickSum;
//    //            }
//    //        }
//    //        return dp[index - 1, target];
//    //    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 2, 3, 3, 3, 4, 5 };

//        int sum = 0;

//        Helper h = new Helper();

//        for (int i = 0; i < arr.Length; i++)
//        {
//            sum += arr[i];
//        }


//        if (sum % 2 == 0)
//        {
//            int target = sum / 2;
//            //int[,] dp = new int[arr.Length, target + 1];

//            //for (int i = 0; i < dp.GetLength(0); i++)
//            //{
//            //    for (int j = 0; j < dp.GetLength(1); j++)
//            //    {
//            //        dp[i, j] = -1;
//            //    }
//            //}

//            bool[,] dp = new bool[arr.Length, target + 1];

//            for (int i = 0; i < dp.GetLength(0); i++)
//            {
//                for (int j = 0; j < dp.GetLength(1); j++)
//                {
//                    dp[i, j] = false;
//                }
//            }


//            Console.WriteLine(h.Solve(arr, arr.Length - 1, target, dp));

//        }
//        else
//        {
//            Console.WriteLine(false);
//        }
//    }
//}