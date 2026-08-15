
//public class Solution
//{
//    // Time :O(m+n), space :(O(m+n))
//    public int[] Intersection(int[] nums1, int[] nums2)
//    {
//        HashSet<int> set1 = new HashSet<int>(nums1);
//        HashSet<int> set2 = new HashSet<int>();

//        foreach (int item in nums2)
//        {
//            if (set1.Contains(item))
//            {
//                set2.Add(item);
//            }
//        }
//        return set2.ToArray();
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] nums1 = { 4, 9, 5 };
//        int[] nums2 = { 9, 4, 9, 8, 4 };

//        Solution s = new Solution();

//        int[] result = s.Intersection(nums1, nums2);

//        foreach (int i in result)
//        {
//            Console.Write($"{i}" + " ");
//        }
//    }
//}