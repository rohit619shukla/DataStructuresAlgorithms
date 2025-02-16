//public class Solution
//{
//    // Time  : O(n) , space :O(n)
//    public string RemoveDuplicates(string str)
//    {
//        Stack<char> st = new Stack<char>();

//        foreach (char ch in str)
//        {
//            if (st.Count > 0 && st.Peek() == ch)
//            {
//                st.Pop();
//            }
//            else
//            {
//                st.Push(ch);
//            }
//        }

//        char[] chr = new char[st.Count];
//        int index = chr.Length;

//        while (st.Count > 0)
//        {
//            chr[--index] = st.Pop();
//        }

//        return new string(chr);
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "azxxzy";

//        Solution s = new Solution();

//        Console.WriteLine(s.RemoveDuplicates(str));
//    }
//}