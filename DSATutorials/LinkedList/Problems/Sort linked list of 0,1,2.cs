
//class Node
//{
//    public int data;
//    public Node next;

//    public Node(int val)
//    {
//        data = val;
//    }
//}
//class Solution
//{
//    public Node SortList(Node head)
//    {
//        // temproray list which will be storing head
//        Node temp0 = new Node(-1);
//        Node temp1 = new Node(-1);
//        Node temp2 = new Node(-1);

//        // temproray list which will be going till tail
//        Node n0 = temp0;
//        Node n1 = temp1;
//        Node n2 = temp2;

//        // to traverse
//        Node temp = head;

//        while (temp != null)
//        {
//            switch (temp.data)
//            {
//                case 0:
//                    n0.next = temp;
//                    n0 = n0.next;
//                    break;

//                case 1:
//                    n1.next = temp;
//                    n1 = n1.next;
//                    break;

//                case 2:
//                    n2.next = temp;
//                    n2 = n2.next;
//                    break;
//            }
//            temp = temp.next;
//        }

//        n0.next = temp1.next;
//        n1.next = temp2.next;
//        n2.next = null;

//        head = temp0.next;
//        return head;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();
//        Node head = new Node(1);
//        head.next = new Node(2);
//        head.next.next = new Node(0);
//        head.next.next.next = new Node(0);
//        head.next.next.next.next = new Node(1);
//        head.next.next.next.next.next = new Node(2);
//        head.next.next.next.next.next.next = new Node(1);
//        head.next.next.next.next.next.next.next = new Node(2);
//        head.next.next.next.next.next.next.next.next = new Node(1);

//        head = s.SortList(head);

//        Node temp = head;
//        while (temp != null)
//        {
//            Console.Write($"{temp.data}" + " ");
//            temp = temp.next;
//        }
//    }
//}

// Time : O(n) , space : O(1)