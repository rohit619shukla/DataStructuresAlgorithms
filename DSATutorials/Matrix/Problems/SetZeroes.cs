//using System.Data;

//class Solution
//{
//    public void SetZeroes(int[][] matrix)
//    {
//        int rows = matrix.Length, cols = matrix[0].Length;
//        bool isFirstRowZero = false, isFirstColumnZero = false;

//        // Step 1: Does first row and col contains a zero
//        for (int i = 0; i < cols; i++)
//        {
//            if (matrix[0][i] == 0)
//            {
//                isFirstRowZero = true;
//                break;
//            }
//        }

//        for (int i = 0; i < rows; i++)
//        {
//            if (matrix[i][0] == 0)
//            {
//                isFirstColumnZero = true;
//                break;
//            }
//        }

//        // Step 2: Mark zero the respective 0th row and col wherever you find a 0
//        for (int i = 1; i < rows; i++)
//        {
//            for (int j = 1; j < cols; j++)
//            {
//                if (matrix[i][j] == 0)
//                {
//                    matrix[i][0] = 0;
//                    matrix[0][j] = 0;
//                }
//            }
//        }

//        // Step 3: Use zero at first row and col to mark others as zero
//        for (int i = 1; i < rows; i++)
//        {
//            for (int j = 1; j < cols; j++)
//            {
//                if (matrix[i][0] == 0 || matrix[0][j] == 0)
//                {
//                    matrix[i][j] = 0;
//                }
//            }
//        }

//        // Step 4: finally mark all celss as zero where first row or col contain 0
//        if (isFirstRowZero)
//        {
//            for (int i = 0; i < cols; i++)
//            {
//                matrix[0][i] = 0;
//            }
//        }

//        if (isFirstColumnZero)
//        {
//            for (int i = 0; i < rows; i++)
//            {
//                matrix[i][0] = 0;
//            }
//        }
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] matrix = new int[][] {
//            new int[] { 0,1,2,0},
//            new int[]{3,4,0,2 },
//             new int[]{ 1,3,1,5},
//              new int[]{ 8,7,6,9}
//        };

//        Solution s = new Solution();

//        s.SetZeroes(matrix);

//        int rows = matrix.Length;
//        int cols = matrix[0].Length;

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                Console.Write($"{matrix[i][j]}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}

//// Tim :O(n*m) , space :O(1)