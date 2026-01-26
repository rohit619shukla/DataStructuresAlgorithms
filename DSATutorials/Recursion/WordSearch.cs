//using System.Text;
//public class Solution
//{
//    public bool Exist(char[][] board, string word)
//    {
//        int rows = board.Length;
//        int cols = board[0].Length;

//        // Direction arrays for clean neighbor traversal
//        int[] deltaRows = { 1, 0, 0, -1 };
//        int[] deltaCols = { 0, -1, 1, 0 };

//        bool[,] visited = new bool[rows, cols];

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                // Kick off DFS if the first character matches
//                if (board[i][j] == word[0])
//                {
//                    if (DFS(i, j, rows, cols, deltaRows, deltaCols, board, word, 0, visited))
//                        return true;
//                }
//            }
//        }
//        return false;
//    }

//    private bool DFS(int r, int c, int rows, int cols,
//                     int[] deltaRows, int[] deltaCols,
//                     char[][] board, string word, int index, bool[,] visited)
//    {
//        // 1. Base Case: Successfully matched the entire word
//        if (index == word.Length)
//            return true;

//        // 2. Base Case: Failure conditions
//        // - Out of bounds
//        // - Character doesn't match
//        // - Already visited in current path
//        if (r < 0 || r >= rows || c < 0 || c >= cols ||
//            board[r][c] != word[index] || visited[r, c])
//        {
//            return false;
//        }

//        // 3. Action: Mark the current node as visited (OUTSIDE the loop)
//        visited[r, c] = true;

//        // 4. Explore: Try all 4 directions for the NEXT character
//        for (int i = 0; i < 4; i++)
//        {
//            int nextR = r + deltaRows[i];
//            int nextC = c + deltaCols[i];

//            if (DFS(nextR, nextC, rows, cols, deltaRows, deltaCols, board, word, index + 1, visited))
//                return true;
//        }

//        // 5. Backtrack: Unmark the current node (OUTSIDE the loop)
//        visited[r, c] = false;

//        return false;
//    }
//}



//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        char[][] board = new char[][] {
//            new char[] {'A','B','C','E' },
//            new char[] { 'S','F','C','S'},
//            new char[] { 'A','D','E','E'},
//        };

//        //char[][] board = new char[][] {
//        //new char[] { 'a'}
//        //};

//        string word = "a";

//        Console.WriteLine(s.Exist(board, word));
//    }
//}

//// Time :O(4 *N*M) , space :O(N*M+L)