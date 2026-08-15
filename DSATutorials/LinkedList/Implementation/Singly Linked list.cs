
//class Node
//{
//    public int data;
//    public Node next;

//    public Node(int val)
//    {
//        data = val;  
//    }
//}

//class SinglyLinkedlist
//{
//    Node head;    /* head pointer */

//    public Node CreateNode(int data)
//    {
//        Node n = new Node();
//        n.data = data;
//        n.next = null;

//        return n;
//    }

//    public void InsertNodeAtEnd(int data)
//    {
//        if (head == null)
//        {
//            head = CreateNode(data);
//        }
//        else
//        {
//            Node temp = head;
//            while (temp.next != null)
//            {
//                temp = temp.next;
//            }

//            temp.next = CreateNode(data);
//        }
//    }

//    public void InsertNodeAtFront(int data)
//    {
//        if (head == null)
//        {
//            head = CreateNode(data);
//        }
//        else
//        {
//            Node n = CreateNode(data);
//            n.next = head;
//            head = n;
//        }
//    }

//    public void PrintList()
//    {
//        if (head == null)
//        {
//            Console.WriteLine("Nothing to print");
//            return;
//        }
//        else
//        {
//            Node temp = head;

//            while (temp.next != null)
//            {
//                Console.Write($"{temp.data}" + " ");
//                temp = temp.next;
//            }
//            Console.Write($"{temp.data}" + " ");
//        }
//    }

//    public void RemoveNodeFromLast()
//    {
//        if (head == null)
//        {
//            Console.WriteLine("Nothing to remove");
//            return;
//        }
//        else if (head.next == null)
//        {
//            Console.WriteLine($"only 1 node remained and now removed from list : {head.data}");
//            head = null;
//        }
//        else
//        {
//            Node prev = null;
//            Node temp = head;

//            while (temp.next != null)
//            {
//                prev = temp;
//                temp = temp.next;
//            }
//            prev.next = null;
//            Console.WriteLine($"Node removed from list is : {temp.data}");
//        }
//    }

//    public void RemoveNodeFromFront()
//    {
//        if (head == null)
//        {
//            Console.WriteLine("Notgin to remove");
//            return;
//        }
//        else if (head.next == null)
//        {
//            Console.WriteLine($"only 1 node remained and now removed from list : {head.data}");
//            head = null;
//        }
//        else
//        {
//            Console.WriteLine($"Node removed from list is :{head.data}");
//            head = head.next;
//        }
//    }

//    public void ReverseList()
//    {
//        Node prev = null;
//        Node curr = head;
//        Node next = curr.next;

//        while (next != null)
//        {
//            curr.next = prev;
//            prev = curr;
//            curr = next;
//            next = next.next;
//        }
//        curr.next = prev;
//        head = curr;

//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        SinglyLinkedlist s = new SinglyLinkedlist();

//        s.InsertNodeAtEnd(2);
//        s.InsertNodeAtEnd(19);
//        s.InsertNodeAtEnd(20);
//        s.InsertNodeAtEnd(5);
//        s.InsertNodeAtEnd(56);
//        s.InsertNodeAtEnd(22);

//        s.PrintList();
//        //Console.WriteLine();
//        //s.RemoveNodeFromLast();

//        //Console.WriteLine();	
//        //s.RemoveNodeFromFront();
//        //s.PrintList();
//        Console.WriteLine();
//        s.InsertNodeAtFront(47);
//        s.PrintList();

//        Console.WriteLine();
//        s.ReverseList();
//        s.PrintList();

//    }
//}