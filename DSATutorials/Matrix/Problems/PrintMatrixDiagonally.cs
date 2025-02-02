//using System;

//class TestClass
//{
//    public int[] FindDiagonalOrder(int[][] mat)
//    {
//        int rowEnd = mat.Length;    // Total number of rows
//        int colEnd = mat[0].Length;   // Total number of columns
//        int[] result = new int[rowEnd * colEnd]; // Array to store the final diagonal order

//        int index = 0;              // Index to insert values into the result array
//        int rowBegin = 0, colBegin = 0;       // Pointers to navigate through the matrix
//        bool upward = true;         // Direction flag: true for upward, false for downward

//        // Iterate until we've filled all elements in the result array
//        while (index < result.Length)
//        {
//            result[index++] = mat[rowBegin][colBegin]; // Add the current matrix element to result array

//            if (upward)
//            {
//                // If moving upward:
//                if (colBegin == colEnd - 1)
//                {
//                    // If we're at the last column, move down to the next row
//                    rowBegin++;
//                    upward = false;       // Change direction to downward
//                }
//                else if (rowBegin == 0)
//                {
//                    // If we're at the top row, move right to the next column
//                    colBegin++;
//                    upward = false;       // Change direction to downward
//                }
//                else
//                {
//                    // Otherwise, keep moving upward: decrement row, increment column
//                    rowBegin--;
//                    colBegin++;
//                }
//            }
//            else
//            {
//                // If moving downward:
//                if (rowBegin == rowEnd - 1)
//                {
//                    // If we're at the last row, move right to the next column
//                    colBegin++;
//                    upward = true;        // Change direction to upward
//                }
//                else if (colBegin == 0)
//                {
//                    // If we're at the first column, move down to the next row
//                    rowBegin++;
//                    upward = true;        // Change direction to upward
//                }
//                else
//                {
//                    // Otherwise, keep moving downward: increment row, decrement column
//                    rowBegin++;
//                    colBegin--;
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