

//class Solution
//{
//    public int MySqrt(int x)
//{
//    int lb = 1;
//    int ub = x;
//    int result = 0; // Initialize result to 0 to handle x = 0

//    while (lb <= ub)
//    {
//        int mid = lb + (ub - lb) / 2;

//        // Use division to prevent overflow
//        if ((long)(mid * mid) <= x) // Casting mid to long to handle overflow
//        {
//            result = mid; // Update the result
//            lb = mid + 1; // Search in the right half
//        }
//        else
//        {
//            ub = mid - 1; // Search in the left half
//        }
//    }

//    return result;
//}

//}
//class Program
//{
//    public static void Main()
//    {
//        int x = 8;

//        Solution s = new Solution();
//        Console.WriteLine(s.MySqrt(x));
//    }
//}