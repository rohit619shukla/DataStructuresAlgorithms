//public class Solution
//{
//    // Time : O(n+m) both loops execute sequentially , space :O(1)
//    public int LengthOfLongestSubstring(string str)
//    {
//        if (string.IsNullOrEmpty(str))
//            return 0;

//        int[] freq = new int[128]; // covers standard ASCII
//        int i = 0, j = 0, maxlen = 0;

//        while (j < str.Length)
//        {
//            // Use the actual character code as index
//            while (freq[str[j]] != 0)
//            {
//                freq[str[i]]--;
//                i++;
//            }
//            freq[str[j]]++;
//            maxlen = Math.Max(maxlen, j - i + 1);
//            j++;
//        }
//        return maxlen;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "abcabcbb";

//        Solution s = new Solution();

//        Console.WriteLine(s.LengthOfLongestSubstring(str));
//    }
//}