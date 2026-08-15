
//class Node
//{
//    public int data;
//    public Node next;

//    public Node(int val)
//    {
//        data = val;
        
//    }
//}
//public class ListNode
//{
//    public int val;
//    public ListNode next;

//    public ListNode(int data)
//    {
//        val = data;
//    }
//}
//public class Solution
//{
//    public bool HasCycle(ListNode head)
//    {
//        if (head == null || head.next == null)
//        {
//            return false;
//        }

//        ListNode slow = head;
//        ListNode fast = head;

//        while (fast != null && fast.next != null)
//        {
//            slow = slow.next;
//            fast = fast.next.next;

//            if (fast == slow)
//            {
//                return true;
//            }
//        }

//        return false;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        ListNode head = new ListNode(3);
//        head.next = new ListNode(2);
//        head.next.next = new ListNode(0);
//        head.next.next.next = new ListNode(4);
//        head.next.next.next.next = head.next;

//        Console.WriteLine(s.HasCycle(head));
//    }
//}

//// Time : O(n) , space :O(1)