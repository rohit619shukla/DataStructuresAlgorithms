
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
//    public ListNode OddEvenList(ListNode head)
//    {
//        if (head == null)
//        {
//            return null;
//        }

//        ListNode listA = head;
//        ListNode listB = head.next;
//        ListNode newListB = listB;

//        while (newListB != null && newListB.next != null)
//        {
//            listA.next = listA.next?.next;
//            newListB.next = newListB.next?.next;

//            listA = listA.next;
//            newListB = newListB.next;
//        }

//        listA.next = listB;
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
//        head.next.next.next = new ListNode(4);
//        head.next.next.next.next = new ListNode(5);
//        head.next.next.next.next.next = new ListNode(6);
//        head.next.next.next.next.next.next = new ListNode(7);
//        head.next.next.next.next.next.next.next = new ListNode(8);

//        ListNode result = s.OddEvenList(head);

//        while (result != null)
//        {
//            Console.Write($"{result.val}" + " ");
//            result = result.next;
//        }
//    }
//}

///* Complexity : O(n) , space : O(1) */