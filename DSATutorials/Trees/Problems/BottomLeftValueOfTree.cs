
//class Helper
//{
//    // Time : O(N), space : O(n)
//    public int Solve(TNode root)
//    {
//        Queue<TNode> q = new Queue<TNode>();

//        q.Enqueue(root);

//        int leftMostValue = -1;

//        while (q.Count != 0)
//        {
//            int levelCount = q.Count;

//            for (int i = 0; i < levelCount; i++)
//            {
//                TNode temp = q.Dequeue();

//                if (i == 0)
//                {
//                    leftMostValue = temp.data;
//                }

//                if (temp.left != null)
//                {
//                    q.Enqueue(temp.left);
//                }

//                if (temp.right != null)
//                {
//                    q.Enqueue(temp.right);
//                }
//            }
//        }

//        return leftMostValue;
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
//        root.right.left = new TNode(5);
//        root.right.right = new TNode(6);
//        root.right.left.left = new TNode(7);

//        Helper h = new Helper();

//        Console.WriteLine(h.Solve(root));
//    }
//}