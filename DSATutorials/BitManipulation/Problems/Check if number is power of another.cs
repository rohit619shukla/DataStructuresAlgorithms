//using System;

//class TestClass
//{
//    /// <summary>
//    /// Check if y is power of x
//    /// </summary>
//    /// <param name="x"></param>
//    /// <param name="y"></param>
//    /// <returns></returns>
//    public bool IsNUmberPowerOfAnother(int x, int y)
//    {

//        if (x == 1)
//        {
//            return (y == 1);
//        }

//        int pow = 1;
//        while (pow < y)
//        {
//            pow *= x;
//        }

//        if (pow == y)
//        {
//            return true;
//        }
//        return false;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        TestClass t = new TestClass();
//        Console.WriteLine($"{t.IsNUmberPowerOfAnother(0, 1)}");
//        Console.WriteLine($"{t.IsNUmberPowerOfAnother(1, 20)}");
//        Console.WriteLine($"{t.IsNUmberPowerOfAnother(2, 128)}");
//        Console.WriteLine($"{t.IsNUmberPowerOfAnother(2, 30)}");
//        Console.WriteLine($"{t.IsNUmberPowerOfAnother(1, 0)}");
//    }
//}

////Complexity: O(logxY)