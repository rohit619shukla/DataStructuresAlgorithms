
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
//    public void DeleteNode(ListNode node)
//    {
//        if (node == null)
//            return;

//        node.val = node.next.val;
//        node.next = node.next.next;

//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        ListNode head = new ListNode(4);
//        head.next = new ListNode(5);
//        head.next.next = new ListNode(1);
//        head.next.next.next = new ListNode(9);


//        s.DeleteNode(head.next);
//    }
//}

////Time : O(1), space : O(1)