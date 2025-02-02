
//class Helper
//{
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

//    public void PreOrder(TNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Console.Write($"{root.data}" + " ");
//        PreOrder(root.left);
//        PreOrder(root.right);
//    }

//    public void PostOrder(TNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        PostOrder(root.left);
//        PostOrder(root.right);
//        Console.Write($"{root.data}" + " ");
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

//        Console.WriteLine("Inorder :");
//        h.Inorder(root);

//        Console.WriteLine("\nPreOrder :");
//        h.PreOrder(root);

//        Console.WriteLine("\nPostOrder :");
//        h.PostOrder(root);
//    }
//}

//// Complexity : O(N), space : O(N)  (The function visits each node exactly once)