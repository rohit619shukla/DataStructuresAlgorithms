
//public class MyStack
//{
//    private Queue<int> queue1;
//    private Queue<int> queue2;
//    public MyStack()
//    {
//        queue1 = new Queue<int>();
//        queue2 = new Queue<int>();
//    }

//    //public void Push(int x)
//    //{
//    //    // 1. Push to queue2
//    //    queue2.Enqueue(x);

//    //    // 2. Move lements from q1 to q2
//    //    while (queue1.Count > 0)
//    //    {
//    //        queue2.Enqueue(queue1.Dequeue());
//    //    }

//    //    // 3. Q1 should be source of truth
//    //    Queue<int> temp = queue1;
//    //    queue1 = queue2;
//    //    queue2 = temp;
//    //}

//    // Uisng 1 queue only
//    public void Push(int x)
//    {
//        queue1.Enqueue(x);

//        for (int i = 0; i < queue1.Count - 1; i++)
//        {
//            int val = queue1.Dequeue();
//            queue1.Enqueue(val);
//        }
//    }

//    public int Pop()
//    {
//        return queue1.Dequeue();
//    }

//    public int Top()
//    {
//        return queue1.Peek();
//    }

//    public bool Empty()
//    {
//        return queue1.Count == 0;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        MyStack myStack = new MyStack();

//        myStack.Push(1);
//        myStack.Push(2);
//        Console.WriteLine(myStack.Top());
//        Console.WriteLine(myStack.Pop());
//        Console.WriteLine(myStack.Empty());
//    }
//}

//// Time : O(n) for Push and O(1) for rest., space :O(n)