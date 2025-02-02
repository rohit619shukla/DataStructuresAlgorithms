
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
//    public Node head, tail;

//    // Time : O(1) , space :O(1)
//    public void Push(int val)
//    {
//        Node n = new Node(val);

//        if (head == null)
//        {
//            head = tail = n;
//        }
//        else
//        {
//            tail.next = n;
//            tail = n;
//        }

//        Console.WriteLine($"Node inserted is: {val}");
//    }

//    // Time : O(1) , space :O(1)
//    public void Pop()
//    {

//        if (head == null)
//        {
//            return;
//        }

//        Console.WriteLine($" Element removed is: {head.val}");
//        head = head.next;

//    }

//    // Time : O(n) , space :O(1)
//    public void PrintList()
//    {
//        Node temp = head;

//        while (temp != null)
//        {
//            Console.Write($"{temp.val}" + " ");
//            temp = temp.next;
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();


//        s.Push(1);
//        s.Push(2);
//        s.Push(3);
//        s.Push(4);

//        s.PrintList();

//        s.Pop();
//        s.Pop();

//    }
//}

