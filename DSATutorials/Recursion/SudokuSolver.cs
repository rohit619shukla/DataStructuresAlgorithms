

//class Solution
//{
//    public void SolveSudoku(char[][] board)
//    {
//        int rows = board.Length;
//        int cols = board[0].Length;

//        Solve(board, rows, cols);
//    }

//    private bool Solve(char[][] board, int rows, int cols)
//    {
//        // Iterate of rows and columns to check for the space to be filled
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                // If the current cell is empty only then try to fill
//                if (board[i][j] == '.')
//                {
//                    // Try combination of all 9 colors can be filled or not
//                    for (char k = '1'; k <= '9'; k++)
//                    {
//                        // Now check if the cell can be filled or not
//                        if (CanBeFilled(board, i, j, k))
//                        {
//                            // fill the give cell
//                            board[i][j] = k;

//                            if (Solve(board, rows, cols))
//                            {
//                                return true;
//                            }

//                            //backtrack , cannot be filled
//                            board[i][j] = '.';
//                        }
//                    }

//                    // none of the color can be applied
//                    return false;
//                }
//            }
//        }

//        // the board is already filled
//        return true;
//    }

//    private bool CanBeFilled(char[][] board, int currentRowNode, int currentColNode, char currentChar)
//    {
//        for (int i = 0; i < 9; i++)
//        {
//            // Check for column
//            if (board[currentRowNode][i] == currentChar)
//            {
//                return false;
//            }

//            // Check for rows
//            if (board[i][currentColNode] == currentChar)
//            {
//                return false;
//            }

//            // Check for 3 * 3 matrix within the given matrix
//            int rowNode = 3 * (currentRowNode / 3) + (i / 3);
//            int colNode = 3 * (currentColNode / 3) + (i % 3);

//            if (board[rowNode][colNode] == currentChar)
//            {
//                return false;
//            }
//        }

//        return true;
//    }
//}
//class Program
//{
//    private static void Main()
//    {
//        char[][] board = new char[][] {
//            new char[] {'5','3','.','.','7','.','.','.','.' },
//            new char[] {'6','.','.','1','9','5','.','.','.'},
//            new char[] {'.','9','8','.','.','.','.','6','.'},
//            new char[] {'8','.','.','.','6','.','.','.','3'},
//            new char[] {'4','.','.','8','.','3','.','.','1'},
//            new char[] {'7','.','.','.','2','.','.','.','6'},
//            new char[] {'.','6','.','.','.','.','2','8','.' },
//            new char[] {'.','.','.','4','1','9','.','.','5' },
//            new char[] {'.','.','.','.','8','.','.','7','9'},
//        };


//        Solution s = new Solution();
//        s.SolveSudoku(board);

//        for (int i = 0; i < board.Length; i++)
//        {
//            for (int j = 0; j < board[0].Length; j++)
//            {
//                Console.Write($"{board[i][j]}" + " ");
//            }

//            Console.WriteLine();
//        }
//    }
//}

////Time Complexity: O(9^N) where n is number of empty cells, in the worst case, for each cell in the n2 board, we have 9 possible numbers.
//// Space :O(N) Recursive stack space for n cells