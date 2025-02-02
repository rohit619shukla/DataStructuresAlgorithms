

//class Solution
//{
//    public int FindMin(int[] arr)
//    {
//        int lb = 0;
//        int ub = arr.Length - 1;
//        int n = arr.Length;

//        while (lb <= ub)
//        {
//            // if the array is already sorted
//            if (arr[lb] <= arr[ub])
//            {
//                return arr[lb];
//            }
//            int mid = lb + (ub - lb) / 2;
//            int next = (mid + 1) % n;
//            int prev = (mid + n - 1) % n;

//            // We got pivot point
//            if (arr[prev] >= arr[mid] && arr[next] >= arr[mid])
//            {
//                return arr[mid];
//            }

//            // If left side is sorted then we need to search in right side
//            if (arr[lb] <= arr[mid])
//            {
//                lb = mid + 1;
//            }
//            else if (arr[mid] <= arr[ub])
//            {
//                // the right side is sorted
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
//        int[] arr = { 2, 1 };

//        Solution s = new Solution();

//        Console.WriteLine(s.FindMin(arr));
//    }
//}