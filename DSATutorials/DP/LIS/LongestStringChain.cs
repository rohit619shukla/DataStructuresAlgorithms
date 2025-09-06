//public class Solution
//{
//    // Time : O(nlogn) + O(n^2 *n), space :O(n)
//    public int LongestStrChain(string[] words)
//    {
//        // Sort the word array so that we can get a better answer. We will sort on legnth of each words
//        // No where mentioned not to sort

//        Array.Sort(words, new Comparison());

//        int[] dp = new int[words.Length];

//        // Every word is LIS in itself
//        Array.Fill(dp, 1);

//        int max = int.MinValue;

//        // Perform modified LIS but core logic remains same
//        for (int curr = 1; curr < words.Length; curr++)
//        {
//            for (int prev = 0; prev < curr; prev++)
//            {
//                if (IsSubsequence(words[prev], words[curr]))
//                {
//                    dp[curr] = Math.Max(dp[curr], dp[prev] + 1);
//                }
//            }
//            max = Math.Max(max, dp[curr]);
//        }
//        return max;
//    }

//    private bool IsSubsequence(string s1, string s2)
//    {
//        // The difference has to be equal to 1, as we need to insert exactly 1 word only
//        if (s2.Length - s1.Length != 1)
//        {
//            return false;
//        }

//        int x = 0;
//        int y = 0;

//        while (x < s1.Length && y < s2.Length)
//        {
//            if (s1[x] == s2[y])
//            {
//                x++;
//            }
//            // y will anyway keep on increase
//            y++;
//        }

//        // as we have gone over x we know that subsequence is there
//        return x == s1.Length;
//    }
//}


//internal class Comparison : IComparer<string>
//{
//    public int Compare(string s1, string s2)
//    {
//        return s1.Length.CompareTo(s2.Length);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string[] words = { "xbc", "pcxbcf", "xb", "cxbc", "pcxbc" };

//        Solution s = new Solution();

//        Console.WriteLine(s.LongestStrChain(words));

//    }
//}