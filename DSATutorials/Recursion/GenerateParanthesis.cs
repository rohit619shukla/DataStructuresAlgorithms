//using System.Text;

//public class Solution
//{
//    public IList<string> GenerateParenthesis(int n)
//    {
//        IList<string> result = new List<string>();

//        StringBuilder sb = new StringBuilder();

//        Recursion(n, 0, 0, sb, result); // Fix: Added open & close counters

//        return result;
//    }

//    private void Recursion(int n, int open, int close, StringBuilder sb, IList<string> result)
//    {
//        // base case
//        // As we will have 2*n braces in any given sequence
//        if (sb.Length == 2 * n)
//        {
//            result.Add(sb.ToString());
//            return;
//        }

//        // This will make sure we dont have more than n open braces
//        // Ex : n= 2 then 2*n = 4 braces, for them to be good it will be 2 open and 2 closed
//        if (open < n)
//        {
//            sb.Append('(');

//            // Recurse to next
//            Recursion(n, open + 1, close, sb, result);

//            // Backtrack
//            sb.Length--;
//        }

//        // This will make sure we dont have more close braces than open
//        if (close < open)
//        {
//            sb.Append(')');

//            Recursion(n, open, close + 1, sb, result);

//            sb.Length--;
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

//        foreach (string str in result)
//        {
//            Console.WriteLine(str);
//        }
//    }
//}

//// Time : O(2^2n) , space : O(2n)