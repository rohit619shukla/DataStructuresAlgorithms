

//class Solution
//{
//    public int Search(int[] nums, int target)
//    {
//        if (nums == null)
//        {
//            return -1;
//        }

//        int lb = 0;
//        int ub = nums.Length - 1;

//        while (lb <= ub)
//        {
//            int mid = (lb + ub) / 2;

//            if (nums[mid] == target)
//            {
//                return mid;
//            }

//            if (target > nums[mid])
//            {
//                lb = mid + 1;
//            }
//            else
//            {
//                ub = mid - 1;
//            }
//        }

//        return -1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {

//        int[] nums = { -1, 0, 3, 5, 9, 12 };

//        int target = 9;

//        Solution s = new Solution();

//        Console.WriteLine(s.Search(nums, target));
//    }
//}

///* Complexity : O(logn), Space : O(1) */

///* Note while searching an element in reverse sorted array simply swap the lb and ub conditions */