//using System;

//class Helper
//{
//    // Recurison
//    // Time : Exponential, space : O(n)
//    //public int Solve(int[] arr, int i, int j)
//    //{
//    //    // base case

//    //    // we just have 1 element, which is not valid
//    //    if (i == j)
//    //    {
//    //        return 0;
//    //    }

//    //    int minCost = int.MaxValue;

//    //    // Although we are runnning till j-1, which is arr.len-1, but for us to k+1 scenario as non empty we need to run loop till k < j
//    //    for (int k = i; k < j; k++)
//    //    {
//    //        int cost = (arr[i - 1] * arr[k] * arr[j]) +
//    //            Solve(arr, i, k) +
//    //            Solve(arr, k + 1, j);'

//    //        minCost = Math.Min(minCost, cost);
//    //    }

//    //    return minCost;
//    //}

//    // Memoization
//    // TIme : O(n^3) , space : O(n) + O(n*m)
//    //There are N* N states and we explicitly run a loop inside the function which will run for N times, therefore at max ‘N* N*N’ new problems will be solved.
//    //public int Solve(int[] arr, int i, int j, int[,] dp)
//    //{
//    //    if (i == j)
//    //    {
//    //        return 0;
//    //    }

//    //    if (dp[i, j] != -1)
//    //    {
//    //        return dp[i, j];
//    //    }

//    //    int minCost = int.MaxValue;

//    //    for (int k = i; k < j; k++)
//    //    {
//    //        int cost = arr[i - 1] * arr[k] * arr[j] +
//    //            Solve(arr, i, k, dp) +
//    //            Solve(arr, k + 1, j, dp);

//    //        minCost = Math.Min(minCost, cost);
//    //    }

//    //    return dp[i, j] = minCost;
//    //}

//    // Tabulation
//    // Time : O(n^3) , space : O(n*m)
//    public int Solve(int[] arr)
//    {
//        // create a dp array
//        int[,] dp = new int[arr.Length, arr.Length];

//        // N-1 to 1
//        for (int i = arr.Length - 1; i >= 1; i--)
//        {
//            // i+1 to N-1 (bascially j will always be right to i)
//            for (int j = i + 1; j < arr.Length; j++)
//            {
//                int minCost = int.MaxValue;
//                for (int k = i; k < j; k++)  // the reason why wer are not going till j-1 is because this time i is moving from N-1 to 1 and k will also safely move move with it
//                {
//                    int cost = arr[i - 1] * arr[k] * arr[j] +
//                        dp[i, k] +
//                        dp[k + 1, j];

//                    minCost = Math.Min(minCost, cost);
//                }
//                dp[i, j] = minCost;
//            }
//        }

//        return dp[1, arr.Length - 1];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 10, 20, 30, 40, 50 };

//        Helper h = new Helper();

//        int[,] dp = new int[arr.Length, arr.Length];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }

//        if (arr.Length > 1)
//        {
//            //Console.WriteLine($"{h.Solve(arr, 1, arr.Length - 1, dp)}");
//            Console.WriteLine($"{h.Solve(arr)}");
//        }
//        else
//        {
//            Console.WriteLine(arr[0]);
//        }
//    }
//}


////Leetcode: Minimum Score Triangulation of Polygon (can be solved with this)