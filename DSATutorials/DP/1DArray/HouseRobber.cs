//using System;
//using System.Runtime.Intrinsics.Arm;


//class Helper
//{
//    // Recursion
//    // Time : O(2^n) , space: O(n)
//    //public int Solve(int[] arr, int index)
//    //{
//    //    if (index == 0)
//    //    {
//             // Take whatever is there
//    //        return arr[index];
//    //    }

//    //    int notPick = Solve(arr, index - 1);

//    //    int pick = arr[index];

//    //    if (index - 2 >= 0)
//    //    {
//    //        pick = arr[index] + Solve(arr, index - 2);
//    //    }

//    //    return Math.Max(notPick, pick);
//    //}


//    // Memoization
//    // Time : O(n) , space : O(n)
//    //public int Solve(int[] arr, int index, int[] dp)
//    //{
//    //    if (index == 0)
//    //    {
//    //        return arr[index];
//    //    }

//    //    if (dp[index] != -1)
//    //    {
//    //        return dp[index];
//    //    }
//    //    int notPick = Solve(arr, index - 1, dp);

//    //    int pick = arr[index];

//    //    if (index - 2 >= 0)
//    //    {
//    //        pick = arr[index] + Solve(arr, index - 2, dp);
//    //    }

//    //    return dp[index] = Math.Max(notPick, pick);
//    //}

//    // Tabulation
//    // Time : O(n) , space : O(n)
//    //public int Solve(int[] arr)
//    //{
//    //    int[] dp = new int[arr.Length + 1];

//    //    dp[0] = 0;

//    //    for (int i = 1; i < arr.Length; i++)
//    //    {
//    //        int notPick = dp[i - 1];

//    //        int pick = arr[i];

//    //        if (i - 2 >= 0)
//    //        {
//    //            pick = arr[i] + dp[i - 2];
//    //        }

//    //        dp[i] = Math.Max(notPick, pick);
//    //    }

//    //    return dp[arr.Length - 1];
//    //}

//    // Tabulation
//    // Time : O(n) , space : O(1)
//    //public int Solve(int[] arr)
//    //{
//    //    int prev = arr[0];
//    //    int prev2 = 0;

//    //    for (int i = 1; i < arr.Length; i++)
//    //    {
//    //        int notPick = prev;

//    //        int pick = arr[i] + prev2;

//    //        int temp = Math.Max(notPick, pick);
//    //        prev2 = prev;
//    //        prev = temp;
//    //    }

//    //    return prev;
//    //}
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 5, 1, 2, 6 };

//        int[] temp1 = new int[arr.Length];
//        int[] temp2 = new int[arr.Length];


//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (i != arr.Length - 1)
//            {
//                temp1[i] = arr[i];
//            }

//            if (i != 0)
//            {
//                temp2[i] = arr[i];
//            }
//        }

//        Helper h = new Helper();



//        int result1 = h.Solve(temp1);


//        int result2 = h.Solve(temp2);

//        Console.WriteLine(Math.Max(result1, result2));
//    }
//}