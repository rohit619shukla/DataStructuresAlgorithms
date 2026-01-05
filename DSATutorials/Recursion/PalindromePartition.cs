//using System;
//using System.Collections.Generic;

//public class Solution
//{
//    public IList<IList<string>> Partition(string s)
//    {
//        IList<IList<string>> result = new List<IList<string>>();
//        IList<string> temp = new List<string>();

//        Solve(s, 0, result, temp);

//        return result;
//    }

//    private void Solve(string s, int index, IList<IList<string>> result, IList<string> temp)
//    {
//        // Base case: If index reaches the end of the string, we found a valid partition
//        if (index == s.Length)
//        {
//            result.Add(new List<string>(temp));
//            return;
//        }

//        for (int i = index; i < s.Length; i++)
//        {
//            // Check if the substring from 'index' to 'i' is a palindrome
//            if (IsPalindrome(s, index, i))
//            {
//                // Choose: add the substring to our current path
//                temp.Add(s.Substring(index, i - index + 1));

//                // Explore: move to the next character AFTER the current palindrome (i + 1)
//                Solve(s, i + 1, result, temp);

//                // Backtrack: remove the last added substring to try other possibilities
//                temp.RemoveAt(temp.Count - 1);
//            }
//        }
//    }

//    private bool IsPalindrome(string s, int lb, int ub)
//    {
//        while (lb < ub)
//        {
//            if (s[lb] != s[ub])
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
//        string str = "aab";

//        Solution s = new Solution();

//        var result = s.Partition(str);

//        for (int i = 0; i < result.Count; i++)
//        {
//            var temp = result[i];

//            foreach (var item in temp)
//            {
//                Console.Write($"{item}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }

//}
