

//public class Solution
//{
//    public int OrangesRotting(int[][] grid)
//    {
//        int rows = grid.Length;
//        int cols = grid[0].Length;

//        Queue<(int, int, int)> q = new Queue<(int, int, int)>();

//        int[,] visited = new int[rows, cols];

//        // Add all the rotten oranges to queue to start with BFS
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

//        int totalTime = 0;

//        int[] deltaRow = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };

//        // start BFS
//        while (q.Count > 0)
//        {
//            (int sourcNode, int destNode, int time) = q.Dequeue();

//            totalTime = time;

//            // Explore all adh=jacent nodes in 4 directions
//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = sourcNode + deltaRow[i];
//                int newCol = destNode + deltaCols[i];

//                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1 && visited[newRow, newCol] != 1)
//                {
//                    visited[newRow, newCol] = 1;
//                    q.Enqueue((newRow, newCol, time + 1));
//                }
//            }
//        }

//        // check if all node are rotten
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (grid[i][j] == 1 && visited[i, j] != 1)
//                {
//                    return -1;
//                }
//            }
//        }

//        return totalTime;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] grid = new int[][] {
//                    new int[] {2,1,1 },
//                    new int[] {1,1,0 },
//                    new int[] { 0,1,1}
//                };


//        Solution s = new Solution();

//        Console.WriteLine($"{s.OrangesRotting(grid)}");
//    }
//}

//// Complexity : O(N*M)