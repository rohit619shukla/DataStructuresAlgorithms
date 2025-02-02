//using System;
//using System.Collections.Generic;
//using System.Linq;

//class StringHelper
//{
//    public void RemoveAdjacentDuplicates(string str)
//    {
//        if (string.IsNullOrWhiteSpace(str))
//        {
//            return;
//        }

//        char[] ch = { };
//        Stack<char> st = new Stack<char>();

//        char prev = ' ';

//        for (int i = 0; i < str.Length; i++)
//        {

//            if (str[i] == prev)
//            {
//                continue;
//            }
//            else if (st.Count == 0 || st.Peek() != str[i])
//            {
//                st.Push(str[i]);
//            }
//            else
//            {
//                prev = st.Peek();
//                st.Pop();
//            }
//        }

//        if (st.Count > 0)
//        {
//            ch = new char[st.Count];
//            int i = 0;
//            while (st.Count != 0)
//            {
//                ch[i] = st.Peek();
//                st.Pop();
//                i++;
//            }

//            ReverseString(ch, 0, ch.Length - 1);

//            Console.WriteLine(new String(ch));
//        }

//    }

//    private void ReverseString(char[] ch, int lb, int ub)
//    {
//        while (lb < ub)
//        {
//            char temp = ch[lb];
//            ch[lb] = ch[ub];
//            ch[ub] = temp;
//            lb++;
//            ub--;
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "acaaabbbacdddd";

//        StringHelper s = new StringHelper();
//        s.RemoveAdjacentDuplicates(str);
//    }
//}

////Complexity : O(N), space : O(N)