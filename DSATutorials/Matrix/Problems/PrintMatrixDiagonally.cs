//using System;

//class TestClass
//{
//    public int[] FindDiagonalOrder(int[][] mat)
//    {
//        if (mat.Length == 0 || mat[0].Length == 0)
//            return new int[0];

//        int rowEnd = mat.Length;           // Total number of rows
//        int colEnd = mat[0].Length;        // Total number of columns
//        int[] result = new int[rowEnd * colEnd]; // Array to store the final diagonal order

//        int index = 0;                     // Index to insert values into result array
//        int row = 0, col = 0;               // Pointers to navigate through the matrix
//        bool upward = true;                // Direction flag: true for upward, false for downward

//        while (index < result.Length)
//        {
//            result[index++] = mat[row][col]; // Store the current matrix element

//            if (upward)
//            {
//                if (col == colEnd - 1)      // If at the last column, move down
//                {
//                    row++;
//                    upward = false;
//                }
//                else if (row == 0)          // If at the first row, move right
//                {
//                    col++;
//                    upward = false;
//                }
//                else                        // Move diagonally up-right
//                {
//                    row--;
//                    col++;
//                }
//            }
//            else
//            {
//                if (row == rowEnd - 1)      // If at the last row, move right
//                {
//                    col++;
//                    upward = true;
//                }
//                else if (col == 0)          // If at the first column, move down
//                {
//                    row++;
//                    upward = true;
//                }
//                else                        // Move diagonally down-left
//                {
//                    row++;
//                    col--;
//                }
//            }
//        }

//        return result;
//    }


//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] arr = new int[][]{
//        new int[]{ 1, 2, 3 },
//            new int[]{ 4,5,6 },
//           new int[] {7,8,9 },
//        };

//        TestClass t = new TestClass();
//        var result = t.FindDiagonalOrder(arr);

//        foreach (int item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}

//// Complexity : O(M*N) , space :O(M*N) although we are creating a 1D array but in reality we are storing all eleemnts of matrix of size m*n