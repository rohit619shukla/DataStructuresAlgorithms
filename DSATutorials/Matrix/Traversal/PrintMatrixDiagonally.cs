// // Time Complexity:  O(rows * cols) -> every element is visited once to bucket it by diagonal,
// //                   and once more while copying to the result (reversing is bounded by the
// //                   same total number of elements).
// // Space Complexity: O(rows * cols) -> the dictionary stores every element grouped by diagonal,
// //                   plus the result array of the same size.
// public class Solution
// {
//     public int[] FindDiagonalOrder(int[][] mat)
//     {
//         // Key idea for diagonal traversal:
//         // all cells on the same anti-diagonal share the same value of (i + j).
//         // So we group cells by the key (i + j); each group is one diagonal.

//         int rows = mat.Length;
//         int cols = mat[0].Length;

//         int[] result = new int[rows * cols];

//         // key = (i + j) -> list of elements lying on that diagonal.
//         Dictionary<int, List<int>> tempList = new Dictionary<int, List<int>>();

//         // Bucket every element into its diagonal group using key = i + j.
//         for (int i = 0; i < rows; i++)
//         {
//             for (int j = 0; j < cols; j++)
//             {
//                 int key = i + j; // diagonal this cell belongs to

//                 if (tempList.ContainsKey(key))
//                 {
//                     tempList[key].Add(mat[i][j]); // append to existing diagonal
//                 }
//                 else
//                 {
//                     tempList.Add(key, new List<int> { mat[i][j] }); // start a new diagonal
//                 }
//             }
//         }

//         // Emit diagonals in order, flipping direction on alternate diagonals
//         // (LeetCode 498 zig-zags: one diagonal goes up, the next goes down).
//         int count = 0;
//         bool flip = false;

//         // Diagonal 0 is always just mat[0][0]; add it first, then start flipping from diagonal 1.
//         result[count] = mat[0][0];
//         count++;

//         // Start from the second diagonal (key = 1).
//         for (int i = 1; i < tempList.Count; i++)
//         {
//             if (flip)
//             {
//                 // Reverse this diagonal so it is emitted in the opposite direction.
//                 Reverse(tempList[i], 0, tempList[i].Count - 1);
//             }

//             // Copy the (possibly reversed) diagonal into the result.
//             foreach (int num in tempList[i])
//             {
//                 result[count] = num;
//                 count++;
//             }

//             flip = !flip; // alternate direction for the next diagonal
//         }
//         return result;
//     }

//     // In-place two-pointer reversal of list[lb..ub].
//     private void Reverse(List<int> list, int lb, int ub)
//     {
//         while (lb < ub)
//         {
//             int temp = list[lb];
//             list[lb] = list[ub];
//             list[ub] = temp;

//             lb++;
//             ub--;
//         }
//     }
// }


// class Prorgam
// {
//     public static void Main()
//     {
//         int[][] mat =
//         {
//             new int[]{ 1, 2, 3 },
//            new int[]{ 4,5,6 },
//           new int[] {7,8,9 },

//         };

//         Solution s = new Solution();

//         var result = s.FindDiagonalOrder(mat);

//         foreach (var num in result)
//         {
//             Console.Write($"{num}" + " ");
//         }
//     }
// }