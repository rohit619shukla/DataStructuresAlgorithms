//// LeetCode 863: All Nodes Distance K in Binary Tree
//// https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/
////
//// Approach: BFS with Parent Pointers
//// - A tree only has downward links (left/right children). To traverse upward, we first
////   build a parent map using BFS so each node knows its parent.
//// - Then starting from the target node, we do a level-by-level BFS expanding in all 3
////   directions (left child, right child, parent). After K levels, all nodes in the queue
////   are exactly at distance K.
////
//// Time: O(N) - two BFS passes over all nodes
//// Space: O(N) - parent map + visited set + queue

//public class TreeNode
//{
//    public TreeNode left;
//    public TreeNode right;
//    public int val;

//    public TreeNode(int data)
//    {
//        val = data;
//    }
//}

//public class Solution
//{
//    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
//    {
//        IList<int> result = new List<int>();

//        // Step 1: Build parent map using BFS
//        // Key insight: In a tree we can only go down (left/right), but distance K nodes
//        // can also be in the upward direction. A parent map enables upward traversal.
//        Dictionary<TreeNode, TreeNode> map = new Dictionary<TreeNode, TreeNode>();
//        Queue<TreeNode> q = new Queue<TreeNode>();

//        q.Enqueue(root);
//        map[root] = null;

//        while (q.Count > 0)
//        {
//            TreeNode node = q.Dequeue();

//            if (node.left != null)
//            {
//                map[node.left] = node;
//                q.Enqueue(node.left);
//            }

//            if (node.right != null)
//            {
//                map[node.right] = node;
//                q.Enqueue(node.right);
//            }
//        }

//        // Step 2: BFS from target node, expanding in all 3 directions (left, right, parent)
//        // We use a visited set to prevent revisiting nodes (e.g., going back down after going up)
//        Queue<TreeNode> temp = new Queue<TreeNode>();
//        HashSet<int> set = new HashSet<int>();

//        temp.Enqueue(target);
//        set.Add(target.val);

//        int count = 0; // tracks current distance from target

//        while (temp.Count > 0)
//        {
//            int size = temp.Count;

//            // Once we've expanded K levels, all nodes currently in queue are at distance K
//            if (count == k)
//            {
//                break;
//            }

//            for (int i = 0; i < size; i++)
//            {
//                TreeNode node = temp.Dequeue();

//                // Expand left child
//                if (node.left != null && !set.Contains(node.left.val))
//                {
//                    set.Add(node.left.val);
//                    temp.Enqueue(node.left);
//                }

//                // Expand right child
//                if (node.right != null && !set.Contains(node.right.val))
//                {
//                    set.Add(node.right.val);
//                    temp.Enqueue(node.right);
//                }

//                // Expand parent (upward traversal using parent map)
//                if (map[node] != null && !set.Contains(map[node].val))
//                {
//                    set.Add(map[node].val);
//                    temp.Enqueue(map[node]);
//                }
//            }

//            count++;
//        }

//        // Step 3: Collect results - all remaining nodes in queue are at distance K
//        while (temp.Count > 0)
//        {
//            result.Add(temp.Dequeue().val);
//        }
//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        //         3
//        //        / \
//        //       5   1
//        //      / \ / \
//        //     6  2 0  8
//        //       / \
//        //      7   4
//        TreeNode root = new TreeNode(3);
//        root.left = new TreeNode(5);
//        root.right = new TreeNode(1);
//        root.left.left = new TreeNode(6);
//        root.left.right = new TreeNode(2);
//        root.right.left = new TreeNode(0);
//        root.right.right = new TreeNode(8);
//        root.left.right.left = new TreeNode(7);
//        root.left.right.right = new TreeNode(4);

//        TreeNode target = root.left; // node with value 5
//        int k = 2;

//        Solution sol = new Solution();
//        IList<int> result = sol.DistanceK(root, target, k);

//        Console.WriteLine(string.Join(", ", result)); // Expected: 7, 4, 1
//    }
//}