
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
//    public TreeNode SearchBST(TreeNode root, int val)
//    {
//        if (root == null) return null;

//        while (root != null)
//        {
//            // We found the node, lets return
//            if (root.val == val)
//            {
//                return root;
//            }
//            // We will move to left side
//            else if (root.val > val)
//            {
//                root = root.left;
//            }
//            else
//            {
//                root = root.right;
//            }
//        }

//        return root;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        // Build BST from image:
//        //         4
//        //        / \
//        //       2   7
//        //      / \
//        //     1   3
//        TreeNode root = new TreeNode(4);
//        root.left = new TreeNode(2);
//        root.right = new TreeNode(7);
//        root.left.left = new TreeNode(1);
//        root.left.right = new TreeNode(3);

//        Solution sol = new Solution();

//        int target = 2;
//        TreeNode result = sol.SearchBST(root, target);

//        if (result != null)
//            Console.WriteLine($"Found node with value: {result.val}");
//        else
//            Console.WriteLine($"Node {target} not found in BST");
//    }
//}

//// Time : O(Log2N), as we will only scan either left or right side of a tree, which is nothing but the height of the tree