//public class Solution
//{

//    // Time : O(N^2 * L) , space : O(N)
//    public int LongestStrChain(string[] words)
//    {

//        // 1. Sort the array based on length of words, it will make life easier
//        Array.Sort(words, new SortClass());

//        // 2. Apply LIS with modified check 

//        int[] dp = new int[words.Length];

//        Array.Fill(dp, 1);

//        int maxLen = 0;
//        for (int curr = 1; curr < words.Length; curr++)
//        {
//            for (int prev = 0; prev < curr; prev++)
//            {
//                if (IsOkToProceed(words[prev], words[curr]))
//                {
//                    dp[curr] = Math.Max(dp[prev] + 1, dp[curr]);
//                }
//            }

//            maxLen = Math.Max(maxLen, dp[curr]);
//        }

//        return maxLen;
//    }

//    private bool IsOkToProceed(string prev, string curr)
//    {
//        // The difference between the string should be exactly 1
//        // Since the array is already sorted we are good
//        if (curr.Length - prev.Length != 1)
//        {
//            return false;
//        }

//        // keep 2 pointers and increment to check for comparisons
//        int prev_ptr = 0, curr_ptr = 0;

//        // Since we expect the length of prev to be either same or 1 less than curr
//        while (prev_ptr < prev.Length && curr_ptr < curr.Length)
//        {
//            if (prev[prev_ptr] == curr[curr_ptr])
//            {
//                prev_ptr++;
//            }
//            curr_ptr++;
//        }

//        // The prev pointer has reached end of string meaning we are good and go the answer
//        return prev_ptr == prev.Length;
//    }
//}

//internal class SortClass : IComparer<string>
//{
//    public int Compare(string a, string b)
//    {
//        return a.Length - b.Length;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string[] words = { "a" };

//        Solution s = new Solution();

//        Console.WriteLine(s.LongestStrChain(words));
//    }
//}