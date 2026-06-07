
// Leetcode 572 - Subtree of Another Tree
// https://leetcode.com/problems/subtree-of-another-tree/
// BFS to find matching root node, then recursively compare subtrees
// Time : O(M * N), Space : O(M + N) where M = root nodes, N = subRoot nodes

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
//    public bool IsSubtree(TreeNode root, TreeNode subRoot)
//    {
//        Queue<TreeNode> q = new Queue<TreeNode>();

//        TreeNode findRoot = root;

//        q.Enqueue(findRoot);

//        bool result = false;
//        while (q.Count > 0)
//        {
//            TreeNode head = q.Dequeue();

//            if (head.val == subRoot.val)
//            {
//                result = Solve(head, subRoot);
//                if (result) break;
//            }

//            if (head.left != null)
//            {
//                q.Enqueue(head.left);
//            }

//            if (head.right != null)
//            {
//                q.Enqueue(head.right);
//            }
//        }


//        return result;
//    }

//    private bool Solve(TreeNode head, TreeNode subRoot)
//    {
//        if (head == null && subRoot == null)
//        {
//            return true;
//        }

//        if (head == null || subRoot == null)
//        {
//            return false;
//        }

//        if (head.val != subRoot.val)
//        {
//            return false;
//        }


//        return Solve(head.left, subRoot.left) && Solve(head.right, subRoot.right);
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        // root = [3,4,5,1,2]
//        TreeNode root = new TreeNode(3);
//        root.left = new TreeNode(4);
//        root.right = new TreeNode(5);
//        root.left.left = new TreeNode(1);
//        root.left.right = new TreeNode(2);

//        // subRoot = [4,1,2]
//        TreeNode subRoot = new TreeNode(4);
//        subRoot.left = new TreeNode(1);
//        subRoot.right = new TreeNode(2);

//        Console.WriteLine(s.IsSubtree(root, subRoot));
//    }
//}
