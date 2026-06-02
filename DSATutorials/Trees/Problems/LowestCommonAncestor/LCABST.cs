
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
//    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
//    {
//        TreeNode curr = root;

//        while (curr != null)
//        {
//            if (curr.val > p.val && curr.val > p.val)
//            {
//                // means both the nodes lie to left of subtree
//                curr = curr.left;
//            }
//            else if (curr.val < p.val && curr.val < q.val)
//            {
//                curr = curr.right;
//            }
//            else
//            {
//                // This is our LCA
//                return root;
//            }
//        }

//        return root;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        // Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
//        TreeNode root = new TreeNode(6);
//        root.left = new TreeNode(2);
//        root.right = new TreeNode(8);
//        root.left.left = new TreeNode(0);
//        root.left.right = new TreeNode(4);
//        root.right.left = new TreeNode(7);
//        root.right.right = new TreeNode(9);
//        root.left.right.left = new TreeNode(3);
//        root.left.right.right = new TreeNode(5);

//        TreeNode p = root.left;        // node with val 2
//        TreeNode q = root.right;       // node with val 8

//        Solution sol = new Solution();
//        TreeNode lca = sol.LowestCommonAncestor(root, p, q);
//        Console.WriteLine(lca.val);    // Expected output: 6
//    }
//}