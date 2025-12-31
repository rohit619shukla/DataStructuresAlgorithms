//public class Solution
//{
//    // Time : Log(n) as we are each time doing divide by 2
//    public double MyPow(double x, int n)
//    {
//        return Solve(x, (long)n);
//    }

//    private double Solve(double x, long n)
//    {
//        // base case
//        // Any number to 0 is always 1
//        if (n == 0)
//        {
//            return 1;
//        }

//        // For -ve numbers
//        if (n < 0)
//        {
//            return Solve(1 / x, -n);
//        }

//        // For evevn or odd numbers
//        if (n % 2 == 0)
//        {
//            return Solve(x * x, n / 2);   // We kept on returning the answer to the root
//        }
//        else
//        {
//            return x * Solve(x * x, (n - 1) / 2);
//        }
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        double x = 2.00000;
//        int n = 4;

//        Solution s = new Solution();
//        Console.WriteLine(s.MyPow(x, n));
//    }
//}