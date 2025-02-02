
//class Node
//{
//    public int val;
//    public Node next;
//    public Node prev;

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
//        }
//        else
//        {
//            Node temp = head;

//            while (temp.next != null)
//            {
//                temp = temp.next;
//            }

//            temp.next = n;
//            n.prev = temp;
//        }

//        return head;
//    }

//    public Node InsertNodeAtFirst(int val, Node head)
//    {
//        Node n = new Node(val);
//        if (head == null)
//        {
//            head = n;
//        }
//        else
//        {
//            n.next = head;
//            head.prev = n;
//            head = n;
//        }

//        return head;
//    }

//    public Node RemoveNodeAtLast(Node head)
//    {
//        if (head == null)
//        {
//            return null;
//        }
//        else
//        {
//            Node prev = null;
//            Node curr = head;

//            while (curr.next != null)
//            {
//                prev = curr;
//                curr = curr.next;
//            }
//            prev.next = null;

//            return head;
//        }
//    }

//    public Node RemoveNodeAtFront(Node head)
//    {
//        if (head == null)
//        {
//            return null;
//        }
//        else
//        {
//            head = head.next;
//            return head;
//        }
//    }
//    public void PrintList(Node head)
//    {
//        Node temp = head;

//        while (temp != null)
//        {
//            Console.Write($"{temp.val}" + " ");
//            temp = temp.next;
//        }
//    }

//    public Node ReverseList(Node head)
//    {
//        Node curr = head;
//        Node next = head.next;
//        while (next != null)
//        {
//            Swap(curr);
//            curr = next;
//            next= next.next;
//        }
//        Swap(curr);
//        head = curr;

//        return head;
//    }

//    private void Swap(Node curr)
//    {
//        Node n = curr.prev;
//        curr.prev = curr.next;
//        curr.next = n;
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

//        s.PrintList(head);
//        Console.WriteLine();

//        head = s.RemoveNodeAtLast(head);
//        Console.WriteLine();
//        s.PrintList(head);

//        head = s.RemoveNodeAtLast(head);
//        Console.WriteLine();
//        s.PrintList(head);

//        //head = s.RemoveNodeAtFront(head);
//        //Console.WriteLine();
//        //s.PrintList(head);

//        //head = s.RemoveNodeAtFront(head);
//        //Console.WriteLine();
//        //s.PrintList(head);

//        head = s.ReverseList(head);
//        Console.WriteLine();
//        s.PrintList(head);

//        head = s.ReverseList(head);
//        Console.WriteLine();
//        s.PrintList(head);
//    }
//}