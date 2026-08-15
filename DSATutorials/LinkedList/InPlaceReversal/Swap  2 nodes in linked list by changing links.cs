
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
//    public Node SwapNodes(Node head, int n1, int n2)
//    {
//        if (head == null)
//        {
//            return null;
//        }

//        // Get location for first node
//        Node prev1 = null;
//        Node curr1 = head;

//        while (curr1 != null)
//        {
//            if (curr1.val == n1)
//            {
//                break;
//            }
//            prev1 = curr1;
//            curr1 = curr1.next;
//        }

//        // Get location for second node
//        Node prev2 = null;
//        Node curr2 = head;

//        while (curr2 != null)
//        {
//            if (curr2.val == n2)
//            {
//                break;
//            }
//            prev2 = curr2;
//            curr2 = curr2.next;
//        }

//        // Adjust heads node
//        // Means curr1 is the start node
//        if (prev1 == null)
//        {
//            head = curr2;
//        }
//        else
//        {
//            prev1.next = curr2;
//        }

//        // Means curr1 is the start node
//        if (prev2 == null)
//        {
//            head = curr1;
//        }
//        else
//        {
//            prev2.next = curr1;
//        }

//        // Swap next values of the nodes
//        Node temp = curr1.next;
//        curr1.next = curr2.next;
//        curr2.next = temp;

//        return head;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution h = new Solution();
//        Node head = new Node(10);
//        head.next = new Node(20);
//        head.next.next = new Node(30);
//        head.next.next.next = new Node(40);
//        head.next.next.next.next = new Node(50);
//        head.next.next.next.next.next = new Node(60);
//        head.next.next.next.next.next.next = new Node(70);

//        Node result = h.SwapNodes(head, 10, 60);
//        while (result != null)
//        {
//            Console.Write($"{result.val}" + " ");
//            result = result.next;
//        }
//    }
//}

//// Time : O(n) , space :O(1)