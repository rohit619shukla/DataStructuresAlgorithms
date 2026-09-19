// // Rotate an n x n matrix by 90 degrees clockwise, in place.
// //
// // Time Complexity : O(n^2) - every one of the n*n elements is touched a
// //                   constant number of times (once during transpose, once
// //                   during the row reversal).
// // Space Complexity: O(1)   - the rotation is done in place using only a few
// //                   scalar temporaries; no extra matrix is allocated.
// public class Solution
// {
//     public void Rotate(int[][] matrix)
//     {
//         // Step 1: Transpose the matrix (mirror across the main diagonal).
//         // Transpose in short : matrix[i][j] <=> matrix[j][i]

//         int rows = matrix.Length;
//         int cols = matrix[0].Length;

//         for (int i = 0; i < rows; i++)
//         {
//             // Start j at i so each pair (i, j) is swapped only once and the
//             // diagonal (i == j) is left untouched.
//             for (int j = i; j < cols; j++)
//             {
//                 Swap(matrix, i, j);
//             }
//         }


//         // Step 2: Reverse each row in place. Transpose + row-reverse together
//         // produce a 90-degree clockwise rotation.
//         for (int i = 0; i < rows; i++)
//         {
//             // lb and ub are the left/right column pointers; i is the row pointer.
//             int lb = 0, ub = cols - 1;

//             // Two-pointer swap walking inward until the pointers meet.
//             while (lb < ub)
//             {
//                 int temp = matrix[i][lb];
//                 matrix[i][lb] = matrix[i][ub];
//                 matrix[i][ub] = temp;

//                 lb++;
//                 ub--;
//             }
//         }
//     }

//     // Swaps the two mirrored elements matrix[n1][n2] and matrix[n2][n1].
//     private void Swap(int[][] matrix, int n1, int n2)
//     {
//         int temp = matrix[n1][n2];
//         matrix[n1][n2] = matrix[n2][n1];
//         matrix[n2][n1] = temp;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[][] matrix = new int[][] {
//             new int[]{1,2,3 },
//             new int[]{4,5,6 },
//             new int[]{ 7,8,9}
//        };

//         Solution s = new Solution();

//         s.Rotate(matrix);

//         int rows = matrix.Length;
//         int cols = matrix[0].Length;

//         for (int i = 0; i < rows; i++)
//         {
//             for (int j = 0; j < cols; j++)
//             {
//                 Console.Write($"{matrix[i][j]}" + " ");
//             }
//             Console.WriteLine();
//         }
//     }
// }