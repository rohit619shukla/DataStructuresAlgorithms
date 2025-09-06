
//public class Solution
//{
//    //    Time Complexity: O(N* M)
//    public string ShortestCommonSupersequence(string str1, string str2)
//    {
//        int[,] dp = new int[str1.Length + 1, str2.Length + 1];

//        for (int i = 0; i <= str1.Length; i++)
//        {
//            for (int j = 0; j <= str2.Length; j++)
//            {
//                if (i == 0 || j == 0)
//                {
//                    continue;
//                }

//                if (str1[i - 1] == str2[j - 1])
//                {
//                    dp[i, j] = 1 + dp[i - 1, j - 1];
//                }
//                else
//                {
//                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
//                }
//            }
//        }

//        int lcs_length = dp[str1.Length, str2.Length];
//        int x = str1.Length, y = str2.Length;
//        // This is the whole crux. The SCS of two string is given by followinf formula
//        char[] charArray = new char[str1.Length + str2.Length - lcs_length];
//        int count = charArray.Length;

//        while (x > 0 && y > 0)
//        {
//            if (str1[x - 1] == str2[y - 1])
//            {
//                charArray[count - 1] = str1[x - 1];
//                x--;
//                y--;
//            }
//            else
//            {
//                if (dp[x - 1, y] > dp[x, y - 1])
//                {
//                    charArray[count - 1] = str1[x - 1];
//                    x--;
//                }
//                else
//                {
//                    charArray[count - 1] = str2[y - 1];
//                    y--;
//                }
//            }
//            count--;
//        }

//        while (x > 0)
//        {
//            charArray[count - 1] = str1[x - 1];
//            x--;
//            count--;
//        }

//        while (y > 0)
//        {
//            charArray[count - 1] = str2[y - 1];
//            y--;
//            count--;
//        }

//        return new string(charArray);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string s1 = "aaaaaaaa";
//        string s2 = "aaaaaaaa";

//        Solution s = new Solution();

//        Console.WriteLine(s.ShortestCommonSupersequence(s1, s2));
//    }
//}