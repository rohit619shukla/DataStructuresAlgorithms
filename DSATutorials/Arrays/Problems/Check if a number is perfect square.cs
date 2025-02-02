
//public class Solution
//{
//    // Time :O(logn) , space :O(1)
//    public bool IsPerfectSquare(int num)
//    {
//        long lb = 1;
//        long ub = num;

//        while (lb <= ub)
//        {
//            long mid = lb + (ub - lb) / 2;
//            long result = mid * mid;

//            if (result == num)
//            {
//                return true;
//            }

//            if (result > num)
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
//        int num = 2147483647;

//        Solution s = new Solution();

//        Console.WriteLine(s.IsPerfectSquare(num));
//    }
//}