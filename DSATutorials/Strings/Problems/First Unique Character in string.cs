//public class Solution
//{
//    // Time : O(n) , space :O(1)
//    public int FirstUniqChar(string s)
//    {
//        int[] freq = new int[26];

//        for (int i = 0; i < s.Length; i++)
//        {
//            freq[s[i] - 'a']++;
//        }

//        for (int j = 0; j < s.Length; j++)
//        {
//            int index = s[j] - 'a';
//            if (freq[index] == 1)
//            {
//                return j;
//            }
//        }
//        return -1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "leetcode";

//        Solution sol = new Solution();
//        Console.WriteLine(sol.FirstUniqChar(str));
//    }
//}