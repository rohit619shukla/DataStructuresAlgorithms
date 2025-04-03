
//using System.Text;

//class Solution
//{
//    public void Solve(int[][] arr)
//    {
//        int rows = arr.Length;
//        int columns = arr[0].Length;

//        int[,] visited = new int[rows, columns];

//        int[] deltaRows = { 1, 0, 0, -1 };
//        int[] deltaCols = { 0, -1, 1, 0 };

//        string directions = "DLRU";

//        StringBuilder result = new StringBuilder();

//        Maze(arr, visited, deltaRows, deltaCols, directions, 0, 0, rows, columns, result);
//    }

//    private void Maze(int[][] arr, int[,] visited,
//        int[] deltaRows, int[] deltaCols, string directions,
//        int currRowNode, int currColNode,
//        int rows, int cols, StringBuilder result)
//    {

//        // base case
//        if (currRowNode == rows - 1 && currColNode == cols - 1)
//        {
//            // print the given string
//            Console.WriteLine(result.ToString());
//            return;
//        }

//        // Explore the 4 directions
//        for (int i = 0; i < 4; i++)
//        {
//            int newRow = currRowNode + deltaRows[i];
//            int newCol = currColNode + deltaCols[i];

//            if (IsOkToVisit(arr, visited, newRow, newCol, rows, cols))
//            {
//                // Mark the given node as visited
//                visited[currRowNode, currColNode] = 1;

//                // Move to next call for new nodes and add to string
//                Maze(arr, visited,
//                     deltaRows, deltaCols, directions,
//                     newRow, newCol,
//                     rows, cols, result.Append(directions[i]));

//                //backtracking
//                visited[currRowNode, currColNode] = 0;

//                result.Length--;
//            }
//        }


//    }

//    private bool IsOkToVisit(int[][] arr, int[,] visited, int currRowNode, int currColNode, int rows, int cols)
//    {
//        if (currRowNode >= 0 && currRowNode < rows &&
//            currColNode >= 0 && currColNode < cols &&
//            arr[currRowNode][currColNode] == 1 &&
//            visited[currRowNode, currColNode] == 0)
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
//        int[][] arr =
//        {
//                            new int[] { 1, 0, 0, 0 },
//                            new int[] { 1, 1, 0, 1 },
//                            new int[] { 1, 1, 0, 0 },
//                            new int[] { 0, 1, 1, 1 }
//                        };


//        Solution s = new Solution();
//        s.Solve(arr);
//    }
//}

//// Time : 4 * (rows*columns) ,spacE :O(rows*cols)