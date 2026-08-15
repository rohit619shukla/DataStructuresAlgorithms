
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
//    public bool IsPalindrome(ListNode head)
//    {
//        // If the list is empty
//        if (head == null)
//        {
//            return false;
//        }

//        // If the list is only containing 1 node
//        if (head.next == null)
//        {
//            return true;
//        }

//        ListNode slow = head;
//        ListNode fast = head;

//        while (fast != null && fast.next != null)
//        {
//            slow = slow.next;
//            fast = fast.next.next;
//        }

//        ListNode l1 = head;
//        ListNode l2 = ReverseList(slow);
//        slow.next = null;

//        while (l1 != null && l2 != null)
//        {
//            if (l1.val != l2.val)
//            {
//                return false;
//            }
//            l1 = l1.next;
//            l2 = l2.next;
//        }

//        return true;
//    }

//    private ListNode ReverseList(ListNode head)
//    {
//        ListNode prev = null;
//        ListNode curr = head;
//        ListNode next = curr.next;

//        while (next != null)
//        {
//            curr.next = prev;
//            prev = curr;
//            curr = next;
//            next = next.next;
//        }
//        curr.next = prev;
//        head = curr;

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
//        head.next.next.next = new ListNode(3);
//        head.next.next.next.next = new ListNode(2);
//        head.next.next.next.next.next = new ListNode(1);

//        Console.WriteLine(s.IsPalindrome(head));
//    }
//}

//// Time : O(n) , space : O(1)