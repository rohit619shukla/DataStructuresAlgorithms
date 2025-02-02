
//class Solution
//{
//    // Time : O(log10(x)) we are taking 10(y) = x operations , space :O(1)
//    public int Reverse(int x)
//    {
//        // Use long to avoid overflow
//        long reversed = 0;

//        while (x != 0)
//        {
//            int digit = x % 10;  // Extract the last digit
//            reversed = reversed * 10 + digit;  // Build the reversed number

//            // Check for overflow
//            if (reversed > int.MaxValue || reversed < int.MinValue)
//                return 0;

//            x /= 10;  // Remove the last digit
//        }

//        return (int)reversed;  // Safe to cast back to int now
//    }

//}


//class Program
//{
//    public static void Main()
//    {
//        int x = -123;

//        Solution s = new Solution();

//        Console.WriteLine(s.Reverse(x));
//    }
//}