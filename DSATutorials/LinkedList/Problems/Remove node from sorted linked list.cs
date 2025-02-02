

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
//    public Node RemoveFromSorted(Node head)
//    {
//        if (head == null)
//        {
//            return null;
//        }

//        Node slow = head;
//        Node fast = head.next;

//        while (fast != null)
//        {
//            if (slow.val == fast.val)
//            {
//                fast = fast.next;
//            }
//            else
//            {
//                slow.next = fast;
//                slow = fast;
//                fast = fast.next;
//            }
//        }
//        slow.next = fast;
//        return head;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        Node head = null;
//        head = new Node(1);
//        head.next = new Node(1);
//        head.next.next = new Node(2);
//        head.next.next.next = new Node(3);
//        head.next.next.next.next = new Node(3);

//        //Node head = null;
//        //head = new Node(1);
//        //head.next = new Node(1);
//        //head.next.next = new Node(2);

//        Node result = s.RemoveFromSorted(head);

//        while (result != null)
//        {
//            Console.Write($"{result.val}" + " ");
//            result = result.next;
//        }
//    }
//}

//// Time : O(n) , space : O(1)