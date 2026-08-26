// public class Solution
// {
//     // Time Complexity  : O(n) - we traverse the array once with pointer j
//     // Space Complexity : O(1) - duplicates are removed in-place, no extra space used
//     public int RemoveDuplicates(int[] nums)
//     {
//         // Here we will use two pointer approach
//         // i : This will always hold the unique element
//         // j : This will move ahead and figure out next unique element for i to make place for

//         int i = 0, j = 1, n = nums.Length;

//         while (j < n)
//         {
//             if (nums[i] != nums[j])
//             {
//                 nums[++i] = nums[j];
//             }
//             j++;
//         }

//         return i + 1;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

//         Solution s = new Solution();

//         Console.WriteLine(s.RemoveDuplicates(nums));
//     }
// }