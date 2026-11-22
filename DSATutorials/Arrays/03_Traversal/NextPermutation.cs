// // ---------------------------------------------------------------------------
// // Next Permutation
// // ---------------------------------------------------------------------------
// // Rearranges nums IN-PLACE into the lexicographically next greater permutation.
// // If no greater permutation exists (array is fully descending, e.g. 3,2,1),
// // it wraps around to the smallest permutation (fully ascending, e.g. 1,2,3).
// //
// // Intuition (based on observation):
// //   1. Scan from the right to find the first "pivot" where nums[i-1] < nums[i].
// //      This is the rightmost position that can be increased. Everything to its
// //      right is in descending order (already the largest arrangement).
// //   2. From the right, find the smallest number that is still greater than the
// //      pivot and swap them. This makes the prefix the next-bigger value.
// //   3. The suffix after the pivot is still descending, so reverse it to make it
// //      ascending (the smallest possible ordering) -> the immediate next perm.
// //
// // My intuition: "Next" = the IMMEDIATELY bigger permutation, with none in
// // between. So make the SMALLEST possible change: pivot as far right as
// // possible, swap with its smallest bigger successor, reverse the tail.
// // (Any bigger arrangement would skip the perfect ones in between.)
// //
// // Time Complexity : O(n)  -> at most a few single passes over the array.
// // Space Complexity: O(1)  -> all work is done in-place, no extra storage.
// // ---------------------------------------------------------------------------
// public class Solution
// {
//     public void NextPermutation(int[] nums)
//     {
//         // Step 1: Find the pivot index (first drop from the right).
//         // We look for the first pair where nums[i - 1] < nums[i]; that i - 1
//         // is the pivot we want to increase. If none exists, gola_idx stays -1
//         // meaning the array is fully descending (the last permutation).
//         int gola_idx = -1, n = nums.Length;

//         for (int i = n - 1; i > 0; i--)
//         {
//             if (nums[i - 1] < nums[i])
//             {
//                 gola_idx = i - 1;
//                 break;
//             }
//         }

//         if (gola_idx != -1)
//         {
//             // Step 2: Find the successor to swap with the pivot.
//             // Scanning from the right, the last index whose value is greater
//             // than the pivot is the smallest value greater than the pivot
//             // (because the suffix is descending).
//             int swap_idx = -1;

//             for (int i = n - 1; i > gola_idx; i--)
//             {
//                 if (nums[gola_idx] < nums[i])
//                 {
//                     swap_idx = i;
//                     break;
//                 }
//             }

//             // Step 3: Swap the pivot with its successor to bump the prefix up.
//             Swap(gola_idx, swap_idx, nums);
//         }

//         // Step 4: Reverse the suffix after the pivot to turn it from descending
//         // into ascending (its smallest arrangement). When gola_idx == -1 this
//         // reverses the whole array, producing the smallest permutation.
//         int lb = gola_idx + 1, ub = n - 1;

//         while (lb < ub)
//         {
//             Swap(lb, ub, nums);
//             lb++;
//             ub--;
//         }
//     }

//     private void Swap(int n1, int n2, int[] nums)
//     {
//         int temp = nums[n1];
//         nums[n1] = nums[n2];
//         nums[n2] = temp;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 3, 2, 1 };

//         Solution s = new Solution();

//         s.NextPermutation(nums);
//     }
// }