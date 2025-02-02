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
//    public void PrintList(Node head)
//    {
//        if (head == null)
//        {
//            return;
//        }
//        else
//        {
//            Node temp = head;
//            while (temp != null)
//            {
//                Console.Write($"{temp.data}" + " ");
//                temp = temp.next;
//            }
//        }
//    }

//    public Node SwapNodes(Node head)
//    {
//        if (head == null)
//        {
//            return null;
//        }
//        else
//        {
//            Node temp = head;

//            while (temp != null && temp.next != null)
//            {
//                int k = temp.data;
//                temp.data = temp.next.data;
//                temp.next.data = k;

//                temp = temp.next.next;
//            }
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

//        Console.WriteLine("List before swapping is :");
//        h.PrintList(head);

//        head = h.SwapNodes(head);
//        Console.WriteLine();
//        Console.WriteLine("List After swapping is :");
//        h.PrintList(head);

//    }
//}

///* Complexity : O(n) and space : O(1) */