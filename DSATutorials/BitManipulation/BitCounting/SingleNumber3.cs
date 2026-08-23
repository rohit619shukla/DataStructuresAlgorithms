// public class Solution
// {
//     // Problem: Every element appears twice except for exactly TWO elements that
//     // appear only once. Find those two unique numbers.

//     public int[] SingleNumber(int[] nums)
//     {
//         // Thought process:

//         // 1. XOR every number together. Elements that appear twice cancel out
//         //    (a ^ a == 0), so the final result is the XOR of the two unique
//         //    numbers only: xorResult = a ^ b.
//         int xorResult = 0;

//         foreach (var num in nums)
//         {
//             xorResult ^= num;
//         }

//         // 2. Build a mask that isolates the lowest set bit of xorResult.
//         //    Since a != b, at least one bit in a ^ b is 1. That bit is 1 in one
//         //    of the two unique numbers and 0 in the other, so it lets us split
//         //    the array into two groups. x & (-x) keeps only the rightmost set bit.
//         int mask = xorResult & (-xorResult);

//         // 3. Partition all numbers into two groups by that bit and XOR each group
//         //    separately. Duplicates always land in the same group and cancel out,
//         //    leaving one unique number in each group.
//         int groupA = 0;
//         int groupB = 0;

//         foreach (var num in nums)
//         {
//             // (num & mask) == 0 means the isolated bit is 0 for this number,
//             // so it belongs to groupA; otherwise it belongs to groupB.
//             if ((num & mask) == 0)
//             {
//                 groupA ^= num;
//             }
//             else
//             {
//                 groupB ^= num;
//             }
//         }

//         return new int[] { groupA, groupB };
//     }

//     // Time Complexity:  O(n) - two passes over the array, each O(n).
//     // Space Complexity: O(1) - only a few integer variables are used
//     //                   (the returned array of size 2 is constant, not extra work space).
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 1, 2, 1, 3, 2, 5 };

//         Solution s = new Solution();

//         var result = s.SingleNumber(nums);

//         foreach (var r in result)
//         {
//             Console.Write($"{r}" + " ");
//         }
//     }
// }