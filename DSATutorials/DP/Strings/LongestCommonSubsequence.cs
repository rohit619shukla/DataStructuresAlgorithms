//using System;

//class Helper
//{
//    // Recursion
//    // Time : O(2^n) , space : O(n)
//    //public int Solve(string s1, string s2, int index1, int index2)
//    //{
//    //    // base case

//    //    // If any one index goes out of bound we return 
//    //    if (index1 < 0 || index2 < 0)
//    //    {
//    //        return 0;
//    //    }

//    //    // Match case
//    //    if (s1[index1] == s2[index2])
//    //    {
//    //        // We have compared 1 character and it macthed, hence we add 1 to our sequence
//    //        // and we check on next char in line from both sequence
//    //        return 1 + Solve(s1, s2, index1 - 1, index2 - 1);
//    //    }

//    //    // Non match case

//    //    return Math.Max(Solve(s1, s2, index1 - 1, index2),
//    //                    Solve(s1, s2, index1, index2 - 1));
//    //}

//    // Memoization
//    // Time : O(index1 * index2) , space : O(index1 * index2)
//    //public int Solve(string s1, string s2, int index1, int index2, int[,] dp)
//    //{
//    //    // base case

//    //    if (index1 < 0 || index2 < 0)
//    //    {
//    //        return 0;
//    //    }

//    //    if (dp[index1, index2] != -1)
//    //    {
//    //        return dp[index1, index2];
//    //    }

//    //    if (s1[index1] == s2[index2])
//    //    {
//    //        return dp[index1, index2]  = 1 + Solve(s1, s2, index1 - 1, index2 - 1, dp);
//    //    }


//    //    return dp[index1, index2] = Math.Max(Solve(s1, s2, index1 - 1, index2, dp)
//    //                    , Solve(s1, s2, index1, index2 - 1, dp));
//    //}

//    // Tabulation
//    // Time : O(m*n ), space : O(m*n)
//    //public int Solve(string s1, string s2)
//    //{
//    //    int[,] dp = new int[s1.Length + 1, s2.Length + 1];

//    //    for (int i = 0; i <= s1.Length; i++)
//    //    {
//    //        for (int j = 0; j <= s2.Length; j++)
//    //        {
//    //            if (i == 0 || j == 0)
//    //            {
//    //                dp[i, j] = 0;
//    //            }
//    //            else if (s1[i - 1] == s2[j - 1])
//    //            {
//    //                dp[i, j] = 1 + dp[i - 1, j - 1];
//    //            }
//    //            else
//    //            {
//    //                dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
//    //            }
//    //        }
//    //    }

//    //    return dp[s1.Length, s2.Length];
//    //}

//    // Tabulation
//    // Time : O(m*n), space : O(n)
//    //public int Solve(string s1, string s2)
//    //{
//    //    int[] prev = new int[s1.Length + 1];

//    //    for (int i = 0; i <= s1.Length; i++)
//    //    {
//    //        int[] curr = new int[s2.Length + 1];
//    //        for (int j = 0; j <= s2.Length; j++)
//    //        {
//    //            if (i == 0 || j == 0)
//    //            {
//    //                curr[j] = 0;
//    //            }
//    //            else if (s1[i - 1] == s2[j - 1])
//    //            {
//    //                curr[j] = 1 + prev[j - 1];
//    //            }
//    //            else
//    //            {
//    //                curr[j] = Math.Max(prev[j], curr[j - 1]);
//    //            }
//    //        }
//    //        prev = curr;
//    //    }

//    //    return prev[s2.Length];
//    //}
//}

//class Program
//{
//    public static void Main()
//    {
//        string s1 = "acd";
//        string s2 = "ced";

//        int[,] dp = new int[s1.Length, s2.Length];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = 0;
//            }
//        }

//        Helper h = new Helper();
//        //Console.WriteLine(h.Solve(s1, s2, s1.Length - 1, s2.Length - 1, dp));

//        Console.WriteLine(h.Solve(s1, s2));
//    }
//}