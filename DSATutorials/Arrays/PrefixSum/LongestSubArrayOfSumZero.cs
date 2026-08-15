
//class Solution
//{
//    // Time :O(N^2) , space :O(1)
//    //public int LongestZeroSumSubarray(int[] nums)
//    //{
//    //    int maxCount = 0;

//    //    for (int i = 0; i < nums.Length; i++)
//    //    {
//    //        int cumulativeSum = 0;

//    //        for (int j = i; j < nums.Length; j++)
//    //        {
//    //            cumulativeSum += nums[j];

//    //            if (cumulativeSum == 0)
//    //            {
//    //                maxCount = Math.Max(maxCount, j - 1 + 1);
//    //            }
//    //        }
//    //    }

//    //    return maxCount;
//    //}

//    // Time : O(n) , space :O(n)
//    // The idea here is if we have an array whose total sum is lest say s and we get a subarray as s then the remaining portion of array will have sum as 0
//    public int LongestZeroSumSubarray(int[] nums)
//    {
//        var map = new Dictionary<int, int>();  // Stores first occurrence of each prefix sum
//        int maxLength = 0;                     // To track the longest subarray length
//        int cumulativeSum = 0;                     // Cumulative sum of the array

//        for (int i = 0; i < nums.Length; i++)
//        {
//            // Update the cumulative sum
//            cumulativeSum += nums[i];

//            // If cumulativeSum is 0, it means the sum of the subarray from 0 to i is zero
//            if (cumulativeSum == 0)
//            {
//                maxLength = i + 1;  // If sum from index 0 to i is zero, update maxLength
//            }

//            // If prefixSum has been seen before, calculate the length of the subarray
//            // from the first occurrence to current index i
//            else if (map.ContainsKey(cumulativeSum))
//            {
//                maxLength = Math.Max(maxLength, i - map[cumulativeSum]);
//            }
//            else
//            {
//                // Store the first occurrence of prefixSum with the current index
//                map[cumulativeSum] = i;
//            }
//        }

//        return maxLength;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 15, -2, 2, -8, 1, 7, 10, 23 };

//        Solution s = new Solution();

//        Console.WriteLine(s.LongestZeroSumSubarray(arr));
//    }
//}