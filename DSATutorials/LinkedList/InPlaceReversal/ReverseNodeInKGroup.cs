
//public class ListNode
//{
//    public int val;
//    public ListNode next;
//    public ListNode(int data, ListNode node = null)
//    {
//        val = data;
//        next = node;
//    }
//}

//class Solution
//{
//    public ListNode ReverseKGroup(ListNode head, int k)
//    {
//        // base case
//        if (head == null || head.next == null || k < 2)
//        {
//            return head;
//        }

//        // creating a dummy node with head as its next node
//        ListNode dummy = new ListNode(0, head);
//        ListNode temp = head, prev = dummy;

//        // Time : O(n/k) , temp iterates over n nodes in k interval
//        while (temp != null)
//        {
//            // Time : O(n/k) * O(k) = O(k)
//            ListNode kthNode = GetKthNode(k, temp);

//            if (kthNode == null)
//            {
//                break;
//            }
//            ListNode nextNodeTok = kthNode.next;

//             // Time : O(n/k) * O(k) = O(k)
//            // Reverse the list till kthNode
//            ReverseNode(kthNode, temp);

//            // Adjust prev and next nodes
//            prev.next = kthNode;
//            temp.next = nextNodeTok;

//            // Adjust pointers
//            prev = temp;
//            temp = nextNodeTok;
//        }

//        return dummy.next;
//    }

//    private ListNode GetKthNode(int k, ListNode temp)
//    {
//        ListNode node = temp;

//        while (node != null && k > 1)
//        {
//            node = node.next;
//            k--;
//        }
//        return node;
//    }

//    private void ReverseNode(ListNode tailNode, ListNode currentNode)
//    {
//        ListNode end = tailNode, curr = currentNode, prev = null;

//        while (prev != end)
//        {
//            ListNode next = curr.next;
//            curr.next = prev;
//            prev = curr;
//            curr = next;
//        }
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

//        ListNode result = s.ReverseKGroup(head, 2);

//        while (result != null)
//        {
//            Console.Write($"{result.val}" + " ");
//            result = result.next;
//        }
//    }
//}


//// Time : O(n) , space : O(1)