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
//    public TreeNode InsertIntoBST(TreeNode root, int val)
//    {
//        // If the root is empty, we will just assign and create anew value node
//        if (root == null) return new TreeNode(val);

//        // We will first try to figure out best position for this node in the tree
//        TreeNode curr = root;
//        TreeNode prev = null;

//        while (curr != null)
//        {
//            if (curr.val > val)
//            {
//                prev = curr;
//                curr = curr.left;
//            }
//            else
//            {
//                prev = curr;
//                curr = curr.right;
//            }
//        }

//        if (prev.val > val)
//        {
//            prev.left = new TreeNode(val);
//        }
//        else
//        {
//            prev.right = new TreeNode(val);
//        }

//        return root;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        // Input: root = [4,2,7,1,3], val = 5
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

//        int val = 5;
//        root = sol.InsertIntoBST(root, val);
//    }
//}

//// Time : O(Log2N) or O(H), as we only traverse either left or right side at each level, which is the height of the tree.
////        In worst case (skewed tree), it becomes O(N).
//// Space : O(1), as we are using iterative approach with no extra space.
