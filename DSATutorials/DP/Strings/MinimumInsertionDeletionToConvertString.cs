//using System;

//class Helper
//{
//    //Tabulation
//    //Time : O(n* m) , space : O(n* m)
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


//        // basically we will make sure to get 
//        int deletion = s1.Length - dp[s1.Length, s2.Length];

//        int insertion = s2.Length - dp[s1.Length, s2.Length];

//        Console.WriteLine($"Insertions are : {insertion} and deletions are : {deletion}");
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        string s1 = "intention";
//        string s2 = "execution";

//        Helper h = new Helper();
//        h.Solve(s1, s2);
//    }
//}