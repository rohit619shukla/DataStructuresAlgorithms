//public class Solution
//{

//    // Time : O(n) , space :O(n)
//    public IList<int> FindDuplicates(int[] nums)
//    {
//        List<int> result = new List<int>();

//        for (int i = 0; i < nums.Length; i++)
//        {
//            // get the absolute value at current index
//            int abs = Math.Abs(nums[i]);

//            // get the index of the element - 1
//            int newIndex = abs - 1;

//            // If the number is -ve then its already visited
//            if (nums[newIndex] < 0)
//            {
//                result.Add(Math.Abs(nums[i]));
//            }
//            else
//            {
//                // mark the number as -ve
//                nums[newIndex] = -nums[newIndex];
//            }
//        }

//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] nums = { 1, 1, 2 };

//        Solution s = new Solution();

//        var result = s.FindDuplicates(nums);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}