
//class Solution
//{
//    public int SingleNonDuplicate(int[] nums)
//    {
//        int low = 0;
//        int high = nums.Length - 1;

//        // Unlike lb<=ub we stop soon as the number is equal or greater than high as we are looking for low==high for just 1 value
//        // and going beyond that value is useless
//        while (low < high)
//        {
//            int mid = low + (high - low) / 2;

//            // Ensure mid is even for proper pairing, as we need pairs. If the number is odd we want make sure its stat of pair
//            if (mid % 2 == 1)
//            {
//                mid--;
//            }

//            if (nums[mid] == nums[mid + 1])
//            {
//                // Single element is in the right half
//                low = mid + 2;
//            }
//            else
//            {
//                // Single element is in the left half
//                high = mid;
//            }
//        }

//        // high points to the single element
//        return nums[high];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 3, 3, 7, 7, 10, 11, 11 };

//        Solution s = new Solution();

//        Console.WriteLine(s.SingleNonDuplicate(arr));
//    }
//}

//// Time : O(Logn), space : O(1)