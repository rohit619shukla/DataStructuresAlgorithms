
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
//    public void ReorderList(ListNode head)
//    {
//        if (head == null || head.next == null)
//        {
//            return;
//        }

//        // PartitionList
//        ListNode slow = head;
//        ListNode fast = head;

//        while (fast != null && fast.next != null)
//        {
//            slow = slow.next;
//            fast = fast.next.next;
//        }

//        ListNode p = head;
//        ListNode q = ReverseList(slow.next);
//        slow.next = null;

//        // Merge list
//        ListNode temp = p;
//        p = p.next;

//        bool flag = true;

//        while (p != null && q != null)
//        {
//            if (flag)
//            {
//                temp.next = q;
//                temp = q;
//                q = q.next;
//                flag = !flag;
//            }
//            else
//            {
//                temp.next = p;
//                temp = p;
//                p = p.next;
//                flag = !flag;
//            }
//        }

//        if (q == null)
//        {
//            temp.next = p;
//        }
//        if (p == null)
//        {
//            temp.next = q;
//        }

//    }

//    private ListNode ReverseList(ListNode node)
//    {
//        if (node == null)
//        {
//            return null;
//        }
//        ListNode prev = null;
//        ListNode curr = node;
//        ListNode next = node.next;

//        while (next != null)
//        {
//            curr.next = prev;
//            prev = curr;
//            curr = next;
//            next = next.next;
//        }
//        curr.next = prev;
//        node = curr;

//        return node;
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
//        //head.next.next.next.next = new ListNode(5);

//        s.ReorderList(head);

//        while (head != null)
//        {
//            Console.Write($"{head.val}" + " ");
//            head = head.next;
//        }
//    }
//}

//// Time : O(n), space :O(1)