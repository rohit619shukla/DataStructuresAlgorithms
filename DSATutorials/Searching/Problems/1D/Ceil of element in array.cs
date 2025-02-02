
//class Solution
//{
//    public int Solve(int[] arr, int key)
//    {
//        int lb = 0;
//        int ub = arr.Length - 1;

//        int ceil = -1;

//        while (lb <= ub)
//        {
//            int mid = (lb + ub) / 2;

//            if (arr[mid] == key)
//            {
//                return arr[mid];
//            }

//            if (arr[mid] > key)
//            {
//                ceil = mid;
//                ub = mid - 1;
//            }
//            else
//            {
//                lb = mid + 1;
//            }
//        }

//        return ceil == -1 ? -1 : arr[ceil];
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 2, 8, 10, 10, 12, 19 };

//        int key = 20;

//        Solution s = new Solution();

//        Console.WriteLine(s.Solve(arr, key));

//    }
//}

//// Time : Log(n) space : O(1)