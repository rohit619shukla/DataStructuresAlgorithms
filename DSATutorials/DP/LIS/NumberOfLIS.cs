//public class Solution
//{
//    // Time O(N^2) , space :O(n)
//    public int FindNumberOfLIS(int[] nums)
//    {
//        int[] dp = new int[nums.Length];
//        int[] count = new int[nums.Length];

//        Array.Fill(dp, 1);
//        Array.Fill(count, 1);

//        int maxlen = 1;
//        for (int i = 1; i < nums.Length; i++)
//        {
//            for (int j = 0; j < i; j++)
//            {
//                // Usual LIS check
//                if (nums[i] > nums[j])
//                {
//                    if (dp[j] + 1 > dp[i])
//                    {
//                        dp[i] = dp[j] + 1;

//                        // Since we are seeing this LIS for first time, we might have found a better LIS and it is derived from adding 1 to j
//                        count[i] = count[j];
//                    }
//                    else if (dp[j] + 1 == dp[i])
//                    {
//                        // At index j we might have already got a similar sequence length hence add it

//                        count[i] += count[j];
//                    }
//                }
//            }

//            // Will be used at last to get the final count
//            maxlen = Math.Max(maxlen, dp[i]);
//        }

//        int ans = 0;
//        for (int i = 0; i < nums.Length; i++)
//        {
//            if (dp[i] == maxlen)
//            {
//                ans += count[i];
//            }
//        }
//        return ans;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 3, 5, 4, 7 };

//        Solution s = new Solution();

//        Console.WriteLine(s.FindNumberOfLIS(arr));
//    }
//}