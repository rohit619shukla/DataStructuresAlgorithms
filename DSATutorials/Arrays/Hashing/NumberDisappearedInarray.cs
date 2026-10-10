// using Microsoft.Azure.Cosmos.Serialization.HybridRow;

// public class Solution
// {
//     // Approach 2: Time: O(n), Space: O(1) auxiliary and O(k) for the result
//     public IList<int> FindDisappearedNumbers(int[] nums)
//     {
//         List<int> result = new List<int>();

//         // Approach 1 : HashSet lookup
//         // Time: O(n) expected, Space: O(n) auxiliary and O(k) for the result
//         // HashSet<int> set = new HashSet<int>(nums);

//         // for (int i = 0; i < nums.Length; i++)
//         // {
//         //     int number = i + 1;

//         //     // Check whether the number is missing.
//         //     if (!set.Contains(number))
//         //     {
//         //         result.Add(number);
//         //     }
//         // }


//         // Approach 2: Each value x in [1, n] maps to index x - 1.
//         // Mark that index negative to record that x exists.
//         // Math.Abs recovers the original value if its position was already marked.
//         for (int i = 0; i < nums.Length; i++)
//         {
//             int numberIndex = Math.Abs(nums[i]) - 1;

//             if (nums[numberIndex] > 0)
//             {
//                 nums[numberIndex] = 0 - nums[numberIndex];
//             }
//         }

//         // A positive nums[i] means no value mapped to index i, so i + 1 is missing.
//         for (int i = 0; i < nums.Length; i++)
//         {
//             if (nums[i] > 0)
//             {
//                 result.Add(i + 1);
//             }
//         }
//         return result;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 4, 3, 2, 7, 8, 2, 3, 1 };

//         Solution s = new Solution();

//         var result = s.FindDisappearedNumbers(nums);

//         foreach (int num in result)
//         {
//             Console.Write($"{num}" + " ");
//         }
//     }
// }