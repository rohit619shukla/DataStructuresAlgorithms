

//class Solution
//{
//    public bool SearchMatrix(int[][] matrix, int target)
//    {
//        int rows = matrix.Length;
//        int cols = matrix[0].Length;

//        for (int i = 0; i < rows; i++)
//        {
//            if (matrix[i][0] <= target && target <= matrix[i][cols - 1])
//            {
//                int index = Solve(matrix[i], target);

//                if (index != -1)
//                {
//                    return true;
//                }
//            }
//        }

//        return false;
//    }

//    private int Solve(int[] arr, int key)
//    {
//        int lb = 0;
//        int ub = arr.Length - 1;

//        while (lb <= ub)
//        {
//            int mid = lb + (ub - lb) / 2;

//            if (arr[mid] == key)
//            {
//                return mid;
//            }

//            if (arr[mid] > key)
//            {
//                ub = mid - 1;
//            }
//            else
//            {
//                lb = mid + 1;
//            }
//        }

//        return -1;
//    }

//    //    public bool SearchMatrix(int[][] matrix, int target)
//    //    {
//    //        int rows = matrix.Length;
//    //        int cols = matrix[0].Length;

//    //        int row = 0, col = cols - 1; // Start at top-right corner

//    //        while (row < rows && col >= 0)
//    //        {
//    //            int value = matrix[row][col];

//    //            if (value == target)
//    //                return true;
//    //            else if (value > target)
//    //                col--; // Move left
//    //            else
//    //                row++; // Move down
//    //        }

//    //        return false;
//    //    }

//    //}
//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] matrix = new int[][] {
//         new int[] {1,4,7,11,15},
//         new int[] { 2, 5, 8, 12, 19 },
//         new int[] { 3, 6, 9, 16, 22 },
//         new int[] { 10, 13, 14, 17, 24 },
//         new int[] { 18, 21, 23, 26, 30 }
//        };

//        Solution s = new Solution();
//        Console.WriteLine(s.SearchMatrix(matrix, 5));
//    }
//}

//// With Binary Search : O(n×logm) , where n is rows and m is columns.
//// Without Binary Search : O(n+m)