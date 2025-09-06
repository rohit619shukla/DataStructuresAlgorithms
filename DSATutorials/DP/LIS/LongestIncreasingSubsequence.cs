//using System;

//class Helper
//{
//    // Recursion
//    // Time : (2^n), space : O(n)
//    //public int Solve(int currIndex, int prevIndex, int[] arr)
//    //{

//    //    // base case

//    //    // If we are running over the bound starting from 0 to n-1
//    //    if (currIndex == arr.Length)
//    //    {
//    //        return 0;
//    //    }
//    //    // not take case
//    //    // Since we dont take, we will move to next index and keep prev index as same
//    //    int notTake = Solve(currIndex + 1, prevIndex, arr);

//    //    int take = 0;

//    //    // If the current element is 1st in sequence or the current is grater than prev
//    //    if (prevIndex == -1 || arr[currIndex] > arr[prevIndex])
//    //    {
//    //        take = 1 + Solve(currIndex + 1, currIndex, arr);
//    //    }

//    //    return Math.Max(take, notTake);
//    //}

//    // Memoization
//    // Time : O(n*m), space : O(n)
//    //public int Solve(int currIndex, int prevIndex, int[] arr, int[,] dp)
//    //{

//    //    // base case
//    //    // If we are running over the bount starting from 0 to n-1
//    //    if (currIndex == arr.Length)
//    //    {
//    //        return 0;
//    //    }

//    //    if (dp[currIndex, prevIndex + 1] != 0)
//    //    {
//    //        return dp[currIndex, prevIndex + 1];
//    //    }

//    //    // not take case
//    //    // Since we dont take, we will move to next index and keep prev index as same
//    //    int notTake = Solve(currIndex + 1, prevIndex, arr, dp);

//    //    int take = 0;

//    //    // If the current element is 1st in sequence or the current is grater than prev
//    //    if (prevIndex == -1 || arr[currIndex] > arr[prevIndex])
//    //    {
//    //        take = 1 + Solve(currIndex + 1, currIndex, arr, dp);
//    //    }

//    //    return dp[currIndex, prevIndex + 1] = Math.Max(take, notTake);
//    //}

//    // Tabulation
//    // Time : O(n*m) , space : O(n*m)
//    //    public int Solve(int[] arr)
//    //    {
//    //        int n = arr.Length;

//    //        int[,] dp = new int[arr.Length + 1, arr.Length + 1];

//    //        //Reverse of memoization
//    //        for (int curr = n - 1; curr >= 0; curr--)
//    //        {
//    //            for (int prev = curr - 1; prev >= -1; prev--)
//    //            {
//    //                int notTake = dp[curr + 1, prev + 1];

//    //                int take = 0;

//    //                if (prev == -1 || arr[curr] > arr[prev])
//    //                {
//    //                    take = 1 + dp[curr + 1, curr + 1];   // we are doing +1 at second index because at some point it will reach -1
//    //                }

//    //                dp[curr, prev + 1] = Math.Max(notTake, take);
//    //            }
//    //        }

//    //        // result would be stored in dp[0,-1[, but since we are doing co-ordinate shift 
//    //        return dp[0, 0];
//    //    }



//    // Time : O(n^2) , space :O(n)
//    public int Solve(int[] nums)
//    {
//        // Create a temp array :
//        int[] temp = new int[nums.Length];

//        // By default every element is a LIS in itself
//        Array.Fill(temp, 1);

//        int maxSeq = 1;

//        for (int i = 1; i < nums.Length; i++)
//        {
//            for (int j = 0; j <= i; j++)
//            {
//                if (nums[i] > nums[j])
//                {
//                    temp[i] = Math.Max(temp[i], temp[j] + 1);
//                }
//            }
//            maxSeq = Math.Max(maxSeq, temp[i]);
//        }

//        return maxSeq;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 7, 7, 7, 7, 7, 7, 7 };

//        Helper h = new Helper();
//        //Console.WriteLine(h.Solve(0, -1, arr));

//        // for memoization
//        int[,] dp = new int[arr.Length, arr.Length + 1];

//        //for (int i = 0; i < dp.GetLength(0); i++)
//        //{
//        //    for (int j = 0; j < dp.GetLength(1); j++)
//        //    {
//        //        dp[i, j] = 0;
//        //    }
//        //}

//        Console.WriteLine(h.Solve(arr));
//        //Console.WriteLine(h.Solve(0, -1, arr, dp));
//    }
//}

///// Note : Co - ordinate shifting is the key here as we are starting with -1