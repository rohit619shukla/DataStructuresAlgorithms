// public class Solution
// {
//     public int MaxSubarraySumCircular(int[] nums)
//     {

//         // Approach 1 : O(N^2)
//         // Rotate the array by one position at a time and run Kadane's algorithm on each rotation.
//         // The best result across all N rotations is the answer. N rotations x O(N) Kadane = O(N^2).


//         // Approach 2 : O(N)  (the one implemented below)
//         // The maximum sum subarray in a CIRCULAR array falls into one of two cases:
//         //   Case 1 : The subarray is non-wrapping (a normal contiguous slice inside the array).
//         //   Case 2 : The subarray wraps around the end (uses elements from both ends).
//         // The final answer is the maximum of these two cases.
//         //
//         // Case 1 is just the standard maximum subarray -> plain Kadane (KadaneMax).
//         //
//         // Case 2 (the wrapping case) uses a nice trick:
//         //   If a wrapping subarray has the maximum sum, then the ELEMENTS IT LEAVES OUT form a
//         //   contiguous, non-wrapping block in the middle. To make the wrapping sum as large as
//         //   possible, the leftover middle block must be as SMALL as possible.
//         //   So:  maxWrapSum = totalSum - (minimum subarray sum)
//         //   We get the minimum subarray sum with a "minimizing" Kadane (KadaneMin).

//         // Algorithm
//         // 1. Compute the total sum of the array (S).
//         int totSum = 0, n = nums.Length;

//         for (int i = 0; i < n; i++)
//         {
//             totSum += nums[i];
//         }

//         // 2. Compute the MINIMUM subarray sum using a minimizing Kadane (this is the leftover block).
//         int minSum = KadaneMin(nums);

//         // 3. Compute the MAXIMUM subarray sum using standard Kadane -> Case 1 (non-wrapping).
//         int maxSum = KadaneMax(nums);

//         // 4. Case 2 (wrapping): best wrapping sum = totalSum - minimum subarray sum.
//         int max_Sum_Circ_Sub = totSum - minSum;

//         // 5. Return the better of Case 1 and Case 2.
//         // Guard for the all-negative array: if maxSum <= 0, every element is negative, so the
//         // minimum subarray is the whole array and (totSum - minSum) becomes 0 (empty leftover).
//         // That 0 is invalid because a subarray must be non-empty, so we fall back to maxSum instead.
//         if (maxSum > 0)
//         {
//             return Math.Max(maxSum, max_Sum_Circ_Sub);
//         }
//         else
//         {
//             return maxSum;
//         }
//     }

//     // Kadane variant that finds the MINIMUM sum contiguous subarray.
//     private int KadaneMin(int[] nums)
//     {
//         int currSum = 0;
//         int minSum = int.MaxValue;

//         for (int i = 0; i < nums.Length; i++)
//         {
//             currSum += nums[i];

//             // Track the smallest running sum seen so far.
//             if (currSum < minSum)
//             {
//                 minSum = currSum;
//             }

//             // If the running sum grows positive, it can only hurt a minimum, so reset it.
//             if (currSum > 0)
//             {
//                 currSum = 0;
//             }
//         }

//         return minSum;
//     }

//     // Standard Kadane that finds the MAXIMUM sum contiguous subarray.
//     private int KadaneMax(int[] nums)
//     {
//         int currSum = 0;
//         int maxSum = int.MinValue;

//         for (int i = 0; i < nums.Length; i++)
//         {
//             currSum += nums[i];

//             // Track the largest running sum seen so far.
//             if (currSum > maxSum)
//             {
//                 maxSum = currSum;
//             }

//             // If the running sum goes negative, it can only hurt a maximum, so reset it.
//             if (currSum < 0)
//             {
//                 currSum = 0;
//             }
//         }

//         return maxSum;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 5, -3, 5 };

//         Solution s = new Solution();

//         Console.WriteLine($"{s.MaxSubarraySumCircular(nums)}");
//     }
// }