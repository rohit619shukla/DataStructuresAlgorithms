
//public class Solution
//{
//    public bool SearchMatrix(int[][] matrix, int target)
//    {
//        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
//        {
//            return false;
//        }

//        int rows = matrix.Length;
//        int cols = matrix[0].Length;

//        int lb = 0;
//        int ub = (rows * cols) - 1;

//        while (lb <= ub)
//        {
//            int mid = lb + (ub - lb) / 2;
//            int midValue = matrix[mid / cols][mid % cols];

//            if (midValue == target)
//            {
//                return true;
//            }
//            else if (midValue > target)
//            {
//                ub = mid - 1;
//            }
//            else
//            {
//                lb = mid + 1;
//            }
//        }

//        return false;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] matrix = new int[][] {
//            new int[]  { 1,3,5,7},
//            new int[]  { 10,11, 16,20},
//            new int[]  { 23, 30, 34, 60},
//        };

//        Solution s = new Solution();

//        Console.WriteLine(s.SearchMatrix(matrix, 16));
//    }
//}

//// Time : O(Log(n*m)) becuase BS work on n*m elements in matrix, space : O(1)