//using System;
//using System.ComponentModel.DataAnnotations;
//using System.Runtime.Intrinsics.Arm;

//class Helper
//{
//    // Recursion
//    // Time : exponential, space : O(n)
//    //public int Solve(string s1, string s2, int i, int j)
//    //{
//    //    // base case
//    //    // 1. string 1 got exhausted, but string 2 is there, so you will need j+1 operation to convert empty string 1 to 2 
//    //    if (i < 0)
//    //    {
//    //        return j + 1;
//    //    }

//    //    // 2. string 2 got exhausted, but string 1 is there, so you will need i+1 operation to convert empty string 2 to 1 
//    //    if (j < 0)
//    //    {
//    //        return i + 1;
//    //    }

//    //    // characters of string got matched, no operation needs to be performed further but lets shrink size of string
//    //    if (s1[i] == s2[j])
//    //    {
//    //        return Solve(s1, s2, i - 1, j - 1);
//    //    }
//    //    else
//    //    {
//    //        return 1 + Math.Min(
//    //            Solve(s1, s2, i, j - 1),  // Insert operation, here some char has been inserted in front of i hypothetically
//    //            Math.Min(
//    //                Solve(s1, s2, i - 1, j),  // Deletion operation, reduce i by 1
//    //                Solve(s1, s2, i - 1, j - 1))); // Replace operation, since we have replaced something so there is a match, hence reduce
//    //    }
//    //}


//    // Memoization
//    // Time : O(n*m) , space :(n*m)
//    //public int Solve(string s1, string s2, int i, int j, int[,] dp)
//    //{
//    //    if (i < 0)
//    //    {
//    //        return j + 1;
//    //    }

//    //    if (j < 0)
//    //    {
//    //        return i + 1;
//    //    }

//    //    if (dp[i, j] != -1)
//    //    {
//    //        return dp[i, j];
//    //    }

//    //    if (s1[i] == s2[j])
//    //    {
//    //        return dp[i, j] = Solve(s1, s2, i - 1, j - 1, dp);
//    //    }
//    //    else
//    //    {
//    //        return dp[i, j] = 1 + Math.Min(
//    //            Solve(s1, s2, i, j - 1, dp),
//    //            Math.Min(
//    //                Solve(s1, s2, i - 1, j, dp),
//    //                Solve(s1, s2, i - 1, j - 1, dp)));
//    //    }
//    //}

//    // Tabulation
//    // Time : O(n*m) , space : O(n*m)
//    public int Solve(string s1, string s2)
//    {
//        int[,] dp = new int[s1.Length + 1, s2.Length + 1];

//        // base case

//        // 1. string 1 got exhausted
//        for (int j = 0; j <= s2.Length; j++)
//        {
//            dp[0, j] = j;
//        }

//        // 2. string 2 got exhausted
//        for (int i = 0; i <= s1.Length; i++)
//        {
//            dp[i, 0] = i;
//        }

//        for (int i = 1; i <= s1.Length; i++)
//        {
//            for (int j = 1; j <= s2.Length; j++)
//            {
//                if (s1[i - 1] == s2[j - 1])
//                {
//                    dp[i, j] = dp[i - 1, j - 1];
//                }
//                else
//                {
//                    dp[i, j] = 1 + Math.Min(
//                        dp[i, j - 1],
//                        Math.Min(
//                            dp[i - 1, j],
//                            dp[i - 1, j - 1]));
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
//        string s1 = "horse";
//        string s2 = "ros";

//        Helper h = new Helper();

//        int[,] dp = new int[s1.Length + 1, s2.Length + 1];

//        for (int i = 0; i <= s1.Length; i++)
//        {
//            for (int j = 0; j <= s2.Length; j++)
//            {
//                dp[i, j] = -1;
//            }
//        }

//        //Console.WriteLine(h.Solve(s1, s2, s1.Length - 1, s2.Length - 1, dp));
//        Console.WriteLine(h.Solve(s1, s2));
//    }
//}