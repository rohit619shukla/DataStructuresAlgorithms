// Same code as min coin with only diff that here we are counting ways, over there how many denimincations

//using System;

//class Helper
//{
//    // Recursion
//    // Time : exponential, space : O(index)
//    //public int Solve(int[] arr, int index, int target)
//    //{
//    //    // base case
//    //    if (index == 0)
//    //    {
//    //        if (target % arr[index] == 0)
//    //        {
//    //            return 1;
//    //        }
//    //        else
//    //        {
//    //            return 0;
//    //        }
//    //    }

//    //    int notPick = Solve(arr, index - 1, target);

//    //    int pick = 0;

//    //    if (arr[index] <= target)
//    //    {
//    //        pick = Solve(arr, index, target - arr[index]);
//    //    }

//    //    return pick + notPick;
//    //}

//    // Memoization
//    // Time : O(index * target) , space : O(index * target) + O(index)
//    //public int Solve(int[] arr, int index, int target, int[,] dp)
//    //{
//    //    // base case
//    //    if (index == 0)
//    //    {
//    //        if (target % arr[index] == 0)
//    //        {
//    //            return 1;
//    //        }
//    //        else
//    //        {
//    //            return 0;
//    //        }
//    //    }

//    //    if (dp[index, target] != -1)
//    //    {
//    //        return dp[index, target];
//    //    }

//    //    int notPick = Solve(arr, index - 1, target, dp);

//    //    int pick = 0;

//    //    if (arr[index] <= target)
//    //    {
//    //        pick = Solve(arr, index, target - arr[index], dp);
//    //    }

//    //    return dp[index, target] = pick + notPick;
//    //}

//    // Memoization
//    // Time : O(index * target) , space : O(index * target)
//    //public int Solve(int[] arr, int index, int target, int[,] dp)
//    //{
//    //    // base case
//    //    for (int i = 0; i <= target; i++)
//    //    {
//    //        if (target % arr[0] == 0)
//    //        {
//    //            dp[0, i] = 1;
//    //        }
//    //        else
//    //        {
//    //            dp[0, i] = 0;
//    //        }
//    //    }

//    //    for (int i = 1; i <= index; i++)
//    //    {
//    //        for (int j = 0; j <= target; j++)
//    //        {
//    //            int notPick = dp[i - 1, j];

//    //            int pick = 0;

//    //            if (arr[i] <= j)
//    //            {
//    //                pick = dp[i, j - arr[i]];
//    //            }

//    //            dp[i, j] = notPick + pick;
//    //        }
//    //    }

//    //    return dp[index, target];
//    //}

//    // Tabulation
//    // Time : O(index * target) , space : O(index)
//    public int Solve(int[] arr, int index, int target)
//    {
//        int[] prev = new int[target + 1];

//        for (int i = 0; i <= target; i++)
//        {
//            if (i % arr[0] == 0)
//            {
//                prev[i] = 1;
//            }
//            else
//            {
//                prev[i] = 0;
//            }
//        }

//        for (int i = 1; i <= index; i++)
//        {
//            int[] curr = new int[target + 1];

//            for (int j = 0; j <= target; j++)
//            {
//                int notPick = prev[j];

//                int pick = 0;

//                if (arr[i] <= j)
//                {
//                    pick = curr[j - arr[i]];
//                }

//                curr[j] = notPick + pick;
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
//        int[] arr = { 1, 2, 5 };
//        int target = 5;

//        Helper h = new Helper();

//        int[,] dp = new int[arr.Length, target + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }

//        //Console.WriteLine(h.Solve(arr, arr.Length - 1, target, dp));

//        Console.WriteLine(h.Solve(arr, arr.Length - 1, target));
//    }
//}