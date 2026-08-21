// public class Solution
// {
//     // Generates the power set (all possible subsets) of the given array
//     // using the bitmask technique instead of recursion/backtracking.
//     //
//     // Core idea: for an array of length n there are exactly 2^n subsets.
//     // Each subset can be represented by an n-bit number (a "mask"):
//     //   - bit j = 1  -> include nums[j] in this subset
//     //   - bit j = 0  -> skip nums[j]
//     // By looping over every mask from 0 to 2^n - 1, we enumerate every subset.
//     //
//     // Example for nums = {1, 2, 3}:
//     //   mask 000 -> {}        mask 100 -> {3}
//     //   mask 001 -> {1}       mask 101 -> {1,3}
//     //   mask 010 -> {2}       mask 110 -> {2,3}
//     //   mask 011 -> {1,2}     mask 111 -> {1,2,3}
//     //
//     // Time:  O(n * 2^n) -> 2^n subsets to build, and up to n work to build each one.
//     // Space: O(n * 2^n) -> we store all 2^n subsets (this is just the output size).
//     //        Extra/auxiliary space is only O(n) for the `temp` list.
//     public IList<IList<int>> Subsets(int[] nums)
//     {
//         IList<IList<int>> result = new List<IList<int>>();

//         // Total number of subsets = 2^n, written efficiently as a left shift: 1 << n.
//         int range = 1 << nums.Length;

//         // Iterate over every possible mask (each represents one unique subset).
//         for (int i = 0; i < range; i++)
//         {
//             List<int> temp = new List<int>();

//             // Inspect each bit position j to decide whether nums[j] belongs to this subset.
//             for (int j = 0; j < nums.Length; j++)
//             {
//                 // (1 << j) is a mask with only bit j set.
//                 // If (i & (1 << j)) is non-zero, bit j is set in i -> include nums[j].
//                 if ((i & (1 << j)) != 0)
//                 {
//                     temp.Add(nums[j]);
//                 }
//             }

//             result.Add(temp);
//         }

//         return result;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();
//         int[] nums = { 1, 2, 3 };

//         var result = s.Subsets(nums);

//         foreach (var lst in result)
//         {
//             foreach (var item in lst)
//             {
//                 Console.Write($"{item}" + " ");
//             }
//             Console.WriteLine();
//         }
//     }
// }