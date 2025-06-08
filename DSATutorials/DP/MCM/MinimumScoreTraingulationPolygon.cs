//public class Solution
//{
//    public int MinScoreTriangulation(int[] values)
//    {
//        int[,] dp = new int[values.Length, values.Length];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                dp[i, j] = -1;
//            }
//        }

//        return Solve(values, 0, values.Length - 1);
//        //return Solve(values, 0, values.Length - 1, dp);

//        //return Solve(values);

//    }

//    // Time : O(2^n) , space :O(n)
//    private int Solve(int[] values, int i, int j)
//    {
//        // base case
//        // If the next immediate element is j itself then it means we cannot have a triangle
//        if (i + 1 == j)
//        {
//            return 0;
//        }

//        int minCost = int.MaxValue;

//        // Now start applying K
//        for (int k = i + 1; k <= j - 1; k++)
//        {
//            int currentCost = values[i] * values[k] * values[j] +
//                               Solve(values, i, k) +
//                               Solve(values, k, j);

//            minCost = Math.Min(minCost, currentCost);
//        }

//        return minCost;
//    }

//    // Time : O(n * n * K) => O(n^2 * k) , space : O(n^2 + n) recursion stack and dp array
//    private int Solve(int[] values, int i, int j, int[,] dp)
//    {
//        // base case
//        // If the next immediate element is j itself then it means we cannot have a triangle
//        if (i + 1 == j)
//        {
//            return 0;
//        }

//        if (dp[i, j] != -1)
//        {
//            return dp[i, j];
//        }

//        int minCost = int.MaxValue;

//        // Now start applying K
//        for (int k = i + 1; k <= j - 1; k++)
//        {
//            int currentCost = values[i] * values[k] * values[j] +
//                               Solve(values, i, k) +
//                               Solve(values, k, j);

//            minCost = Math.Min(minCost, currentCost);
//        }

//        return dp[i, j] = minCost;
//    }

//    // Time :O(N^3) , space :O(N^2)
//    private int Solve(int[] values)
//    {
//        int[,] dp = new int[values.Length, values.Length];

//        for (int i = values.Length - 1; i >= 0; i--)
//        {
//            for (int j = i + 1; j < values.Length; j++)
//            {
//                if (i + 1 == j)
//                {
//                    continue;
//                }
//                int minCost = int.MaxValue;

//                // Now start applying K
//                for (int k = i + 1; k <= j - 1; k++)
//                {
//                    int currentCost = values[i] * values[k] * values[j] +
//                                       dp[i, k] +
//                                       dp[k, j];

//                    minCost = Math.Min(minCost, currentCost);
//                }

//                dp[i, j] = minCost;
//            }
//        }

//        return dp[0, values.Length - 1];
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] values = { 3, 7, 4, 5 };

//        Solution s = new Solution();

//        Console.WriteLine(s.MinScoreTriangulation(values));
//    }
//}


////Triangulation is inherently recursive — a triangle splits a polygon into two smaller polygons.

////Those smaller polygons themselves require optimal triangulation.

////So you need to solve them recursively and combine their costs.