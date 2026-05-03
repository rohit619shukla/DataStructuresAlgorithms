//using System;

//class Helper
//{
//    // Time : O(N) , sapce : O(N) in worst case of skewed
//    public bool AreTreeIdentical(TNode root1, TNode root2)
//    {
//        if (root1 == null || root2 == null)
//        {
//            return (root1 == root2);  // Check if both of them are null or either of them is null
//        }

//        return (root1.data == root2.data) &&
//            AreTreeIdentical(root1.left, root2.left)
//            && AreTreeIdentical(root1.right, root2.right);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root1 = new TNode(1);
//        root1.left = new TNode(2);
//        root1.right = new TNode(3);
//        root1.left.left = new TNode(4);
//        root1.left.right = new TNode(5);

//        TNode root2 = new TNode(1);
//        root2.left = new TNode(2);
//        root2.right = new TNode(3);
//        root2.left.left = new TNode(4);
//        root2.left.right = new TNode(6);

//        Console.WriteLine($"{h.AreTreeIdentical(root1, root2)}");
//    }
//}

