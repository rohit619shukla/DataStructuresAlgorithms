
//class Helper
//{

//    // Time : O(N) , space : O(N)
//    public int Solve(TNode root)
//    {
//        Queue<TNode> q = new Queue<TNode>();

//        q.Enqueue(root);

//        int max = int.MinValue;

//        while (q.Count != 0)
//        {

//            int levelCount = q.Count;

//            for (int i = 0; i < levelCount; i++)
//            {
//                TNode temp = q.Dequeue();

//                if (temp.left != null)
//                {
//                    q.Enqueue(temp.left);
//                }

//                if (temp.right != null)
//                {
//                    q.Enqueue(temp.right);
//                }
//            }

//            max = Math.Max(max, levelCount);
//        }

//        return max;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = new TNode(1);
//        root.left = new TNode(2);
//        root.right = new TNode(3);
//        root.left.left = new TNode(4);
//        root.left.left.left = new TNode(8);
//        root.left.right = new TNode(5);
//        root.right.left = new TNode(6);
//        root.right.right = new TNode(7);

//        Console.WriteLine($"{h.Solve(root)}");
//    }
//}

