

//class Helper
//{

//    // Time  : O(N), space : O(N)
//    public void Solve(TNode root)
//    {
//        Queue<TNode> q = new Queue<TNode>();

//        IList<IList<int>> resultList = new List<IList<int>>();

//        q.Enqueue(root);

//        while (q.Count != 0)
//        {
//            int levelCount = q.Count;

//            List<int> currentList = new List<int>();

//            for (int i = 0; i < levelCount; i++)
//            {
//                TNode node = q.Dequeue();

//                currentList.Add(node.data);

//                if (node.left != null)
//                {
//                    q.Enqueue(node.left);
//                }

//                if (node.right != null)
//                {
//                    q.Enqueue(node.right);
//                }
//            }

//            resultList.Add(currentList);
//        }

//        foreach (var item in resultList)
//        {
//            foreach (var item1 in item)
//            {
//                Console.Write($"{item1}" + " ");
//            }

//            Console.WriteLine();
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

//        h.Solve(root);
//    }
//}