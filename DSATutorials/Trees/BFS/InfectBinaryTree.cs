//// LeetCode 2385: Amount of Time for Binary Tree to Be Infected
//// https://leetcode.com/problems/amount-of-time-for-binary-tree-to-be-infected/
////
//// Approach: BFS with Parent Pointers (same pattern as "Nodes at Distance K")
//// - Build a parent map so we can traverse upward from any node.
//// - Locate the starting infected node during the parent-map BFS.
//// - From the infected node, do a level-by-level BFS in all 3 directions
////   (left, right, parent). Each level = 1 minute of infection spread.
//// - Total minutes = number of BFS levels - 1 (the starting node is level 0).
////
//// Time: O(N) - two BFS passes over all nodes
//// Space: O(N) - parent map + visited set + queue

//class Solution
//{
//    public int AmountOfTime(TNode root, int start)
//    {
//        // Step 1: Build parent map and locate the infected start node
//        Dictionary<TNode, TNode> map = new Dictionary<TNode, TNode>();
//        Queue<TNode> q = new Queue<TNode>();

//        q.Enqueue(root);
//        map[root] = null;

//        TNode infectedNode = null;

//        while (q.Count > 0)
//        {
//            TNode temp = q.Dequeue();

//            // Identify the start node reference while traversing
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

//        // Step 2: BFS from infected node in 3 directions (left, right, parent)
//        // Each BFS level represents 1 minute of infection spreading
//        HashSet<int> set = new HashSet<int>();
//        set.Add(infectedNode.data);
//        q.Enqueue(infectedNode);

//        int count = 0;

//        while (q.Count > 0)
//        {
//            int levelCount = q.Count;

//            for (int i = 0; i < levelCount; i++)
//            {
//                TNode temp = q.Dequeue();

//                // Expand left child
//                if (temp.left != null && !set.Contains(temp.left.data))
//                {
//                    set.Add(temp.left.data);
//                    q.Enqueue(temp.left);
//                }

//                // Expand right child
//                if (temp.right != null && !set.Contains(temp.right.data))
//                {
//                    set.Add(temp.right.data);
//                    q.Enqueue(temp.right);
//                }

//                // Expand parent (upward traversal using parent map)
//                if (map[temp] != null && !set.Contains(map[temp].data))
//                {
//                    set.Add(map[temp].data);
//                    q.Enqueue(map[temp]);
//                }
//            }
//            count++;
//        }

//        // Subtract 1 because the starting node's level doesn't count as a minute
//        return count - 1;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        //       1
//        //      / \
//        //     5   3
//        //      \ / \
//        //      4 10  6
//        //     / \
//        //    9   2
//        Solution s = new Solution();

//        TNode root = new TNode(1);
//        root.left = new TNode(5);
//        root.right = new TNode(3);
//        root.left.right = new TNode(4);
//        root.left.right.left = new TNode(9);
//        root.left.right.right = new TNode(2);
//        root.right.left = new TNode(10);
//        root.right.right = new TNode(6);

//        Console.WriteLine(s.AmountOfTime(root, 3)); // Expected: 3
//    }
//}