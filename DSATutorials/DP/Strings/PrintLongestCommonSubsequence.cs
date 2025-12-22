//using System;

//class Helper
//{
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
//                else if (s1[i - 1] == s2[j - 1])
//                {
//                    dp[i, j] = 1 + dp[i - 1, j - 1];
//                }
//                else
//                {
//                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
//                }
//            }
//        }

//        int size = dp[s1.Length, s2.Length];
//        char[] charArray = new char[size];

//        int x = s1.Length;
//        int y = s2.Length;

//        // We wont be going till 0 coz at 0 the string is considered to be empty
//        while (x > 0 && y > 0)
//        {
//            if (s1[x - 1] == s2[y - 1])
//            {
//                charArray[--size] = s1[x - 1];
//                x--;
//                y--;
//            }
//            else if (dp[x - 1, y] > dp[x, y - 1])
//            {
//                x--;
//            }
//            else
//            {
//                y--;
//            }
//        }

//        Console.WriteLine(new string(charArray));

//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string s1 = "acd";
//        string s2 = "ced";

//        Helper h = new Helper();
//        h.Solve(s1, s2);
//    }
//}