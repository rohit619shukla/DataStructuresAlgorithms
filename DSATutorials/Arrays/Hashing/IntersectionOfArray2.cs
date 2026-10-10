// public class Solution
// {
//     // Time: O(m log m + n log n), Space: O(log m + log n) auxiliary and O(k) for the result
//     public int[] Intersect(int[] nums1, int[] nums2)
//     {
//         // Lets sort both the arrays
//         Array.Sort(nums1);

//         Array.Sort(nums2);

//         List<int> result = new List<int>();

//         // Lets keep 2 pointers to track the result
//         int i = 0, j = 0;

//         while (i < nums1.Length && j < nums2.Length)
//         {
//             if (nums1[i] == nums2[j])
//             {
//                 result.Add(nums1[i]);
//                 i++;
//                 j++;
//             }
//             else if (nums1[i] < nums2[j])
//             {
//                 i++;
//             }
//             else if (nums1[i] > nums2[j])
//             {
//                 j++;
//             }
//         }

//         return result.ToArray();
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums1 = { 1, 2, 2, 1 };

//         int[] nums2 = { 2, 2 };

//         Solution s = new Solution();

//         var result = s.Intersect(nums1, nums2);

//         foreach (int n in result)
//         {
//             Console.Write($"{n}" + " ");
//         }
//     }
// }