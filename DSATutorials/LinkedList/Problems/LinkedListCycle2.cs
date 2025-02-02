
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
//    public ListNode DetectCycle(ListNode head)
//    {
//        if (head == null || head.next == null)
//        {
//            return null;
//        }

//        ListNode slow = head, fast = head;

//        while (fast != null && fast.next != null)
//        {
//            slow = slow.next;
//            fast = fast.next.next;

//            // Cycle detected
//            if (slow == fast)
//            {
//                ListNode temp = head;
//                // get the start node
//                while (temp != slow)
//                {
//                    temp = temp.next;
//                    slow = slow.next;
//                }
//                return slow;
//            }
//        }
//        return null;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        ListNode head = new ListNode(1);
//        head.next = new ListNode(2);
//        //head.next.next = new ListNode(0);
//        //head.next.next.next = new ListNode(4);

//        //head.next.next.next.next = head.next;
//        head.next.next = head;

//        ListNode result = s.DetectCycle(head);

//        Console.WriteLine($"{result.val}" + " ");
//    }
//}

//// Time : O(n) , space :(1) , fast, slow and temp visit each nodes atmost once only