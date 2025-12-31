//using System;
//using System.Collections.Generic;

//using System;
//using System.Collections.Generic;

//public class Solution
//{
//    // Time : O(nlogn) + O(2^n) + O(n) + O(n)
//    public IList<IList<int>> SubsetsWithDup(int[] nums)
//    {
//        IList<IList<int>> result = new List<IList<int>>();
//        IList<int> tempList = new List<int>();

//        // 1. Sort the array so that duplicates are adjacent.
//        // This is mandatory for the skipping logic to work.
//        Array.Sort(nums);

//        Recursion(result, tempList, 0, nums);

//        return result;
//    }

//    private void Recursion(IList<IList<int>> result, IList<int> tempList, int index, int[] nums)
//    {
//        // Base case: When we have made a decision for every element in the array
//        if (index == nums.Length)
//        {
//            result.Add(new List<int>(tempList));
//            return;
//        }

//        // --- OPTION 1: PICK the element ---
//        tempList.Add(nums[index]);
//        // Move to the next index normally
//        Recursion(result, tempList, index + 1, nums);

//        // Backtrack: Remove the element before trying the "No-Pick" option
//        tempList.RemoveAt(tempList.Count - 1);

//        // --- OPTION 2: NO-PICK (Skip) the element ---
//        // To avoid duplicate subsets, we must skip all identical numbers.
//        // If we skip the first '2', we must skip all '2's at this level.
//        while (index + 1 < nums.Length && nums[index] == nums[index + 1])
//        {
//            index++;
//        }

//        // Move to the next index after all duplicates of the current value
//        Recursion(result, tempList, index + 1, nums);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] nums = { 1, 2, 2 };

//        Solution s = new Solution();

//        var result = s.SubsetsWithDup(nums);

//        for (int i = 0; i < result.Count; i++)
//        {
//            var temp = result[i];

//            foreach (var item in temp)
//            {
//                Console.Write($"{item}");
//            }
//            Console.WriteLine();
//        }
//    }
//}