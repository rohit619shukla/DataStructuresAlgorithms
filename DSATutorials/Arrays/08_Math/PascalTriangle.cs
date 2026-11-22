

// public class Solution
// {
//     // Time: O(numRows^2), because every value in the triangle is computed once.
//     // Space: O(numRows^2) for the returned triangle; O(1) auxiliary space.
//     public IList<IList<int>> Generate(int numRows)
//     {
//         int[][] result = new int[numRows][];

//         for (int i = 0; i < numRows; i++)
//         {
//             result[i] = new int[i + 1];

//             // Row i contains i + 1 values. Its boundary values are 1, while each
//             // interior value is the sum of the two values above it.
//             for (int j = 0; j <= i; j++)
//             {
//                 if (j == 0 || j == i)
//                 {
//                     result[i][j] = 1;
//                 }
//                 else
//                 {
//                     result[i][j] = result[i - 1][j] + result[i - 1][j - 1];
//                 }
//             }
//         }

//         return result;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         int numRows = 5;

//         Solution s = new Solution();

//         IList<IList<int>> result = s.Generate(numRows);

//         foreach (int[] lst in result)
//         {
//             foreach (int item in lst)
//             {
//                 Console.Write($"{item}" + " ");
//             }
//             Console.WriteLine();
//         }
//     }
// }