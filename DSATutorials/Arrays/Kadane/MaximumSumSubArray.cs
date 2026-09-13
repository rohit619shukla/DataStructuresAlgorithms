// public class Solution
// {
//     public int MaxSubArray(int[] nums)
//     {
//         // currSum -> running sum of the CURRENT window
//         // maxSum  -> best sum found so far (start at MinValue to handle all-negative arrays)
//         // s       -> left edge of the CURRENT running window (keeps sliding forward)
//         // start   -> left edge of the BEST window found so far (pinned/frozen)
//         // end     -> right edge of the BEST window found so far
//         int currSum = 0, maxSum = int.MinValue, start = 0, end = 0, s = 0;

//         for (int i = 0; i < nums.Length; i++)
//         {
//             // Extend the current window by taking the next element
//             currSum += nums[i];

//             // Found a new best? Commit to it.
//             if (currSum > maxSum)
//             {
//                 maxSum = currSum;

//                 // Pin BOTH boundaries of the best window at this instant.
//                 // 's' is the current window's left edge, so freeze it into 'start';
//                 // it will keep moving later, but 'start' must stay put on the best window.
//                 start = s;
//                 end = i;
//             }

//             // If the running sum goes negative, any future window is better off
//             // dropping this prefix entirely, so reset and restart the window.
//             if (currSum < 0)
//             {
//                 currSum = 0;

//                 // Everything up to and including i is discarded,
//                 // so the next window starts right after i.
//                 s = i + 1;
//             }
//         }

//         // Print the best subarray using its pinned boundaries [start, end]
//         for (int i = start; i <= end; i++)
//         {
//             Console.Write($"{nums[i]}" + " ");
//         }

//         return maxSum;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

//         Solution s = new Solution();

//         Console.WriteLine($"{s.MaxSubArray(nums)}" + " ");
//     }
// }