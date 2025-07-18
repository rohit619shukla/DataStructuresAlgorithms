//public class Solution
//{
//    public int CherryPickup(int[][] grid)
//    {
//        int rows = grid.Length;
//        int cols = grid[0].Length;

//        int[,,] dp = new int[rows, cols, rows];

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                for (int k = 0; k < rows; k++)
//                {
//                    dp[i, j, k] = -1;
//                }
//            }
//        }

//        //return Math.Max(0, Solve(0, 0, 0, rows, cols, grid, dp));
//        //return Math.Max(0, ForwardPath(0, 0, rows, cols, grid));
//        return Solve(grid, rows, cols);
//    }

//    // O(2^(rows+cols) * 2^(rows+cols))
//    //private int ForwardPath(int r, int c, int rows, int cols, int[][] grid)
//    //{
//    //    // base case
//    //    if (!IsSafe(r, c, rows, cols, grid))
//    //    {
//    //        return -(int)1e9;
//    //    }

//    //    // Last cell
//    //    if (r == rows - 1 && c == cols - 1)
//    //    {
//    //        // This is crtical , you are perfroming backward traversal on the current state which might have already changed
//    //        // This is the crux
//    //        return BackwardPath(r, c, rows, cols, grid);
//    //    }

//    //    // Normal cells
//    //    // Pick the current cherry
//    //    int currentCherry = grid[r][c];

//    //    // Mark it as picked
//    //    grid[r][c] = 0;

//    //    // Move in required directions
//    //    int right = ForwardPath(r, c + 1, rows, cols, grid);
//    //    int down = ForwardPath(r + 1, c, rows, cols, grid);


//    //    // backtrack
//    //    grid[r][c] = currentCherry;

//    //    // pick the best path
//    //    int bestPath = Math.Max(right, down);

//    //    // could be invalid
//    //    if (bestPath == -(int)1e9)
//    //    {
//    //        return bestPath;
//    //    }

//    //    // looks good, so add the incoming values to current cherry
//    //    return currentCherry += bestPath;
//    //}

//    //private int BackwardPath(int r, int c, int rows, int cols, int[][] grid)
//    //{
//    //    // base case
//    //    if (!IsSafe(r, c, rows, cols, grid))
//    //    {
//    //        return -(int)1e9;
//    //    }

//    //    // Reached First cell
//    //    if (r == 0 && c == 0)
//    //    {
//    //        return grid[r][c];
//    //    }

//    //    // Normal cells
//    //    // Pick the current cherry
//    //    int currentCherry = grid[r][c];

//    //    // Mark it as picked
//    //    grid[r][c] = 0;

//    //    // Move in required directions
//    //    int up = BackwardPath(r - 1, c, rows, cols, grid);
//    //    int left = BackwardPath(r, c - 1, rows, cols, grid);

//    //    // backtrack
//    //    grid[r][c] = currentCherry;

//    //    // pick the best path
//    //    int bestPath = Math.Max(up, left);

//    //    // could be invalid
//    //    if (bestPath == -(int)1e9)
//    //    {
//    //        return bestPath;
//    //    }

//    //    // looks good, so add the returning values to current cherry
//    //    return currentCherry += bestPath;
//    //}


//    // Time : O(N^3) , Space : O(N^3)
//    private int Solve(int r1, int c1, int r2, int rows, int cols, int[][] grid, int[,,] dp)
//    {
//        // this is very crucial as we know both guys will take same steps in time t, hence r1+c1 = r2+c2
//        int c2 = r1 + c1 - r2;

//        // base case
//        if (!IsSafe(r1, c1, rows, cols, grid) || !IsSafe(r2, c2, rows, cols, grid))
//        {
//            return -(int)1e9;
//        }

//        if (dp[r1, c1, r2] != -1)
//        {
//            return dp[r1, c1, r2];
//        }
//        // we are just accounting for 1st person , but second person to follwo same suit
//        if (r1 == rows - 1 && c1 == cols - 1)
//        {
//            return grid[r1][c1];
//        }

//        // Now start picking the cherry
//        int currentCherry = 0;

