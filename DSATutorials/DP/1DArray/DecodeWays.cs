//public class Solution
//{
//    public int NumDecodings(string s)
//    {
//        //int[] dp = new int[s.Length + 1];
//        //Array.Fill(dp, -1);

//        ////return Solve(s, 0);
//        //return Solve(s, 0, dp);

//        return Solve(s);
//    }

//    //Time : O(2^n) , space :O(n)
//    private int Solve(string s, int i)
//    {
//        // base case
//        // We have reached end of string while performing partitions, which means we got the answer
//        if (i >= s.Length)
//        {
//            return 1;
//        }

//        // This is not a valid case as we cannot have any mapping
//        if (s[i] == '0')
//        {
//            return 0;
//        }

//        // Note : The mapping of char are from 1 - 26

//        // This means we will take 1 char and move
//        int oneJump = Solve(s, i + 1);


//        // This means, we will take 2 char and move i. We cannot beyond 2 chars as only between 1 - 26
//        int twoJump = 0;

//        // This is critical, s[i] =='1' means we dont care and should be ok.
//        // S[i] ='2' && s[i+1] <='6' , means we should not extend beyond 26 actual english chars while taking 2 char
//        if (i + 1 < s.Length)
//        {
//            if (s[i] == '1' || (s[i] == '2' && s[i + 1] <= '6'))
//            {
//                twoJump = Solve(s, i + 2);
//            }
//        }

//        return oneJump + twoJump;
//    }

//    private int Solve(string s, int i, int[] dp)
//    {
//        if (i >= s.Length)
//        {
//            return 1;
//        }

//        if (dp[i] != -1)
//        {
//            return dp[i];
//        }

//        if (s[i] == '0')
//        {
//            return 0;
//        }

//        int oneJump = Solve(s, i + 1, dp);

//        int twoJump = 0;

//        if (i + 1 < s.Length)
//        {
//            if (s[i] == '1' || (s[i] == '2' && s[i + 1] <= '6'))
//            {
//                twoJump = Solve(s, i + 2, dp);
//            }
//        }

//        return dp[i] = oneJump + twoJump;
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
//                dp[i] = 0;
//            }
//            else
//            {
//                int oneJump = 0;
//                int twoJump = 0;
//                oneJump = dp[i + 1];

//                twoJump = 0;

//                if (i + 1 < s.Length)
//                {
//                    if (s[i] == '1' || (s[i] == '2' && s[i + 1] <= '6'))
//                    {
//                        twoJump = dp[i + 2];
//                    }
//                }

//                dp[i] = oneJump + twoJump;
//            }
//        }

//        return dp[0];
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string str = "06";

//        Solution s = new Solution();

//        Console.WriteLine(s.NumDecodings(str));
//    }
//}