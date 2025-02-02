
//public class ListNode
//{
//    public int val;
//    public ListNode next;
//    public ListNode(int val = 0, ListNode next = null)
//    {
//        this.val = val;
//        this.next = next;
//    }
//}
//public class Solution
//{
//    public ListNode Partition(ListNode head, int x)
//    {
//        if (head == null || head.next == null)
//        {
//            return head;
//        }

//        ListNode temp = head;
//        ListNode dummy1 = new ListNode(0);
//        ListNode dummy2 = new ListNode(0);

//        ListNode l1 = dummy1;
//        ListNode l2 = dummy2;

//        while (temp != null)
//        {
//            if (temp.val < x)
//            {
//                l1.next = temp;
//                l1 = l1.next;
//            }
//            else
//            {
//                l2.next = temp;
//                l2 = l2.next;
//            }
//            temp = temp.next;
//        }

//        l1.next = dummy2.next;
//        l2.next = null;
//        head = dummy1.next;

//        return head;
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
//        head.next.next.next = new ListNode(2);
//        head.next.next.next.next = new ListNode(5);
//        head.next.next.next.next.next = new ListNode(2);

//        ListNode result = s.Partition(head, 6);

//        while (result != null)
//        {
//            Console.Write($"{result.val}" + " ");
//            result = result.next;
//        }
//    }
//}

//// Time : O(n) , space :O(1)