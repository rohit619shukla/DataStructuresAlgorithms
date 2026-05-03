
//// The height of a binary tree refers to the number of vertices (nodes) in the tree from the root to the deepest node. 
//// using System;

//class Helper
//{
//    public int HeightOfBinaryTree(TNode root)
//    {
//        if (root == null)
//        {
//            return 0;
//        }

//        int leftHeight = HeightOfBinaryTree(root.left);
//        int rightHeight = HeightOfBinaryTree(root.right);

//        return Math.Max(leftHeight, rightHeight) + 1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = new TNode(1);
//        root.left = new TNode(2);
//        root.left.left = new TNode(4);
//        root.left.right = new TNode(5);
//        root.right = new TNode(3);

//        Console.WriteLine($"{h.HeightOfBinaryTree(root)}");
//    }
//}

//// Complexity : O(N), space : O(N) as we are visisting every node in the tree