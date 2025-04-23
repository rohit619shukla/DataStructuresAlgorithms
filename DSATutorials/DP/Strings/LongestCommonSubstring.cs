

//class Solution
//{
//    // Time : O(m*n) , space : O(m*n)
//    public void Solve(string s1, string s2)
//    {
//        int[,] dp = new int[s1.Length + 1, s2.Length + 1];

//        int max = int.MinValue;
//        int endIndex = 0;

//        for (int i = 0; i <= s1.Length; i++)
//        {
//            for (int j = 0; j <= s2.Length; j++)
//            {
//                if (i == 0 || j == 0)
//                {
//                    dp[i, j] = 0;
//                }
//                else
//                {
//                    if (s1[i - 1] == s2[j - 1])
//                    {
//                        dp[i, j] = 1 + dp[i - 1, j - 1];

//                        if (dp[i, j] > max)
//                        {
//                            max = dp[i, j];
//                            endIndex = i;
//                        }
//                    }
//                }
//            }
//        }

//        Console.WriteLine($"Length of Longest common Substring is: {max}");

//        Console.WriteLine($"The Longest common substring is: {s1.Substring(endIndex - max, max)}");
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string s1 = "abcjklp";
//        string s2 = "acjkp";

//        Solution s = new Solution();

//        s.Solve(s1, s2);
//    }
//}