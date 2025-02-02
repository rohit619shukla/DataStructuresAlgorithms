
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

//        // First node in sequence
//        if (head == null)
//        {
//            head = n;
//            head.prev = head;
//            head.next = head;
//        }
//        else
//        {
//            Node tail = head.prev;  // Tail node
//            tail.next = n;
//            n.prev = tail;
//            n.next = head;
//            head.prev = n;
//        }

//        return head;
//    }

//    public Node InsertNodeAtFirst(int val, Node head)
//    {
//        Node n = new Node(val);
//        // First node in sequence
//        if (head == null)
//        {
//            head = n;
//            head.prev = head;
//            head.next = head;
//        }
//        else
//        {
//            Node tail = head.prev;
//            n.next = head;
//            n.prev = head.prev;
//            tail.next = n;
//            head.prev = n;
//            head = n;
//        }
//        return head;
//    }

//    public Node RemoveFirstNode(Node head)
//    {
//        // If its the only node
//        if (head.next == head)
//        {
//            return null;
//        }
//        else
//        {
//            Node temp = head;
//            Node tail = head.prev;
//            Node newHead = head.next;
//            tail.next = newHead;
//            newHead.prev = tail;
//            temp = null; //removing all references of old head
//            head = newHead;

//            return head;
//        }
//    }

//    public Node RemoveNodeLast(Node head)
//    {
//        if (head.next == head)
//        {
//            return null;
//        }
//        else
//        {
//            Node tail = head.prev;
//            tail.prev.next = head;
//            head.prev = tail.prev;
//            tail = null;

//            return head;
//        }
//    }

//    public Node ReverseList(Node head)
//    {
//        Node curr = head;
//        Node next = head.next;

//        while (next.next != head)
//        {
//            Swap(curr);
//            curr = next;
//            next = next.next;
//        }
//        Swap(curr);
//        Swap(next);

//        head = next;
//        return head;
//    }

//    private void Swap(Node n)
//    {
//        Node temp = n.prev;
//        n.prev = n.next;
//        n.next = temp;
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

//        s.PrintList(head);
//        Console.WriteLine();

//        head = s.InsertNodeAtFirst(60, head);
//        head = s.InsertNodeAtFirst(70, head);
//        head = s.InsertNodeAtFirst(80, head);

//        s.PrintList(head);
//        Console.WriteLine();

//        head = s.RemoveFirstNode(head);
//        s.PrintList(head);
//        Console.WriteLine();

//        head = s.RemoveFirstNode(head);
//        s.PrintList(head);
//        Console.WriteLine();

//        //head = s.RemoveNodeLast(head);
//        //s.PrintList(head);
//        //Console.WriteLine();

//        //head = s.RemoveNodeLast(head);
//        //s.PrintList(head);
//        //Console.WriteLine();

//        head = s.ReverseList(head);
//        s.PrintList(head);
//        Console.WriteLine();

//    }
//}