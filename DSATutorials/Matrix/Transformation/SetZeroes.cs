// public class Solution
// {
//     public void SetZeroes(int[][] matrix)
//     {
//         // Approach 1 : would be to carry 2 1D array each for row and col.
//         // We will traverse the matrix and mark the respective row and col array as True if the row or col contains 0 at any position
//         // Then we will traverse the matix once again and for every cell we will check if its corresponding row or col is True(0) in the 1D array, we will mark it as 0
//         // Here the space is O(n) + O(n)

//         // Approach 2: 

//         int rows = matrix.Length;
//         int cols = matrix[0].Length;

//         bool isFirstRowZero = false;
//         bool isFirstColZero = false;

//         for (int i = 0; i < rows; i++)
//         {
//             if (matrix[i][0] == 0)
//             {
//                 isFirstColZero = true;
//                 break;
//             }
//         }

//         for (int i = 0; i < cols; i++)
//         {
//             if (matrix[0][i] == 0)
//             {
//                 isFirstRowZero = true;
//                 break;
//             }
//         }

//         // Step 1 : We assume the very first col and row of this matrix, the same extra 1D array we took in Approach 1
//         // So we will start with 1st row and 1st Col
//         for (int i = 1; i < rows; i++)
//         {
//             for (int j = 1; j < cols; j++)
//             {
//                 // If the given cell is 0 mark the very firt cell of that row and very first cell of that col as 0
//                 if (matrix[i][j] == 0)
//                 {
//                     matrix[i][0] = 0;
//                     matrix[0][j] = 0;
//                 }
//             }
//         }


//         // Step 2 : Now we will again scan the matrix from row =1 and col=1, and for that cell if the very first cell of that row or col is 
//         // set to 0 already in step 1, then the cell becomes 0

//         for (int i = 1; i < rows; i++)
//         {
//             for (int j = 1; j < cols; j++)
//             {
//                 if (matrix[i][0] == 0 || matrix[0][j] == 0)
//                 {
//                     matrix[i][j] = 0;
//                 }
//             }
//         }

//         // Step 3. Now we are only left to process the first row and first column completely
//         // If any cell in 1st row is 0 mark the entire row as 0
//         if (isFirstRowZero)
//         {
//             for (int i = 0; i < cols; i++)
//             {
//                 matrix[0][i] = 0;
//             }
//         }

//         if (isFirstColZero)
//         {
//             for (int i = 0; i < rows; i++)
//             {
//                 matrix[i][0] = 0;
//             }
//         }
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[][] matrix =
//         {
//             new int[] {1,1,1},
//             new int[] {1,0,1},
//             new int[] {1,1,1}
//         };


//         Solution s = new Solution();

//         s.SetZeroes(matrix);

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