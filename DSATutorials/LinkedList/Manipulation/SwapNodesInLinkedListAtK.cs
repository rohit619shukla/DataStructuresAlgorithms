
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
//    public ListNode SwapNodes(ListNode head, int k)
//    {
//        if (head == null)
//        {
//            return null;
//        }

//        ListNode fast = head;

//        // 1. Move the fast pointer till k places
//        for (int i = 1; i < k; i++)
//        {
//            fast = fast.next;
//        }

//        // Use two pointers to run
//        ListNode temp = fast, slow = head;
//        while (temp.next != null)
//        {
//            slow = slow.next;
//            temp = temp.next;
//        }

//        // Slow will cross fast, then swap them
//        int swap = slow.val;
//        slow.val = fast.val;
//        fast.val = swap;

//        return head;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        //ListNode head = new ListNode(1);
//        //head.next = new ListNode(2);
//        //head.next.next = new ListNode(3);
//        //head.next.next.next = new ListNode(4);
//        //head.next.next.next.next = new ListNode(5);

//        ListNode head = new ListNode(7);
//        head.next = new ListNode(9);
//        head.next.next = new ListNode(6);
//        head.next.next.next = new ListNode(6);
//        head.next.next.next.next = new ListNode(7);
//        head.next.next.next.next.next = new ListNode(8);
//        head.next.next.next.next.next.next = new ListNode(3);
//        head.next.next.next.next.next.next.next = new ListNode(0);
//        head.next.next.next.next.next.next.next.next = new ListNode(9);
//        head.next.next.next.next.next.next.next.next.next = new ListNode(5);

//        ListNode result = s.SwapNodes(head, 5);

//        while (result != null)
//        {
//            Console.Write($"{result.val}" + " ");
//            result = result.next;
//        }
//    }
//}

//// Time  :O(n) , Space :O(1)