

//using System;
//using System.Reflection;

//class Soltuion
//{
//    public int NumDecodings(string s)
//    {
//        //int[] dp = new int[s.Length + 1];

//        //Array.Fill(dp, -1);

//        //return Solve(s, 0, dp);

//        return Solve(s);
//    }

//    //Time : O(n) , space :O(n) +O(n)
//    private int Solve(string str, int index, int[] dp)
//    {
//        // base case
//        if (index >= str.Length)
//        {
//            // we have reached the end of the string and found a way to decode
//            return 1;
//        }

//        if (str[index] == '0')
//        {
//            // we cannot decode a string starting with 0
//            return 0;
//        }

//        if (dp[index] != -1)
//        {
//            return dp[index];
//        }
//        int one_Char = Solve(str, index + 1, dp);

//        int two_Char = 0;

//        // check if we can take two characters
//        if (index + 1 < str.Length)
//        {
//            if (str[index] == '1' || (str[index] == '2' && str[index + 1] <= '6'))
//            {
//                two_Char = Solve(str, index + 2, dp);
//            }
//        }

//        return dp[index] = one_Char + two_Char;
//    }

//    // Time : O(n) , space :O(n)
//    private int Solve(string s)
//    {
//        int[] dp = new int[s.Length + 1];

//        dp[s.Length] = 1;

//        for (int i = s.Length - 1; i >= 0; i--)
//        {
//            if (s[i] == '0')
//            {
//                continue;
//            }

//            int one_Char = dp[i + 1];

//            int two_Char = 0;

//            // check if we can take two characters
//            if (i + 1 < s.Length)
//            {
//                if (s[i] == '1' || (s[i] == '2' && s[i + 1] <= '6'))
//                {
//                    two_Char = dp[i + 2];
//                }
//            }
//            dp[i] = one_Char + two_Char;
//        }

//        return dp[0];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Soltuion s = new Soltuion();

//        Console.WriteLine(s.NumDecodings("06"));
//    }
//}