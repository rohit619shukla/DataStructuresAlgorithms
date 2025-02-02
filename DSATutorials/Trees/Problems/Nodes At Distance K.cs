//// Leetcode 863. (Medium)
//class Solution
//{
//    public IList<int> DistanceK(TNode root, TNode target, int k)
//    {
//        Dictionary<TNode, TNode> map = new Dictionary<TNode, TNode>();

//        // Map containing parent child relation
//        ParentChildMap(root, map);

//        // result
//        List<int> resultList = new List<int>();

//        // visited list
//        HashSet<TNode> visited = new HashSet<TNode>();

//        visited.Add(target);

//        // start BFS
//        Queue<TNode> q = new Queue<TNode>();

//        // Enter target Node at start node
//        q.Enqueue(target);

//        int count = 0;
//        while (q.Count != 0)
//        {
//            int currentLevelCount = q.Count;

//            if (count == k)
//            {
//                break;
//            }

//            for (int i = 0; i < currentLevelCount; i++)
//            {
//                // We will iterate in all 3 directions : left, right and upwards

//                TNode temp = q.Dequeue();

//                // Get left Node and insert in queue if not visited
//                if (temp.left != null && !visited.Contains(temp.left))
//                {
//                    visited.Add(temp.left);
//                    q.Enqueue(temp.left);
//                }

//                // Get right Node and insert in queue if not visited
//                if (temp.right != null && !visited.Contains(temp.right))
//                {
//                    visited.Add(temp.right);
//                    q.Enqueue(temp.right);
//                }

//                // Get upward Node and insert in queue if not visited
//                if (map[temp] != null && !visited.Contains(map[temp]))
//                {
//                    visited.Add(map[temp]);
//                    q.Enqueue(map[temp]);
//                }
//            }

//            count++;
//        }


//        while (q.Count != 0)
//        {
//            TNode temp = q.Dequeue();
//            resultList.Add(temp.data);
//        }
//        return resultList;
//    }

//    private void ParentChildMap(TNode root, Dictionary<TNode, TNode> map)
//    {
//        Queue<TNode> q = new Queue<TNode>();

//        q.Enqueue(root);

//        map[root] = null;
//        while (q.Count != 0)
//        {
//            TNode temp = q.Dequeue();

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
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        TNode root = new TNode(3);
//        root.left = new TNode(5);
//        root.right = new TNode(1);
//        root.left.left = new TNode(6);
//        root.left.right = new TNode(2);
//        root.left.right.left = new TNode(7);
//        root.left.right.right = new TNode(4);
//        root.right.left = new TNode(0);
//        root.right.right = new TNode(8);

//        var result = s.DistanceK(root, root.left, 2);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}


//// Time : O(N), space : O(N)