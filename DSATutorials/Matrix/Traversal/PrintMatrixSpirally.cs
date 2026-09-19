// // Time Complexity:  O(rows * cols) -> every element of the matrix is visited exactly once.
// // Space Complexity: O(1) extra space -> only a few pointers are used
// //                   (the output list of size rows*cols is not counted as extra space).
// public class Solution
// {
//     public IList<int> SpiralOrder(int[][] matrix)
//     {
//         IList<int> result = new List<int>();

//         int rows = matrix.Length;
//         int cols = matrix[0].Length;

//         // 4 boundary pointers that shrink inward as we peel off each layer.
//         int top = 0, down = rows - 1, left = 0, right = cols - 1;

//         // Keep going while there is still a valid box (top row is above bottom, left is before right).
//         while (top <= down && left <= right)
//         {
//             // 1) Move LEFT -> RIGHT along the current top row.
//             for (int i = left; i <= right; i++)
//             {
//                 result.Add(matrix[top][i]);
//             }
//             top++; // top row is done, move the boundary down.

//             // 2) Move TOP -> DOWN along the current right column.
//             for (int i = top; i <= down; i++)
//             {
//                 result.Add(matrix[i][right]);
//             }
//             right--; // right column is done, move the boundary left.

//             // 3) Move RIGHT -> LEFT along the current bottom row.
//             //    Guard: after top++ the rows may have crossed, so make sure a bottom row still exists
//             //    (prevents printing the same row twice in matrices with an odd number of rows).
//             if (top <= down)
//             {
//                 for (int i = right; i >= left; i--)
//                 {
//                     result.Add(matrix[down][i]);
//                 }
//                 down--; // bottom row is done, move the boundary up.
//             }

//             // 4) Move DOWN -> TOP along the current left column.
//             //    Guard: after right-- the columns may have crossed, so make sure a left column still exists
//             //    (prevents printing the same column twice in matrices with an odd number of columns).
//             if (left <= right)
//             {
//                 for (int i = down; i >= top; i--)
//                 {
//                     result.Add(matrix[i][left]);
//                 }
//                 left++; // left column is done, move the boundary right.
//             }
//         }
//         return result;
//     }
// }

// class Prorgam
// {
//     public static void Main()
//     {
//         int[][] matrix = new int[][]
//         {
//              new int[] { 1,2,3},
//              new int[] { 4,5,6},
//             new int[]{ 7, 8, 9 }

//         };

//         Solution s = new Solution();

//         var result = s.SpiralOrder(matrix);

//         foreach (var num in result)
//         {
//             Console.Write($"{num}" + " ");
//         }
//     }
// }