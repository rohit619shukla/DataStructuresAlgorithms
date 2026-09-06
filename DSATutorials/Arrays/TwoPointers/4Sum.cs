// public class Solution
// {
//     // Time  : O(n^3) -> sorting is O(n log n); the two nested loops (i, j) are O(n^2)
//     //         and each drives an O(n) two-pointer scan, so O(n^2) * O(n) = O(n^3) dominates.
//     // Space : O(1) auxiliary (ignoring the output list and the in-place sort's stack).
//     public IList<IList<int>> FourSum(int[] nums, int target)
//     {
//         IList<IList<int>> result = new List<IList<int>>();

//         // Sort so we can fix two numbers and collapse the remaining pair with the
//         // two-pointer 2 Sum technique, and so duplicates sit next to each other.
//         Array.Sort(nums);

//         int n = nums.Length;

//         // Fix the first number of the quadruple.
//         for (int i = 0; i < n - 3; i++)
//         {
//             // Skip duplicate values for i so we don't emit duplicate quadruples.
//             if (i > 0 && nums[i] == nums[i - 1])
//             {
//                 continue;
//             }

//             // Fix the second number of the quadruple.
//             for (int j = i + 1; j < n - 2; j++)
//             {
//                 // Skip duplicate values for j, but keep the first j (== i + 1) since
//                 // that is the starting position, not a repeat.
//                 if (j != i + 1 && nums[j] == nums[j - 1])
//                 {
//                     continue;
//                 }

//                 // Remaining window [k .. l] is searched with two pointers.
//                 int k = j + 1;
//                 int l = n - 1;

//                 // Find pairs in the window that complete the target sum.
//                 TwoSum(result, nums, target, i, j, k, l);
//             }
//         }

//         return result;
//     }

//     private void TwoSum(IList<IList<int>> result, int[] nums, int target, int n1, int n2, int lb, int ub)
//     {
//         // n1 and n2 are already fixed by the caller; move lb/ub inward to hit the target.
//         while (lb < ub)
//         {
//             // Use long to avoid int overflow when values are near int.MaxValue.
//             long sum = nums[n1];
//             sum += nums[n2];
//             sum += nums[lb];
//             sum += nums[ub];

//             if (sum < target)
//             {
//                 // Sum too small -> need a larger value, advance the lower pointer.
//                 lb++;
//             }
//             else if (sum > target)
//             {
//                 // Sum too large -> need a smaller value, retreat the upper pointer.
//                 ub--;
//             }
//             else
//             {
//                 // Match found. Skip duplicates on both ends so each quadruple is unique.
//                 while (lb < ub && nums[lb] == nums[lb + 1])
//                 {
//                     lb++;
//                 }

//                 while (lb < ub && nums[ub] == nums[ub - 1])
//                 {
//                     ub--;
//                 }

//                 result.Add(new List<int> { nums[n1], nums[n2], nums[lb], nums[ub] });

//                 // Move both pointers past the recorded pair.
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
//         int[] nums = { 1000000000,1000000000,1000000000,1000000000 };

//         Solution s = new Solution();

//         var result = s.FourSum(nums, -294967296);

//         foreach (List<int> temp in result)
//         {
//             foreach (int n in temp)
//             {
//                 Console.Write($"{n}" + " ");
//             }
//             Console.WriteLine();
//         }
//     }
// }