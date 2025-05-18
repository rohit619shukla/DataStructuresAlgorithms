

//class Solution
//{
//    // Time : O(2^n *2^n) => O(4^n) , space :O(n)
//    //    public int CherryPickup(int[][] grid)
//    //    {
//    //        int rows = grid.Length;
//    //        int cols = grid[0].Length;

//    //        return ForwardPath(grid, rows, cols, 0, 0);
//    //    }

//    //    private int ForwardPath(int[][] grid, int rows, int cols, int currRow, int currCol)
//    //    {
//    //        // base case
//    //        if (!IsSafe(grid, rows, cols, currRow, currCol))
//    //        {
//    //            return int.MinValue; // invalid path
//    //        }

//    //        // we reached last cell, now go backward
//    //        if (currRow == rows - 1 && currCol == cols - 1)
//    //        {
//    //            return BackwardPath(grid, rows, cols, currRow, currCol);
//    //        }

//    //        // Collect cherry
//    //        int cherry = grid[currRow][currCol];
//    //        grid[currRow][currCol] = 0;

//    //        // Explore paths
//    //        int down = ForwardPath(grid, rows, cols, currRow + 1, currCol);
//    //        int right = ForwardPath(grid, rows, cols, currRow, currCol + 1);

//    //        // Backtrack
//    //        grid[currRow][currCol] = cherry;

//    //        int bestForward = Math.Max(down, right);
//    //        if (bestForward == int.MinValue)
//    //        {
//    //            return int.MinValue; // no valid forward path
//    //        }

//    //        return cherry + bestForward;
//    //    }

//    //    private int BackwardPath(int[][] grid, int rows, int cols, int currRow, int currCol)
//    //    {
//    //        // base case
//    //        if (!IsSafe(grid, rows, cols, currRow, currCol))
//    //        {
//    //            return int.MinValue; // invalid path
//    //        }

//    //        // we reached start cell
//    //        if (currRow == 0 && currCol == 0)
//    //        {
//    //            return grid[currRow][currCol];
//    //        }

//    //        // Collect cherry
//    //        int cherry = grid[currRow][currCol];
//    //        grid[currRow][currCol] = 0;

//    //        // Explore paths
//    //        int up = BackwardPath(grid, rows, cols, currRow - 1, currCol);
//    //        int left = BackwardPath(grid, rows, cols, currRow, currCol - 1);

//    //        // Backtrack
//    //        grid[currRow][currCol] = cherry;

//    //        int bestBackward = Math.Max(up, left);
//    //        if (bestBackward == int.MinValue)
//    //        {
//    //            return int.MinValue; // no valid backward path
//    //        }

//    //        return cherry + bestBackward;
//    //    }

//    //private bool IsSafe(int[][] grid, int rows, int cols, int currRow, int currCol)
//    //{
//    //    return currRow >= 0 && currRow < rows &&
//    //           currCol >= 0 && currCol < cols &&
//    //           grid[currRow][currCol] != -1;
//    //}

//    // Memoization : Time : O(N^3) , space :O(n+m) = O(n) mainly due to stack space going for path
//    //public int CherryPickup(int[][] grid)
//    //{
//    //    int rows = grid.Length;
//    //    int cols = grid[0].Length;

//    //    int[,,] dp = new int[rows, cols, rows];
//    //    for (int i = 0; i < rows; i++)
//    //    {
//    //        for (int j = 0; j < cols; j++)
//    //        {
//    //            for (int k = 0; k < rows; k++)
//    //            {
//    //                dp[i, j, k] = -1;
//    //            }
//    //        }
//    //    }

//    //    return Math.Max(0, Solve(grid, rows, cols, 0, 0, 0, dp));
//    //}

//    //private int Solve(int[][] grid, int rows, int cols, int r1, int c1, int r2, int[,,] dp)
//    //{
//    //    int c2 = r1 + c1 - r2;  // this is derived and is same as carrying an extra parameter in the function call . but will save memory   

//    //    if (!IsSafe(grid, rows, cols, r1, c1, r2, c2))
//    //    {
//    //        return int.MinValue;
//    //    }

             //// We have reached last cell
//    //    if (r1 == rows - 1 && c1 == cols - 1)
//    //    {
//    //        return grid[r1][c1];
//    //    }

//    //    if (dp[r1, c1, r2] != -1)
//    //    {
//    //        return dp[r1, c1, r2];
//    //    }

//    //    int cherryPick = 0;
            

            //// If both point to same cell we will take it once only
//    //    if (r1 == r2 && c1 == c2)
//    //    {
//    //        cherryPick += grid[r1][c1];
//    //    }
//    //    else
//    //    {
//    //        cherryPick += grid[r1][c1] + grid[r2][c2];
//    //    }

//    //    int maxAns = int.MinValue;

//    //    maxAns = Math.Max(maxAns, Solve(grid, rows, cols, r1 + 1, c1, r2 + 1, dp)); // both down
//    //    maxAns = Math.Max(maxAns, Solve(grid, rows, cols, r1, c1 + 1, r2, dp));     // both right
//    //    maxAns = Math.Max(maxAns, Solve(grid, rows, cols, r1 + 1, c1, r2, dp));     // p1 down, p2 right
//    //    maxAns = Math.Max(maxAns, Solve(grid, rows, cols, r1, c1 + 1, r2 + 1, dp)); // p1 right, p2 down

//    //    return dp[r1, c1, r2] = cherryPick + maxAns;
//    //}
        

        // Since we are moving both we need to take both into account
