//using System.Text;
//public class Solution
//{
//    public bool Exist(char[][] board, string word)
//    {
//        int rows = board.Length;
//        int cols = board[0].Length;
//        int[] deltaRows = { 1, 0, 0, -1 };
//        int[] deltaCols = { 0, -1, 1, 0 };
//        int[,] visited = new int[rows, cols];

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (board[i][j] == word[0]) // Start search only if first character matches
//                {
//                    if (Recursion(board, word, deltaRows, deltaCols, i, j, 0, visited))
//                    {
//                        return true;
//                    }
//                }
//            }
//        }

//        return false;
//    }

//    private bool Recursion(char[][] board,
//        string word,
//        int[] deltaRows,
//        int[] deltaCols,
//        int currRow,
//        int currCol,
//        int index,
//        int[,] visited)
//    {

//        // Base case: if we have matched the full word
//        if (index == word.Length - 1)
//        {
//            return true;
//        }

//        // Traverse all 4 directions
//        for (int i = 0; i < 4; i++)
//        {
//            int newRow = currRow + deltaRows[i];
//            int newCol = currCol + deltaCols[i];

//            // Check if the next move is valid before proceeding
//            if (GoodToAdd(board.Length, board[0].Length, visited, newRow, newCol, board, word, index + 1))
//            {
//                // Mark as visited
//                visited[currRow, currCol] = 1;

//                // Move to next
//                if (Recursion(board, word, deltaRows, deltaCols, newRow, newCol, index + 1, visited))
//                {
//                    return true;
//                }

//                // Backtracking
//                visited[currRow, currCol] = 0;
//            }
//        }

//        return false;
//    }

//    private bool GoodToAdd(int rows, int cols, int[,] visited, int currRow, int currCol, char[][] board, string word, int index)
//    {
//        return currRow >= 0 && currRow < rows &&
//               currCol >= 0 && currCol < cols &&
//               visited[currRow, currCol] == 0 &&
//               board[currRow][currCol] == word[index];
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        //char[][] board = new char[][] {
//        //    new char[] {'A','B','C','E' },
//        //    new char[] { 'S','F','C','S'},
//        //    new char[] { 'A','D','E','E'},
//        //};

//        char[][] board = new char[][] {
//        new char[] { 'a'}
//        };

//        string word = "a";

//        Console.WriteLine(s.Exist(board, word));
//    }
//}

//// Time :O(4 *N*M) , space :O(N*M+L)