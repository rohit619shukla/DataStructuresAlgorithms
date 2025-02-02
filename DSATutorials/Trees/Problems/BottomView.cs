
//class Solution
//{
//    public void Solve(TNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        // To store co-ordinates with the co-ordinates and node at those co-ordinates
//        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

//        // For BFS , storing node and its co-ordinates
//        Queue<(TNode, int)> q = new Queue<(TNode, int)>();

//        q.Enqueue((root, 0));

//        int minValue = int.MaxValue;
//        int maxValue = int.MinValue;

//        // Add initial node to the queue
//        while (q.Count > 0)
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

//            minValue = Math.Min(minValue, dist);
//            maxValue = Math.Max(maxValue, dist);
//        }


//        for (int i = minValue; i <= maxValue; i++)
//        {
//            List<int> currentValues = map[i];

//            Console.Write($"{currentValues[currentValues.Count - 1]}" + " ");
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        TNode root = new TNode(20);
//        root.left = new TNode(8);
//        root.right = new TNode(22);
//        root.left.left = new TNode(5);
//        root.left.right = new TNode(3);
//        root.right.left = new TNode(4);
//        root.right.right = new TNode(25);
//        root.left.right.left = new TNode(10);
//        root.left.right.right = new TNode(14);

//        Solution h = new Solution();
//        h.Solve(root);
//    }
//}

//// Time : O(N), space : O(N)