//    //private bool IsSafe(int[][] grid, int rows, int cols, int r1, int c1, int r2, int c2)
//    //{
//    //    if (r1 >= 0 && r1 < rows && c1 >= 0 && c1 < cols &&
//    //        r2 >= 0 && r2 < rows && c2 >= 0 && c2 < cols &&
//    //        grid[r1][c1] != -1 && grid[r2][c2] != -1)
//    //    {
//    //        return true;
//    //    }
//    //    return false;
//    //}

//    // Tabulation : O(N^3) , apce :O(N^3), no recursive stack space
//    public int CherryPickup(int[][] grid)
//    {
//        int n = grid.Length;
//        int m = grid[0].Length;

//        int[,,] dp = new int[n, m, n];

//        for (int r1 = 0; r1 < n; r1++)
//        {
//            for (int c1 = 0; c1 < m; c1++)
//            {
//                for (int r2 = 0; r2 < n; r2++)
//                {
//                    dp[r1, c1, r2] = int.MinValue;
//                }
//            }
//        }

//        dp[n - 1, m - 1, n - 1] = grid[n - 1][m - 1];

//        for (int r1 = n - 1; r1 >= 0; r1--)
//        {
//            for (int c1 = m - 1; c1 >= 0; c1--)
//            {
//                for (int r2 = n - 1; r2 >= 0; r2--)
//                {
//                    int c2 = r1 + c1 - r2;

//                    if (c2 < 0 || c2 >= m || grid[r1][c1] == -1 || grid[r2][c2] == -1)
//                        continue;

//                    // 🍒 First collect cherries
//                    int cherries = (r1 == r2 && c1 == c2) ? grid[r1][c1] : grid[r1][c1] + grid[r2][c2];

//                    int currentMax = int.MinValue;

//                    // 🚀 Now check all moves
//                    if (c1 + 1 < m && c2 + 1 < m)
//                        currentMax = Math.Max(currentMax, dp[r1, c1 + 1, r2]);

//                    if (r1 + 1 < n && c2 + 1 < m)
//                        currentMax = Math.Max(currentMax, dp[r1 + 1, c1, r2]);

//                    if (c1 + 1 < m && r2 + 1 < n)
//                        currentMax = Math.Max(currentMax, dp[r1, c1 + 1, r2 + 1]);

//                    if (r1 + 1 < n && r2 + 1 < n)
//                        currentMax = Math.Max(currentMax, dp[r1 + 1, c1, r2 + 1]);

//                    if (currentMax == int.MinValue)
//                        continue;

//                    // 🍒 Add current cherries after moves, as per your recursive style
//                    dp[r1, c1, r2] = cherries + currentMax;
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
//        int[][] grid = new int[][]
// {
//    new int[] { 1, 1, -1 },
//    new int[] { 1, -1, 1 },
//    new int[] { 1, 0, 1 }
// };

//        Solution s = new Solution();

//        Console.WriteLine(s.CherryPickup(grid));
//    }
//}

//// Note : this is very interesting DP example with state changes and all

////🚫 Approach 1: Forward and Backward (Two Sequential Trips)
////Steps:
////First trip: (0, 0) → (N - 1, N - 1), collect cherries.

////Mark cherries as picked (set cell to 0).

////Second trip: (N - 1, N - 1) → (0, 0), collect remaining cherries.

////❌ Shortcomings:
////Sequential Dependency:

////Second trip depends on the state after the first trip.

////If you pick cherries in a way that blocks your return path, you're stuck.

////Example: You clear cherries while going forward but accidentally block your path for coming back.

////Rigid Exploration:

////You are limited to: go full forward → go full backward.

////No flexibility to explore paths dynamically.

////Redundant Work:

////You simulate two separate paths.

////Difficult to memoize efficiently across trips.

////Might recompute similar states in forward and backward trips.

////Higher Risk of Failure:

////Path to return might not exist after the forward trip.

////Some grids work fine, but trickier layouts can trap you.

////Complex Implementation:

////Need to manage grid states carefully between trips.

////Requires grid copy or undo operations to backtrack cherry collection.

////✅ Approach 2: Two - Person Simultaneous Traversal
////Steps:
////Simulate two persons starting at (0,0).

////Both take exactly the same number of steps at any point.

////Possible moves:

////Person 1 → right or down

////Person 2 → right or down

////Collect cherries at both positions, count once if they meet.

////🎉 Advantages:
////Parallel Exploration:

////Both persons explore different paths simultaneously.

////If one person is blocked, the other might still reach valuable cherries.

////Better coverage of the grid in one pass.

////Flexible Movement (4 Recursive Options):

////(Right, Right)

////(Down, Down)

////(Right, Down)

////(Down, Right)

////🔥 Huge benefit: Even if one person takes a risky path, the other can go safer, maximizing total cherries.

////Avoids Sequential Dependency:

////No "forward" then "backward" constraint.

////Both trips (forward + return) happen together, removing risk of getting stuck between phases.

////Simpler Memoization:

////State = (r1, c1, r2, c2), or optimized to 3D since steps are equal.

////Reuse results of subproblems efficiently.

////Cleaner Code & No Need to Reset Grid:

////No need to modify the grid to "remove cherries".

////Handle cherry counting within the state itself.

////Works on All Grid Types:

////Handles grids with tight paths and obstacles more reliably.

////Always finds the best combination of paths between both persons.

