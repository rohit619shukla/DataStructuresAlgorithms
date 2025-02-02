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
//    public ListNode RotateRight(ListNode head, int k)
//    {
//        if (head == null || head.next == null || k == 0)
//        {
//            return head;
//        }

//        // Get the count of nodes in list along with tail Node
//        ListNode tail = head;
//        int len = 1;
//        while (tail.next != null)
//        {
//            len++;
//            tail = tail.next;
//        }


//        // We will leverage the fact that if count of nodes is same as k in terms of number or multiples then we use following formula.
//        // This helps to prevent TLE in case K is too long
//        k %= len;

//        // Link last node to head node to create circular list
//        tail.next = head;

//        // Now we will need to break circular behaviuor of list with following formula:
//        int breakPoint = len - k;

//        // start iterating
//        while (breakPoint-- > 0)
//        {
//            tail = tail.next;
//        }
//        head = tail.next;
//        tail.next = null;
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

//        ListNode result = s.RotateRight(head, 2);

//        while (result != null)
//        {
//            Console.Write($"{result.val}" + " ");
//            result = result.next;
//        }
//    }
//}

//// Time : O(n) , spacew :O(1)