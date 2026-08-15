//public class Solution
//{
//    // Time : O(N) , Space :O(1)
//    public int FindMaxConsecutiveOnes(int[] nums)
//    {
//        int currentCount = 0, maxCount = int.MinValue;

//        for (int i = 0; i < nums.Length; i++)
//        {
//            if (nums[i] != 0)
//            {
//                currentCount++;
//                maxCount = Math.Max(maxCount, currentCount);
//            }
//            else
//            {
//                currentCount = 0;
//            }
//        }

//        return maxCount;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 0, 1, 1, 0, 1 };

//        Solution s = new Solution();

//        Console.WriteLine(s.FindMaxConsecutiveOnes(arr));
//    }
//}