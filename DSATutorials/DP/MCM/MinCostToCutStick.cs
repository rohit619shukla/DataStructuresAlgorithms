//public class Solution
//{
//    public int MinCost(int n, int[] cuts)
//    {
//        // We will sort the Array first to make sure when we cut something at a interval the values is indeed present in correct side of sequence
//        Array.Sort(cuts);

//        // Now we need to add padded cells to the array to treat it as a scale
//        int[] temp = new int[cuts.Length + 2];
//        temp[0] = 0;
//        temp[cuts.Length + 1] = n;

//        for (int i = 0; i < cuts.Length; i++)
//        {
//            temp[i + 1] = cuts[i];
//        }

//        int[,] dp = new int[temp.Length + 1, temp.Length + 1];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }

//        //return Solve(temp, 0, temp.Length - 1);
//        //return Solve(temp, 0, temp.Length - 1, dp);
//        return Solve(temp);
//    }

//    // Time : O(n!) , space : O(n)
//    private int Solve(int[] temp, int i, int j)
//    {
//        // base case
//        // We need atleast 3 elements in the range to be able to apply cut
//        if (j - i == 1)
//        {
//            return 0;
//        }

//        int minCost = int.MaxValue;

//        for (int k = i + 1; k < j; k++)
//        {
//            int currentCost = (temp[j] - temp[i]) + Solve(temp, i, k) + Solve(temp, k, j);

//            minCost = Math.Min(minCost, currentCost);
//        }

//        return minCost;
//    }

//    // Time : O(N^2)
//    private int Solve(int[] temp, int i, int j, int[,] dp)
//    {
//        // base case
//        // We need atleast 3 elements in the range to be able to apply cut
//        if (j - i == 1)
//        {
//            return 0;
//        }

//        if (dp[i, j] != -1)
//        {
//            return dp[i, j];
//        }

//        int minCost = int.MaxValue;

//        for (int k = i + 1; k < j; k++)
//        {
//            int currentCost = (temp[j] - temp[i]) + Solve(temp, i, k, dp) + Solve(temp, k, j, dp);

//            minCost = Math.Min(minCost, currentCost);
//        }

//        return dp[i, j] = minCost;
//    }

//    // Time : O(N^3)
//    private int Solve(int[] temp)
//    {
//        int[,] dp = new int[temp.Length + 1, temp.Length + 1];

//        int n = temp.Length;

//        for (int i = temp.Length - 1; i >= 0; i--)
//        {
              // Here j  cannot be i as we need atleast 1 connect to work 
//            for (int j = i + 1; j < temp.Length; j++)
//            {
//                if (j - i == 1)
//                {
//                    continue;
//                }

//                int minCost = int.MaxValue;

//                for (int k = i + 1; k < j; k++)
//                {
//                    int currentCost = (temp[j] - temp[i]) + dp[i, k] + dp[k, j];

//                    minCost = Math.Min(minCost, currentCost);
//                }

//                dp[i, j] = minCost;
//            }
//        }

//        return dp[0, temp.Length - 1];
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        int[] cuts = { 1, 3, 4, 5 };

//        Console.WriteLine($"{s.MinCost(7, cuts)}");
//    }
//}