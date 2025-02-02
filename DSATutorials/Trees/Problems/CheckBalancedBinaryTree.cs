//using System;

//class Helper
//{
//    // Time : O(N), space : O(N)
//    public int HeightOfTree(TNode root)
//    {
//        if (root == null)
//        {
//            return 0;
//        }

//        int leftHeight = HeightOfTree(root.left);

//        if (leftHeight == -1)
//        {
//            return -1;
//        }

//        int rightHeight = HeightOfTree(root.right);


//        if (rightHeight == -1)
//        {
//            return -1;
//        }

//        if (Math.Abs(leftHeight - rightHeight) > 1)
//        {
//            return -1;
//        }

//        return 1 + Math.Max(leftHeight, rightHeight);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = new TNode(10);
//        root.left = new TNode(5);
//        root.right = new TNode(30);
//        root.right.left = new TNode(15);
//        root.right.right = new TNode(20);

//        var result = h.HeightOfTree(root);

//        if (result == -1)
//        {
//            Console.WriteLine($"Not balanced");
//        }
//        else
//        {
//            Console.WriteLine($"Balanced: {result}");
//        }
//    }
//}

//// Complexity : O(N)