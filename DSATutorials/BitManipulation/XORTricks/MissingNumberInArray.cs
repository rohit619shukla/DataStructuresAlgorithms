//public class Solution
//{
//    // Time : O(n) , space :O(1)
//    public int MissingNumber(int[] nums)
//    {
//        int set1 = 0, set2 = 0;
//        // Set 1: for all the distinct numbers in range 0-n

//        for (int i = 0; i <= nums.Length; i++)
//        {
//            set1 ^= i;
//        }

//        // Set 2: for all the numbers in actual array
//        for (int j = 0; j < nums.Length; j++)
//        {
//            set2 ^= nums[j];
//        }

//        // Finally if numbers in set are same they will cancel out each other and will spill out the missing number
//        return set1 ^ set2;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] nums = { 3, 0, 1 };

//        Solution s = new Solution();

//        Console.WriteLine(s.MissingNumber(nums));
//    }
//}