//// Leetcode 733 (Medium)

//public class Solution
//{
//    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
//    {
//        // This will be the source color to recognize the connected nodes
//        int initialColor = image[sr][sc];

//        int rows = image.Length;
//        int cols = image[0].Length;

//        int[,] explored = new int[rows, cols];

//        // for traversing in 4 directions
//        int[] deltaRow = { -1, 0, 1, 0 };
//        int[] deltaCol = { 0, 1, 0, -1 };

//        // start DFS floodfill from given co-ordinates
//        DFS(sr, sc, rows, cols, deltaRow, deltaCol, initialColor, image, explored, color);

//        return image;
//    }

//    private void DFS(int currRow, int currCol, int rows, int cols, int[] deltaRow, int[] deltaCol, int initialColor, int[][] image, int[,] explored, int color)
//    {
//        // mark the given node co-ordinates as visited
//        explored[currRow, currCol] = 1;

//        // fill the node with color
//        image[currRow][currCol] = color;

//        // start exploring the adjacent nodes
//        for (int i = 0; i < 4; i++)
//        {
//            int newRow = currRow + deltaRow[i];
//            int newCol = currCol + deltaCol[i];

//            if (IsGoodToFill(newRow, newCol, image, explored, rows, cols, initialColor))
//            {
//                DFS(newRow, newCol, rows, cols, deltaRow, deltaCol, initialColor, image, explored, color);
//            }

//        }
//    }

//    private bool IsGoodToFill(int newRow, int newCol, int[][] image, int[,] explored, int rows, int cols, int initialColor)
//    {
//        if (newRow >= 0 && newRow < rows &&
//            newCol >= 0 && newCol < cols &&
//            explored[newRow, newCol] == 0 &&
//            image[newRow][newCol] == initialColor)
//        {
//            return true;
//        }

//        return false;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] image = new int[][] {
//            new int[] { 1,1,1},
//            new int[] { 1,1,0},
//            new int[] { 1, 0, 1 }
//        };

//        Solution g = new Solution();

//        int[][] result = g.FloodFill(image, 1, 1, 2);

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

//////Time Complexity: O(N * M)
//////Auxiliary Space: O(N * M)