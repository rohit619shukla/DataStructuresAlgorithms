// public class Solution
// {
//     // Time Complexity  : O(n) - we traverse the array once with pointer j
//     // Space Complexity : O(1) - elements are removed in-place, no extra space used
//     public int RemoveElement(int[] nums, int val)
//     {
//         // Approach : Here we will use 2 pointers
//         // i : will contain unique element
//         // j : will fetch unique element and bring to i

//         int i = 0, j = 0, n = nums.Length;

//         while (j < n)
//         {
//             if (nums[j] != val)
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
//         int[] nums = {3,2,2,3};

//         Solution s = new Solution();

//         Console.WriteLine(s.RemoveElement(nums, 2));
//     }
// }