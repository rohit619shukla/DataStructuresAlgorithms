
//public class Solution
//{
//    public bool Check(int[] nums)
//    {
//        if (nums == null || nums.Length == 0)
//        {
//            return false;
//        }

//        int count = 0;
//        int len = nums.Length;

//        for (int i = 0; i < len; i++)
//        {
//            if (nums[i] > nums[(i + 1) % len])
//            {
//                count++;
//            }

//            // Counting violations.If count is greater than 1 violation is clear and not sorted
//            if (count > 1)
//            {
//                return false;
//            }
//        }

//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 3, 4, 5, 1, 2 };

//        Solution s = new Solution();

//        Console.WriteLine(s.Check(arr));
//    }
//}

//// TIme :O(n) ,space :O(1)