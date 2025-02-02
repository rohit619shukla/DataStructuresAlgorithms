

//public class MyQueue
//{
//    private Stack<int> inStack;
//    private Stack<int> outStack;
//    private int top;
//    public MyQueue()
//    {
//        inStack = new Stack<int>();
//        outStack = new Stack<int>();
//    }

//    public void Push(int x)
//    {
//        if (inStack.Count == 0)
//        {
//            top = x;
//        }
//        inStack.Push(x);
//    }

//    public int Pop()
//    {
//        if (outStack.Count == 0)
//        {
//            while (inStack.Count > 0)
//            {
//                outStack.Push(inStack.Pop());
//            }
//        }

//        return outStack.Pop();
//    }

//    public int Peek()
//    {
//        return outStack.Count == 0 ? top : outStack.Peek();
//    }

//    public bool Empty()
//    {
//        return outStack.Count == 0 && inStack.Count == 0;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        MyQueue myQueue = new MyQueue();
//        myQueue.Push(1);
//        myQueue.Push(2);
//        Console.WriteLine(myQueue.Peek());
//        Console.WriteLine(myQueue.Pop());
//        Console.WriteLine(myQueue.Empty());
//    }
//}

//// Note : InStack will be used primarily for Push and Top and Outstack for Pop and peek
//// Time :
//// Push : O(1)
//// Pop : O(1) amortized majority of the time pop will result in O(1) time and only in some cases it will be O(n), hence amortized is O(1)
//// Peek() : O(1)
//// Empty : O(1)