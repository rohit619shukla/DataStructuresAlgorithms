// public class Solution
// {
//     // Time: O(n), where n is the number of elements in nums.
//     // Space: O(n) for the prefix-sum frequencies stored in the dictionary.
//     public int NumSubarraysWithSum(int[] nums, int goal)
//     {
//         Dictionary<int, int> map = new Dictionary<int, int>();

//         // The empty prefix has sum 0 and occurs once. This allows subarrays
//         // starting at index 0 to be counted.
//         map[0] = 1;

//         int cumuLativeSum = 0, count = 0;

//         for (int i = 0; i < nums.Length; i++)
//         {
//             cumuLativeSum += nums[i];

//             // cumulativeSum - previousPrefixSum = goal, so the required
//             // previous prefix sum is cumulativeSum - goal.
//             int preFixSum = cumuLativeSum - goal;

//             if (map.ContainsKey(preFixSum))
//             {
//                 // Every occurrence of the required prefix sum forms a valid
//                 // subarray ending at the current index.
//                 count += map[preFixSum];
//             }

//             // Record this prefix sum for subarrays ending at later indices.
//             if (map.ContainsKey(cumuLativeSum))
//             {
//                 map[cumuLativeSum]++;
//             }
//             else
//             {
//                 map[cumuLativeSum] = 1;
//             }
//         }

//         return count;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 1, 0, 1, 0, 1 };

//         Solution s = new Solution();

//         Console.WriteLine(s.NumSubarraysWithSum(nums, 2));
//     }
// }