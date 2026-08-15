
//class Solution
//{
//    public int MinEatingSpeed(int[] arr, int h)
//    {
//        int lb = 1;
//        int ub = int.MinValue;

//        foreach (int i in arr)
//        {
//            ub = Math.Max(i, ub);
//        }

//        // We just want that one minimum element
//        while (lb < ub)
//        {
//            int mid = lb + (ub - lb) / 2;

//            // Means the no:of bananas we took were high hence hours is left and we can reduce
//            if (GetTotalTime(arr, mid) <= h)
//            {
//                ub = mid;
//            }
//            else
//            {
//                // Means the no:of bananas we took were less hence hours is taken more and we need to increase number per hours
//                lb = mid + 1;
//            }
//        }

//        return lb;
//    }

//    private int GetTotalTime(int[] arr, int mid)
//    {
//        // We are taking ceil and not floor as we dont want to underestimate the remaninder hourse needed
//        int ceil = 0;
//        foreach (int item in arr)
//            ceil += (int)Math.Ceiling((double)item / mid);  // We have to double to get additional left of number as int/int will discard additional left over number
//        return ceil;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 3, 6, 7, 11 };

//        Solution s = new Solution();

//        Console.WriteLine(s.MinEatingSpeed(arr, 8));
//    }
//}

//// Time : O(n log m)