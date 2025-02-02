
//class Solution
//{
//    public int Solve(int[] arr, int target)
//    {
//        int floor = -1;

//        int lb = 0;
//        int ub = arr.Length - 1;

//        while (lb <= ub)
//        {
//            int mid = (lb + ub) / 2;

//            if (arr[mid] == target)
//            {
//                return arr[mid];
//            }

//            if (arr[mid] > target)
//            {
//                ub = mid - 1;
//            }
//            else
//            {
//                floor = mid;
//                lb = mid + 1;
//            }
//        }

//        return floor == -1 ? -1 : arr[floor];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 2, 8, 10, 10, 12, 19 };

//        int key = 5;

//        Solution s = new Solution();

//        Console.WriteLine(s.Solve(arr, key));
//    }
//}

//// Time : Log(n) , space : O(1)