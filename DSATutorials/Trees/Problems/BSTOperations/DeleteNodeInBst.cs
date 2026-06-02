

//using System.Xml.Linq;

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
//    // Time Complexity: O(H) - We traverse down one path to find the node, and finding the
//    // inorder successor is confined to the right subtree (right once, then left),
//    // so total work is bounded by the height. Worst case O(N) for skewed trees.
//    // Space Complexity: O(H) - Auxiliary stack space due to recursion, and also the actual space.
//    public TreeNode DeleteNode(TreeNode root, int key)
//    {
       
//        TreeNode head = root;

//        return Solve(head, key);

//    }

//    private TreeNode Solve(TreeNode head, int val)
//    {
//        if (head == null) return null;

//        // Lets figure out where node to be deleted is present in the tree
//        if (head.val > val)
//        {
//            // move to left
//            head.left = Solve(head.left, val);
//        }
//        else if (head.val < val)
//        {
//            // move to left
//            head.right = Solve(head.right, val);
//        }
//        else
//        {
//            // we found the node
//            // Node could only have had right side
//            if (head.left == null)
//            {
//                // whatever we have on right
//                return head.right;
//            }

//            if (head.right == null)
//            {
//                // whatever we have on left
//                return head.left;
//            }

//            // Possible that this node has left and right.
//            // We cannot just delete this node, we will need either 
//            // Inorder successor : smallest from right
//            // Inorder predecessor : largest from left;
//            TreeNode inorderNode = GetInorderSuccessor(head.right);

//            // Update the value of this inorder node with, the node to be deleted
//            head.val = inorderNode.val;

//            // Now remove the reference of this  inorder node as we have already picked up its value;
//            head.right = Solve(head.right, inorderNode.val);
//        }

//        return head;
//    }

//    private TreeNode GetInorderSuccessor(TreeNode node)
//    {
//        // Inorder successor will be on the right, but will be smallest value on right

//        TreeNode inorderNode = null;

//        while (node != null)
//        {
//            inorderNode = node;
//            node = node.left;
//        }

//        return inorderNode;
//    }

//}

//class Program
//{
//    public static void Main(string[] args)
//    {
//        TreeNode root = new TreeNode(5);
//        root.left = new TreeNode(3);
//        root.right = new TreeNode(6);
//        root.left.left = new TreeNode(2);
//        root.left.right = new TreeNode(4);
//        root.right.right = new TreeNode(7);

//        int key = 0;

//        Solution sol = new Solution();
//        root = sol.DeleteNode(root, key);
//    }
//}