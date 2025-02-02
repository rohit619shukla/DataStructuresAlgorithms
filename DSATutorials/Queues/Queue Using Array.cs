
//class Solution
//{
//    private int[] arr;
//    private int size;
//    private int rear;
//    private int front;

//    public Solution(int max)
//    {
//        size = max;
//        arr = new int[max];
//        front = rear = -1;
//    }
//    public void Display()
//    {
//        if (front == -1 && rear == -1)
//        {
//            return;
//        }
//        for (int i = front; i < rear; i++)
//        {
//            Console.Write($"{arr[i]}" + " ");
//        }
//    }

//    public void Enqueue(int val)
//    {
//        // queue is overflow
//        if (rear == size)
//        {
//            Console.WriteLine("overflow");
//            return;
//        }
//        // currently empty
//        else if (front == -1 && rear == -1)
//        {
//            front = rear = 0;
//        }
//        arr[rear] = val;
//        rear++;
//    }

//    public void Dequeue()
//    {
//        // Queue is empty
//        if (front == -1 && rear == -1)
//        {
//            Console.WriteLine("Nothing to delete");
//            return;
//        }
//        else if (front == rear)
//        {
//            Console.WriteLine($"Element removed is: {arr[front]}");
//            front = rear = -1;
//        }
//        else
//        {
//            Console.WriteLine($"Element removed is: {arr[front]}");
//            front++;
//        }
//    }

//    public void Peek()
//    {
//        if (front == -1 && rear == -1)
//        {
//            Console.WriteLine("Nothing to peek");
//            return;
//        }

//        Console.WriteLine($"Peek element is: {arr[front]}");
//    }
//}
//class Program
//{
//    public static void Main()
//    {

//        Solution h = new Solution(5);
//        h.Display();

//        h.Enqueue(20);
//        h.Enqueue(30);
//        h.Enqueue(40);
//        h.Enqueue(50);
//        h.Enqueue(60);

//        // print Queue elements
//        h.Display();

//        // insert element in the queue
//        h.Enqueue(60);

//        h.Dequeue();
//        h.Dequeue();
//        Console.Write("\n\nafter two node deletion\n\n");

//        // print Queue elements
//        h.Display();

//        // print front of the queue
//        h.Peek();
//    }
//}