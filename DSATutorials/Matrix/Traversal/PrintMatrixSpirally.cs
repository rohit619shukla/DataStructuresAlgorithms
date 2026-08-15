//public class Solution
//{
//    public IList<int> SpiralOrder(int[][] matrix)
//    {
//        List<int> result = new List<int>();
//        int rowBegin = 0, colBegin = 0;
//        int rowEnd = matrix.Length - 1, colEnd = matrix[0].Length - 1;
//        while (rowBegin <= rowEnd && colBegin <= colEnd)
//        {
//            for (int i = colBegin; i <= colEnd; i++)
//            {
//                result.Add(matrix[rowBegin][i]);
//            }
//            rowBegin++;

//            for (int i = rowBegin; i <= rowEnd; i++)
//            {
//                result.Add(matrix[i][colEnd]);
//            }
//            colEnd--;

//            // Adding to make sure we have something to reach and not printing something again
//            if (rowBegin <= rowEnd)
//            {
//                for (int i = colEnd; i >= colBegin; i--)
//                {
//                    result.Add(matrix[rowEnd][i]);
//                }
//                rowEnd--;
//            }

//            if (colBegin <= colEnd)
//            {
//                for (int i = rowEnd; i >= rowBegin; i--)
//                {
//                    result.Add(matrix[i][colBegin]);
//                }
//                colBegin++;
//            }

//        }

//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {

//        Solution s = new Solution();

//        int[][] matrix = new int[][] {
//            new int[] { 1,2,3,4},
//            new int[] { 5,6,7,8},
//            new int[]{ 9, 10, 11, 12 }

//        };

//        var result = s.SpiralOrder(matrix);

//        foreach (int item in result)
//        {
//            Console.Write($"{item}" + " ");

//        }
//    }
//}

//// Time :O(N^2) , space :O(1)