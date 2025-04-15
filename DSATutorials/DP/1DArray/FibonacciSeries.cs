//using System;

//class FibonacciHelper
//{
//    // Recursive
//    // Time : O(2^n), space : O(n)
//    //public int GetFibonacci(int num)
//    //{
//    //    if (num == 1 || num == 0)
//    //    {
//    //        return num;
//    //    }

//    //    return GetFibonacci(num - 1) + GetFibonacci(num - 2);
//    //}

//    // Memoization
//    // Time : O(n) , Space : O(n)
//    //public int GetFibonacci(int num, int[] dp)
//    //{
//    //    if (num == 1 || num == 0)
//    //    {
//    //        return num;
//    //    }

//    //    if (dp[num] != -1)
//    //    {
//    //        return dp[num];
//    //    }

//    //    return dp[num] = GetFibonacci(num - 1, dp) + GetFibonacci(num - 2, dp);
//    //}

//    // Tabulation
//    // Time : O(n), space : O(n)
//    //public int GetFibonacci(int num, int[] dp)
//    //{
//    //    dp[0] = 0;
//    //    dp[1] = 1;

//    //    for (int i = 2; i <= num; i++)
//    //    {
//    //        dp[i] = dp[i - 1] + dp[i - 2];
//    //    }

//    //    return dp[num];
//    //}

//    // Tabulation with space optimization
//    // Time: O(n), space : O(1) as it uses constant input space
//    public int GetFibonacci(int n)
//    {
//        if (n <= 1)
//        {
//            return n;
//        }
//        int prev2 = 0;
//        int prev1 = 1;

//        for (int i = 2; i <= n; i++)
//        {
//            int currentValue = prev1 + prev2;
//            prev2 = prev1;
//            prev1 = currentValue;
//        }

//        return prev1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Console.WriteLine("Enter a number");
//        int n = Convert.ToInt32(Console.ReadLine());

//        int[] dp = new int[n + 1];

//        for (int i = 0; i < dp.Length; i++)
//        {
//            dp[i] = -1;
//        }

//        FibonacciHelper f = new FibonacciHelper();
//        //Console.WriteLine($"{f.GetFibonacci(n, dp)}");
//        Console.WriteLine($"{f.GetFibonacci(n)}");
//    }
//}
