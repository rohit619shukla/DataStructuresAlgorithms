//using System;

//class Helper
//{
//    //Time Complexity: O(n* k*k) where n is number of eggs and k is number of floors.
//    //Auxiliary Space: O(n* k) as 2D memoisation table has been used.
//    public int Solve(int eggs, int floors, int[,] dp)
//    {
//        if (floors == 1 || floors == 0)
//        {
//            return floors;
//        }

//        if (eggs == 1)
//        {
//            return floors;
//        }


//        if (dp[eggs, floors] != -1)
//        {
//            return dp[eggs, floors];
//        }

//        int minEffort = int.MaxValue;

//        for (int k = 1; k <= floors; k++)
//        {
//            int currentEffort = 1 + Math.Max(Solve(eggs - 1, k - 1, dp), Solve(eggs, floors - k, dp));

//            minEffort = Math.Min(minEffort, currentEffort);
//        }

//        return dp[eggs, floors] = minEffort;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();
//        int eggs = 3;
//        int floors = 14;

//        int[,] dp = new int[eggs + 1, floors + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }
//        Console.WriteLine(h.Solve(eggs, floors, dp));
//    }
//}