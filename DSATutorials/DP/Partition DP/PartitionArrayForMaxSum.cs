
//public class Solution
//{
//    public int MaxSumAfterPartitioning(int[] arr, int k)
//    {
//        //int[] dp = new int[arr.Length];

//        //Array.Fill(dp, -1);

//        //return Solve(arr, 0, k, dp);

//        return Solve(arr, k);
//    }


//    // Time : O(K^n) , space :O(n) + O(n)
//    private int Solve(int[] arr, int startIndex, int k, int[] dp)
//    {
//        // base case
//        if (startIndex >= arr.Length)
//        {
//            return 0;
//        }

//        if (dp[startIndex] != -1)
//        {
//            return dp[startIndex];
//        }

//        int currentMax = int.MinValue;
//        int maxSum = int.MinValue;

//        for (int j = startIndex; j < arr.Length && j - startIndex + 1 <= k; j++)
//        {
//            currentMax = Math.Max(currentMax, arr[j]);

//            int multipliedValue = currentMax * (j - startIndex + 1);

//            maxSum = Math.Max(maxSum, multipliedValue + Solve(arr, j + 1, k, dp));
//        }

//        return dp[startIndex] = maxSum;
//    }

//    // Time : O(n*k) , space : O(n)
//    private int Solve(int[] arr, int k)
//    {
//        int[] dp = new int[arr.Length + 1];

//        for (int startIndex = arr.Length - 1; startIndex >= 0; startIndex--)
//        {
//            int currentMax = int.MinValue;
//            int maxSum = int.MinValue;

//            for (int j = startIndex; j < arr.Length && j - startIndex + 1 <= k; j++)
//            {
//                currentMax = Math.Max(currentMax, arr[j]);

//                int multipliedValue = currentMax * (j - startIndex + 1);

//                maxSum = Math.Max(maxSum, multipliedValue + dp[j + 1]);
//            }

//            dp[startIndex] = maxSum;
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

//        Console.WriteLine(s.MaxSumAfterPartitioning(arr, 3));
//    }
//}