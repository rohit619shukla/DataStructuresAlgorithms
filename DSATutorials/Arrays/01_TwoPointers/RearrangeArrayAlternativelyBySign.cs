// public class Solution
// {
//     public int[] RearrangeArray(int[] nums)
//     {
//         // Goal: return an array where signs alternate, starting with a positive.
//         // The count of positives and negatives is guaranteed to be equal.

//         // Approach 1 (not used): Split nums into separate positive and negative
//         // arrays, then merge them alternately into the result. This is simple but
//         // needs O(n) extra space for the two temporary arrays.

//         // Approach 2 (used below): Single pass with two write positions.
//         //   - Positives go to even indices: 0, 2, 4, ...
//         //   - Negatives go to odd indices:  1, 3, 5, ...
//         // This preserves the relative order of each sign and produces an
//         // alternating pattern directly.
//         // Time: O(n), Auxiliary Space: O(1) (result array excluded)
//         int positivePtr = 0;   // next even index to place a positive number
//         int negativePtr = 1;   // next odd index to place a negative number

//         int[] result = new int[nums.Length];

//         for (int i = 0; i < nums.Length; i++)
//         {
//             if (nums[i] > 0)
//             {
//                 // Positive number -> place at the next even index
//                 result[positivePtr] = nums[i];
//                 positivePtr += 2;
//             }
//             else
//             {
//                 // Negative number -> place at the next odd index
//                 result[negativePtr] = nums[i];
//                 negativePtr += 2;
//             }
//         }

//         return result;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 3, 1, -2, -5, 2, -4 };

//         Solution s = new Solution();

//         var result = s.RearrangeArray(nums);

//         foreach (var num in result)
//         {
//             Console.Write($"{num}" + " ");
//         }
//     }
// }