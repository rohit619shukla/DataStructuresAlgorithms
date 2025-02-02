
//class Node
//{
//    public Node next;
//    public int val;

//    public Node(int data)
//    {
//        val = data;
//    }
//}

//class Solution
//{
//    private Node front, rear;
//    public void Enqueue(int val)
//    {
//        Node n = new Node(val);

//        if (front == null && rear == null)
//        {
//            front = rear = n;
//        }
//        else
//        {
//            rear.next = n;
//            rear = n;
//        }
//    }

//    public void Display()
//    {
//        if (front == null)
//        {
//            Console.WriteLine("Empty");
//            return;
//        }

//        Node temp = front;
//        while (temp != null)
//        {
//            Console.Write($"{temp.val}" + " ");
//            temp = temp.next;
//        }
//    }

//    public int Dequeue()
//    {
//        if (front == null && rear == null)
//        {
//            Console.WriteLine("Queue is empty");
//        }

//        int result = front.val;
//        if (front == rear)
//        {
//            Console.WriteLine($"Node deleted is: {front.val}");
//            front = rear = null;
//        }
//        else
//        {
//            result = front.val;
//            Console.WriteLine($"Node deleted is: {front.val}");
//            front = front.next;
//        }
//        return result;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        s.Enqueue(10);
//        s.Enqueue(20);
//        s.Enqueue(30);

//        s.Display();

//        s.Dequeue();
//        s.Dequeue();

//        s.Display();
//    }
//}