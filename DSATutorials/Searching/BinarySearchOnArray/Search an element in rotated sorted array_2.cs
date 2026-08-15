

//class Solution
//{
//    public bool Search(int[] nums, int target)
//    {
//        int lb = 0;
//        int ub = nums.Length - 1;

//        while (lb <= ub)
//        {
//            int mid = lb + (ub - lb) / 2;

//            if (nums[mid] == target)
//            {
//                return true;
//            }

//            // Special case
//            // This is the only condition which could prevent from checking the below conditions, hence we need to shirnk size in half
//            if (nums[lb] == nums[mid] && nums[mid] == nums[ub])
//            {
//                lb++;
//                ub--;
//                continue;
//            }

//            if (nums[lb] <= nums[mid])
//            {
//                if (nums[lb] <= target && target <= nums[mid])
//                {
//                    ub = mid - 1;
//                }
//                else
//                {
//                    lb = mid + 1;
//                }
//            }
//            else
//            {
//                if (nums[mid] <= nums[ub])
//                {
//                    if (nums[mid] <= target && target <= nums[ub])
//                    {
//                        lb = mid + 1;
//                    }
//                    else
//                    {
//                        ub = mid - 1;
//                    }
//                }
//            }
//        }

//        return false;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 2, 5, 6, 0, 0, 1, 2 };

//        Solution s = new Solution();

//        Console.WriteLine(s.Search(arr, 0));
//    }
//}

//// Time : O(logn) : Best case when all elements are unique or not many duplicates and O(N) in worst case when we have many duplicates to shrink the size