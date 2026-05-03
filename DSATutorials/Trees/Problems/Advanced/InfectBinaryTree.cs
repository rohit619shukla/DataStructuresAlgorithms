


//class Solution
//{
//    public int AmountOfTime(TNode root, int start)
//    {
//        // Create parent child map
//        Dictionary<TNode, TNode> map = new Dictionary<TNode, TNode>();

//        // the parent of root is always null
//        map[root] = null;

//        // Peform bfs to fill map
//        Queue<TNode> q = new Queue<TNode>();

//        q.Enqueue(root);

//        TNode infectedNode = null;

//        while (q.Count > 0)
//        {
//            TNode temp = q.Dequeue();

//            // We need to actually see if the node even exist or not
//            if (temp.data == start)
//            {
//                infectedNode = temp;
//            }

//            if (temp.left != null)
//            {
//                map[temp.left] = temp;
//                q.Enqueue(temp.left);
//            }

//            if (temp.right != null)
//            {
//                map[temp.right] = temp;
//                q.Enqueue(temp.right);
//            }
//        }

//        int count = 0;

//        if (infectedNode != null)
//        {

//            // Infected or not set to check
//            HashSet<int> set = new HashSet<int>();

//            set.Add(infectedNode.data);

//            // Perform 3 directional BFS
//            q.Enqueue(infectedNode);

//            while (q.Count > 0)
//            {
//                int levelCount = q.Count;

//                for (int i = 0; i < levelCount; i++)
//                {
//                    TNode temp = q.Dequeue();

//                    if (temp.left != null && !set.Contains(temp.left.data))
//                    {
//                        set.Add(temp.left.data);  // mark it as infected
//                        q.Enqueue(temp.left);
//                    }

//                    if (temp.right != null && !set.Contains(temp.right.data))
//                    {
//                        set.Add(temp.right.data);
//                        q.Enqueue(temp.right);
//                    }

//                    if (map[temp] != null && !set.Contains(map[temp].data))
//                    {
//                        set.Add(map[temp].data);
//                        q.Enqueue(map[temp]);
//                    }
//                }
//                count++;
//            }
//        }

//        return count - 1;

//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        TNode root = new TNode(1);
//        root.left = new TNode(5);
//        root.right = new TNode(3);
//        root.left.right = new TNode(4);
//        root.left.right.left = new TNode(9);
//        root.left.right.right = new TNode(2);
//        root.right.left = new TNode(10);
//        root.right.right = new TNode(6);

//        Console.WriteLine(s.AmountOfTime(root, 1));

//    }
//}

//// Time : O(N), space : O(N)

//// idea : Basically it is just a 3 directional BFS, where we just create a Parent child map and use that map to traverse a nodes adjcent neighbors in 3 direction.
//// Similar to BFS , once each level completes we increase infection count.