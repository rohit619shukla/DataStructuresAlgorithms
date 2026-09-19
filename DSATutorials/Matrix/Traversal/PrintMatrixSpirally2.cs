// // Time Complexity:  O(n * n) -> every cell of the n x n matrix is filled exactly once.
// // Space Complexity: O(1) extra space -> only a few pointers and a counter are used
// //                   (the n x n matrix we build and return is not counted as extra space).
// public class Solution
// {
//     public int[][] GenerateMatrix(int n)
//     {
//         // Allocate the n x n matrix (jagged array), one row at a time.
//         int[][] matrix = new int[n][];
//         for (int i = 0; i < n; i++)
//         {
//             matrix[i] = new int[n];
//         }

//         // 4 boundary pointers that shrink inward as we fill each layer.
//         int top = 0, down = n - 1, left = 0, right = n - 1;

//         // Running value to place; ++count gives 1, 2, 3, ... in spiral order.
//         int count = 0;

//         // Keep going while there is still an unfilled box.
//         while (top <= down && left <= right)
//         {
//             // 1) Fill LEFT -> RIGHT along the current top row.
//             for (int i = left; i <= right; i++)
//             {
//                 matrix[top][i] = ++count;
//             }
//             top++; // top row is filled, move the boundary down.

//             // 2) Fill TOP -> DOWN along the current right column.
//             for (int i = top; i <= down; i++)
//             {
//                 matrix[i][right] = ++count;
//             }
//             right--; // right column is filled, move the boundary left.

//             // 3) Fill RIGHT -> LEFT along the current bottom row.
//             //    Guard: after top++ the rows may have crossed, so make sure a bottom row still exists
//             //    (prevents overwriting the same row twice for odd n).
//             if (top <= down)
//             {
//                 for (int i = right; i >= left; i--)
//                 {
//                     matrix[down][i] = ++count;
//                 }
//                 down--; // bottom row is filled, move the boundary up.
//             }

//             // 4) Fill DOWN -> TOP along the current left column.
//             //    Guard: after right-- the columns may have crossed, so make sure a left column still exists
//             //    (prevents overwriting the same column twice for odd n).
//             if (left <= right)
//             {
//                 for (int i = down; i >= top; i--)
//                 {
//                     matrix[i][left] = ++count;
//                 }
//                 left++; // left column is filled, move the boundary right.
//             }
//         }

//         return matrix;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         int n = 3;

//         Solution s = new Solution();

//         int[][] result = s.GenerateMatrix(n);

//         int rows = result.Length;
//         int cols = result[0].Length;

//         for (int i = 0; i < rows; i++)
//         {
//             for (int j = 0; j < cols; j++)
//             {
//                 Console.Write($"{result[i][j]}" + " ");
//             }
//             Console.WriteLine();
//         }
//     }
// }