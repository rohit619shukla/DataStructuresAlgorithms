
//class Solution
//{
//    public void Solve(int[] arr)
//    {
//        // We will take 2 arrays for solving this using DP
//        int[] dp = new int[arr.Length];    // for storing the dp results
//        int[] count = new int[arr.Length];  // for storing count

//        Array.Fill(dp, 1);
//        Array.Fill(count, 1);

//        for (int curr = 1; curr < arr.Length; curr++)
//        {
//            for (int prev = 0; prev < curr; prev++)
//            {
//                if (arr[curr] > arr[prev] && dp[prev] + 1 == dp[curr])
//                {
//                    count[curr] += count[prev];
//                }
//                else if (arr[curr] > arr[prev] && dp[prev] + 1 > dp[curr])
//                {
//                    dp[curr] = dp[prev] + 1;

//                    count[curr] = count[prev];
//                }

//            }
//        }

//        int longestCount = 0;
//        int max = int.MinValue;

//        for (int i = 0; i < dp.Length; i++)
//        {
//            if (max < dp[i])
//            {
//                max = dp[i];
//                longestCount = count[i];
//            }
//        }

//        Console.WriteLine(longestCount);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 3, 5, 4, 7 };

//        Solution s = new Solution();

//        s.Solve(arr);
//    }
//}

////Time Complexity: O(n^2) , Space Complexity: O(n)