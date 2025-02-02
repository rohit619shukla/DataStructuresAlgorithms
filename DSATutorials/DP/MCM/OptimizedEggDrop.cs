

//class Solution
//{
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

//        int low = 1;
//        int high = floors;

//        int minEffort = int.MaxValue;

//        while (low <= high)
//        {
//            int mid = (low + high) / 2;

//            int eggBreak = Solve(eggs - 1, mid - 1, dp);

//            int noBreak = Solve(eggs, floors - mid, dp);

//            int currentEffort = 1 + Math.Max(eggBreak, noBreak);

//            minEffort = Math.Min(minEffort, currentEffort);

//            if (eggBreak > noBreak)
//            {
//                high = mid - 1;          // We dont need to go up the floor
//            }
//            else
//            {
//                low = mid + 1;      // We need to find new floors up the order
//            }
//        }

//        return dp[eggs, floors] = minEffort;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
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

//        Solution s = new Solution();
//        Console.WriteLine(s.Solve(eggs, floors, dp));

//    }
//}

////Time : O(eggs * floor * log floors)
//// Space : O(eggs * floor)