

//class Solution
//{
//    //    Time Complexity: O(N* M)
//    public void Solve(string s1, string s2, int x, int y)
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
//                else
//                {
//                    if (s1[i - 1] == s2[j - 1])
//                    {
//                        dp[i, j] = 1 + dp[i - 1, j - 1];
//                    }
//                    else
//                    {
//                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
//                    }
//                }
//            }
//        }


//        int lcsSize = dp[s1.Length, s2.Length];

//        int count = lcsSize;

//        int ind1 = s1.Length;
//        int ind2 = s2.Length;


//        Stack<char> st = new Stack<char>();
//        while (ind1 > 0 && ind2 > 0)
//        {
//            if (s1[ind1 - 1] == s2[ind2 - 1])
//            {
//                st.Push(s1[ind1 - 1]);
//                ind1--;
//                ind2--;
//            }
//            else if (dp[ind1 - 1, ind2] > dp[ind1, ind2 - 1])
//            {
//                st.Push(s1[ind1 - 1]);
//                ind1--;
//            }
//            else
//            {
//                st.Push(s2[ind2 - 1]);
//                ind2--;
//            }
//        }

//        while (ind1 > 0)
//        {
//            st.Push(s1[ind1 - 1]);
//            ind1--;
//        }

//        while (ind2 > 0)
//        {
//            st.Push(s2[ind2 - 1]);
//            ind2--;
//        }

//        string result = "";

//        while (st.Count > 0)
//        {
//            result += st.Pop();
//        }

//        Console.WriteLine(result);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string s1 = "brute";
//        string s2 = "groot";

//        Solution s = new Solution();

//        s.Solve(s1, s2, s1.Length - 1, s2.Length - 1);
//    }
//}