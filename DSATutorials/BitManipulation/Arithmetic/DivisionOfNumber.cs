//public class Solution
//{
//    // Striver video
//    // Time : O(Logn) as we are working with 2's power
//    public int Divide(int dividend, int divisor)
//    {
//        if (dividend == int.MinValue && divisor == -1)
//        {
//            return int.MaxValue;
//        }

//        bool sign = (dividend >= 0 && divisor < 0) || (dividend < 0 && divisor >= 0);


//        long numerator = Math.Abs((long)dividend);
//        long denominator = Math.Abs((long)divisor);
//        long quotient = 0;

//        while (numerator >= denominator)
//        {
//            int counter = 0;

//            while (numerator >= (denominator << counter + 1))
//            {
//                counter++;
//            }

//            quotient += 1 << counter;
//            numerator -= (denominator << counter);
//        }

//        if (quotient > int.MaxValue)
//        {
//            return int.MaxValue;
//        }

//        if (quotient < int.MinValue)
//        {
//            return int.MinValue;
//        }

//        return sign ? (int)-quotient : (int)quotient;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int dividend = 22;

//        int divisor = 3;

//        Solution s = new Solution();

//        Console.WriteLine(s.Divide(dividend, divisor));
//    }
//}