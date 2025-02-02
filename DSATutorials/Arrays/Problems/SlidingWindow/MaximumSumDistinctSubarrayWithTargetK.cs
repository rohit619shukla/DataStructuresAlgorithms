//public class Solution
//{
//    // Time :O(n) , space :O(1)
//    public long MaximumSubarraySum(int[] nums, int k)
//    {
//        long currentSum = 0, maxSum = 0;
//        int i = 0, j = 0;

//        HashSet<int> set = new HashSet<int>();

//        while (j < nums.Length)
//        {
//            // We will need to shrink the window starting from i till we make sure no occurence of j is already in set 
//            while (set.Contains(nums[j]))
//            {
//                currentSum -= nums[i];
//                set.Remove(nums[i]);
//                i++;
//            }

//            currentSum += nums[j];
//            set.Add(nums[j]);

//            // The window is hit , get the max details and shringk the window
//            if (j - i + 1 == k)
//            {
//                maxSum = Math.Max(maxSum, currentSum);
//                currentSum -= nums[i];
//                set.Remove(nums[i]);
//                i++;
//            }

//            j++;
//        }

//        return maxSum;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        //int[] arr = { 1, 5, 4, 2, 9, 9, 9 };
//        int[] arr = { 1, 1, 1, 7, 8, 9 };

//        Solution s = new Solution();

//        Console.WriteLine(s.MaximumSubarraySum(arr, 3));
//    }
//}