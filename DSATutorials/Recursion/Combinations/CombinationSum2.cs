//using System;
//using System.Collections.Generic;

//public class Solution
//{
//    // Time : (nlogn) + O(n * 2^n)
//    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
//    {
//        IList<IList<int>> result = new List<IList<int>>();

//        IList<int> temp = new List<int>();

//        //Array.Sort(candidates);
//        Solve(candidates, 0, target, result, temp);
//        return result;
//    }

//    private void Solve(int[] candidate, int index, int target, IList<IList<int>> result, IList<int> temp)
//    {
//        // base case
//        if (index >= candidate.Length)
//        {
//            if (target == 0)
//            {
//                result.Add(new List<int>(temp));
//            }
//            return;
//        }

//        if (target >= candidate[index])
//        {
//            temp.Add(candidate[index]);

//            Solve(candidate, index + 1, target - candidate[index], result, temp);

//            temp.RemoveAt(temp.Count - 1);

//            while (index + 1 < candidate.Length && candidate[index] == candidate[index + 1])
//            {
//                index++;
//            }
//        }

//        Solve(candidate, index + 1, target, result, temp);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] candidates = { 1, 7, 1 };
//        int target = 8;

//        Solution s = new Solution();

//        var result = s.CombinationSum2(candidates, target);

//        for (int i = 0; i < result.Count; i++)
//        {
//            var temp = result[i];

//            foreach (var item in temp)
//            {
//                Console.Write($"{item}" + " ,");
//            }
//            Console.WriteLine();
//        }
//    }
//}


//// Note : The whole idea of skipping the elements when same is that post sorting ww will move i+1 to next level and also in same level we can skip 