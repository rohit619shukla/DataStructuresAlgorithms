
//class Node
//{
//    public int val;
//    public Node next;

//    public Node(int data)
//    {
//        val = data;
//    }
//}
//class Solution
//{
//    public Node RemoveDuplicteNodes(Node head)
//    {
//        if (head == null)
//        {
//            return null;
//        }

//        if (head.next == null)
//        {
//            return head;
//        }
//        HashSet<int> set = new HashSet<int>();

//        set.Add(head.val);
//        Node prev = head, curr = head;

//        while (curr != null)
//        {
//            if (!set.Contains(curr.val))
//            {
//                set.Add(curr.val);
//                prev.next = curr;
//                prev = curr;
//            }
//            curr = curr.next;
//        }
//        prev.next = null;
//        return head;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        Node head = null;

//        //head = new Node(12);
//        //head.next = new Node(11);
//        //head.next.next = new Node(12);
//        //head.next.next.next = new Node(21);
//        //head.next.next.next.next = new Node(41);
//        //head.next.next.next.next.next = new Node(43);
//        //head.next.next.next.next.next.next = new Node(21);

//        head = new Node(1);
//        head.next = new Node(2);
//        head.next.next = new Node(3);
//        head.next.next.next = new Node(2);
//        head.next.next.next.next = new Node(4);


//        Node result = s.RemoveDuplicteNodes(head);

//        while (result != null)
//        {
//            Console.Write($"{result.val}" + " ");
//            result = result.next;
//        }
//    }
//}

//// Time : O(n) , space :O(n)