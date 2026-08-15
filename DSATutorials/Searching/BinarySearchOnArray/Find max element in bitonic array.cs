

//class Solution
//{
//    public int Solve(int[] arr)
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

//        return arr[lb];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 100, 80, 60, 40, 20, 0 };

//        Solution s = new Solution();

//        Console.WriteLine(s.Solve(arr));
//    }
//}

//// Time : O(Logn), space : O(1)