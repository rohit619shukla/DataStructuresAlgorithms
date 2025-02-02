
//public class Solution
//{
//    public bool IsValid(string str)
//    {
//        if (str.Length == 0)
//        {
//            return false;
//        }

//        // Create stack to store all open braces
//        Stack<char> st = new Stack<char>();


//        // Now iterate over all char in string
//        for (int i = 0; i < str.Length; i++)
//        {
//            // Evenrything been good so far but to continue lets add 
//            if (st.Count == 0)
//            {
//                st.Push(str[i]);
//                continue;
//            }

//            char ch = str[i];

//            // For all chars which are closing
//            switch (ch)
//            {
//                case ')':
//                    if (st.Peek() == '(')
//                    {
//                        st.Pop();
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                    break;

//                case ']':
//                    if (st.Peek() == '[')
//                    {
//                        st.Pop();
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                    break;

//                case '}':
//                    if (st.Peek() == '{')
//                    {
//                        st.Pop();
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                    break;

//                default:
//                    //anything that is not part of original closed list
//                    st.Push(str[i]);
//                    break;
//            }

//        }
//        // We never got them removed
//        if (st.Count != 0)
//        {
//            return false;
//        }
//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "(){}}{";

//        Solution s = new Solution();

//        Console.WriteLine(s.IsValid(str));
//    }
//}