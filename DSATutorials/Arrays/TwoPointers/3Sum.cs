// // 3Sum : return all unique triplets (a, b, c) such that a + b + c = 0.
// //
// // Time Complexity  : O(n^2)
// //   - Sorting the array takes O(n log n).
// //   - The outer loop runs O(n) times and, for each iteration, the inner
// //     two-pointer scan runs O(n), giving O(n^2), which dominates the sort.
// //
// // Space Complexity : O(1) auxiliary (or O(n) if the sort is not in-place).
// //   - We use only a constant number of extra variables; the two-pointer
// //     scan needs no additional data structures.
// //   - The output list is not counted as auxiliary space. If it is counted,
// //     total space is O(n^2), since the number of unique triplets that sum
// //     to zero can grow on the order of n^2 in the worst case.
// //     Simple way to see it: each fixed number can pair with many others,
// //     so one number gives many triplets, not just one -> n * (many) = n^2.

// public class Solution
// {
//     public IList<IList<int>> ThreeSum(int[] nums)
//     {
//         IList<IList<int>> result = new List<IList<int>>();

//         // Approach :
//         // Whenever the question asks us to return the numbers themselves rather than their indices,
//         // we should sort the array so we can harness the power of Two Sum on a sorted range.
//         // Internally we still apply Two Sum, but with a twist and some setup done a few steps earlier.
//         Array.Sort(nums);

//         // We have been asked for a triplet where n1 + n2 + n3 = 0.
//         // This can be converted to a Two Sum problem like this : n2 + n3 = -n1.
//         // Unlike Two Sum, where we return as soon as a match is found, here we need
//         // all such triplet combinations, so we fix each number and scan the rest.

//         int n = nums.Length;

//         for (int i = 0; i < n - 1; i++)
//         {
//             // Skip duplicate values for the fixed element so we only produce unique triplets
//             if (i > 0 && nums[i] == nums[i - 1])
//             {
//                 continue;
//             }

//             int target = -(nums[i]);   // -n1, the value n2 + n3 must add up to

//             // Using these two pointers we will search for n2 and n3 in the remaining sorted range
//             int lb = i + 1;   // lower bound
//             int ub = n - 1;   // upper bound

//             TwoSum(result, nums, lb, ub, target);
//         }

//         return result;
//     }

//     private void TwoSum(IList<IList<int>> result, int[] nums, int lb, int ub, int target)
//     {

//         while (lb < ub)
//         {
//             int sum = nums[lb] + nums[ub];

//             if (sum > target)
//             {
//                 // Sum too large: move the upper pointer left to reduce it
//                 ub--;
//             }
//             else if (sum < target)
//             {
//                 // Sum too small: move the lower pointer right to increase it
//                 lb++;
//             }
//             else
//             {
//                 // Match found. Skip duplicate values on both sides so we don't emit the same triplet twice
//                 while (lb < ub && nums[lb] == nums[lb + 1])
//                 {
//                     lb++;
//                 }

//                 while (lb < ub && nums[ub] == nums[ub - 1])
//                 {
//                     ub--;
//                 }

//                 // Add the unique triplet to our result and move both pointers inward
//                 result.Add(new List<int> { -target, nums[lb], nums[ub] });
//                 lb++;
//                 ub--;
//             }
//         }
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { -1, 0, 1, 2, -1, -4 };

//         Solution s = new Solution();

//         var result = s.ThreeSum(nums);

//         foreach (List<int> item in result)
//         {
//             foreach (int n in item)
//             {
//                 Console.Write($"{n}" + " ");
//             }
//             Console.WriteLine();
//         }
//     }
// }