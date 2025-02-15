//public class Solution
//{
//    public int StrStr(string haystack, string needle)
//    {
//        if (string.IsNullOrWhiteSpace(haystack) || string.IsNullOrWhiteSpace(needle))
//        {
//            return -1;
//        }

//        return Solve(haystack, needle);
//    }

//    private int Solve(string str, string pattern)
//    {
//        // Step 1: Create LPS
//        int[] lps = new int[pattern.Length];
//        LPS(lps, pattern);

//        // Step 2: Perform actual comparison
//        int i = 0, j = 0;

//        while (i < str.Length)
//        {
//            if (str[i] == pattern[j])
//            {
//                i++;
//                j++;
//            }

//            if (j == pattern.Length)
//            {
//                return i - j;
//            }
//            else if (i < str.Length && j < pattern.Length && str[i] != pattern[j])
//            {
//                if (j == 0)
//                {
//                    i++;
//                }
//                else
//                {
//                    j = lps[j - 1];
//                }
//            }
//        }
//        return -1;
//    }

//    private void LPS(int[] lps, string pattern)
//    {
//        int i = 0, j = 1;

//        while (j < pattern.Length)
//        {
//            if (pattern[i] == pattern[j])
//            {
//                lps[j] = i + 1;
//                i++;
//                j++;
//            }
//            else
//            {
//                if (i == 0)
//                {
//                    lps[j] = 0;
//                    j++;
//                }
//                else
//                {
//                    i = lps[i - 1];
//                }
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string haystack = "abc";
//        string needle = "c";

//        Solution s = new Solution();

//        Console.WriteLine(s.StrStr(haystack, needle));
//    }
//}