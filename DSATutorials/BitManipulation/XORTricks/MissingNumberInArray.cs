// public class Solution
// {
//     // Problem: Given an array 'nums' containing n distinct numbers taken from
//     // the range [0, n], exactly one number in that range is missing. Return it.
//     //
//     // There are two common approaches to solve this:
//     //
//     // 1. Mathematical (Sum) approach:
//     //    - The sum of all numbers in [0, n] is n * (n + 1) / 2.
//     //    - Subtract every value present in the array from that expected sum.
//     //    - Whatever remains is the missing number.
//     //    - Time:  O(n) - single pass over the array.
//     //    - Space: O(1) - only a running sum is stored.
//     //    - Caveat: the intermediate sum can overflow for very large n.
//     //
//     //      int n = nums.Length;
//     //      int sum = n * (n + 1) / 2;      // expected sum of 0..n
//     //      foreach (int val in nums)
//     //      {
//     //          sum -= val;                 // remove each present value
//     //      }
//     //      return sum;                     // leftover is the missing number
//     //
//     // 2. Bitwise XOR approach (implemented below):
//     //    - Key facts: the array holds n distinct numbers from the range [0, n],
//     //      so every valid index i (0..n-1) plus the extra value n covers all
//     //      numbers we expect, while nums[] covers all numbers actually present.
//     //    - XOR of a number with itself is 0, and XOR with 0 leaves it unchanged.
//     //      So XOR-ing every expected number with every present number cancels out
//     //      all matching pairs, leaving only the missing number behind.
//     //    - This avoids the overflow risk of the sum approach.
//     public int MissingNumber(int[] nums)
//     {
//         // Seed 'result' with n (the length). This accounts for the value n in the
//         // expected range [0, n] that no index i in [0, n-1] can produce.
//         int result = nums.Length;

//         for (int i = 0; i < nums.Length; i++)
//         {
//             // XOR in the index (an expected number) and the value at that index
//             // (a present number). Matching pairs cancel; the missing one survives.
//             // In effect, each value in the array gets XOR-ed against its matching
//             // index, so identical index/value pairs cancel to 0.
//             result ^= i;
//             result ^= nums[i];
//         }

//         // Every expected/present pair has cancelled out, leaving the missing number.
//         return result;
//     }
// }

// // Complexity of the implemented XOR approach:
// //   Time:  O(n) - a single pass over the array, constant work per element.
// //   Space: O(1) - only the 'result' accumulator is used, no extra data structures.


// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 3, 0, 1 };

//         Solution s = new Solution();

//         Console.WriteLine(s.MissingNumber(nums));
//     }
// }