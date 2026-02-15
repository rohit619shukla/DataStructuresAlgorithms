//public class Solution
//{
//    public int MinimumEffortPath(int[][] heights)
//    {
//        int rows = heights.Length;
//        int cols = heights[0].Length;

//        int[,] result = new int[rows, cols];

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {

//                result[i, j] = (int)1e9;
//            }
//        }

//        result[0, 0] = 0;

//        int[] delatRows = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };

//        PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();

//        pq.Enqueue((0, 0), 0);


//        while (pq.Count > 0)
//        {
//            if (pq.TryDequeue(out (int r, int c) cell, out int cost))
//            {
//                int sr = cell.r;
//                int sc = cell.c;

//                // Same like visited array
//                if (cost > result[sr, sc])
//                {
//                    continue;
//                }

//                // Since we are using a PQ, we may have n entires for same cell, but the moment we will pop we will always get the smallest on top
//                if (sr == rows - 1 && sc == cols - 1)
//                {
//                    return cost;
//                }

//                for (int i = 0; i < 4; i++)
//                {
//                    int newRow = sr + delatRows[i];
//                    int newCol = sc + deltaCols[i];

//                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
//                    {
//                        // We need to get the currentMaxEffort as asked in the question
//                        int effort = Math.Max(cost, Math.Abs(heights[sr][sc] - heights[newRow][newCol]));

//                        if (result[newRow, newCol] > effort)
//                        {
//                            result[newRow, newCol] = effort;
//                            pq.Enqueue((newRow, newCol), effort);
//                        }
//                    }
//                }
//            }
//        }

//        return 0;
//    }
//}

//// Time : O(N*M)

//class Program
//{
//    public static void Main()
//    {
//        int[][] heights = {
//            new int[] { 1,2,2},
//            new int[] {3,8,2 },
//            new int[] { 5,3,5}
//        };

//        Solution s = new Solution();

//        Console.WriteLine($"{s.MinimumEffortPath(heights)}");
//    }
//}

//// Idea to apply Dijk comes from fact that we have a source and a dest to reac with variable wieghts to each edge