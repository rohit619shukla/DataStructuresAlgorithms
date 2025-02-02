

//class Solution
//{
//    public int Search(int[] nums, int target)
//    {
//        int lb = 0;
//        int ub = nums.Length - 1;

//        while (lb <= ub)
//        {
//            int mid = lb + (ub - lb) / 2;

//            if (nums[mid] == target)
//            {
//                return mid;
//            }

//            // Case 1: Check if left half is sorted
//            if (nums[lb] <= nums[mid])
//            {
//                // Check if the target lies in left half or not
//                if (nums[lb] <= target && target <= nums[mid])
//                {
//                    ub = mid - 1;
//                }
//                else
//                {
//                    lb = mid + 1;
//                }
//            }
//            else if (nums[mid] <= nums[ub])
//            {
//                // case 2: Right half is sorted
//                // Check if the target lies in right half or not
//                if (nums[mid] <= target && target <= nums[ub])
//                {
//                    lb = mid + 1;
//                }
//                else
//                {
//                    ub = mid - 1;
//                }
//            }
//        }

//        return -1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 3 };

//        Solution s = new Solution();

//        Console.WriteLine(s.Search(arr, 3));
//    }
//}

////* O(LogN), spcae : O(1) 