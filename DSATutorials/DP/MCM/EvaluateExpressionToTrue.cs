//using System;
//class Helper
//{
//    const int mod = (int)1e9 + 7;

//    // Recursion
//    // Time : Exponential
//    //private long Solve(string exp, int i, int j, int isTrue)
//    //{
//    //    // base case
//    //    // 1. If the string becomes invalid
//    //    if (i > j)
//    //    {
//    //        return 0;
//    //    }

//    //    // 2. If only 1 char remains
//    //    if (i == j)
//    //    {
//    //        // If we are looking for a true, then if the current char is true we return 1 else 0
//    //        if (isTrue == 1)
//    //        {
//    //            return exp[i] == 'T' ? 1 : 0;
//    //        }
//    //        else
//    //        {
//    //            // If we are looking for a false, then if the current char is false we return 1 else 0
//    //            return exp[i] == 'F' ? 1 : 0;
//    //        }
//    //    }

//    //    long ways = 0;

//    //    // Add partition from i+1 becoz we are gonna partition on operator only which will come after 2 hops starting from i+1
//    //    for (int indx = i + 1; indx <= j - 1; indx += 2)
//    //    {
//    //        // There will always be 4 ways to partition
//    //        long lT = Solve(exp, i, indx - 1, 1);
//    //        long lF = Solve(exp, i, indx - 1, 0);
//    //        long rT = Solve(exp, indx + 1, j, 1);
//    //        long rF = Solve(exp, indx + 1, j, 0);

//    //        // get the current operator at location
//    //        char ch = exp[indx];

//    //        // we will always have 3 operator
//    //        switch (ch)
//    //        {
//    //            case '&':

//    //                // for each operator break we will check for both true and false sides we obtained before
//    //                if (isTrue == 1)
//    //                {
//    //                    ways += lT * rT;
//    //                }
//    //                else
//    //                {
//    //                    ways += (lT * rF) + (lF * rT) + (lF * rF);
//    //                }
//    //                break;

//    //            case '|':
//    //                if (isTrue == 1)
//    //                {
//    //                    ways += (lT * rT) + (lT * rF) + (lF * rT);
//    //                }
//    //                else
//    //                {
//    //                    ways += lF * rF;
//    //                }
//    //                break;

//    //            case '^':
//    //                if (isTrue == 1)
//    //                {
//    //                    ways += (lT * rF) + (lF * rT);
//    //                }
//    //                else
//    //                {
//    //                    ways += (lT * rT) + (lF * rF);
//    //                }
//    //                break;
//    //        }
//    //    }

//    //    return ways % mod;
//    //}

//    // Memoization
//    // Time : O(N*N*2 * N) ~ O(N3), we are using dp Array of size N*N and the looping outside for N
//    // space : O(2*N2) + Auxiliary stack space of O(N), 2*N2 for the dp array we are using.
//    private long Solve(string exp, int i, int j, int isTrue, long[,,] dp)
//    {
//        // base case
//        // 1. If the string becomes invalid
//        if (i > j)
//        {
//            return 0;
//        }

//        // 2. If only 1 char remains
//        if (i == j)
//        {
//            // If we are looking for a true, then if the current char is true we return 1 else 0
//            if (isTrue == 1)
//            {
//                return exp[i] == 'T' ? 1 : 0;
//            }
//            else
//            {
//                // If we are looking for a false, then if the current char is false we return 1 else 0
//                return exp[i] == 'F' ? 1 : 0;
//            }
//        }

//        if (dp[i, j, isTrue] != -1)
//        {
//            return dp[i, j, isTrue];
//        }

//        long ways = 0;

//        // Add partition from i+1 becoz we are gonna partition on operator only which will come after 2 hops starting from i+1
//        for (int indx = i + 1; indx <= j - 1; indx += 2)
//        {
//            // There will always be 4 ways to partition
//            long lT = Solve(exp, i, indx - 1, 1, dp);
//            long lF = Solve(exp, i, indx - 1, 0, dp);
//            long rT = Solve(exp, indx + 1, j, 1, dp);
//            long rF = Solve(exp, indx + 1, j, 0, dp);

//            // get the current operator at location
//            char ch = exp[indx];

//            // we will always have 3 operator
//            switch (ch)
//            {
//                case '&':

//                    // for each operator break we will check for both true and false sides we obtained before
//                    if (isTrue == 1)
//                    {
//                        ways += lT * rT;
//                    }
//                    else
//                    {
//                        ways += (lT * rF) + (lF * rT) + (lF * rF);
//                    }
//                    break;

//                case '|':
//                    if (isTrue == 1)
//                    {
//                        ways += (lT * rT) + (lT * rF) + (lF * rT);
//                    }
//                    else
//                    {
//                        ways += lF * rF;
//                    }
//                    break;

//                case '^':
//                    if (isTrue == 1)
//                    {
//                        ways += (lT * rF) + (lF * rT);
//                    }
//                    else
//                    {
//                        ways += (lT * rT) + (lF * rF);
//                    }
//                    break;
//            }
//        }

//        return dp[i, j, isTrue] = ways % mod;
//    }

//    public int Evaluate(string exp)
//    {
//        //return (int)Solve(exp, 0, exp.Length - 1, 1);

//        // We take 2 in dp becoz of 1/0 in true of false
//        long[,,] dp = new long[exp.Length, exp.Length, 2];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                for (int k = 0; k < dp.GetLength(2); k++)
//                {
//                    dp[i, j, k] = -1;
//                }
//            }
//        }

//        return (int)Solve(exp, 0, exp.Length - 1, 1, dp);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string exp = "F|T^F";
//        //string exp = "T|T&F^T";

//        Helper h = new Helper();
//        Console.WriteLine(h.Evaluate(exp));
//    }
//}