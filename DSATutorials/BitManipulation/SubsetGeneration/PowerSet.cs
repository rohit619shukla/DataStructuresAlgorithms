//// Leetcode 78

//public class Solution
//{
//    // Time and Space : O(2^n)
//    public IList<IList<int>> Subsets(int[] nums)
//    {
//        IList<IList<int>> result = new List<IList<int>>();

//        // What we know is the for a given array with n unique numbers the subsets will be 2^n
//        // We will use the same principle to generate the subsets
//        // Lets convert 2^n to a number using same old left shifet stuff

//        int subsets = 1 << nums.Length;

//        // Those many subsets will be there
//        for (int i = 0; i < subsets; i++)
//        {
//            List<int> temp = new List<int>();

//            // For each number we will check if the ith bit is set or not
//            for (int j = 0; j < nums.Length; j++)
//            {
//                // Now check wheter the current bit for the number is set or not.
//                // If set add it to list
//                if ((i & (1 << j)) != 0)
//                {
//                    temp.Add(nums[j]);
//                }
//            }

//            result.Add(temp);
//        }

//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] nums = { 1, 2, 3 };

//        Solution s = new Solution();

//        var result = s.Subsets(nums);

//        foreach (var item in result)
//        {
//            for (int i = 0; i < item.Count; i++)
//            {
//                Console.Write($"{item[i]}" + " ");
//            }
//            Console.WriteLine();
//        }
        
//    }
//}