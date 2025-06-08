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
//                        // Think of j as giving us sources from which we can extend to reach index i.
//                        // We cannot do i++ becuase at dp[j] we might have a lis whose count maybe not 1 but bigger than one, and those will also get added to i

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