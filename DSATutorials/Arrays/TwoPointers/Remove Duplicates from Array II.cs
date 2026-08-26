// public class Solution
// {
//     // Time Complexity  : O(n) - we traverse the array once with pointer j
//     // Space Complexity : O(1) - duplicates are removed in-place, no extra space used
//     public int RemoveDuplicates(int[] nums)
//     {
//         // Approach : Two pointer technique (each element allowed at most twice)
//         // i : slow pointer - marks the next slot where a valid element goes
//         // j : fast pointer - scans every element of the array

//         int n = nums.Length;

//         if (n <= 2)
//         {
//             // With 2 or fewer elements the constraint is always satisfied, so keep them all
//             return n;
//         }

//         // The first two elements are always valid, so both pointers start at index 2
//         int i = 2, j = 2;

//         while (j < n)
//         {
//             // Compare against nums[i - 2] (the element two slots back in the result).
//             // If they differ, nums[j] appears at most twice so far, so it is safe to keep.
//             // If they are equal, this would be the 3rd occurrence, so we skip it.
//             if (nums[i - 2] != nums[j])
//             {
//                 nums[i] = nums[j];
//                 i++;
//             }

//             j++;
//         }

//         return i;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 0, 0, 1, 1, 1, 1, 2, 3, 3 };

//         Solution s = new Solution();

//         Console.WriteLine(s.RemoveDuplicates(nums));
//     }
// }
