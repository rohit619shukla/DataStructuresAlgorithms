//public class Solution
//{
//    public bool IsPowerOfTwo(int n)
//    {
//        // Ideally if any number only has 1 set bit is a power of 2, hence if we negate the number and do a bitwise AND operation with the original number, we should get 0.
//        return n > 0 && (n & (n - 1)) == 0;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int num = 16;

//        Solution s = new Solution();

//        Console.WriteLine(s.IsPowerOfTwo(num));
//    }
//}