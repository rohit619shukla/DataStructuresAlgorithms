//// Leetcode 130. (Medium)

//class Graph
//{
//    public void SurroundedRegions(char[,] mat, int rows, int cols)
//    {
//        // Create Queue to perform BFS starting from 'O' node
//        Queue<(int, int)> q = new Queue<(int, int)>();

//        // Iterate through the matrix and get all 'O'

//        int[,] explored = new int[rows, cols];
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (i == 0 || j == cols - 1 || i == rows - 1 || j == 0)
//                {
//                    if (mat[i, j] == 'O')
//                    {
//                        explored[i, j] = 1;
//                        q.Enqueue((i, j));
//                    }

//                }
//            }
//        }

//        int[] deltaRows = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };


//        // Start BFS
//        while (q.Count > 0)
//        {
//            (int currRowNode, int currColNode) = q.Dequeue();

//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = currRowNode + deltaRows[i];
//                int newCol = currColNode + deltaCols[i];

//                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && explored[newRow, newCol] == 0 && mat[newRow, newCol] == 'O')
//                {
//                    explored[newRow, newCol] = 1;
//                    q.Enqueue((newRow, newCol));
//                }
//            }
//        }

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (explored[i, j] == 0 && mat[i, j] == 'O')
//                {
//                    mat[i, j] = 'X';
//                }
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        char[,] mat =  {{'X', 'O', 'X', 'X', 'X', 'X'},
//                            {'X', 'O', 'X', 'X', 'O', 'X'},
//                            {'X', 'X', 'X', 'O', 'O', 'X'},
//                            {'O', 'X', 'X', 'X', 'X', 'X'},
//                            {'X', 'X', 'X', 'O', 'X', 'O'},
//                            {'O', 'O', 'X', 'O', 'O', 'O'},
//                        };

//        int rows = mat.GetLength(0);
//        int cols = mat.GetLength(1);

//        Graph g = new Graph();
//        g.SurroundedRegions(mat, rows, cols);

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                Console.Write($"{mat[i, j]}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}

//// Complexity : O(N*M) space as well