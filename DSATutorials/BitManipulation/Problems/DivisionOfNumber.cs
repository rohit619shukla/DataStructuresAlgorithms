//// C# implementation to Divide
//// two integers without using
//// multiplication, division
//// and mod operator
//using System;

//// Function to divide a by b
//// and return floor value it
//class GFG
//{
//    public static long divide(long dividend,
//                              long divisor)
//    {

//        // Calculate sign of divisor
//        // i.e., sign will be negative
//        // only iff either one of them
//        // is negative otherwise it
//        // will be positive
//        long sign = ((dividend < 0) ^
//                     (divisor < 0)) ? -1 : 1;

//        // remove sign of operands
//        dividend = Math.Abs(dividend);
//        divisor = Math.Abs(divisor);

//        // Initialize the quotient
//        long quotient = 0, temp = 0;

//        // test down from the highest
//        // bit and accumulate the
//        // tentative value for
//        // valid bit
//        for (int i = 31; i >= 0; --i)
//        {

//            if (temp + (divisor << i) <= dividend)            /* (divisor<<i) : ex : 8 * 2^i */
//            {
//                temp += divisor << i;
//                quotient |= 1 << i;                           /* (1<<i) : ex : 8*4 = 8+8+8+8 basically count */
//            }
//        }
//        //if the sign value computed earlier is -1 then negate the value of quotient
//        if (sign == -1)
//            quotient = -quotient;
//        return quotient;
//    }

//    // Driver code
//    public static void Main()
//    {
//        int a = -32, b = 2;
//        Console.WriteLine(divide(a, b));

//        int a1 = 43, b1 = -8;
//        Console.WriteLine(divide(a1, b1));

//    }
//}

////Time complexity : O(log(a))
////Auxiliary space : O(1)