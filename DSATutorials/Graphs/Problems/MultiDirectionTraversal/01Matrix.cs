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

//// Time : 4 * (N*M)