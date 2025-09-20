//using System;

//class Helper
//{
//    // Time : O(N^3) , space : O(n)
//    //public int Solve(string str, int index)
//    //{
//    //    if (index == str.Length)
//    //    {
//    //        return 0;
//    //    }

//    //    int minCost = int.MaxValue;

//    //    for (int k = index; k < str.Length; k++)
//    //    {
//    //        if (IsPalindrome(str, index, k))
//    //        {
//    //            int currCost = 1 + Solve(str, k + 1);  // Where k stops new string begins

//    //            minCost = Math.Min(minCost, currCost);
//    //        }
//    //    }

//    //    return minCost;
//    //}

//    // Time : O(N^2), space : O(N)
//    //public int Solve(string str, int index, int[] dp)
//    //{
//    //    if (index == str.Length)
//    //    {
//    //        return 0;
//    //    }

//    //    if (dp[index] != -1)
//    //    {
//    //        return dp[index];
//    //    }

//    //    int minCost = int.MaxValue;

//    //    for (int k = index; k < str.Length; k++)
//    //    {
//    //        if (IsPalindrome(str, index, k))
//    //        {
//    //            int currCost = 1 + Solve(str, k + 1, dp);  // Where k stops new string begins

//    //            minCost = Math.Min(minCost, currCost);
//    //        }
//    //    }

//    //    return dp[index] = minCost;
//    //}


//    // Time : O(N^2) , space : O(N)
//    public int Solve(string str)
//    {
//        int[] dp = new int[str.Length + 1];

//        for (int index = str.Length - 1; index >= 0; index--)
//        {
//            int minCost = int.MaxValue;

//            for (int k = index; k < str.Length; k++)
//            {
//                if (IsPalindrome(str, index, k))
//                {
//                    int currCost = 1 + dp[k + 1];

//                    minCost = Math.Min(minCost, currCost);
//                }
//            }

//            dp[index] = minCost;
//        }

//        return dp[0];
//    }

//    private bool IsPalindrome(string str, int lb, int ub)
//    {
//        while (lb < ub)
//        {
//            if (str[lb] != str[ub])
//            {
//                return false;
//            }

//            lb++;
//            ub--;
//        }

//        return true;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string str = "BABABCBADCEDE";

//        Helper h = new Helper();

//        //int[] dp = new int[str.Length + 1];

//        //Array.Fill(dp, -1);

//        //Console.WriteLine(h.Solve(str, 0, dp) - 1);

//        Console.WriteLine(h.Solve(str) - 1);
//    }
//}