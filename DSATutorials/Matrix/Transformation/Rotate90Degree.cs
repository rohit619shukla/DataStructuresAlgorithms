//public class Solution
//{

//    // Time : O(N^2) + O(N^2) + O(N^2), Space :O(N^2)
//    //public void Rotate(int[][] matrix)
//    //{
//    //    int rows = matrix.Length;
//    //    int cols = matrix[0].Length;
//    //    int[][] dummy = new int[rows][];
//    //    for (int i = 0; i < rows; i++)
//    //    {
//    //        dummy[i] = new int[cols];
//    //    }
//    //    int cl = cols - 1;
//    //    for (int i = 0; i < rows; i++)
//    //    {
//    //        int ro = 0;
//    //        for (int j = 0; j < cols; j++)
//    //        {
//    //            int val = matrix[i][j];

//    //            dummy[ro][cl] = val;
//    //            ro++;
//    //        }
//    //        cl--;
//    //    }

//    //    for (int i = 0; i < rows; i++)
//    //    {
//    //        for (int j = 0; j < cols; j++)
//    //        {
//    //            matrix[i][j] = dummy[i][j];
//    //        }
//    //    }
//    //}

//    // Time :O(N^2) , space :O(1)
//    public void Rotate(int[][] matrix)
//    {
//        int rows = matrix.Length;
//        int cols = matrix[0].Length;

//        // step 1: Transpose the matrix
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = i + 1; j < cols; j++)
//            {
//                int temp = matrix[i][j];
//                matrix[i][j] = matrix[j][i];
//                matrix[j][i] = temp;
//            }
//        }

//        // step 2: Reverse the values in row 1 by 1
//        for (int i = 0; i < rows; i++)
//        {
//            int lb = 0, ub = rows - 1;
//            while (lb < ub)
//            {
//                int temp = matrix[i][lb];
//                matrix[i][lb] = matrix[i][ub];
//                matrix[i][ub] = temp;

//                lb++;
//                ub--;
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] matrix = new int[][] {
//        new int[]{1,2,3 },
//        new int[]{4,5,6 },
//        new int[]{ 7,8,9}
//        };

//        Solution s = new Solution();

//        s.Rotate(matrix);
//    }
//}