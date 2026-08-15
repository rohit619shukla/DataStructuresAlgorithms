
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
//    // Morris Inorder Traversal approach to validate BST
//    // Key insight: Inorder traversal of a valid BST is strictly increasing.
//    // Instead of comparing node with immediate children (wrong — misses ancestor constraints),
//    // we track the previously visited node and ensure current > prev at every visit point.
//    public bool IsValidBST(TreeNode root)
//    {
//        TreeNode head = root;
//        TreeNode prev = null; // Tracks the previously visited node in inorder sequence

//        while (head != null)
//        {
//            if (head.left != null)
//            {
//                // Find the inorder predecessor of head
//                TreeNode temp = head.left;

//                while (temp.right != null && temp.right != head)
//                {
//                    temp = temp.right;
//                }

//                if (temp.right == null)
//                {
//                    // Create a thread: link predecessor's right to current node (for backtracking)
//                    temp.right = head;
//                    head = head.left;
//                }
//                else
//                {
//                    // Thread already exists — we're revisiting. Remove thread to restore tree.
//                    temp.right = null;
//                    // Inorder visit: check current > prev (strictly increasing)
//                    if (prev != null && head.val <= prev.val)
//                    {
//                        return false;
//                    }
//                    prev = head;
//                    head = head.right;
//                }
//            }
//            else
//            {
//                // No left child — visit this node directly
//                // Inorder visit: check current > prev (strictly increasing)
//                if (prev != null && head.val <= prev.val)
//                {
//                    return false;
//                }
//                prev = head;
//                head = head.right;
//            }
//        }

//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution h = new Solution();

//        TreeNode root = new TreeNode(5);
//        root.left = new TreeNode(1);
//        root.right = new TreeNode(4);
//        root.right.left = new TreeNode(3);
//        root.right.right = new TreeNode(6);

//        Console.WriteLine(h.IsValidBST(root));
//    }
//}


//// Time : O(N), space : O(1)

//// Morris Inorder Traversal: at each visit point, check that current node > previously visited node.
//// A valid BST's inorder traversal is strictly increasing.