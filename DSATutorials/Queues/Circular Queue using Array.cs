
//// Leetcode : 622
//public class MyCircularQueue
//{
//    private int rear, front, size;
//    private int[] arr;

//    public MyCircularQueue(int k)
//    {
//        size = k;
//        arr = new int[k];
//        front = rear = -1;
//    }

//    public bool EnQueue(int value)
//    {
//        // Queue is full
//        if ((rear + 1) % size == front)
//        {
//            return false;
//        }

//        // Queue is empty
//        if (front == -1 && rear == -1)
//        {
//            front = rear = 0;
//        }
//        else
//        {
//            rear = (rear + 1) % size;
//        }
//        arr[rear] = value;

//        return true;
//    }

//    public bool DeQueue()
//    {
//        // Queue is empty : underflow
//        if (front == -1 && rear == -1)
//        {
//            return false;
//        }

//        // Only 1 elemnt in queue
//        if (front == rear)
//        {
//            front = rear = -1;
//        }
//        else
//        {
//            front = (front + 1) % size;
//        }
//        return true;
//    }

//    public int Front()
//    {
//        // nothing in queue
//        if (front == -1)
//        {
//            return front;
//        }
//        return arr[front];
//    }

//    public int Rear()
//    {
//        // nothing in queue
//        if (rear == -1)
//        {
//            return rear;
//        }
//        return arr[rear];
//    }

//    public bool IsEmpty()
//    {
//        return front == -1 && rear == -1;
//    }

//    public bool IsFull()
//    {
//        return (rear + 1) % size == front;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        MyCircularQueue obj = new MyCircularQueue(3);

//        Console.WriteLine(obj.EnQueue(7));
//        Console.WriteLine(obj.DeQueue());
//        Console.WriteLine(obj.Front());
//        Console.WriteLine(obj.DeQueue());
//        Console.WriteLine(obj.Front());
//        Console.WriteLine(obj.Rear());
//        Console.WriteLine(obj.EnQueue(4));
//        Console.WriteLine(obj.IsFull());
//        Console.WriteLine(obj.DeQueue());
//        Console.WriteLine(obj.Rear());
//        Console.WriteLine(obj.EnQueue(3));

//    }
//}