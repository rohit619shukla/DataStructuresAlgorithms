

//public class Solution
//{
//    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
//    {
//        int rows = image.Length;
//        int cols = image[0].Length;

//        int[][] visited = new int[rows][];

//        for (int i = 0; i < visited.Length; i++)
//        {
//            visited[i] = new int[cols];
//        }

//        int originalColor = image[sr][sc];

//        Queue<(int, int)> q = new Queue<(int, int)>();

//        q.Enqueue((sr, sc));
//        image[sr][sc] = color;
//        visited[sr][sc] = 1;

//        int[] deltaRow = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };

//        while (q.Count > 0)
//        {
//            (int sourceNode, int destNode) = q.Dequeue();

//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = sourceNode + deltaRow[i];
//                int newCol = destNode + deltaCols[i];

//                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && image[newRow][newCol] == originalColor && visited[newRow][newCol] != 1)
//                {
//                    q.Enqueue((newRow, newCol));
//                    visited[newRow][newCol] = 1;
//                    image[newRow][newCol] = color;
//                }
//            }
//        }

//        return image;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int[][] image = {
//            new int[] { 1,1,1},
//            new int[] { 1,1,0},
//            new int[] { 1, 0, 1 }
//        };

//        int sr = 1, sc = 1, color = 2;

//        Solution s = new Solution();

//        var result = s.FloodFill(image, sr, sc, color);

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

////Time Complexity: O(N * M)
////Auxiliary Space: O(N * M)