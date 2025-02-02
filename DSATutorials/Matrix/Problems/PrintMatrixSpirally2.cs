//public class Solution
//{
//    public int[][] GenerateMatrix(int n)
//    {

//        int[][] matrix = new int[n][];
//        for (int i = 0; i < matrix.Length; i++)
//        {
//            matrix[i] = new int[n];
//        }
//        int rowBegin = 0, colBegin = 0, num = 1;
//        int rowEnd = matrix.Length - 1, colEnd = matrix[0].Length - 1;
//        while (rowBegin <= rowEnd && colBegin <= colEnd)
//        {
//            for (int i = colBegin; i <= colEnd; i++)
//            {
//                matrix[rowBegin][i] = num++;
//            }
//            rowBegin++;

//            for (int i = rowBegin; i <= rowEnd; i++)
//            {
//                matrix[i][colEnd] = num++;
//            }
//            colEnd--;

//            // Adding to make sure we have something to reach and not printing something again
//            if (rowBegin <= rowEnd)
//            {
//                for (int i = colEnd; i >= colBegin; i--)
//                {
//                    matrix[rowEnd][i] = num++;
//                }
//                rowEnd--;
//            }

//            if (colBegin <= colEnd)
//            {
//                for (int i = rowEnd; i >= rowBegin; i--)
//                {
//                    matrix[i][colBegin] = num++;
//                }
//                colBegin++;
//            }

//        }

//        return matrix;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int n = 3;

//        Solution s = new Solution();

//        s.GenerateMatrix(n);
//    }
//}