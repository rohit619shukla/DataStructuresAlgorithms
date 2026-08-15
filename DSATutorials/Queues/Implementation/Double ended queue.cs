//using System;

//class Helper
//{
//    public int[] N;
//    public int front;
//    public int rear;
//    public int max;

//    public Helper(int size)
//    {
//        max = size;
//        N = new int[size];
//        front = rear = -1;
//    }

//    public void EnqueueFront(int num)
//    {
//        if (front == -1 && rear == -1)
//        {
//            front = rear = 0;
//            N[front] = num;
//        }
//        else if (front == 0)
//        {
//            front = max - 1;
//            N[front] = num;
//        }
//        else if ((rear + 1) % max == front)
//        {
//            Console.WriteLine("Queue is full");
//            return;
//        }
//        else
//        {
//            front--;
//            N[front] = num;
//        }
//        Console.WriteLine($"Node inserted is :{N[front]}");
//    }

//    public void DequeueFront()
//    {
//        if (front == -1 && rear == -1)
//        {
//            Console.WriteLine("Queue is empty");
//        }
//        else if (front == max - 1)
//        {
//            Console.WriteLine($"Node removed from queue is : {N[front]}");
//            front = 0;
//        }
//        else if (front == rear)
//        {
//            Console.WriteLine($"Node removed from queue is : {N[front]}");
//            front = rear = -1;
//        }
//        else
//        {
//            Console.WriteLine($"Node removed from queue is : {N[front]}");
//            front++;
//        }
//    }

//    public void EnqueueRear(int num)
//    {
//        /* Queue is empty */
//        if (front == -1 && rear == -1)
//        {
//            front = rear = 0;
//            N[rear] = num;
//            Console.WriteLine($"Element inserted is : {N[rear]}");
//        }
//        else if ((rear + 1) % max == front)
//        {
//            Console.WriteLine("Queue is full");
//        }
//        else if (rear == max - 1)
//        {
//            rear = 0;
//            N[rear] = num;
//            Console.WriteLine($"Element inserted is :{N[rear]}");
//        }
//        else
//        {
//            rear++;
//            N[rear] = num;
//            Console.WriteLine($"Element inserted is : {N[rear]}");
//        }
//    }

//    public void DequeueRear()
//    {
//        if (front == -1 && rear == -1)
//        {
//            Console.WriteLine("Queue is empty");
//            return;
//        }
//        else if (rear == 0)
//        {
//            Console.WriteLine($"Node deleted is :{N[rear]}");
//            rear = max - 1;
//        }
//        else if (rear == front)
//        {
//            Console.WriteLine($"Node deleted is :{N[rear]}");
//            front = rear = -1;
//        }
//        else
//        {
//            Console.WriteLine($"Node deleted is :{N[rear]}");
//            rear--;
//        }
//    }

//    public void Display()
//    {
//        if (front == -1 && rear == -1)
//        {
//            Console.WriteLine("Queue is empty");
//        }
//        else
//        {
//            int i = front;
//            while (i != rear)
//            {
//                Console.Write($"{N[i]}" + " ");
//                i = (i + 1) % max;
//            }
//            Console.Write($"{N[i]}");
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper(5);

//        h.EnqueueRear(5);
//        h.EnqueueRear(20);
//        h.EnqueueRear(31);
//        h.EnqueueRear(10);
//        h.EnqueueRear(11);
//        h.EnqueueRear(12);

//        h.DequeueFront();
//        h.EnqueueRear(12);
//        h.EnqueueRear(13);

//        Console.WriteLine("Node in queue are :");
//        h.Display();

//        Console.WriteLine();
//        h.DequeueFront();
//        h.DequeueFront();
//        h.DequeueFront();
//        h.DequeueFront();
//        h.DequeueFront();

//        h.Display();
//        Console.WriteLine();
//        h.EnqueueFront(1);
//        h.EnqueueFront(4);
//        h.EnqueueFront(10);
//        h.EnqueueFront(29);
//        h.EnqueueFront(33);
//        h.EnqueueFront(8);

//        h.DequeueRear();
//        h.DequeueRear();
//        h.DequeueRear();
//        h.DequeueRear();
//        h.DequeueRear();
//        h.DequeueRear();
//    }
//}