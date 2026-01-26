//public class Solution
//{
//    public IList<IList<int>> PermuteUnique(int[] nums)
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

//        // Here we use set as we will be iterating at same level first before going to next one
//        HashSet<int> set = new HashSet<int>();
//        for (int i = index; i < nums.Length; i++)
//        {
//            //if (set.Contains(nums[i]))
//            //{
//            //    continue;
//            //}
//            set.Add(nums[i]);

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

//        int[] nums = { 1, 1, 2 };

//        var result = s.PermuteUnique(nums);

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