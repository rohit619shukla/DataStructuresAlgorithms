
//class Node
//{
//    public int data;
//    public Node next;

//    public Node(int val)
//    {
//        data = val;
//    }
//}

//class Helper
//{


//    public Node SwapAdjacentNodes(Node head)
//    {
//        if (head == null)
//        {
//            return null;
//        }

//        Node prev = null, curr = head;

//        // Handle even and odd ll
//        while (curr != null && curr.next != null)
//        {
//            Node temp = curr.next;
//            curr.next = temp.next;
//            temp.next = curr;

//            if (prev == null)
//            {
//                head = temp;
//            }
//            else
//            {
//                prev.next = temp;
//            }
//            prev = curr;
//            curr = curr.next;
//        }
//        return head;
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();
//        Node head = new Node(1);
//        head.next = new Node(2);
//        head.next.next = new Node(3);
//        head.next.next.next = new Node(4);
//        head.next.next.next.next = new Node(5);
//        head.next.next.next.next.next = new Node(6);
//        head.next.next.next.next.next.next = new Node(7);


//        Node result = h.SwapAdjacentNodes(head);

//        while (result != null)
//        {
//            Console.Write($"{result.data}" + " ");

//            result = result.next;
//        }
//    }
//}

///* O(N) and O(1) */