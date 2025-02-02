///// Leetcode : 561
///// 
//public class Solution
//{
//    public int ArrayPairSum(int[] nums)
//    {
//        Array.Sort(nums);
//        int sum = 0;
//        for (int i = 0; i < nums.Length; i += 2)
//        {
//            sum += nums[i];
//        }
//        return sum;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();
//        int[] arr = { 6, 2, 6, 5, 1, 2 };

//        Console.WriteLine(s.ArrayPairSum(arr));
//    }
//}