
//class Solution
//{
//    public int Solve(TNode root)
//    {
//        Queue<(TNode, int)> q = new Queue<(TNode, int)>();

//        q.Enqueue((root, 0));

//        int maxPath = int.MinValue;

//        // start levelorder traversal
//        while (q.Count > 0)
//        {
//            int levelCount = q.Count;

//            int leftMostDist = -1;
//            int rightMostDist = -1;

//            for (int i = 0; i < levelCount; i++)
//            {
//                (TNode currentNode, int dist) = q.Dequeue();

//                if (i == 0)
//                {
//                    leftMostDist = dist;
//                }

//                if (i == levelCount - 1)
//                {
//                    rightMostDist = dist;
//                }

//                if (currentNode.left != null)
//                {
//                    q.Enqueue((currentNode.left, 2 * dist + 1));
//                }

//                if (currentNode.right != null)
//                {
//                    q.Enqueue((currentNode.right, 2 * dist + 2));
//                }
//            }

//            // (We add 1 here because diff between 2 numbers [8..12] = 12-8+1 = 5 => 8,9,10,11,12)
//            maxPath = Math.Max(maxPath, rightMostDist - leftMostDist + 1);
//        }

//        return maxPath;

//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution h = new Solution();

//        TNode root = new TNode(1);

//        root.left = new TNode(3);
//        root.right = new TNode(2);
//        root.left.left = new TNode(5);
//        root.left.left.left = new TNode(6);
//        root.right.right = new TNode(9);
//        root.right.right.left = new TNode(7);

//        Console.WriteLine(h.Solve(root));
//    }
//}

//// Time : O(N) , space : O(N)