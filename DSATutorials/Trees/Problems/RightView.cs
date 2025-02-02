


//class Helper
//{
//    // Time : O(N), space :O(N)
//    public void Solve(TNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Queue<TNode> q = new Queue<TNode>();

//        IList<int> resultList = new List<int>();

//        q.Enqueue(root);

//        while (q.Count != 0)
//        {
//            int levelCount = q.Count;

//            for (int i = 0; i < levelCount; i++)
//            {
//                TNode node = q.Dequeue();

//                // If the node is the last node in the level , print it
//                if (i + 1 == levelCount)
//                {
//                    resultList.Add(node.data);
//                }

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


//        foreach (var item in resultList)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = new TNode(1);
//        root.left = new TNode(8);
//        root.left.left = new TNode(7);

//        h.Solve(root);
//    }
//}