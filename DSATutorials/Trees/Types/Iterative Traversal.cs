//class Helper
//{
//    public void Inorder(TNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Stack<TNode> st = new Stack<TNode>();

//        TNode head = root;

//        while (true)
//        {
//            while (head != null)
//            {
//                st.Push(head);
//                head = head.left;
//            }

//            if (st.Count == 0)
//            {
//                return;
//            }

//            head = st.Pop();
//            Console.Write($"{head.data}" + " ");
//            head = head.right;
//        }
//    }

//    public void PreOrder(TNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Stack<TNode> st = new Stack<TNode>();
//        TNode head = root;

//        while (true)
//        {
//            while (head != null)
//            {
//                st.Push(head);
//                Console.Write($"{head.data}" + " ");
//                head = head.left;
//            }

//            if (st.Count == 0)
//            {
//                return;
//            }

//            head = st.Pop();
//            head = head.right;
//        }
//    }

//    public void PostOrder(TNode root)
//    {
//        Stack<TNode> st = new Stack<TNode>();

//        TNode head = root;
//        TNode prev = null;

//        st.Push(head);
//        head = head.left;

//        while (st.Count != 0)
//        {
//            while (head != null)
//            {
//                st.Push(head);
//                head = head.left;
//            }

//            while (head == null && st.Count != 0)
//            {
//                head = st.Peek();
//                if (head.right == null || head.right == prev)
//                {
//                    st.Pop();
//                    Console.Write($"{head.data}" + " ");
//                    prev = head;
//                    head = null;
//                }
//                else
//                {
//                    head = head.right;
//                }
//            }
//        }
//    }

//    public void LevelOrder(TNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Queue<TNode> q = new Queue<TNode>();
//        q.Enqueue(root);

//        while (q.Count != 0)
//        {
//            TNode node = q.Dequeue();
//            Console.Write($"{node.data}" + " ");

//            if (node.left != null)
//            {
//                q.Enqueue(node.left);
//            }

//            if (node.right != null)
//            {
//                q.Enqueue(node.right);
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = null;
//        root = new TNode(1);
//        root.left = new TNode(2);
//        root.right = new TNode(3);
//        root.left.left = new TNode(4);
//        root.left.right = new TNode(5);

//        Console.WriteLine("Inroder:");
//        h.Inorder(root);

//        Console.WriteLine("\nPreOrder:");
//        h.PreOrder(root);

//        Console.WriteLine("\nPostOrder:");
//        h.PostOrder(root);

//        Console.WriteLine("\nLevelOrder:");
//        h.LevelOrder(root);
//    }
//}