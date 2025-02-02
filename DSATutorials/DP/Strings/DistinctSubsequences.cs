//using System;
//using System.Runtime.Intrinsics.Arm;

//class Helper
//{
//    // Memoization
//    // Time: O(m*n) , space : O(n) + O(m*n)
//    //public int Solve(string s1, string s2, int i, int j, int[,] dp)
//    //{
//    //    // if s2 goes below the limit, then it means the entire string s2 was matched. Hence we want to make sure that s2 is checked first or else we will get wrong result
//    //    if (j < 0)
//    //    {
//    //        return 1;
//    //    }

//    //    // if s1 goes below the limit, then we cannot get a match
//    //    if (i < 0)
//    //    {
//    //        return 0;
//    //    }

//    //    if (dp[i, j] != -1)
//    //    {
//    //        return dp[i, j];
//    //    }

//    //    // match found
//    //    if (s1[i] == s2[j])
//    //    {
//    //        //case1:
// either both of them matches or else we iognore the char from first string and try it out another char in second string
//    //        return dp[i, j] = Solve(s1, s2, i - 1, j - 1, dp) + Solve(s1, s2, i - 1, j, dp);
//    //    }
//    //    else
//    //    {
//    //        // no match found
//    //        // we need to shrink the found path to get somewhere
//    //        return dp[i, j] = Solve(s1, s2, i - 1, j, dp);
//    //    }
//    //}

//    // Tabulation
//    // Time : O(m*n) , space: O(m*n)
//    public int Solve(string s1, string s2)
//    {
//        int[,] dp = new int[s1.Length + 1, s2.Length + 1];

//        for (int i = 0; i <= s1.Length; i++)
//        {
//            dp[i, 0] = 1;
//        }

//        // note : here we dont want to take second loop for initialize since the dp array itself is 0

//        for (int x = 1; x <= s1.Length; x++)
//        {
//            for (int y = 1; y <= s2.Length; y++)
//            {
//                // match found
//                if (s1[x - 1] == s2[y - 1])
//                {
//                    dp[x, y] = dp[x - 1, y - 1] + dp[x - 1, y];
//                }
//                else
//                {
//                    // no match found
//                    // we need to shrink the found path to get somewhere
//                    dp[x, y] = dp[x - 1, y];
//                }
//            }
//        }

//        return dp[s1.Length, s2.Length];
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        string str1 = "babgbag";
//        string str2 = "bag";

//        Helper h = new Helper();

//        //int[,] dp = new int[str1.Length + 1, str2.Length + 1];

//        //for (int i = 0; i < str1.Length; i++)
//        //{
//        //    for (int j = 0; j < str2.Length; j++)
//        //    {
//        //        dp[i, j] = -1;
//        //    }
//        //}

//        //Console.WriteLine(h.Solve(str1, str2, str1.Length - 1, str2.Length - 1, dp));

//        Console.WriteLine(h.Solve(str1, str2));

//    }
//}