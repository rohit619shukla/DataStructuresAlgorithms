
//class Helper
//{
//    public void Solve(TNode root)
//    {
//        Queue<(TNode, int)> q = new Queue<(TNode, int)>();

//        // Add root node to map with default distance
//        q.Enqueue((root, 0));

//        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

//        int min = int.MaxValue;
//        int max = int.MinValue;

//        while (q.Count != 0)
//        {
//            (TNode node, int dist) = q.Dequeue();

//            if (map.ContainsKey(dist))
//            {
//                map[dist].Add(node.data);
//            }
//            else
//            {
//                map.Add(dist, new List<int> { node.data });
//            }
//            if (node.left != null)
//            {
//                q.Enqueue((node.left, dist - 1));
//            }

//            if (node.right != null)
//            {
//                q.Enqueue((node.right, dist + 1));
//            }

//            min = Math.Min(min, dist);
//            max = Math.Max(max, dist);
//        }

//        for (int i = min; i <= max; i++)
//        {

//            foreach (var x in map[i])
//            {
//                Console.Write($"{x}" + " ");
//            }

//            Console.WriteLine();
//        }
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
//        root.right.left = new TNode(6);
//        root.right.right = new TNode(7);
//        root.right.left.right = new TNode(8);
//        root.right.right.right = new TNode(9);


//        Helper h = new Helper();
//        h.Solve(root);
//    }
//}

//// Time : O(n) , space : O(n)