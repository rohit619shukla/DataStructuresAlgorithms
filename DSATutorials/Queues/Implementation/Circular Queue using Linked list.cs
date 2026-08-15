//using System;
//using System.Collections;

//class Node
//{
//    public int data;
//    public Node next;

//    public Node(int num)
//    {
//        data = num;
//        next = null;
//    }
//}

//class Helper
//{
//    Node front = null, rear = null;
//    public void Enqueue(int num)
//    {
//        Node n = new Node(num);

//        /* Queue is empty */
//        if (front == null && rear == null)
//        {
//            front = rear = n;
//            rear.next = front;
//        }
//        else
//        {
//            /* Insert node from rear end */
//            rear.next = n;
//            n.next = front;
//            rear = rear.next;
//        }
//    }

//    public void Display()
//    {
//        if (front == null && rear == null)
//        {
//            return;
//        }
//        else
//        {
//            Node f = front;

//            while (f.next != front)
//            {
//                Console.Write($"{f.data}" + " ");
//                f = f.next;
//            }
//            Console.Write($"{f.data}" + " ");
//        }
//    }

//    public void Dequeue()
//    {
//        if (front == null && rear == null)
//        {
//            return;
//        }
//        else if (front == rear)
//        {
//            front = rear = null;
//        }
//        else
//        {
//            front = front.next;
//            rear.next = front;
//        }
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();
//        h.Enqueue(34);
//        h.Enqueue(33);
//        h.Enqueue(22);
//        h.Enqueue(76);
//        h.Enqueue(32);

//        h.Display();

//        h.Dequeue();
//    }
//}