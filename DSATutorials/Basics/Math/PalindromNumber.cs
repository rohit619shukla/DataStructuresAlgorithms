//public class Solution
//{
//    // Time : O(log10(x)) , space :O(1)
//    public bool IsPalindrome(int x)
//    {
//        int original = x;
//        long reversed = 0;

//        while (x > 0)
//        {
//            int digit = x % 10;

//            reversed = reversed * 10 + digit;

//            x = x / 10;
//        }
//        return reversed == original ? true : false;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int x = -121;

//        Solution s = new Solution();

//        Console.WriteLine(s.IsPalindrome(x));
//    }
//}