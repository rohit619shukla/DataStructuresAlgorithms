// // Move Zeroes To End
// // -------------------
// // Move all zeroes in the array to the end while keeping the relative order
// // of the non-zero elements. The operation is done in-place.
// //
// // Approach: Two pointers.
// //   - i marks the position where the next non-zero element should be written.
// //   - j scans through the array.
// // First pass copies every non-zero element forward; second pass fills the
// // remaining tail with zeroes.
// //
// // Time Complexity:  O(n) - each element is visited a constant number of times.
// // Space Complexity: O(1) - the array is modified in-place, no extra storage.

// public class Solution
// {
//     public void MoveZeroes(int[] nums)
//     {
//         // i: write index for non-zero values, j: read/scan index
//         int i = 0, j = 0, n = nums.Length;

//         // Move all non-zero elements to the front, preserving order.
//         while (j < n)
//         {
//             if (nums[j] != 0)
//             {
//                 nums[i] = nums[j];
//                 i++;
//             }
//             j++;
//         }

//         // Fill the remaining positions with zeroes.
//         while (i < n)
//         {
//             nums[i] = 0;
//             i++;
//         }
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] numks = { 0, 1, 0, 3, 12 };

//         Solution s = new Solution();

//         s.MoveZeroes(numks);
//     }
// }