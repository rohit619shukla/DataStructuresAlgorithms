
//public class TreeNode
//{
//    public TreeNode left;
//    public TreeNode right;
//    public int val;

//    public TreeNode(int data)
//    {
//        val = data;
//    }
//}
//class Helper
//{
//    public void Inorder(TreeNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Stack<TreeNode> st = new Stack<TreeNode>();

//        TreeNode head = root;

//        while (true)
//        {
//            if (head != null)
//            {
//                st.Push(head);
//                head = head.left;
//            }
//            else
//            {
//                if (st.Count == 0)
//                {
//                    return;
//                }

//                head = st.Pop();
//                Console.Write($"{head.val}" + " ");
//                head = head.right;
//            }

//        }
//    }

//    public void PreOrder(TreeNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Stack<TreeNode> st = new Stack<TreeNode>();
//        TreeNode head = root;

//        while (true)
//        {
//            if (head != null)
//            {
//                st.Push(head);
//                Console.Write($"{head.val}" + " ");
//                head = head.left;
//            }
//            else
//            {
//                if (st.Count == 0)
//                {
//                    return;
//                }

//                head = st.Pop();
//                head = head.right;
//            }
//        }
//    }

//    public void PostOrder(TreeNode root)
//    {
//        Stack<TreeNode> st = new Stack<TreeNode>();

//        TreeNode head = root;
//        TreeNode prev = null;

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
//                    Console.Write($"{head.val}" + " ");
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

//    public void LevelOrder(TreeNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Queue<TreeNode> q = new Queue<TreeNode>();
//        q.Enqueue(root);

//        while (q.Count != 0)
//        {
//            int size = q.Count();

//            for (int i = 0; i < size; i++)
//            {
//                TreeNode node = q.Dequeue();

//                Console.Write($"{node.val}" + " ");
//                if (node.left != null)
//                {
//                    q.Enqueue(node.left);
//                }

//                if (node.right != null)
//                {
//                    q.Enqueue(node.right);
//                }
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TreeNode root = null;
//        root = new TreeNode(1);
//        root.left = new TreeNode(2);
//        root.right = new TreeNode(3);
//        root.left.left = new TreeNode(4);
//        root.left.right = new TreeNode(5);

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