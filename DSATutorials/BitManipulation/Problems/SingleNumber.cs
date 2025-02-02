//public class Solution
//{
//    public int SingleNumber(int[] nums)
//    {
//        int result = 0;

//        for (int i = 0; i < nums.Length; i++)
//        {
//            result ^= nums[i];
//        }

//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 4, 1, 2, 1, 2 };

//        Solution s = new Solution();

//        Console.WriteLine(s.SingleNumber(arr));
//    }
//}

//// Time :O(n) , space :(1)