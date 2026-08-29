// public class Solution
// {
//     // Returns the length of the longest run of consecutive 1s in the array.
//     // Time Complexity:  O(n) - single pass over the array.
//     // Space Complexity: O(1) - only two counters are used.
//     public int FindMaxConsecutiveOnes(int[] nums)
//     {
//         int max = 0;   // best run length seen so far
//         int count = 0; // length of the current run of 1s

//         foreach (int n in nums)
//         {
//             if (n == 1)
//             {
//                 // Extend the current run and update the best seen.
//                 count++;
//                 max = Math.Max(max, count);
//             }
//             else
//             {
//                 // A 0 breaks the run, so reset the current count.
//                 count = 0;
//             }
//         }

//         return max;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 1, 1, 0, 1, 1, 1 };

//         Solution s = new Solution();

//         Console.WriteLine(s.FindMaxConsecutiveOnes(nums));
//     }
// }