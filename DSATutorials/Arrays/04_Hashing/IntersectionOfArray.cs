// using Microsoft.Azure.Cosmos.Serialization.HybridRow;

// public class Solution
// {
//     // Time : O(n) => for iterating over the array and addint to map, space : O(n)
//     public int[] Intersection(int[] nums1, int[] nums2)
//     {

//         List<int> result = new List<int>();

//         HashSet<int> set = new HashSet<int>();

//         foreach (int num in nums1)
//         {
//             set.Add(num);
//         }

//         foreach (int n in nums2)
//         {
//             if (set.Contains(n))
//             {
//                 result.Add(n);
//                 set.Remove(n);
//             }
//         }

//         return result.ToArray();
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums1 = { 4,9,5};
//         int[] nums2 = { 9,4,9,8,4};

//         Solution s = new Solution();

//         int[] result = s.Intersection(nums1, nums2);

//         foreach (int num in result)
//         {
//             Console.Write($"{num}" + " ");
//         }
//     }
// }