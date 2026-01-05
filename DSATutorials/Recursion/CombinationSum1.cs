//using System;
//using System.Collections.Generic;

//public class Solution
//{
//    // Time : O(n * 2^n)
//    public IList<IList<int>> CombinationSum(int[] candidates, int target)
//    {
//        IList<IList<int>> result = new List<IList<int>>();

//        IList<int> temp = new List<int>();

//        Solve(candidates, 0, target, result, temp);

//        return result;
//    }

//    private void Solve(int[] candidates, int index, int target, IList<IList<int>> result, IList<int> temp)
//    {
//        // base case
//        if (index >= candidates.Length)
//        {
//            return;
//        }

//        // You have reached the target
//        if (target == 0)
//        {
//            result.Add(new List<int>(temp));
//            return;
//        }

//        // We can take an element only if it satisfy the target
//        if (target >= candidates[index])
//        {
//            // Do
//            temp.Add(candidates[index]);

//            // Explore next, we will stay same index
//            Solve(candidates, index, target - candidates[index], result, temp);

//            // backtrack
//            temp.RemoveAt(temp.Count - 1);
//        }

//        // Not take
//        Solve(candidates, index + 1, target, result, temp);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] candidates = { 2, 3, 6, 7 };
//        int target = 7;

//        Solution s = new Solution();

//        var result = s.CombinationSum(candidates, target);

//        for (int i = 0; i < result.Count; i++)
//        {
//            var temp = result[i];

//            foreach (var item in temp)
//            {
//                Console.Write(item);
//            }
//            Console.WriteLine();
//        }
//    }

//}