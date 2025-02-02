
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
//    public ListNode MiddleNode(ListNode head)
//    {
//        if (head == null)
//        {
//            return null;
//        }

//        ListNode slow = head, fast = head;

//        while (fast != null && fast.next != null)
//        {
//            slow = slow.next;
//            fast = fast.next.next;
//        }

//        return slow;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        ListNode head = new ListNode(1);
//        head.next = new ListNode(2);
//        head.next.next = new ListNode(3);
//        head.next.next.next = new ListNode(4);
//        head.next.next.next.next = new ListNode(5);
//        head.next.next.next.next.next = new ListNode(6);

//        ListNode result = s.MiddleNode(head);

//        Console.WriteLine($"{result.val}" + " ");
//    }
//}

//// Time : O(n), space :O(1)