

//class Solution
//{
//    // Time : O(N^2) , Space  : O(N) + O(N)
//    //public int Solve(int[] arr, int index, int k, int[] dp)
//    //{
//    //    // base case
//    //    if (index == arr.Length)
//    //    {
//    //        return 0;
//    //    }

//    //    if (dp[index] != -1)
//    //    {
//    //        return dp[index];
//    //    }

//    //    int maxNumber = int.MinValue;
//    //    int maxSum = int.MinValue;

//    //    // we dont want to run over hence we are using Math.Min in for loop
//    //    We use k +index because it that place where we want to stop after we have taken those many cuts
//    //    for (int i = index; i < Math.Min(k + index, arr.Length); i++)
//    //    {
//    //        maxNumber = Math.Max(maxNumber, arr[i]);

//    //        int currentSum = ((i - index + 1) * maxNumber) + Solve(arr, i + 1, k, dp);

//    //        maxSum = Math.Max(maxSum, currentSum);
//    //    }

//    //    return dp[index] = maxSum;

//    //}


//    // Time : O(N^2) , Space  : O(N) 
//    public int Solve(int[] arr, int k)
//    {
//        int[] dp = new int[arr.Length + 1];

//        for (int index = arr.Length - 1; index >= 0; index--)
//        {
//            int maxNumber = int.MinValue;
//            int maxSum = int.MinValue;

//            // we dont want to run over hence we are using Math.Min in for loop
//            for (int i = index; i < Math.Min(k + index, arr.Length); i++)
//            {
//                maxNumber = Math.Max(maxNumber, arr[i]);

//                int currentSum = ((i - index + 1) * maxNumber) + dp[i + 1];

//                maxSum = Math.Max(maxSum, currentSum);
//            }

//            dp[index] = maxSum;
//        }

//        return dp[0];

//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 15, 7, 9, 2, 5, 10 };

//        Solution s = new Solution();

//        int k = 3;
//        //int[] dp = new int[arr.Length + 1];

//        //Array.Fill(dp, -1);

//        //Console.WriteLine(s.Solve(arr, 0, k, dp));

//        Console.WriteLine(s.Solve(arr, k));
//    }
//}