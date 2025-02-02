
//public class Node
//{
//    public int val;
//    public Node next;

//    public Node(int data)
//    {
//        val = data;
//    }
//}
//public class Solution
//{
//    public void OddEvenList(Node head)
//    {
//        if (head == null)
//        {
//            Console.WriteLine("odd");
//            return;
//        }

//        Node fast = head;

//        while (fast != null && fast.next != null)
//        {
//            fast = fast.next.next;
//        }

//        if (fast == null)
//        {
//            Console.WriteLine("even");
//        }
//        else
//        {
//            Console.WriteLine("odd");
//        }
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        Node head = new Node(1);
//        head.next = new Node(2);
//        head.next.next = new Node(3);
//        head.next.next.next = new Node(4);
//        head.next.next.next.next = new Node(5);
//        head.next.next.next.next.next = new Node(6);

//        s.OddEvenList(head);
//    }
//}

//// Time : O(n) , space : O(1)