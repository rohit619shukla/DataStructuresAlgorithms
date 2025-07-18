//public class Solution
//{
//    public int TwoEggDrop(int n)
//    {
//        int eggs = 2;

//        int[,] dp = new int[eggs + 1, n + 1];

//        for (int i = 0; i <= eggs; i++)
//        {
//            for (int j = 0; j <= n; j++)
//            {
//                dp[i, j] = -1;
//            }
//        }
//        return Solve(eggs, n, dp);
//    }

//    private int Solve(int eggs, int floors, int[,] dp)
//    {
//        // base case
//        if (floors == 0 || floors == 1)
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
//            int eggBreak = Solve(eggs - 1, k - 1, dp);

//            int eggDontBreak = Solve(eggs, floors - k, dp);

//            int currentEffort = 1 + Math.Max(eggBreak, eggDontBreak);

//            minEffort = Math.Min(minEffort, currentEffort);

//        }
//        return dp[eggs, floors] = minEffort;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int n = 100;

//        Solution s = new Solution();

//        Console.WriteLine(s.TwoEggDrop(n));

//    }
//}

////Time: O(E * N ^ 2) , space: O(N * Eggs) , since Egss are constant we can ignore