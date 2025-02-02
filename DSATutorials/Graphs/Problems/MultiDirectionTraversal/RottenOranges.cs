//// Leetcode: 994 (Medium)

//class Graph
//{
//    public int OrangesRotting(int[][] grid)
//    {
//        // initial configuration
//        int rows = grid.Length;
//        int cols = grid[0].Length;


//        // final array to store the result
//        int[,] result = new int[rows, cols];


//        return BFS(rows, cols, grid, result);
//    }

//    private int BFS(int rows, int cols, int[][] grid, int[,] result)
//    {
//        // Create a queue for BFS : Source node, dest node and time taken to rot
//        Queue<(int, int, int)> q = new Queue<(int, int, int)>();

//        // intialize timer to rot
//        int finalTime = 0;

//        // since we need to figure out min time to rot we chose BFS and hence we will try to process nodes with 2 simulatenously
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (grid[i][j] == 2)
//                {
//                    q.Enqueue((i, j, 0));
//                }
//            }
//        }

//        // For exploration in 4 direction
//        int[] deltaRow = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };

//        // Now we have atleast some nodes to start BFS
//        while (q.Count > 0)
//        {
//            (int currentRow, int currentCol, int time) = q.Dequeue();

//            // Explore adjacent nodes to given node co-ordinates
//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = currentRow + deltaRow[i];
//                int newCol = currentCol + deltaCols[i];

//                if (IsGoodToRotten(newRow, newCol, rows, cols, grid, result))
//                {
//                    finalTime = time + 1;
//                    // rot the orange in the given co-ordinate
//                    result[newRow, newCol] = 2;

//                    // Add the node to queue
//                    q.Enqueue((newRow, newCol, finalTime));
//                }

//            }
//        }

//        return (AreAllRotten(grid, result) ? finalTime : -1);
//    }

//    private bool IsGoodToRotten(int currRow, int currCol, int rows, int cols, int[][] grid, int[,] result)
//    {
//        if (currRow >= 0 && currRow < rows &&
//            currCol >= 0 && currCol < cols &&
//            grid[currRow][currCol] == 1 &&
//            result[currRow, currCol] != 2)
//        {
//            return true;
//        }

//        return false;
//    }

//    private bool AreAllRotten(int[][] grid, int[,] result)
//    {
//        for (int i = 0; i < grid.Length; i++)
//        {
//            for (int j = 0; j < grid[0].Length; j++)
//            {
//                if (grid[i][j] == 1 && result[i, j] != 2)
//                {
//                    return false;
//                }
//            }
//        }

//        return true;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] grid = new int[][] {
//            new int[] {2,1,1 },
//            new int[] {0,1,1 },
//            new int[] { 1,0,1}
//        };

//        Graph g = new Graph();

//        Console.WriteLine(g.OrangesRotting(grid));
//    }
//}


//// Complexity : O(N*M)