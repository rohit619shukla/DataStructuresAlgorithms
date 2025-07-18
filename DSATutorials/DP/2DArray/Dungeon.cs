
//using System;

//public class Solution
//{
//    public int CalculateMinimumHP(int[][] dungeon)
//    {
//        int rows = dungeon.Length;
//        int cols = dungeon[0].Length;

//        int[,] dp = new int[rows, cols];
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                dp[i, j] = -1;
//            }
//        }

//        //return Solve(dungeon, 0, 0, rows, cols);
//        //return Solve(dungeon, 0, 0, rows, cols, dp);
//        return Solve(dungeon, rows, cols);
//    }


//    // Time : 2^(m+n) as we move right or down linealry , space : O(n)
//    private int Solve(int[][] dungeon, int i, int j, int rows, int cols)
//    {
//        // base case : out of bound
//        if (i >= rows || j >= cols)
//        {
//            return (int)1e9;
//        }

//        // Reached last cell
//        if (i == rows - 1 && j == cols - 1)
//        {
//            // If -ve : knight dies, so we need some min health to survive
//            if (dungeon[i][j] <= 0)
//            {
//                return Math.Abs(dungeon[i][j]) + 1;
//            }
//            else
//            {
//                // As anyways if this is a +ve number then we will have more, but we are asked min, hence 1 . 0 will die
//                return 1;
//            }
//        }

//        int right = Solve(dungeon, i, j + 1, rows, cols);
//        int down = Solve(dungeon, i + 1, j, rows, cols);

//        // this is where any non last cell needs to tell its ancestor what they need to give him to survuce further
//        int minValue = Math.Min(right, down);

//        int result = minValue - dungeon[i][j];

//        return result > 0 ? result : 1;
//    }

//    // Time : O(m*n) here we go ahead and compuet for every cell , space :O(m*n) + O(n)
//    private int Solve(int[][] dungeon, int i, int j, int rows, int cols, int[,] dp)
//    {
//        // base case : out of bound
//        if (i >= rows || j >= cols)
//        {
//            return (int)1e9;
//        }

//        if (dp[i, j] != -1)
//        {
//            return dp[i, j];
//        }

//        // Reached last cell
//        if (i == rows - 1 && j == cols - 1)
//        {
//            // If -ve : knight dies, so we need some min health to survive
//            if (dungeon[i][j] <= 0)
//            {
//                return Math.Abs(dungeon[i][j]) + 1;
//            }
//            else
//            {
//                // As anyways if this is a +ve number then we will have more, but we are asked min, hence 1 . 0 will die
//                return 1;
//            }
//        }


//        int right = Solve(dungeon, i, j + 1, rows, cols);
//        int down = Solve(dungeon, i + 1, j, rows, cols);

//        // this is where any non last cell needs to tell its ancestor what they need to give him to survuce further
//        int minValue = Math.Min(right, down);

//        int result = minValue - dungeon[i][j];

//        return dp[i, j] = result > 0 ? result : 1;
//    }

//    // Time : O(m*n) , space :O(m*n)
//    private int Solve(int[][] dungeon, int rows, int cols)
//    {
//        int[,] dp = new int[rows, cols];

//        for (int i = rows - 1; i >= 0; i--)
//        {
//            for (int j = cols - 1; j >= 0; j--)
//            {
//                if (i == rows - 1 && j == cols - 1)
//                {
//                    // If -ve : knight dies, so we need some min health to survive
//                    if (dungeon[i][j] <= 0)
//                    {
//                        dp[i, j] = Math.Abs(dungeon[i][j]) + 1;
//                    }
//                    else
//                    {
//                        // As anyways if this is a +ve number then we will have more, but we are asked min, hence 1 . 0 will die
//                        dp[i, j] = 1;
//                    }
//                }
//                else
//                {
//                    int down = (int)1e9;
//                    int right = (int)1e9;

//                    if (j + 1 < cols)
//                    {
//                        right = dp[i, j + 1];
//                    }

//                    if (i + 1 < rows)
//                    {
//                        down = dp[i + 1, j];
//                    }

//                    int minValue = Math.Min(right, down);

//                    int result = minValue - dungeon[i][j];

//                    dp[i, j] = result > 0 ? result : 1;
//                }
//            }
//        }

//        return dp[0, 0];
//    }


//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] dungeon = new int[][] {
//            new int[] { -2,-3,3},
//            new int[] {-5,-10,1 },
//            new int[]{ 10, 30, -5 }
//        };

//        Solution s = new Solution();
//        Console.WriteLine(s.CalculateMinimumHP(dungeon));
//    }
//}