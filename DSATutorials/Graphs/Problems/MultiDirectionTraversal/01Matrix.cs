//public class Solution
//{
//    public int[][] UpdateMatrix(int[][] mat)
//    {
//        int rows = mat.Length;
//        int cols = mat[0].Length;

//        bool[,] visited = new bool[rows, cols];

//        int[][] distance = new int[rows][];

//        for (int i = 0; i < rows; i++)
//        {
//            distance[i] = new int[cols];
//        }

//        // sr, sc, distance
//        Queue<(int, int, int)> q = new Queue<(int, int, int)>();

//        // Put all 0's in the queue
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (mat[i][j] == 0)
//                {
//                    q.Enqueue((i, j, 0));
//                    visited[i, j] = true;
//                }
//            }
//        }

//        int[] deltaRows = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };

//        // start BFS

//        while (q.Count > 0)
//        {
//            (int sr, int sc, int dist) = q.Dequeue();

//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = sr + deltaRows[i];
//                int newCol = sc + deltaCols[i];

//                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && visited[newRow, newCol] == false && mat[newRow][newCol] == 1)
//                {
//                    q.Enqueue((newRow, newCol, dist + 1));
//                    visited[newRow, newCol] = true;
//                    distance[newRow][newCol] = dist + 1;
//                }
//            }
//        }

//        return distance;
//    }
//}


//class Program
//{
//    public static void Main()
//    {

//        Solution s = new Solution();

//        int[][] mat = new int[][] {
//                    new int[]  {0,0,0 },
//                    new int[] { 0,1,0},
//                    new int[]  { 1,1,1}
//                };

//        var result = s.UpdateMatrix(mat);

//        for (int i = 0; i < result.Length; i++)
//        {
//            for (int j = 0; j < result[0].Length; j++)
//            {
//                Console.Write($"{result[i][j]}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }

//}

//// Time : O(N * M) | Space : O(N * M)

//// Why Multi-Source BFS starting from all 0s?
//// The question asks: find the distance of the nearest 0 from each cell.
//// A cell can be 0 or 1. Distance of 0 to 0 is always 0 (the cell itself is the nearest 0).
//// So we already know the answer for all 0-cells — they are our "known" starting layer.
////
//// We enqueue all 0s with distance 0, then BFS expands level by level:
////   - Level 1: any 1 adjacent to a 0 → distance = 1
////   - Level 2: any 1 adjacent to a distance-1 cell → distance = 2
////   - ...and so on
//// Each 1 is first reached by the closest 0's wavefront, so BFS guarantees the minimum distance.
////
//// Why NOT start from 1s?
//// Multi-source BFS requires all sources to start with the same known distance.
//// 0s all start at distance 0 (their answer is trivially 0) — uniform and known. ✅
//// 1s have unknown distances (that's what we're solving for!) — if we enqueue all 1s
//// with distance 0, we'd be saying "every 1 is 0 away from a 0" which is wrong. ❌
////
//// Individual BFS from each 1 would work but costs O((N*M)^2):
////   ~N*M ones × O(N*M) BFS per one.
//// By flipping the perspective and starting from 0s,
//// one single BFS pass covers the entire matrix in O(N*M).
