//public class Solution
//{
//    // Time : Log(n) as we are each time doing divide by 2

//    public double MyPow(double x, int n)
//    {
//        // n is a -ve number
//        if (n < 0)
//        {
//            return Solve(1 / x, -((long)n));
//        }

//        return Solve(x, (long)n);
//    }

//    private double Solve(double x, long n)
//    {
//        double ans = 1;

//        // as anything raise to 0 is 1
//        while (n > 0)
//        {
//            // check for even or odd number
//            if (n % 2 == 0)
//            {
//                x *= x;
//                n = n / 2;
//            }
//            else
//            {
//                ans *= x;
//                n = n - 1;
//            }
//        }

//        return ans;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        Console.WriteLine($"{s.MyPow(2.00000, -2147483648)}");
//    }
//}