
//using System.Collections.Generic;

//class Solution
//{

//    public void Solve(string str, IList<IList<string>> result, int lb, int ub, List<string> currentList)
//    {
//        // Base case, if we have reached last position afet the last char we cannot procees
//        if (lb == str.Length)
//        {
//            result.Add(new List<string>(currentList));
//            return;
//        }

//        for (int i = lb; i <= ub; i++)
//        {
//            if (IsPalindrome(str, lb, i))
//            {
//                currentList.Add(str.Substring(lb, i - lb + 1));  // start index, size

//                Solve(str, result, i + 1, ub, currentList);

//                currentList.RemoveAt(currentList.Count - 1);
//            }
//        }
//    }

//    private bool IsPalindrome(string str, int lb, int ub)
//    {
//        while (lb < ub)
//        {
//            if (str[lb] != str[ub])
//            {
//                return false;
//            }

//            lb++;
//            ub--;
//        }

//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "aabb";

//        IList<IList<string>> result = new List<IList<string>>();

//        Solution h = new Solution();
//        List<string> currentList = new List<string>();

//        h.Solve(str, result, 0, str.Length - 1, currentList);

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

//// Time : O(N * 2^N) as there can be 2^N combo and N for palindrome check
//// Space : O(N)