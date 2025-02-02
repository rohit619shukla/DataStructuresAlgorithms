

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
//    public Node NthNode(Node head, int key)
//    {
//        // List is empty
//        if (head == null)
//        {
//            return null;
//        }

//        // Only node in list but key asked is bigger
//        if (head.next == null && key > 1)
//        {
//            return null;
//        }

//        Node fast = head;

//        // Stop fast till it is going greater than key
//        for (int i = 0; i < key; i++)
//        {
//            if (fast == null)
//            {
//                Console.WriteLine("Value of key is bigger than nodes");
//                return null;
//            }
//            fast = fast.next;
//        }

//        Node slow = head;

//        // Move both slow and fast at same pace, but in reality slow will be moving behind
//        while (fast != null)
//        {
//            slow = slow.next;
//            fast = fast.next;
//        }

//        return slow;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        Node head = new Node(1);
//        head.next = new Node(2);
//        head.next.next = new Node(3);
//        head.next.next.next = new Node(4);

//        Node result = s.NthNode(head, 3);

//        Console.WriteLine($"{result.val}");
//    }
//}

//// Time : O(n) , space : O(1)