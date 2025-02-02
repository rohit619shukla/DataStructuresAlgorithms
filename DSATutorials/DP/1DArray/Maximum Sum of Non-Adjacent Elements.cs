//using System;

//class Helper
//{
//    // Recursion
//    // Time : O(2^n), space : O(n)
//    //public int Solve(int[] arr, int index)
//    //{
//    //    if (index == 0)
//    //    {
//    //        return arr[0];
//    //    }

//    //    int notPickNumber = 0 + Solve(arr, index - 1);

//    //    int pickNumber = arr[index];

//    //    if (index - 2 >= 0)
//    //    {
//    //        pickNumber += Solve(arr, index - 2);
//    //    }

//    //    return Math.Max(notPickNumber, pickNumber);
//    //}

//    // Memoization
//    // Time : O(n), space : O(n) + O(n) 
//    //public int Solve(int[] arr, int index, int[] dp)
//    //{
//    //    if (index == 0)
//    //    {
//    //        return arr[0];
//    //    }

//    //    if (dp[index] != -1)
//    //    {
//    //        return dp[index];
//    //    }

//    //    int notPickSum = 0 + Solve(arr, index - 1, dp);

//    //    int pickSum = arr[index];

//    //    if (index - 2 >= 0)
//    //    {
//    //        pickSum += Solve(arr, index - 2, dp);
//    //    }

//    //    return dp[index] = Math.Max(notPickSum, pickSum);
//    //}

//    // Tabulation
//    // Time : O(n), space : O(n)
//    //public int Solve(int[] arr, int index, int[] dp)
//    //{
//    //    dp[0] = arr[0];


//    //    for (int i = 1; i <= index; i++)
//    //    {
//    //        int notPickSum = 0 + dp[i - 1];

//    //        int pickSum = arr[i];

//    //        if (i - 2 >= 0)
//    //        {
//    //            pickSum += dp[i - 2];
//    //        }

//    //        dp[i] = Math.Max(pickSum, notPickSum);
//    //    }

//    //    return dp[index];
//    //}

//    // Tabulation : space optimization
//    // Time : O(n), space : O(1)
//    public int Solve(int[] arr, int index)
//    {
//        int prev1 = arr[0];
//        int prev2 = 0;

//        for (int i = 1; i <= index; i++)
//        {
//            int pickSum = arr[i] + prev2;

//            int notPickSum = 0 + prev1;

//            int currentSum = Math.Max(pickSum, notPickSum);
//            prev2 = prev1;
//            prev1 = currentSum;
//        }

//        return prev1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 2, 1, 4, 9 };

//        int n = arr.Length;

//        int[] dp = new int[n + 1];

//        for (int i = 0; i < dp.Length; i++)
//        {
//            dp[i] = -1;
//        }

//        Helper h = new Helper();
//        //Console.WriteLine(h.Solve(arr, n - 1, dp));

//        Console.WriteLine(h.Solve(arr, n - 1));
//    }
//}