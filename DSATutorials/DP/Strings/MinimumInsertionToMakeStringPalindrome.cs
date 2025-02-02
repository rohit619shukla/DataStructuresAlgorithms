//using System;

//class Helper
//{
//    // Time : O(m*n) , space: O(n)
//    public int Solve(string s1, string s2)
//    {

//        int[] prev = new int[s2.Length + 1];

//        for (int i = 1; i <= s1.Length; i++)
//        {
//            int[] curr = new int[s2.Length + 1];

//            for (int j = 1; j <= s2.Length; j++)
//            {
//                if (s1[i - 1] == s2[j - 1])
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

//        return s1.Length - prev[s2.Length];
//    }

//    public string Reverse(string str)
//    {
//        char[] chr = str.ToCharArray();

//        int lb = 0;
//        int ub = str.Length - 1;

//        while (lb < ub)
//        {
//            char temp = chr[lb];
//            chr[lb] = chr[ub];
//            chr[ub] = temp;

//            lb++;
//            ub--;
//        }

//        return new string(chr);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "leetcode";
//        Helper h = new Helper();
//        Console.WriteLine(h.Solve(str, h.Reverse(str)));

//    }
//}


//// Basically it is same as minimum number of deletions only but only thing is we will need to add it in pairs