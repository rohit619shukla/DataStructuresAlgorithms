//using System.Collections.Generic;

//public class Solution
//{
//    // Time : O(n*n!) , space : O(n) auxi
//    public IList<IList<int>> Permute(int[] nums)
//    {
//        List<int> temp = new List<int>();
//        IList<IList<int>> result = new List<IList<int>>();

//        Solve(nums, temp, result, 0);

//        return result;
//    }

//    private void Solve(int[] nums, List<int> temp, IList<IList<int>> result, int index)
//    {
//        // base case
//        if (index == nums.Length)
//        {
//            result.Add(new List<int>(nums));
//            return;
//        }

//        for (int i = index; i < nums.Length; i++)
//        {
//            Swap(nums, index, i);

//            Solve(nums, temp, result, index + 1);

//            Swap(nums, index, i);
//        }
//    }

//    private void Swap(int[] nums, int i, int j)
//    {
//        int temp = nums[i];
//        nums[i] = nums[j];
//        nums[j] = temp;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        int[] nums = { 1, 2, 3 };

//        var result = s.Permute(nums);

//        for (int i = 0; i < result.Count; i++)
//        {
//            var inter = result[i];

//            foreach (var item in inter)
//            {
//                Console.Write($"{item}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}