//using System;
//using System.Collections.Generic;

//public class Solution
//{
//    public IList<IList<int>> CombinationSum3(int k, int n)
//    {
//        IList<IList<int>> result = new List<IList<int>>();

//        IList<int> temp = new List<int>();

//        // We will startt with 1 as range is between 1- 9 only
//        Solve(k, 1, n, result, temp);

//        return result;
//    }

//    private void Solve(int limit, int index, int target, IList<IList<int>> result, IList<int> temp)
//    {

//        // base case
//        // We will stop as we have reached the upperbound to proceed further
//        if (temp.Count == limit)
//        {
//            if (target == 0)
//            {
//                result.Add(new List<int>(temp));
//            }
//            return;
//        }

//        // To prevet overflow
//        if (index > 9)
//        {
//            return;
//        }

//        // Take condition
//        if (target >= index)
//        {
//            // Do
//            temp.Add(index);

//            // Explore
//            Solve(limit, index + 1, target - index, result, temp);

//            // Undo
//            temp.RemoveAt(temp.Count - 1);
//        }

//        // Explore further
//        Solve(limit, index + 1, target, result, temp);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int k = 3, n = 7;

//        Solution s = new Solution();

//        var result = s.CombinationSum3(k, n);

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