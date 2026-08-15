//public class Solution
//{
//    // Time :O(1) , space :O(1)
//    public int GetSum(int a, int b)
//    {
//        while (b != 0)
//        {
//            int carry = a & b;

//            a = a ^ b;

//            b = carry << 1;
//        }

//        return a;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int a = 1, b = 3;

//        Solution s = new Solution();

//        Console.WriteLine(s.GetSum(a, b));
//    }
//}