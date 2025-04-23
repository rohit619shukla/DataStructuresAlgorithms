//using System;

//class Helper
//{
//    // Tabulation
//    // Time : O(n*m), space : O(n*m)
//    public void Solve(string s1, string s2)
//    {
//        int[,] dp = new int[s1.Length + 1, s2.Length + 1];

//        for (int i = 0; i <= s1.Length; i++)
//        {
//            for (int j = 0; j <= s2.Length; j++)
//            {
//                if (i == 0 || j == 0)
//                {
//                    dp[i, j] = 0;
//                }
//                else if (s1[i - 1] == s2[j - 1] && i != j)
//                {
//                    dp[i, j] = 1 + dp[i - 1, j - 1];
//                }
//                else
//                {
//                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
//                }
//            }
//        }

//        int x = s1.Length;
//        int y = s2.Length;
//        string result = "";

//        while (x > 0 && y > 0)
//        {
//            if (s1[x - 1] == s2[y - 1] && x != y)
//            {
//                result += s1[x - 1];
//                x--;
//                y--;
//            }
//            else
//            {
//                if (dp[x - 1, y] > dp[x, y - 1])
//                {
//                    x--;
//                }
//                else
//                {
//                    y--;
//                }
//            }
//        }

//        Console.WriteLine(ReverseString(result));
//    }

//    private string ReverseString(string s)
//    {
//        char[] charArray = s.ToCharArray();

//        int lb = 0;
//        int ub = s.Length - 1;

//        while (lb <= ub)
//        {
//            char temp = charArray[lb];
//            charArray[lb] = charArray[ub];
//            charArray[ub] = temp;

//            lb++;
//            ub--;
//        }

//        return new string(charArray);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string s = "AABEBCDD";

//        Helper h = new Helper();
//        h.Solve(s, s);
//    }
//}

////Note: Same code as LCS but with twist of non matching index
//// The idea here is that the same char should also appear in another index in same sequence