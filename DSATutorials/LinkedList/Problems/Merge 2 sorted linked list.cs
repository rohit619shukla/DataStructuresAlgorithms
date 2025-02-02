
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
//    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
//    {
//        if (list1 == null)
//        {
//            return list2;
//        }
//        else if (list2 == null)
//        {
//            return list1;
//        }

//        ListNode p = list1, q = list2;
//        ListNode temp = null;

//        //set start link based on check
//        if (p.val > q.val)
//        {
//            temp = q;
//            q = q.next;
//        }
//        else
//        {
//            temp = p;
//            p = p.next;
//        }

//        ListNode final = temp;
//        // No merge the lists
//        while (p != null && q != null)
//        {
//            if (p.val > q.val)
//            {
//                temp.next = q;
//                temp = q;
//                q = q.next;
//            }
//            else
//            {
//                temp.next = p;
//                temp = p;
//                p = p.next;
//            }
//        }

//        if (p == null)
//        {
//            temp.next = q;
//        }

//        if (q == null)
//        {
//            temp.next = p;
//        }

//        return final;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        ListNode list1 = new ListNode(1);
//        list1.next = new ListNode(2);
//        list1.next.next = new ListNode(4);

//        ListNode list2 = new ListNode(1);
//        list2.next = new ListNode(3);
//        list2.next.next = new ListNode(4);

//        ListNode result = s.MergeTwoLists(list1, list2);

//        while (result != null)
//        {
//            Console.Write($"{result.val}" + " ");
//            result = result.next;
//        }
//    }
//}

//// Time : O(n), Space : O(1)