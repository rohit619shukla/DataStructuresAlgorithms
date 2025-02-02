
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
//    // Time : O(n^2), while traversing both list in O(n) time we are also doing insertions at O(n)
//    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
//    {
//        ListNode head = null, tail = null, tailNode1 = null, tailNode2 = null;
//        int carryOver = 0;
//        int remainder = 0;
//        int currentSum = 0;
//        // Get length og list
//        int len1 = GetLength(l1);
//        int len2 = GetLength(l2);

//        ListNode temp1 = l1;
//        ListNode temp2 = l2;

//        while (temp1.next != null)
//        {
//            temp1 = temp1.next;
//        }
//        tailNode1 = temp1;

//        while (temp2.next != null)
//        {
//            temp2 = temp2.next;
//        }
//        tailNode2 = temp2;

//        // which ever is less in size add additional zeroes to accomodate
//        if (len1 != len2)
//        {
//            int additonalZeroes = Math.Abs(len1 - len2);
//            if (len2 > len1)
//            {
//                for (int i = 0; i < additonalZeroes; i++)
//                {
//                    l1 = InsertZeroNodeAtEnd(0, l1, l2, true, ref tailNode1, ref tailNode2);
//                }
//            }
//            else
//            {
//                for (int i = 0; i < additonalZeroes; i++)
//                {
//                    l2 = InsertZeroNodeAtEnd(0, l1, l2, false, ref tailNode1, ref tailNode2);
//                }
//            }
//        }

//        // Perform addition
//        while (l1 != null && l2 != null)
//        {
//            currentSum = l1.val + l2.val;
//            if (carryOver > 0)
//            {
//                currentSum += carryOver;
//            }
//            remainder = currentSum % 10;
//            carryOver = currentSum / 10;
//            head = InsertResultNodeAtEnd(remainder, head, ref tail);
//            l1 = l1.next;
//            l2 = l2.next;
//        }

//        // If any carryover is left
//        if (carryOver > 0)
//        {
//            head = InsertResultNodeAtEnd(carryOver, head, ref tail);
//        }

//        return head;
//    }

//    // Time : O(n), space : O(1)
//    private ListNode InsertZeroNodeAtEnd(int val, ListNode n1, ListNode n2, bool flag, ref ListNode tailNode1, ref ListNode tailNode2)
//    {
//        ListNode node = new ListNode(val);
//        if (flag)
//        {
//            if (n1 == null)
//            {
//                n1 = tailNode1 = node;
//            }
//            else
//            {
//                tailNode1.next = node;
//                tailNode1 = node;
//            }
//            return n1;
//        }
//        else
//        {
//            if (n2 == null)
//            {
//                n2 = tailNode2 = node;
//            }
//            else
//            {
//                tailNode2.next = node;
//                tailNode2 = node;
//            }
//            return n2;
//        }
//    }

//    private ListNode InsertResultNodeAtEnd(int val, ListNode head, ref ListNode tailNode)
//    {
//        ListNode node = new ListNode(val);

//        if (head == null)
//        {
//            head = tailNode = node;
//        }
//        else
//        {
//            tailNode.next = node;
//            tailNode = node;
//        }
//        return head;
//    }

//    // Time : O(n), space : O(1)
//    private int GetLength(ListNode node)
//    {
//        int count = 0;
//        ListNode temp = node;
//        while (temp != null)
//        {
//            temp = temp.next;
//            count++;
//        }
//        return count;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        ListNode head1 = new ListNode(9);
//        head1.next = new ListNode(9);
//        head1.next.next = new ListNode(9);
//        head1.next.next.next = new ListNode(9);
//        head1.next.next.next.next = new ListNode(9);
//        head1.next.next.next.next.next = new ListNode(9);
//        head1.next.next.next.next.next.next = new ListNode(9);

//        ListNode head2 = new ListNode(9);
//        head2.next = new ListNode(9);
//        head2.next.next = new ListNode(9);
//        head2.next.next.next = new ListNode(9);

//        ListNode result = s.AddTwoNumbers(head1, head2);

//        while (result != null)
//        {
//            Console.Write($"{result.val}" + " ");
//            result = result.next;
//        }

//    }
//}

////Time : O(n), space : O(n) for result list, auxill : O(1) no additional space used