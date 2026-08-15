
//class Solution
//{
//    public int Solve(int[] arr, int key)
//    {
//        int peak = FindPeak(arr, key);

//        int result1 = SearchIncreasing(arr, key, 0, peak);
//        int result2 = SearchDecreasing(arr, key, peak, arr.Length - 1);

//        if (result1 != -1)
//        {
//            return result1;
//        }
//        else if (result2 != -1)
//        {
//            return result2;
//        }

//        return -1;
//    }

//    private int FindPeak(int[] arr, int key)
//    {
//        int lb = 0;
//        int ub = arr.Length - 1;

//        while (lb < ub)
//        {
//            int mid = lb + (ub - lb) / 2;

//            if (arr[mid] > arr[mid + 1])
//            {
//                ub = mid;
//            }
//            else
//            {
//                lb = mid + 1;
//            }
//        }

//        return lb;
//    }

//    private int SearchIncreasing(int[] arr, int key, int lb, int ub)
//    {
//        while (lb <= ub)
//        {
//            int mid = lb + (ub - lb) / 2;

//            if (arr[mid] == key)
//            {
//                return arr[mid];
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
//    private int SearchDecreasing(int[] arr, int key, int lb, int ub)
//    {

//        while (lb <= ub)
//        {
//            int mid = lb + (ub - lb) / 2;

//            if (arr[mid] == key)
//            {
//                return arr[mid];
//            }

//            if (arr[mid] > key)
//            {
//                lb = mid + 1;
//            }
//            else
//            {
//                ub = mid - 1;
//            }
//        }

//        return -1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { -8, 1, 2, 3, 4, 5, -2, -3 };

//        Solution s = new Solution();

//        Console.WriteLine(s.Solve(arr, 1));
//    }
//}

/////* Complexity : O(LogN) */