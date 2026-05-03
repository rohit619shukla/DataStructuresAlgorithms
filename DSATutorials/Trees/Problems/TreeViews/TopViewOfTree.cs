

//class Helper
//{
//    // Time : O(n) , space : (n)
//    public void Solve(TNode root)
//    {
//        Queue<KeyValuePair<TNode, int>> q = new Queue<KeyValuePair<TNode, int>>();

//        q.Enqueue(new KeyValuePair<TNode, int>(root, 0));

//        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();


//        int min = int.MaxValue;
//        int max = int.MinValue;

//        while (q.Count != 0)
//        {
//            var node = q.Dequeue();
//            TNode temp = node.Key;
//            int dist = node.Value;

//            if (map.ContainsKey(dist))
//            {
//                map[dist].Add(temp.data);
//            }
//            else
//            {
//                map.Add(dist, new List<int> { temp.data });
//            }

//            if (temp.left != null)
//            {
//                q.Enqueue(new KeyValuePair<TNode, int>(temp.left, dist - 1));
//            }

//            if (temp.right != null)
//            {
//                q.Enqueue(new KeyValuePair<TNode, int>(temp.right, dist + 1));
//            }

//            min = Math.Min(min, dist);
//            max = Math.Max(max, dist);

//        }

//        for (int i = min; i <= max; i++)
//        {
//            var temp = map[i];

//            foreach (var item in temp)
//            {
//                Console.Write($"{item}" + " ");
//                break;
//            }
//        }
//    }
//}

//class Prorgam
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = new TNode(1);
//        root.left = new TNode(2);
//        root.right = new TNode(3);
//        root.left.right = new TNode(4);
//        root.left.right.right = new TNode(5);
//        root.left.right.right.right = new TNode(6);

//        h.Solve(root);
//    }
//}