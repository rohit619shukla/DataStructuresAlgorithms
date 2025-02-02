

//class Solution
//{
//    public int Solve(int[] wt, int[] profit, int index, int W, int[,] dp)
//    {

//        for (int i = wt[0]; i <= W; i++)
//        {
//            dp[0, i] = (i / wt[0]) * profit[0];
//        }

//        for (int i = 1; i < wt.Length; i++)
//        {
//            for (int j = 0; j <= W; j++)
//            {
//                int notPick = dp[i - 1, j];

//                int pick = int.MinValue;

//                if (j >= wt[i])
//                {
//                    pick = profit[i] + dp[i, j - wt[i]];
//                }

//                dp[i, j] = Math.Max(pick, notPick);
//            }
//        }

//        return dp[wt.Length - 1, W];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] wt = { 2, 4, 12 };
//        int[] profit = { 5, 11, 13 };
//        int W = 10;

//        Solution s = new Solution();

//        int[,] dp = new int[wt.Length, W + 1];


//        Console.WriteLine(s.Solve(wt, profit, wt.Length - 1, W, dp));

//    }
//}