//        // If both the guys land at same co-ordinate
//        if (r1 == r2 && c1 == c2)
//        {
//            currentCherry = grid[r1][c1];
//        }
//        else
//        {
//            // grab cherries from both guys
//            currentCherry = grid[r1][c1] + grid[r2][c2];
//        }

//        // Now move in all directions

//        int option1 = Solve(r1 + 1, c1, r2 + 1, rows, cols, grid, dp); // ↓ ↓
//        int option2 = Solve(r1 + 1, c1, r2, rows, cols, grid, dp);     // ↓ →
//        int option3 = Solve(r1, c1 + 1, r2 + 1, rows, cols, grid, dp); // → ↓
//        int option4 = Solve(r1, c1 + 1, r2, rows, cols, grid, dp);     // → →

//        int temp = Math.Max(Math.Max(option1, option2), Math.Max(option3, option4));

//        // get the best path
//        if (temp == -(int)1e9)
//        {
//            return temp;
//        }

//        return dp[r1, c1, r2] = currentCherry += temp;
//    }
//    private bool IsSafe(int r, int c, int rows, int cols, int[][] grid)
//    {
//        if (r < 0 || r >= rows || c >= cols || c < 0 || grid[r][c] == -1)
//        {
//            return false;
//        }

//        return true;
//    }

//    private int Solve(int[][] grid, int rows, int cols)
//    {
//        int[,,] dp = new int[rows, cols, rows];


//        for (int r1 = rows - 1; r1 >= 0; r1--)
//        {
//            for (int c1 = cols - 1; c1 >= 0; c1--)
//            {
//                for (int r2 = rows - 1; r2 >= 0; r2--)
//                {
//                    int c2 = r1 + c1 - r2;

//                    if (!IsSafe(r1, c1, rows, cols, grid) || !IsSafe(r2, c2, rows, cols, grid))
//                    {
//                        dp[r1, c1, r2] = -(int)1e9;
//                        continue;
//                    }

//                    // If we're at the bottom-right corner
//                    if (r1 == rows - 1 && c1 == cols - 1)
//                    {
//                        dp[r1, c1, r2] = grid[r1][c1];
//                        continue;
//                    }
//                    int currentCherry = 0;

//                    if (r1 == r2 && c1 == c2)
//                    {
//                        currentCherry = grid[r1][c1];
//                    }
//                    else
//                    {
//                        // grab cherries from both guys
//                        currentCherry = grid[r1][c1] + grid[r2][c2];
//                    }

//                    // Now move in all directions
//                    int option1 = -(int)1e9;
//                    int option2 = -(int)1e9;
//                    int option3 = -(int)1e9;
//                    int option4 = -(int)1e9;

//                    if (r1 + 1 < rows && r2 + 1 < rows)
//                    {
//                        option1 = dp[r1 + 1, c1, r2 + 1]; // ↓ ↓
//                    }

//                    if (r1 + 1 < rows && c2 + 1 < cols)
//                    {
//                        option2 = dp[r1 + 1, c1, r2];     // ↓ →
//                    }

//                    if (c1 + 1 < cols && r2 + 1 < rows)
//                    {
//                        option3 = dp[r1, c1 + 1, r2 + 1]; // → ↓
//                    }

//                    if (c1 + 1 < cols && c2 + 1 < cols)
//                    {
//                        option4 = dp[r1, c1 + 1, r2];     // → →
//                    }

//                    int temp = Math.Max(Math.Max(option1, option2), Math.Max(option3, option4));

//                    if (temp == -(int)1e9)
//                    {
//                        dp[r1, c1, r2] = temp;
//                    }
//                    else
//                    {
//                        dp[r1, c1, r2] = currentCherry + temp;
//                    }

//                }

//            }
//        }
//        return Math.Max(0, dp[0, 0, 0]);
//    }
//}
//class Program
//{
//    public static void Main()
//    {

//        Solution s = new Solution();

//        int[][] grid = new int[][] {
//            new int[]{0,1,-1 },
//            new int[] {1,0,-1 },
//            new int[]{1,1,1 }
//        };

//        Console.WriteLine(s.CherryPickup(grid));
//    }
//}