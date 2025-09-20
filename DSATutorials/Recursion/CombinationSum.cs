//using System.Collections.Generic;

//public class Solution
//{
//    public IList<IList<int>> CombinationSum(int[] candidates, int target)
//    {
//        IList<IList<int>> result = new List<IList<int>>();

//        IList<int> current = new List<int>();

//        Solve(candidates, target, 0, result, current);

//        return result;
//    }

//    // Time : O(2^n) , space : O(n)
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
//            if (target >= candidates[i])
//            {
//                current.Add(candidates[i]);
//                Solve(candidates, target - candidates[i], i, result, current);
//                current.RemoveAt(current.Count - 1);

//                // bascially the for loop does the work of not take already
//            }
//        }
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
//            foreach (int num in result[i])
//            {
//                Console.Write($"{num}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}