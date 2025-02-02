
//public class Node
//{
//    public int val;
//    public Node next;
//    public Node random;

//    public Node(int _val)
//    {
//        val = _val;
//    }
//}

//public class Solution
//{
//    public Node CopyRandomList(Node head)
//    {
//        if (head == null)
//        {
//            return null;
//        }

//        // 1. Create  a clone node right next to each original node
//        Node temp = head;
//        while (temp != null)
//        {
//            Node n = new Node(temp.val);
//            n.next = temp.next;
//            temp.next = n;
//            temp = temp.next.next;
//        }

//        // 2. Assign random pointers for cloned node
//        Node temp2 = head;
//        while (temp2 != null)
//        {
//            temp2.next.random = temp2.random?.next;
//            temp2 = temp2.next.next;
//        }

//        Node originalHead = head;
//        Node copyHead = head.next;
//        Node clone = copyHead;

//        // 3. segregate the clone list
//        while (originalHead != null)
//        {
//            originalHead.next = originalHead.next.next;
//            copyHead.next = copyHead.next?.next;

//            originalHead = originalHead.next;
//            copyHead = copyHead.next;
//        }

//        return clone;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution r = new Solution();

//        Node head = null;

//        head = new Node(1);
//        head.next = new Node(2);
//        head.next.next = new Node(3);
//        head.next.next.next = new Node(4);
//        head.next.next.next.next = new Node(5);
//        head.next.next.next.next.next = new Node(6);

//        // 1's random points to 3
//        head.random = head.next.next;

//        // 2's random points to 1
//        head.next.random = head;

//        //// 3's and 4's random points to 5
//        head.next.next.random = head.next.next.next.next;
//        head.next.next.next.random = head.next.next.next.next;

//        //// 5's random points to 2
//        //head.next.next.next.next.random = head.next;

//        Node result = r.CopyRandomList(head);

//        while (result != null)
//        {
//            Console.WriteLine($"{result.val}" + " ");
//            result = result.next;
//        }
//    }
//}

//// Time : O(n) , space : (n) , auxillary is O(1) as we dont use any new DS : as we create a new list with n nodes