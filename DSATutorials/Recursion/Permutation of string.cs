
//using System.Collections.Generic;

//class Solution
//{
//    public IList<IList<string>> Solve(string str)
//    {
//        IList<IList<string>> result = new List<IList<string>>();

//        char[] currString = str.ToCharArray();

//        Recursion(result, currString, 0, str.Length - 1);

//        return result;
//    }

//    private void Recursion(IList<IList<string>> result, char[] currString, int lb, int ub)
//    {
//        if (lb == ub)
//        {
//            result.Add(new List<string> { new string(currString) });
//            return;
//        }

//        for (int i = lb; i <= ub; i++)
//        {
//            Swap(currString, lb, i);

//            Recursion(result, currString, lb + 1, ub);

//            Swap(currString, lb, i);
//        }
//    }

//    private void Swap(char[] currString, int ub, int lb)
//    {
//        char temp = currString[lb];
//        currString[lb] = currString[ub];
//        currString[ub] = temp;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        string str = "ABC";

//        var result = s.Solve(str);

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

//// Time: O(n * n!), space : O(n)