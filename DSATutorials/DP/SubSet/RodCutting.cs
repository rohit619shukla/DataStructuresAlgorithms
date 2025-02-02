//using System;
//using System.Reflection;

//class Helper
//{

//    // Recursion
//    // Time : exponential, space : O(index)
//    //public int Solve(int[] price, int N, int index)
//    //{
//    //    // base case

//    //    if (index == 0)
//    //    {
//    //        return N * price[0];          // by default the value of 0th index will be 1 only, so the target will be multiplied by 1
//    //    }

//    //    int notPick = Solve(price, N, index - 1);

//    //    int roldLength = index + 1;          // indexing will be from 0 but rod cuts will start from 1

//    //    int pickSum = int.MinValue;

//    //    if (roldLength <= N)
//    //    {
//    //        pickSum = price[index] + Solve(price, N - roldLength, index);
//    //    }

//    //    return Math.Max(notPick, pickSum);
//    //}

//    // Memoization
//    // Time : O(index * N) , space : O(index * N) + O(index)
//    //public int Solve(int[] price, int N, int index, int[,] dp)
//    //{
//    //    // base case
//    //    if (index == 0)
//    //    {
//    //        return N * price[0];          // by default the value of 0th index will be 1 only, so the target will be multiplied by 1
//    //    }

//    //    if (dp[index, N] != -1)
//    //    {
//    //        return dp[index, N];
//    //    }

//    //    int notPick = Solve(price, N, index - 1, dp);

//    //    int pickSum = int.MinValue;

//    //    int rodLength = index + 1;          // indexing will be from 0 but rod cuts will start from 1

//    //    if (rodLength <= N)
//    //    {
//    //        pickSum = price[index] + Solve(price, N - rodLength, index, dp);
//    //    }

//    //    return dp[index, N] = Math.Max(notPick, pickSum);
//    //}

//    // Tabulation
//    // Time : O(index * N) , space : O(index * N)
//    //public int Solve(int[] price, int N, int index, int[,] dp)
//    //{
//    //    for (int i = 0; i <= N; i++)
//    //    {
//    //        dp[0, i] = i * price[0];
//    //    }

//    //    for (int i = 1; i <= index; i++)
//    //    {
//    //        for (int j = 0; j <= N; j++)
//    //        {
//    //            int notPick = dp[i - 1, j];

//    //            int pickSum = 0;

//    //            int rodLength = i + 1;

//    //            if (rodLength <= j)
//    //            {
//    //                pickSum = price[i] + dp[i, j - rodLength];
//    //            }

//    //            dp[i, j] = Math.Max(notPick, pickSum);
//    //        }
//    //    }

//    //    return dp[index, N];
//    //}

//    // Tabulation : Space optimization
//    // Time : O(index * N), space : O(index)
//    //public int Solve(int[] price, int N, int index)
//    //{
//    //    int[] prev = new int[N + 1];

//    //    for (int i = 0; i <= N; i++)
//    //    {
//    //        prev[i] = i * price[0];
//    //    }

//    //    for (int i = 1; i <= index; i++)
//    //    {
//    //        int[] curr = new int[N + 1];

//    //        for (int j = 0; j <= N; j++)
//    //        {
//    //            int notPick = prev[j];

//    //            int pickSum = 0;

//    //            int rodLength = i + 1;

//    //            if (rodLength <= j)
//    //            {
//    //                pickSum = price[i] + curr[j - rodLength];
//    //            }

//    //            curr[j] = Math.Max(notPick, pickSum);
//    //        }
//    //        prev = curr;
//    //    }

//    //    return prev[N];
//    //}

//    // Tabulation : Space optimization wit 1D array
//    // Time : O(index * N), space : O(index)
//    public int Solve(int[] price, int N, int index)
//    {
//        int[] prev = new int[N + 1];

//        for (int i = 0; i <= N; i++)
//        {
//            prev[i] = i * price[0];
//        }

//        for (int i = 1; i <= index; i++)
//        {

//            for (int j = 0; j <= N; j++)
//            {
//                int notPick = prev[j];

//                int pickSum = 0;

//                int rodLength = i + 1;

//                if (rodLength <= j)
//                {
//                    pickSum = price[i] + prev[j - rodLength];
//                }

//                prev[j] = Math.Max(notPick, pickSum);
//            }
//        }

//        return prev[N];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        //int[] price = { 2, 5, 7, 8, 10 };
//        int[] price = { 3, 5, 8, 9, 10, 17, 17, 20 };
//        //int N = 5;
//        int N = price.Length;

//        int[,] dp = new int[price.Length, N + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }
//        Helper h = new Helper();

//        //Console.WriteLine(h.Solve(price, N, price.Length - 1, dp));
//        Console.WriteLine(h.Solve(price, N, price.Length - 1));
//    }
//}