//using System;


//public class Solution
//{
//    public void Merge(int[] nums1, int m, int[] nums2, int n)
//    {
//        int p1 = m - 1; // Pointer for nums1
//        int p2 = n - 1; // Pointer for nums2
//        int p = m + n - 1; // Pointer for the last position in nums1

//        while (p1 >= 0 && p2 >= 0)
//        {
//            if (nums1[p1] > nums2[p2])
//            {
//                nums1[p--] = nums1[p1--];
//            }
//            else
//            {
//                nums1[p--] = nums2[p2--];
//            }
//        }

//        // If there are remaining elements in nums2, add them to nums1
//        while (p2 >= 0)
//        {
//            nums1[p--] = nums2[p2--];
//        }
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        Solution t = new Solution();
//        int[] ar1 = { 1, 2, 3, 0, 0, 0 };
//        int[] ar2 = { 2, 5, 6 };
//        t.Merge(ar1, 3, ar2, 3);

//        for (int i = 0; i < ar1.Length; i++)
//        {
//            Console.Write($"{ar1[i]}" + " ");
//        }

//    }
//}

////Complexity: O(m + n), Space: O(1)