
//class Stack
//{
//    public int top;
//    public int[] arr;
//    public int size;

//    public Stack(int val, int len)
//    {
//        top = val;
//        size = len;
//        arr = new int[size];
//    }

//    public void Push(int data)
//    {
//        // base case
//        if (top == size - 1)
//        {
//            Console.WriteLine("stack is full");
//            return;
//        }

//        top++;
//        arr[top] = data;
//    }

//    public void PrintStack()
//    {
//        for (int i = 0; i <= top; i++)
//        {
//            Console.Write($"{arr[i]}" + " ");
//        }
//    }
//    public void Pop()
//    {
//        // base case
//        if (top == -1)
//        {
//            Console.WriteLine("stack is empty");
//            return;
//        }

//        int num = arr[top];
//        top--;

//        Console.WriteLine($"Element removed from stack is: {num}");
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Stack s = new Stack(-1, 5);

//        s.Push(1);
//        s.Push(2);
//        s.Push(3);
//        s.Push(4);
//        s.Push(5);
//        s.Push(6);

//        s.PrintStack();

//        Console.WriteLine();
//        s.Pop();
//        s.Pop();
//        s.Pop();

//        s.PrintStack();
//        s.Pop();
//        s.Pop();
//        s.Pop();
//    }
//}

//// Space: O(n) for array and Time : O(1) for push and pop 