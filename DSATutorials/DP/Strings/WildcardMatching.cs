//using System;
//using System.Security.Cryptography;

//class Helper
//{
//    // Memoization
//    // Time : O(n*m), space : O(n*m)
//    //public bool Solve(string str, string pattern, int strLength, int patternLength, bool[,] dp)
//    //{
//    //    // base case
//    //    if (strLength < 0 && patternLength < 0)
//    //    {
//    //        return true;
//    //    }

//    //    // 1. if string itslef is exhausted
//    //    if (strLength < 0 && patternLength >= 0)
//    //    {
//    //        for (int k = 0; k <= patternLength; k++)
//    //        {
//    //            if (pattern[k] != '*')
//    //            {
//    //                return false;
//    //            }
//    //        }

//    //        return true;
//    //    }

//    //    // 2. If pattern is exhausted
//    //    if (patternLength < 0 && strLength >= 0)
//    //    {
//    //        return false;
//    //    }

//    //    if (dp[strLength, patternLength] != false)
//    //    {
//    //        return dp[strLength, patternLength];
//    //    }

//    //    if (str[strLength] == pattern[patternLength] || pattern[patternLength] == '?')
//    //    {
//    //        return Solve(str, pattern, strLength - 1, patternLength - 1, dp);
//    //    }

//    //    if (pattern[patternLength] == '*')
//    //    {
//    //It can match or it cannot match with any character
//    //        return Solve(str, pattern, strLength - 1, patternLength, dp) || Solve(str, pattern, strLength, patternLength - 1, dp);
//    //    }

//    //    return false;
//    //}


//    // Tabulation
//    // Time : O(n*m), space : O(n)
//    public bool Solve(string str, string pattern)
//    {
//        bool[,] dp = new bool[str.Length + 1, pattern.Length + 1];

//        // base case

//        // 1. Both got exhausted
//        dp[0, 0] = true;


//        // 2. string got exhausted but pattern is left with some char
//        for (int i = 1; i <= pattern.Length; i++)
//        {
//            if (pattern[i - 1] != '*')
//            {
//                dp[0, i] = false;
//                break;
//            }
//            else
//            {
//                dp[0, i] = true;

//            }

//        }

//        // 3. pattern got exhasuted
//        for (int j = 1; j <= str.Length; j++)
//        {
//            dp[j, 0] = false;
//        }

//        // Recurrence
//        for (int i = 1; i <= str.Length; i++)
//        {
//            for (int j = 1; j <= pattern.Length; j++)
//            {
//                if (str[i - 1] == pattern[j - 1] || pattern[j - 1] == '?')
//                {
//                    dp[i, j] = dp[i - 1, j - 1];
//                }
//                else
//                {
//                    if (pattern[j - 1] == '*')
//                    {
//                        dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
//                    }
//                }
//            }
//        }
//        return dp[str.Length, pattern.Length];
//    }

//    private bool IsAllStars(string s, int indx)
//    {
//        for (int i = 0; i < indx; i++)
//        {
//            if (s[i] != '*')
//            {
//                return false;
//            }
//        }
//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "aa";
//        string pattern = "*";

//        Helper h = new Helper();

//        bool[,] dp = new bool[str.Length + 1, pattern.Length + 1];

//        //Console.WriteLine(h.Solve(str, pattern, str.Length - 1, pattern.Length - 1, dp));

//        Console.WriteLine(h.Solve(str, pattern));
//    }
//}