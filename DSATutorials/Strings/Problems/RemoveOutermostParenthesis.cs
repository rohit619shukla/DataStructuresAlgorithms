//using System.Text;

//public class Solution
//{

//    // Time : O(n) , space :O(n)
//    public string RemoveOuterParentheses(string s)
//    {
//        StringBuilder result = new StringBuilder();
//        Stack<char> stack = new Stack<char>();

//        foreach (char c in s)
//        {
//            if (c == ')')
//            {
//                stack.Pop(); // Pop before appending to check outermost ')'
//            }

//            if (stack.Count > 0)
//            {
//                result.Append(c); // Append only if stack is not empty
//            }

//            if (c == '(')
//            {
//                stack.Push(c); // Push after appending to check outermost '('
//            }
//        }

//        return result.ToString();
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        string str = "(()())(())";

//        Solution s = new Solution();

//        Console.WriteLine(s.RemoveOuterParentheses(str));
//    }
//}