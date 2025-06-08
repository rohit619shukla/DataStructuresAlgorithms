//public class Solution
//{
//    public int TwoEggDrop(int n)
//    {
//        int eggs = 2;

//        int[,] dp = new int[eggs + 1, n + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }

//        return DropEffort(eggs, n, dp);
//    }

//    private int DropEffort(int eggs, int floors, int[,] dp)
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
//        int low = 1;
//        int high = floors;

//        while (low <= high)
//        {
//            int mid = (low + high) / 2;

//            int eggDontBreak = DropEffort(eggs, floors - mid, dp);

//            int eggBreak = DropEffort(eggs - 1, mid - 1, dp);

//            int currentEffort = 1 + Math.Max(eggDontBreak, eggBreak);

//            minEffort = Math.Min(minEffort, currentEffort);

//            if (eggBreak > eggDontBreak)
//            {
//                high = mid - 1;
//            }
//            else
//            {
//                low = mid + 1;
//            }
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

//// Time : O(eggs * floor * log floors), space : O(eggs * floors)
//// Here we have states (eggs * floor) , we use binary search to get a floor hence log floor