//using System;

//class Helper
//{
//    //Since these loops are not nested(one after another), but rather executed sequentially, we consider the time complexity to be the sum of both, which is O(n) + O(n) = O(n), not O(n) * O(n).
//    public bool Solve(string exp)
//    {
//        Stack<char> stack = new Stack<char>();

//        foreach (char ch in exp)
//        {
//            if (ch == ',')
//            {
//                continue;
//            }

//            if (ch == ')')
//            {
//                HashSet<char> set = new HashSet<char>();
//                while (stack.Peek() != '(')
//                {
//                    set.Add(stack.Pop());
//                }

//                stack.Pop();

//                char currChar = stack.Pop();

//                switch (currChar)
//                {
//                    case '&':
//                        stack.Push(set.Contains('f') ? 'f' : 't');
//                        break;
//                    case '|':
//                        stack.Push(set.Contains('t') ? 't' : 'f');
//                        break;
//                    case '!':
//                        stack.Push(set.Contains('t') ? 'f' : 't');
//                        break;
//                }

//            }
//            else
//            {
//                stack.Push(ch);
//            }

//        }

//        return stack.Pop() == 't';
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "|(f,f,f,t)";

//        Helper h = new Helper();

//        Console.WriteLine(h.Solve(str));
//    }
//}