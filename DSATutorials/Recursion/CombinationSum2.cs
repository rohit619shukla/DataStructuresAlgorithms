
//using System.Collections.Generic;

//class Solution
//{
//    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
//    {
//        IList<IList<int>> result = new List<IList<int>>();

//        IList<int> current = new List<int>();

//        Array.Sort(candidates);

//        Solve(candidates, target, 0, result, current);

//        return result;
//    }

//    // Time : O(2^n * n) + O(nlogn) , space :O(n)
//    private void Solve(int[] candidates, int target, int idx, IList<IList<int>> result, IList<int> current)
//    {
//        // base case
//        if (target == 0)
//        {
//            result.Add(new List<int>(current));
//            return;
//        }

//        if (idx >= candidates.Length)
//        {
//            return;
//        }

//        // Here pick condition is bit different : Basically this is another way of working which kind of does the same thing
//        for (int i = idx; i < candidates.Length; i++)
//        {
//            // Since array is already sorted we are good and no point to move further
//            if (candidates[i] > target) break;

//            // Avoid duplicates by making sure that at same level of recursion we skip the duplicate but if level changes we should take 
//            if (i > idx && candidates[i] == candidates[i - 1])
//            {
//                continue;
//            }

//            current.Add(candidates[i]);
//            Solve(candidates, target - candidates[i], i + 1, result, current);
//            current.RemoveAt(current.Count - 1);

//            // bascially the for loop does the work of not take already
//        }
//    }



//}
//class Program
//{
//    public static void Main()
//    {
//        int[] candidates = { 10, 1, 2, 7, 6, 1, 5 };
//        int target = 8;

//        Solution s = new Solution();

//        var result = s.CombinationSum2(candidates, target);

//        for (int i = 0; i < result.Count; i++)
//        {
//            foreach (int num in result[i])
//            {
//                Console.Write($"{num}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }

//}