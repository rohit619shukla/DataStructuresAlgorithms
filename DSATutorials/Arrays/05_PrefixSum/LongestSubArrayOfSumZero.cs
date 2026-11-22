
// class Solution
// {
//     public int maxLength(int[] arr)
//     {
//         Dictionary<int, int> map = new Dictionary<int, int>();


//         int cumulativeSum = 0;
//         int maxLen = int.MinValue;

//         // Treat prefix sum 0 as occurring before the array so a zero-sum
//         // subarray starting at index 0 has length i - (-1).
//         map[0] = -1;

//         for (int i = 0; i < arr.Length; i++)
//         {
//             cumulativeSum += arr[i];

//             // If this prefix sum was seen before, the elements between the
//             // previous index and i have sum 0.
//             if (map.ContainsKey(cumulativeSum))
//             {
//                 // Keep the earliest index for each prefix sum because it
//                 // produces the longest possible zero-sum subarray.
//                 maxLen = Math.Max(maxLen, i - map[cumulativeSum]);
//             }
//             else
//             {
//                 map[cumulativeSum] = i;
//             }
//         }

//         // Time: O(n), where n is the number of elements in arr.
//         // Space: O(n) for the prefix sums stored in the dictionary.
//         return maxLen;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 15, -2, 2, -8, 1, 7, 10, 23 };

//         Solution s = new Solution();

//         Console.WriteLine($"{s.maxLength(nums)}");
//     }
// }