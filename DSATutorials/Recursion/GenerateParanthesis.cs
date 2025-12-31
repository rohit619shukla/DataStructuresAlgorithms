//using System.Drawing;
//using System.Runtime.InteropServices;
//using System.Text;

//public class Solution
//{

//   // Time : O(2^2n) , space : O(2n)
//    public IList<string> GenerateParenthesis(int n)
//    {
//        IList<string> result = new List<string>();

//        Solve(n, result, new StringBuilder(), 0, 0);

//        return result;
//    }

//    private void Solve(int n, IList<string> result, StringBuilder temp, int open, int close)
//    {
//        // base case
//        if (temp.Length == 2 * n)
//        {
//            result.Add(temp.ToString());
//            return;
//        }

//        // We will add till the point we are lesser than accepted value of n
//        if (open < n)
//        {
//            temp.Append('(');

//            Solve(n, result, temp, open + 1, close);

//            temp.Remove(temp.Length - 1, 1);
//        }

//        // Check for other possibility
//        // We will now try to add closing braces till it is not greater than opening one
//        if (close < open)
//        {
//            temp.Append(')');

//            Solve(n, result, temp, open, close + 1);

//            temp.Remove(temp.Length - 1, 1);
//        }
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int n = 3;

//        Solution s = new Solution();

//        var result = s.GenerateParenthesis(n);

//        foreach (var item in result)
//        {
//            Console.WriteLine(item);
//        }
//    }
//}