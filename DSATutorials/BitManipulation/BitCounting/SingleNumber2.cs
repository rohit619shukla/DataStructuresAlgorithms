// public class Solution
// {
//     // Time : O(n) outer loop runs for O(32) => 1
//     public int SingleNumber(int[] nums)
//     {
//         int result = 0;
//         // We will trace upto 32 bits
//         for (int bit = 0; bit < 32; bit++)
//         {
//             int countZeroes = 0, countOnes = 0;
//             for (int j = 0; j < nums.Length; j++)
//             {
//                 // Now we need to check that for the given number if the current bit is set or not
//                 if ((nums[j] & (1 << bit)) == 0)
//                 {
//                     countZeroes++;
//                 }
//                 else
//                 {
//                     countOnes++;
//                 }
//             }

//             // We are only concerned to set bit with 1 as 0 dont make any sense
//             if (countOnes % 3 == 1)
//             {
//                 // Go ahead and set that bit in the result
//                 result = result | (1 << bit);
//             }
//         }

//         return result;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();

//         int[] nums = { 2, 2, 3, 2 };
//         Console.WriteLine($"{s.SingleNumber(nums)}");
//     }
// }