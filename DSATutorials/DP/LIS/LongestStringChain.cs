
//public class Solution
//{
//    // Time : O(nlogn) + O(n^2 *n), space :O(n)
//    public int LongestStrChain(string[] words)
//    {
//        // sort the array
//        Array.Sort(words, new StringComparison());

//        int[] dp = new int[words.Length];

//        Array.Fill(dp, 1);

//        int maxLen = 1;

//        // Apply LIS
//        for (int curr_idx = 1; curr_idx < words.Length; curr_idx++)
//        {
//            for (int prev_idx = 0; prev_idx <= curr_idx; prev_idx++)
//            {
//                if (CanFormLis(prev_idx, curr_idx, words))
//                {
//                    dp[curr_idx] = Math.Max(dp[curr_idx], dp[prev_idx] + 1);
//                }
//            }

//            maxLen = Math.Max(maxLen, dp[curr_idx]);
//        }

//        return maxLen;
//    }

//    private bool CanFormLis(int prev_idx, int curr_idx, string[] words)
//    {
//        string s1 = words[prev_idx];
//        string s2 = words[curr_idx];

//        if (s2.Length - s1.Length != 1)
//        {
//            return false;
//        }
//        int i = 0, j = 0;

//        while (i < s1.Length && j < s2.Length)
//        {
//            if (s1[i] == s2[j])
//            {
//                i++;
//            }
//            j++;

//        }

//        return (i == s1.Length);
//    }
//}

//internal class StringComparison : IComparer<string>
//{
//    public int Compare(string n1, string n2)
//    {
//        return n1.Length - n2.Length;
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