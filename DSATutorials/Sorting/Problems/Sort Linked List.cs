
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
//    public void MergeSort(ref Node head)
//    {
//        if (head == null || head.next == null)
//        {
//            return;
//        }

//        Node a = null, b = null;
//        Partition(head, ref a, ref b);
//        MergeSort(ref a);
//        MergeSort(ref b);
//        head = Merge(a, b);
//    }

//    private void Partition(Node head, ref Node a, ref Node b)
//    {
//        Node slow = head;
//        Node fast = head.next;

//        while (fast != null && fast.next != null)
//        {
//            slow = slow.next;
//            fast = fast.next.next;
//        }

//        a = head;
//        b = slow.next;
//        slow.next = null;
//    }

//    private Node Merge(Node a, Node b)
//    {
//        Node p = a;
//        Node q = b;
//        Node temp = null;

//        if (p.data > q.data)
//        {
//            temp = q;
//            q = q.next;
//        }
//        else
//        {
//            temp = p;
//            p = p.next;
//        }

//        Node final = temp;
//        while (p != null && q != null)
//        {
//            if (p.data > q.data)
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
//        Node head = new Node(1);
//        head.next = new Node(2);
//        head.next.next = new Node(3);
//        head.next.next.next = new Node(2);
//        head.next.next.next.next = new Node(1);

//        Solution s = new Solution();

//        s.MergeSort(ref head);

//        while (head != null)
//        {
//            Console.Write($"{head.data}" + " ");
//            head = head.next;
//        }
//    }
//}

//// Complexity : O(nlogn)