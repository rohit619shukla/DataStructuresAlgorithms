// public class Solution
// {
//     public IList<int> FindDuplicates(int[] nums)
//     {
//         // Values are in [1, n], and each appears once or twice.
//         // Use each value's corresponding index to mark whether it has been seen.
//         // This approach modifies nums in place.
//         // Time: O(n), where n is nums.Length.
//         // Auxiliary space: O(1); the result list uses O(k) space for k duplicates.

//         List<int> result = new List<int>();

//         for (int i = 0; i < nums.Length; i++)
//         {
//             // Recover the original value before mapping [1, n] to zero-based indices.
//             int currentIndex = Math.Abs(nums[i]) - 1;

//             if (nums[currentIndex] > 0)
//             {
//                 // We are visiting for first time so mark it as -ve
//                 nums[currentIndex] = 0 - nums[currentIndex];
//             }
//             else
//             {
//                 // A negative value at this index indicates a repeated occurrence.
//                 result.Add(nums[i]);
//             }
//         }

//         return result;
//     }
// }



// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 10, 2, 5, 10, 9, 1, 1, 4, 3, 7 };

//         Solution s = new Solution();

//         var result = s.FindDuplicates(nums);

//         foreach (int num in result)
//         {
//             Console.Write($"{num}" + " ");
//         }
//     }
// }