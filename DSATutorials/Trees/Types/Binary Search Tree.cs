//using System;

//class Helper
//{
//    public TNode InsertNode(int key, TNode root)
//    {
//        if (root == null)
//        {
//            root = new TNode(key);
//            return root;
//        }

//        TNode head = root;
//        TNode prev = null;

//        while (head != null)
//        {
//            prev = head;

//            if (head.data > key)
//            {
//                head = head.left;
//            }
//            else
//            {
//                head = head.right;
//            }
//        }

//        if (prev.data > key)
//        {
//            prev.left = new TNode(key);
//        }
//        else
//        {
//            prev.right = new TNode(key);

//        }

//        return root;
//    }

//    public void Inorder(TNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Inorder(root.left);
//        Console.Write($"{root.data}" + " ");
//        Inorder(root.right);
//    }

//    public bool Search(TNode root, int key)
//    {
//        if (root == null)
//        {
//            return false;
//        }

//        TNode head = root;

//        while (head != null)
//        {
//            if (head.data == key)
//            {
//                return true;
//            }

//            if (head.data > key)
//            {
//                head = head.left;
//            }
//            else
//            {
//                head = head.right;
//            }
//        }

//        return false;
//    }

//    public TNode DeleteNode(TNode root, int key)
//    {
//        if (root == null)
//        {
//            return root;
//        }

//        TNode head = root;

//        // Iterate left or right subtree till node is found
//        if (head.data > key)
//        {
//            head.left = DeleteNode(head.left, key);
//        }
//        else if (head.data < key)
//        {
//            head.right = DeleteNode(head.right, key);
//        }
//        else
//        {
//            // Node found

//            // We may only have left node
//            if (head.right == null)
//            {
//                return head.left;
//            }
//            // We may only have right node
//            else if (head.left == null)
//            {
//                return head.right;
//            }
//            else
//            {
//                // Get minimum from right subtree
//                TNode min = InorderSuccessor(head.right);

//                // Copy that data onto the given node
//                head.data = min.data;

//                // Set right side now
//                head.right = DeleteNode(head.right, min.data);
//            }

//        }

//        return root;
//    }
//    private TNode InorderSuccessor(TNode root)
//    {
//        if (root == null)
//        {
//            return root;
//        }

//        TNode min = null;

//        while (root != null)
//        {
//            min = root;
//            root = root.left;
//        }
//        return min;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = null;

//        root = h.InsertNode(50, root);
//        root = h.InsertNode(30, root);
//        root = h.InsertNode(20, root);
//        root = h.InsertNode(40, root);
//        root = h.InsertNode(70, root);
//        root = h.InsertNode(60, root);
//        root = h.InsertNode(80, root);

//        Console.WriteLine("Nodes in tree are :");
//        h.Inorder(root);

//        Console.WriteLine($"\n{h.Search(root, 41)}");

//        Console.WriteLine("\n Delete node :");
//        root = h.DeleteNode(root, 21);

//        Console.WriteLine("\nNodes in tree are :");
//        h.Inorder(root);
//    }
//}

//// Complexity : O(H) : logn, and worst : O(n) : for skewed