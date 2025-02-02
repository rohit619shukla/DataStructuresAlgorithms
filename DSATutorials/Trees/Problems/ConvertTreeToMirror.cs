//using System;
//using System.Collections.Generic;
//class Helper
//{
//    //public void ConvertToMirror(TNode root)
//    //{
//    //    if (root == null)
//    //    {
//    //        return;
//    //    }

//    //    Queue<TNode> q = new Queue<TNode>();
//    //    q.Enqueue(root);

//    //    while (q.Count != 0)
//    //    {
//    //        TNode temp = q.Dequeue();

//    //        SwapNodes(temp);

//    //        if (temp.left != null)
//    //        {
//    //            q.Enqueue(temp.left);
//    //        }

//    //        if (temp.right != null)
//    //        {
//    //            q.Enqueue(temp.right);
//    //        }
//    //    }

//    //    PreOrder(root);
//    //}

//    public void ConvertToMirror(TNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        ConvertToMirror(root.left);
//        ConvertToMirror(root.right);
//        SwapNodes(root);
//    }

//    private void SwapNodes(TNode root)
//    {
//        TNode temp = root.left;
//        root.left = root.right;
//        root.right = temp;
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
//}
//class Program
//{
//    public static void Main()
//    {
//        TNode root = new TNode(1);
//        root.left = new TNode(2);
//        root.right = new TNode(3);
//        root.left.left = new TNode(4);
//        root.left.right = new TNode(5);

//        Helper h = new Helper();
//        h.ConvertToMirror(root);
//        h.PreOrder(root);
//    }
//}

//// Complexity : O(N)