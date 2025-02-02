
//using System;

//class Helper
//{
//    public void BoundaryTraversal(TNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Console.Write($"{root.data}" + " ");

//        PrintLeftSide(root.left);

//        PrintLeaf(root.left);
//        PrintLeaf(root.right);

//        PrintRightSide(root.right);
//    }

//    /// <summary>
//    /// Print left side of tree first
//    /// </summary>
//    /// <param name="root"></param>
//    public void PrintLeftSide(TNode root)
//    {
//        if (root != null)
//        {
//            if (root.left != null)
//            {
//                Console.Write($"{root.data}" + " ");
//                PrintLeftSide(root.left);
//            }
//            else if (root.right != null)
//            {
//                Console.Write($"{root.data}" + " ");
//                PrintLeftSide(root.right);
//            }
//        }
//    }

//    /// <summary>
//    /// Print leaf for leaf part
//    /// </summary>
//    public void PrintLeaf(TNode root)
//    {
//        if (root != null)
//        {
//            PrintLeaf(root.left);
//            PrintLeaf(root.right);

//            if ((root.left == null) && (root.right == null))
//            {
//                Console.Write($"{root.data}" + " ");
//            }

//        }

//    }

//    public void PrintRightSide(TNode root)
//    {
//        if (root != null)
//        {
//            if (root.right != null)
//            {
//                Console.Write($"{root.data}" + " ");
//                PrintRightSide(root.right);
//            }
//            else if (root.left != null)
//            {
//                Console.Write($"{root.data}" + " ");
//                PrintRightSide(root.left);
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        TNode root = new TNode(20);
//        root.left = new TNode(8);
//        root.left.left = new TNode(4);
//        root.left.right = new TNode(12);
//        root.left.right.left = new TNode(10);
//        root.left.right.right = new TNode(14);
//        root.right = new TNode(22);
//        root.right.right = new TNode(25);

//        Helper h = new Helper();
//        h.BoundaryTraversal(root);
//    }
//}

//// Complexity : O(N), space : O(N)