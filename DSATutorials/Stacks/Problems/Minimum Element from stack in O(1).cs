
//public class MinStack
//{
//    public Stack<long> st;
//    public int min;
//    public MinStack()
//    {
//        st = new Stack<long>();
//    }

//    public void Push(int val)
//    {
//        if (st.Count == 0)
//        {
//            st.Push(val);
//            min = val;
//        }
//        else
//        {
//            if (min < val)
//            {
//                st.Push(val);
//            }
//            else
//            {
//                st.Push(2L * val - min);
//                min = val;
//            }
//        }
//    }

//    public void Pop()
//    {
//        long top = st.Peek();
//        if (top < min)
//        {
//            min = (int)(2L * min - top);
//        }
//        st.Pop();
//    }

//    public int Top()
//    {
//        long top = st.Peek();
//        if (top < min) return min;
//        else return (int)top;
//    }

//    public int GetMin()
//    {
//        return min;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        MinStack obj = new MinStack();
//        obj.Push(-2);
//        obj.Push(0);
//        obj.Push(-3);
//        Console.WriteLine($"Min element from stack is: {obj.GetMin()}");
//        obj.Pop();
//        Console.WriteLine($"Top element in stack is: {obj.Top()}");
//        Console.WriteLine($"Min element from stack is: {obj.GetMin()}");
//    }
//}

//// Time : O(1) for all operations, Space : O(n)