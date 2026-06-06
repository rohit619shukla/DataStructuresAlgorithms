
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

//        Inorder(root.left);
//        Console.Write($"{root.val}" + " ");
//        Inorder(root.right);
//    }

//    public void PreOrder(TreeNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Console.Write($"{root.val}" + " ");
//        PreOrder(root.left);
//        PreOrder(root.right);
//    }

//    public void PostOrder(TreeNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        PostOrder(root.left);
//        PostOrder(root.right);
//        Console.Write($"{root.val}" + " ");
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

//        Console.WriteLine("Inorder :");
//        h.Inorder(root);

//        Console.WriteLine("\nPreOrder :");
//        h.PreOrder(root);

//        Console.WriteLine("\nPostOrder :");
//        h.PostOrder(root);
//    }
//}

//// Complexity : O(N), space : O(N)  (The function visits each node exactly once)