
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
//    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
//    {
//        if (headA == null || headB == null)
//        {
//            return null;
//        }

//        int len1 = GetLength(headA);
//        int len2 = GetLength(headB);

//        ListNode tempA = headA;
//        ListNode tempB = headB;

//        if (len1 != len2)
//        {
//            int diff = Math.Abs(len1 - len2);

//            if (len1 > len2)
//            {
//                for (int i = 0; i < diff; i++)
//                {
//                    tempA = tempA.next;
//                }
//            }
//            else
//            {
//                for (int i = 0; i < diff; i++)
//                {
//                    tempB = tempB.next;
//                }
//            }
//        }

//        while (tempA != null && tempB != null)
//        {
//            if (tempA == tempB)
//            {
//                return tempA;
//            }
//            tempA = tempA.next;
//            tempB = tempB.next;
//        }
//        return null;
//    }

//    private int GetLength(ListNode head)
//    {
//        ListNode temp = head;
//        int count = 0;

//        while (temp != null)
//        {
//            count++;
//            temp = temp.next;
//        }
//        return count;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        ListNode headA = new ListNode(4);
//        headA.next = new ListNode(1);
//        headA.next.next = new ListNode(8);
//        headA.next.next.next = new ListNode(4);
//        headA.next.next.next.next = new ListNode(5);

//        ListNode headB = new ListNode(5);
//        headB.next = new ListNode(6);
//        headB.next.next = new ListNode(1);
//        headB.next.next.next = new ListNode(8);
//        headB.next.next.next.next = new ListNode(4);
//        headB.next.next.next.next.next = new ListNode(5);

//        headB.next.next.next = headA.next.next;

//        ListNode result = s.GetIntersectionNode(headA, headB);

//        Console.WriteLine($"{result.val}" + " ");
//    }
//}


//// Time : O(n), space :O(1)