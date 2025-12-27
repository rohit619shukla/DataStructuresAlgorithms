//public class Solution
//{
//    public string LongestPalindrome(string s)
//    {
//        int n = s.Length;

//        int startIndex = -1;
//        int maxLen = int.MinValue;
//        bool[,] dp = new bool[n + 1, n + 1];

//        for (int l = 1; l <= n; l++)
//        {
//            for (int i = 0; i + l - 1 < n; i++)
//            {
//                int j = i + l - 1;

//                if (l == 1 && s[i] == s[j])
//                {
//                    dp[i, j] = true;
//                    maxLen = 1;
//                    startIndex = i;
//                }
//                else if (l == 2 && s[i] == s[j])
//                {
//                    dp[i, j] = true;
//                    maxLen = 2;
//                    startIndex = i;
//                }
//                else if (s[i] == s[j] && dp[i + 1, j - 1] == true)
//                {
//                    dp[i, j] = true;
//                    startIndex = i;
//                    if (maxLen < j - i + 1)
//                    {
//                        maxLen = j - i + 1;
//                    }
//                }
//            }
//        }

//        return s.Substring(startIndex, maxLen);
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        string str = "babad";

//        Solution s = new Solution();

//        Console.WriteLine(s.LongestPalindrome(str));
//    }
//}

//// Note : This is the blueprint of solving the substring questions with palindromes. If doubt check codestorywithmik