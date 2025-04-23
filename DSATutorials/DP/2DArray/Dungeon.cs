//public class Solution
//{
//    public int CalculateMinimumHP(int[][] dungeon)
//    {
//        int rows = dungeon.Length;
//        int cols = dungeon[0].Length;

//        int[,] dp = new int[rows, cols];
//        return Solve(dungeon, rows, cols, dp);
//    }


//    // Time : O(2^n) , space : O(n+m)
//    //private int Solve(int[][] dungeon, int rows, int cols, int currRow, int currCol)
//    //{
//    //    // base case
//    //    if (currRow >= rows || currCol >= cols)
//    //    {
//    //        return int.MaxValue;
//    //    }

//    //    // If we have arrived last cell then we, need to make sure that we are atleast alive
//    //    if (currRow == rows - 1 && currCol == cols - 1)
//    //    {
//    //        // In case of :
//    //        // -ve : this formula will give us how much more HP we need to survice this monster and rescue the princes
//    //        // +ve : we dont care for positive as we have already reached last cell we just need to survive
//    //        return Math.Max(1, 1 - dungeon[currRow][currCol]);
//    //    }

//    //    // Explore the minimum HP for down and right paths we will need
//    //    int down = Solve(dungeon, rows, cols, currRow + 1, currCol);
//    //    int right = Solve(dungeon, rows, cols, currRow, currCol + 1);

//    //    // Now from both the paths get the minimum HP to survive
//    //    int minHp = Math.Min(down, right);

//    //    // This is the crux.This will give the HP needed by current cell to survive before it can give some part from itself to it  child
//    //    return Math.Max(1, minHp - dungeon[currRow][currCol]);
//    //}

//    // Time : O(n*m) , space : O(n+m) + O(n*m)
//    //private int Solve(int[][] dungeon, int rows, int cols, int currRow, int currCol, int[,] dp)
//    //{
//    //    // base case
//    //    if (currRow >= rows || currCol >= cols)
//    //    {
//    //        return int.MaxValue;
//    //    }

//    //    // If we have arrived last cell then we, need to make sure that we are atleast alive
//    //    if (currRow == rows - 1 && currCol == cols - 1)
//    //    {
//    //        // In case of :
//    //        // -ve : this formula will give us how much more HP we need to survice this monster and rescue the princes
//    //        // +ve : we dont care for positive as we have already reached last cell we just need to survive
//    //        return Math.Max(1, 1 - dungeon[currRow][currCol]);
//    //    }

//    //    if (dp[currRow, currCol] != -1)
//    //    {
//    //        return dp[currRow, currCol];
//    //    }
//    //    // Explore the minimum HP for down and right paths we will need
//    //    int down = Solve(dungeon, rows, cols, currRow + 1, currCol, dp);
//    //    int right = Solve(dungeon, rows, cols, currRow, currCol + 1, dp);

//    //    // Now from both the paths get the minimum HP to survive
//    //    int minHp = Math.Min(down, right);

//    //    // This is the crux.This will give the HP needed by current cell to survive before it can give some part from itself to it  child
//    //    return dp[currRow, currCol] = Math.Max(1, minHp - dungeon[currRow][currCol]);
//    //}

//    // Time : O(n*m) , space : O(n*m)
//    private int Solve(int[][] dungeon, int rows, int cols, int[,] dp)
//    {

//        for (int i = rows - 1; i >= 0; i--)
//        {
//            for (int j = cols - 1; j >= 0; j--)
//            {
//                if (i == rows - 1 && j == cols - 1)
//                {
//                    dp[i, j] = Math.Max(1, 1 - dungeon[i][j]);
//                    //continue;
//                }
//                else
//                {
//                    // Explore the minimum HP for down and right paths we will need
//                    int down = int.MaxValue, right = int.MaxValue;
//                    if (i + 1 < rows)
//                    {
//                        down = dp[i + 1, j];
//                    }

//                    if (j + 1 < cols)
//                    {
//                        right = dp[i, j + 1];
//                    }

//                    // Now from both the paths get the minimum HP to survive
//                    int minHp = Math.Min(down, right);

//                    // This is the crux.This will give the HP needed by current cell to survive before it can give some part from itself to it  child
//                    dp[i, j] = Math.Max(1, minHp - dungeon[i][j]);
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
//            new int[] { -2, -3, 3 },
//            new int[] { -5, -10, 1 },
//            new int[] { 10, 30, -5 }
//        };

//        Solution s = new Solution();
//        Console.WriteLine(s.CalculateMinimumHP(dungeon));
//    }
//}