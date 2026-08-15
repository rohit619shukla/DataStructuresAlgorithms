

//public class Solution
//{
//    public int FindPeakElement(int[] nums)
//    {
//        int low = 0, high = nums.Length - 1;

//        while (low < high)
//        {
//            int mid = low + (high - low) / 2;
//             // When arr[mid] > arr[mid + 1], the peak must lie in the left half, including mid, because the downward slope indicates there's a peak somewhere on the left.
//            if (nums[mid] > nums[mid + 1])
//            {
//                // If mid is greater than the next element, peak must be on the left side
//                high = mid;
//            }
//            else
//            {
                //// When arr[mid] < arr[mid + 1], the peak must lie in the right half, excluding mid, because the upward slope means the peak is further to the right.
//                // If mid is smaller than the next element, peak must be on the right side
//                low = mid + 1;
//            }
//        }

//        return low; // 'low' is the index of the peak element. We can also return high as well, it does not matter because loop terminates at lb ==ub
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        //int[] arr = { 1, 2, 1, 3, 5, 6, 4 };
//        int[] arr = { 1, 2, 3, 4, 5, 6 };

//        Solution s = new Solution();

//        Console.WriteLine(s.FindPeakElement(arr));
//    }
//}