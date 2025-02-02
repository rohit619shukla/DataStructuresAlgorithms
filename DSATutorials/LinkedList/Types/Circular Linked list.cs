

//class Node
//{
//    public int val;
//    public Node next;

//    public Node(int data)
//    {
//        val = data;
//    }
//}
//class Solution
//{
//    public Node InsertNodeAtLast(int val, Node head)
//    {
//        Node n = new Node(val);

//        if (head == null)
//        {
//            head = n;
//            head.next = head;
//        }
//        else
//        {
//            Node temp = head;
//            while (temp.next != head)
//            {
//                temp = temp.next;
//            }
//            temp.next = n;
//            n.next = head;
//        }

//        return head;
//    }

//    public Node InsertNodeAtFirst(int val, Node head)
//    {
//        Node n = new Node(val);

//        if (head == null)
//        {
//            head = n;
//            head.next = head;
//        }
//        else
//        {
//            Node temp = head;

//            while (temp.next != head)
//            {
//                temp = temp.next;
//            }

//            n.next = head;
//            temp.next = n;
//            head = n;
//        }

//        return head;
//    }

//    public void PrintList(Node head)
//    {
//        Node temp = head;

//        while (temp.next != head)
//        {
//            Console.Write($"{temp.val}" + " ");
//            temp = temp.next;
//        }
//        Console.Write($"{temp.val}" + " ");
//    }

//    public Node RemoveNodeFromLast(Node head)
//    {
//        if (head.next == head)
//        {
//            return null;
//        }
//        else
//        {
//            Node temp = head;
//            Node prev = null;

//            while (temp.next != head)
//            {
//                prev = temp;
//                temp = temp.next;
//            }
//            prev.next = head;
//            temp = null;

//            return head;
//        }

//    }

//    public Node RemoveNodeFromFront(Node head)
//    {
//        if (head == null)
//        {
//            return null;
//        }

//        if (head.next == head)
//        {
//            return null;
//        }
//        else
//        {
//            Node temp = head;

//            while (temp.next != head)
//            {
//                temp = temp.next;
//            }

//            head = head.next;
//            temp.next = head;

//            return head;
//        }

//    }

//    public Node ReverseList(Node head)
//    {
//        if (head == null)
//        {
//            return null;
//        }

//        Node prev = null;
//        Node curr = head;
//        Node next = head.next;

//        while (next.next != head)
//        {
//            curr.next = prev;
//            prev = curr;
//            curr = next;
//            next = next.next;
//        }
//        curr.next = prev;
//        next.next = curr;
//        head.next = next;
//        head = next;

//        return head;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        Node head = null;
//        head = s.InsertNodeAtLast(10, head);
//        head = s.InsertNodeAtLast(20, head);
//        head = s.InsertNodeAtLast(30, head);
//        head = s.InsertNodeAtLast(40, head);
//        head = s.InsertNodeAtLast(50, head);

//        s.PrintList(head);
//        Console.WriteLine();

//        head = s.InsertNodeAtFirst(60, head);
//        head = s.InsertNodeAtFirst(70, head);
//        head = s.InsertNodeAtFirst(80, head);

//        s.PrintList(head);
//        Console.WriteLine();

//        head = s.RemoveNodeFromLast(head);

//        s.PrintList(head);
//        Console.WriteLine();

//        head = s.RemoveNodeFromLast(head);

//        s.PrintList(head);
//        Console.WriteLine();

//        head = s.RemoveNodeFromFront(head);

//        s.PrintList(head);
//        Console.WriteLine();

//        head = s.RemoveNodeFromFront(head);

//        s.PrintList(head);
//        Console.WriteLine();

//        head = s.ReverseList(head);
//        s.PrintList(head);
//        Console.WriteLine();

//        head = s.ReverseList(head);
//        s.PrintList(head);
//        Console.WriteLine();
//    }
//}