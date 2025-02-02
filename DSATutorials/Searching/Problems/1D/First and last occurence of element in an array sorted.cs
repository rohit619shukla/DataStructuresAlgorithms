

//public class Solution
//{
//    public int[] SearchRange(int[] nums, int target)
//    {
//        int[] result = new int[2];

//        Array.Fill(result, -1);

//        if (nums == null || nums.Length == 0)
//        {
//            return result;
//        }

//        result[0] = FirstOccurence(nums, target, 0, nums.Length - 1);
//        result[1] = LastOccurence(nums, target, 0, nums.Length - 1);

//        return result;
//    }

//    private int FirstOccurence(int[] nums, int target, int lb, int ub)
//    {
//        int result = -1;

//        while (lb <= ub)
//        {
//            int mid = lb + (ub - lb) / 2;

//            if (nums[mid] == target)
//            {
//                result = mid;
//                ub = mid - 1;
//            }

//            else if (nums[mid] > target)
//            {
//                ub = mid - 1;
//            }
//            else
//            {
//                lb = mid + 1;
//            }
//        }

//        return result;
//    }

//    private int LastOccurence(int[] nums, int target, int lb, int ub)
//    {
//        int result = -1;

//        while (lb <= ub)
//        {
//            int mid = lb + (ub - lb) / 2;

//            if (nums[mid] == target)
//            {
//                result = mid;
//                lb = mid + 1;
//            }

//            else if (nums[mid] > target)
//            {
//                ub = mid - 1;
//            }
//            else
//            {
//                lb = mid + 1;
//            }
//        }

//        return result;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 5, 7, 7, 8, 8, 10 };

//        Solution s = new Solution();

//        var result = s.SearchRange(arr, 8);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}

//// Time : Log(n) , space: O(1) as its fixed size of 2 always
/// Idea :
/// 1) Find if the element exisit in the array with help if mid condition
/// 2) For first occurence move left 
/// 3) FOr last occurence move right