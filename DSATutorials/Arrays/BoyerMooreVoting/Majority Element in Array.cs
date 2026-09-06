// public class Solution
// {
//     // Time : O(n) , Space : O(1)
//     public int MajorityElement(int[] nums)
//     {
//         // The problem guarantees a majority element (appears more than n/2 times)
//         // always exists, so Boyer-Moore voting finds it in a single pass.

//         // Assume the first element is the candidate with one vote.
//         int candidate = nums[0];
//         int frequency = 1;

//         for (int i = 1; i < nums.Length; i++)
//         {
//             if (frequency == 0)
//             {
//                 // Votes cancelled out: adopt the current number as the new candidate.
//                 candidate = nums[i];
//                 frequency = 1;
//             }
//             else if (nums[i] == candidate)
//             {
//                 // Same as candidate -> add a vote.
//                 frequency++;
//             }
//             else
//             {
//                 // Different number -> cancel one vote.
//                 frequency--;
//             }
//         }

//         // Majority is guaranteed to exist, so no verification pass is needed.
//         return candidate;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 2, 2, 1, 1, 1, 2, 2 };

//         Solution s = new Solution();

//         Console.WriteLine($"{s.MajorityElement(nums)}");
//     }
// }