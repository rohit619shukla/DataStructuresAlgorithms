//public class Solution
//{

//    // Time : O(n) , space :O(1)
//    public int SingleNumber(int[] nums)
//    {
//        int num = 0;

//        foreach (int item in nums)
//        {
//            num ^=  item;
//        }

//        return num;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] nums = { 4, 1, 2, 1, 2 };

//        Solution s = new Solution();
//        Console.WriteLine(s.SingleNumber(nums));
//    }
//}