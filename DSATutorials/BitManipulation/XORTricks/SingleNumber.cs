// public class Solution
// {
//     // Time Complexity: O(n) - single pass over the array
//     // Space Complexity: O(1) - only a constant amount of extra space
//     public int SingleNumber(int[] nums)
//     {
//         int result = 0;

//         foreach (var num in nums)
//         {
//             result ^= num;
//         }

//         return result;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();

//         int[] nums = { 4, 1, 2, 1, 2 };

//         Console.WriteLine(s.SingleNumber(nums));
//     }
// }