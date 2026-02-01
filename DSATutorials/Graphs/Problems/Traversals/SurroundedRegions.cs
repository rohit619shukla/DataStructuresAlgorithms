

//public class Solution
//{
//    public void Solve(char[][] board)
//    {
//        // The core idea is to convert all 'O' to 'X'.
//        // Now we could start from putting all 'O' isn queue and perform mulstisource BFS to mark, but this will be tim consuming
//        // Obeservation states that we need to be wary of boundary 'O' only
//        // So hence we will work only on those 'O' on boundary

//        Queue<(int, int)> q = new Queue<(int, int)>();
//        int rows = board.Length;
//        int cols = board[0].Length;

//        bool[,] visited = new bool[rows, cols];


//        // Put all boundary 'O' in queue
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (board[i][j] == 'O' && (i == 0 || i == rows - 1 || j == 0 || j == cols - 1))
//                {
//                    q.Enqueue((i, j));
//                    visited[i, j] = true;
//                }
//            }
//        }

//        int[] deltaRows = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };

//        // start BFS
//        while (q.Count > 0)
//        {
//            (int sr, int sc) = q.Dequeue();

//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = sr + deltaRows[i];
//                int newCol = sc + deltaCols[i];

//                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && board[newRow][newCol] == 'O' && visited[newRow, newCol] == false)
//                {
//                    q.Enqueue((newRow, newCol));
//                    visited[newRow, newCol] = true;
//                }
//            }
//        }

//        // Now all the cells which are 'O' and were not touched by boundary 'O' can simply be converted to 'X'
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (board[i][j] == 'O' && visited[i, j] == false)
//                {
//                    board[i][j] = 'X';
//                }
//            }
//        }
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        char[][] board = {
//            new char[] {'X','X','X','X' },
//             new char[] { 'X','O','O','X'},
//              new char[] { 'X','X','O','X'},
//               new char[] {'X','O','X','X' },
//        };

//        Solution s = new Solution();

//        s.Solve(board);

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

//// Time : O(N*M)