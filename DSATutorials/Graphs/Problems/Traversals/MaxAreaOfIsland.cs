


//public class Solution
//{
//    public int MaxAreaOfIsland(int[][] grid)
//    {
//        int rows = grid.Length;
//        int cols = grid[0].Length;


//        bool[,] visited = new bool[rows, cols];
//        int[] deltaRows = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };
//        int max = 0;

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (grid[i][j] == 1 && visited[i, j] == false)
//                {
//                    var result = BFS(i, j, visited, grid, deltaRows, deltaCols, rows, cols);
//                    max = Math.Max(max, result);
//                }
//            }
//        }

//        return max;
//    }

//    private int BFS(int sr, int sc, bool[,] visited, int[][] grid, int[] deltaRows, int[] deltaCols, int rows, int cols)
//    {
//        int count = 1;

//        Queue<(int, int)> q = new Queue<(int, int)>();

//        q.Enqueue((sr, sc));
//        visited[sr, sc] = true;

//        while (q.Count > 0)
//        {
//            (int currRow, int currCol) = q.Dequeue();

//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = currRow + deltaRows[i];
//                int newCol = currCol + deltaCols[i];

//                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && visited[newRow, newCol] == false && grid[newRow][newCol] == 1)
//                {
//                    q.Enqueue((newRow, newCol));
//                    visited[newRow, newCol] = true;
//                    count++;
//                }
//            }
//        }

//        return count;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] grid = {
//    new int[] { 1, 1, 0, 0, 0 },
//    new int[] { 1, 1, 0, 0, 0 },
//    new int[] { 0, 0, 0, 1, 1 },
//    new int[] { 0, 0, 0, 1, 1 }
//};

//        Solution s = new Solution();

//        Console.WriteLine($"{s.MaxAreaOfIsland(grid)}");
//    }
//}