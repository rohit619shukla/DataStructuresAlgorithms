//public class Solution
//{
//    // Time :O(n) , space : O(n) as we are not storing all elements
//    public int[] TwoSum(int[] nums, int target)
//    {
//        Dictionary<int, int> map = new Dictionary<int, int>();
//        int diff = 0;
//        for (int i = 0; i < nums.Length; i++)
//        {
//            diff = target - nums[i];

//            if (!map.ContainsKey(diff))
//            {
//                map[nums[i]] = i;
//            }
//            else
//            {
//                return new int[] { i, map[diff] };
//            }
//        }

//        return new int[] { -1, -1 };
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 2, 7, 11, 15 };

//        Solution s = new Solution();

//        var result = s.TwoSum(arr, 9);

//        foreach (int item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}