//using System.Numerics;
//using System.Runtime.Intrinsics.Arm;

//public class Solution
//{
//    public int MaxCoins(int[] nums)
//    {
//        // Create new array to fit pseudo walls at both the ends
//        int[] baloons = new int[nums.Length + 2];

//        // now fill array accordingly
//        baloons[0] = 1;
//        baloons[nums.Length + 1] = 1;

//        for (int i = 0; i < nums.Length; i++)
//        {
//            baloons[i + 1] = nums[i];
//        }

//        int[,] memo = new int[baloons.Length + 1, baloons.Length + 1];

//        for (int i = 0; i < memo.GetLength(0); i++)
//        {
//            for (int j = 0; j < memo.GetLength(1); j++)
//            {
//                memo[i, j] = -1;
//            }
//        }

//        // we will start with i = 1 as 0th will have the walls 
//       // int result = Solve(baloons, 1, baloons.Length - 2);

//        //int result = Solve(baloons, 1, nums.Length, memo);

//        int result = Solve(baloons);

//        return result;
//    }

//    // Time : O(N!) , space :O(N)
//    private int Solve(int[] baloons, int i, int j)
//    {
//        // base case
//        // Note we will not use >= as we can even burst 1 baloon too
//        if (i > j)
//        {
//            return 0;
//        }

//        int maxCost = int.MinValue;

//        // Pick any one baloon and start blasting
//        for (int k = i; k <= j; k++)
//        {
//            // blast left and right side first
//            int leftSide = Solve(baloons, i, k - 1);
//            int rightSide = Solve(baloons, k + 1, j);

//            // Now we are in empty room with k remaining only and walls
//            int currentCost = (baloons[i - 1] * baloons[k] * baloons[j + 1]) + leftSide + rightSide;

//            maxCost = Math.Max(maxCost, currentCost);
//        }

//        return maxCost;
//    }

//    private int Solve(int[] baloons, int i, int j, int[,] memo)
//    {
//        // base case
//        // Note we will not use >= as we can even burst 1 baloon too
//        if (i > j)
//        {
//            return 0;
//        }

//        if (memo[i, j] != -1)
//        {
//            return memo[i, j];
//        }

//        int maxCost = int.MinValue;

//        // Pick any one baloon and start blasting
//        for (int k = i; k <= j; k++)
//        {
//            // blast left and right side first
//            int leftSide = Solve(baloons, i, k - 1);
//            int rightSide = Solve(baloons, k + 1, j);

//            // Now we are in empty room with k remaining only and walls
//            int currentCost = (baloons[i - 1] * baloons[k] * baloons[j + 1]) + leftSide + rightSide;

//            maxCost = Math.Max(maxCost, currentCost);
//        }

//        return memo[i, j] = maxCost;
//    }

//    // Time : O(N^3), space :O(N^2)
//    private int Solve(int[] baloons)
//    {
//        int[,] memo = new int[baloons.Length + 1, baloons.Length + 1];

//        int n = baloons.Length;

//        for (int i = n - 2; i >= 1; i--)
//        {
//            //Here we are keeping j = i and not i + 1 as we can even burst single baloon too
//            for (int j = i; j <= n - 2; j++)
//            {
//                int maxCost = int.MinValue;

//                // Pick any one baloon and start blasting
//                for (int k = i; k <= j; k++)
//                {
//                    // blast left and right side first
//                    int leftSide = memo[i, k - 1];
//                    int rightSide = memo[k + 1, j];

//                    // Now we are in empty room with k remaining only and walls
//                    int currentCost = (baloons[i - 1] * baloons[k] * baloons[j + 1]) + leftSide + rightSide;

//                    maxCost = Math.Max(maxCost, currentCost);
//                }
//                memo[i, j] = maxCost;
//            }
//        }


//        return memo[1, n - 2];
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        int[] nums = { 3, 1, 5, 8 };

//        Console.WriteLine(s.MaxCoins(nums));
//    }
//}