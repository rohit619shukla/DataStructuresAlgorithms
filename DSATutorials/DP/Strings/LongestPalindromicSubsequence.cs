//using System;


//class Helper
//{
//    public int Solve(string s1, string s2)
//    {
//        //int[,] dp = new int[s1.Length + 1, s2.Length + 1];

//        int[] prev = new int[s2.Length + 1];
//        for (int i = 0; i <= s1.Length; i++)
//        {
//            int[] curr = new int[s2.Length + 1];

//            for (int j = 0; j <= s2.Length; j++)
//            {
//                if (i == 0 || j == 0)
//                {
//                    curr[j] = 0;
//                }
//                else if (s1[i - 1] == s2[j - 1])
//                {
//                    curr[j] = 1 + prev[j - 1];
//                }
//                else
//                {
//                    curr[j] = Math.Max(prev[j], curr[j - 1]);
//                }
//            }

//            prev = curr;
//        }

//        return prev[s2.Length];
//    }

//    public string ReverseString(string str)
//    {
//        char[] charArr = str.ToCharArray();

//        int lb = 0;
//        int ub = str.Length - 1;

//        while (lb < ub)
//        {
//            char temp = charArr[lb];
//            charArr[lb] = charArr[ub];
//            charArr[ub] = temp;

//            lb++;
//            ub--;
//        }

//        return new string(charArr);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "bbbab";

//        Helper h = new Helper();

//        Console.WriteLine(h.Solve(str, h.ReverseString(str)));
//    }

//}