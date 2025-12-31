

//using System;
//using System.Collections.Generic;

//class Solution
//{
//    // Time: O(n * n!), space : O(n)
//    public IList<string> Permute(string str)
//    {
//        IList<string> result = new List<string>();

//        Solve(str, 0, result);

//        return result;

//    }

//    private void Solve(string str, int index, IList<string> result)
//    {
//        // base case
//        if (index == str.Length)
//        {
//            result.Add(new string(str));
//            return;
//        }

//        for (int i = index; i < str.Length; i++)
//        {
//            str = Swap(str, index, i);

//            Solve(str, index + 1, result);

//            str = Swap(str, index, i);
//        }
//    }

//    private string Swap(string str, int i, int j)
//    {
//        char[] charArray = str.ToCharArray();

//        while (i < j)
//        {
//            char temp = charArray[i];
//            charArray[i] = charArray[j];
//            charArray[j] = temp;

//            i++;
//            j--;
//        }

//        return new string(charArray);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "ABC";

//        Solution s = new Solution();

//        var result = s.Permute(str);

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