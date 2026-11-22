// // LeetCode 1: Two Sum
// // https://leetcode.com/problems/two-sum/
// //
// // Key Idea:
// //   - Single pass with a hash map storing value -> index of elements seen so far.
// //   - For each element, compute the complement (target - nums[i]). If the
// //     complement was already seen, we have found the pair and return both indices.
// //   - Otherwise, remember the current value and its index for future lookups.
// //
// // Time:  O(n) — each element is visited once, and map lookups/inserts are O(1) amortized.
// // Space: O(n) — the map may hold up to n elements in the worst case.

// public class Solution
// {
//     public int[] TwoSum(int[] nums, int target)
//     {
//         // Keep a Dictionary to check in O(1) whether we have seen a needed value before
//         Dictionary<int, int> map = new Dictionary<int, int>();

//         int[] result = new int[2];

//         for (int i = 0; i < nums.Length; i++)
//         {
//             // The value we would need to pair with nums[i] to reach target
//             int diff = target - nums[i];

//             if (map.ContainsKey(diff))
//             {
//                 // Found the complement earlier -> record both indices
//                 result[0] = map[diff];
//                 result[1] = i;
//             }
//             else
//             {
//                 // Not found yet -> store current value with the index where we found it
//                 map[nums[i]] = i;
//             }
//         }

//         return result;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 2, 7, 11, 15 };

//         int target = 9;

//         Solution s = new Solution();

//         var result = s.TwoSum(nums, target);

//         foreach (int num in result)
//         {
//             Console.Write($"{num}" + " ");
//         }
//     }
// }

// //Time: O(N), space: O(N)