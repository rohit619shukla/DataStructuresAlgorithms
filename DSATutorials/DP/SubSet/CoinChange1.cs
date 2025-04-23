//using System;
//using System.Runtime.InteropServices;

//class Helper
//{
//    public int CoinChange(int[] coins, int amount)
//    {
//        int index = coins.Length - 1;

//        double[,] dp = new double[coins.Length, amount + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }

//        //double ans = MinCoins(coins, amount, index, dp);

//        double ans = MinCoins(coins, amount, index);

//        if (ans != 1e9)
//        {
//            return (int)ans;
//        }
//        else
//        {
//            return -1;
//        }
//    }

//    // Recursion
// Time : O(Exponential) as we have intifinite denominations to pick from, space : O(amount)
//private double MinCoins(int[] coins, int amount, int index)
//{
//    // base cases
//    if (index == 0)
//    {
//        if (amount % coins[0] == 0)
//        {
//            return amount / coins[0];
//        }
//        else
//        {
//            return 1e9;
//        }
//    }

//    double notPickSum = 0 + MinCoins(coins, amount, index - 1);

//    double pickSum = 1e9;

//    if (amount >= coins[index])
//    {
//        // We will be picking 1 coin out of intifinite set of denomination.
//        // Hence we will keep index as there only else if we move backwards we wont be able to get another form same denomination

//        pickSum = 1 + MinCoins(coins, amount - coins[index], index);
//    }

//    return Math.Min(pickSum, notPickSum);
//}


//    // Memoization
//    // Time : O(index * amount), space : O(index * amount) + O(target)
//    //private double MinCoins(int[] coins, int amount, int index, double[,] dp)
//    //{
//    //    // base cases
//    //    if (index == 0)
//    //    {
//    //        if (amount % coins[0] == 0)
//    //        {
//    //            return amount / coins[0];
//    //        }
//    //        else
//    //        {
//    //            return 1e9;
//    //        }
//    //    }

//    //    if (dp[index, amount] != -1)
//    //    {
//    //        return dp[index, amount];
//    //    }

//    //    double notPickSum = 0 + MinCoins(coins, amount, index - 1, dp);

//    //    double pickSum = 1e9;

//    //    if (amount >= coins[index])
//    //    {
//    //        // We will be picking 1 coin out of intifinite set of denomination.
//    //        // Hence we will keep index as there only else if we move backwards we wont be able to get another form same denomination

//    //        pickSum = 1 + MinCoins(coins, amount - coins[index], index, dp);
//    //    }

//    //    return dp[index, amount] = Math.Min(pickSum, notPickSum);
//    //}

//    // Tabulation
//    // Time : O(index * amount), space : O(index * amount)
//    //private double MinCoins(int[] coins, int amount, int index, double[,] dp)
//    //{

//    //    for (int k = 0; k <= amount; k++)
//    //    {
//    //        if (k % coins[0] == 0)
//    //        {
//    //            dp[0, k] = k / coins[0];
//    //        }
//    //        else
//    //        {
//    //            dp[0, k] = 1e9;
//    //        }
//    //    }

//    //    // for index
//    //    for (int i = 1; i <= index; i++)
//    //    {
//    //        // for amount
//    //        for (int j = 0; j <= amount; j++)
//    //        {
//    //            double notPickSum = 0 + dp[i - 1, j];

//    //            double pickSum = 1e9;

//    //            if (j >= coins[i])
//    //            {
//    //                pickSum = 1 + dp[i, j - coins[i]];
//    //            }

//    //            dp[i, j] = Math.Min(pickSum, notPickSum);
//    //        }
//    //    }

//    //    return dp[index, amount];
//    //}

//    // Tabulation with space optimization
//    // Time : O(index * amount) , space : O(n)
//    private double MinCoins(int[] coins, int amount, int index)
//    {
//        double[] prev = new double[amount + 1];
//        double[] curr = new double[amount + 1];

//        for (int k = 0; k <= amount; k++)
//        {
//            if (k % coins[0] == 0)
//            {
//                prev[k] = k / coins[0];
//            }
//            else
//            {
//                prev[k] = 1e9;
//            }
//        }

//        // for index
//        for (int i = 1; i <= index; i++)
//        {
//            // for amount
//            for (int j = 0; j <= amount; j++)
//            {
//                double notPickSum = 0 + prev[j];

//                double pickSum = 1e9;

//                if (j >= coins[i])
//                {
//                    pickSum = 1 + curr[j - coins[i]];
//                }

//                curr[j] = Math.Min(pickSum, notPickSum);
//            }
//            prev = curr;
//        }

//        return prev[amount];
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        int[] coins = { 1, 2, 5 };
//        int amount = 11;

//        Helper h = new Helper();

//        Console.WriteLine($"{h.CoinChange(coins, amount)}");
//    }
//}