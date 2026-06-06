
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
//    public TreeNode InvertTree(TreeNode root)
//    {
//        // We will perform a level order traversal and swap the nodes in doing so.
//        // Idea is left becomes right and right becomes left after swap

//        TreeNode head = root;

//        Queue<TreeNode> q = new Queue<TreeNode>();

//        q.Enqueue(head);

//        while (q.Count > 0)
//        {
//            int size = q.Count;

//            for (int i = 0; i < size; i++)
//            {
//                TreeNode node = q.Dequeue();

//                SwapNodes(ref node.left, ref node.right);

//                if (node.left != null)
//                {
//                    q.Enqueue(node.left);
//                }

//                if (node.right != null)
//                {
//                    q.Enqueue(node.right);
//                }
//            }
//        }

//        return root;
//    }

//    private void SwapNodes(ref TreeNode n1, ref TreeNode n2)
//    {
//        TreeNode temp = n1;
//        n1 = n2;
//        n2 = temp;
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Input: root = [4,2,7,1,3,6,9]
//        TreeNode root = new TreeNode(4);
//        root.left = new TreeNode(2);
//        root.right = new TreeNode(7);
//        root.left.left = new TreeNode(1);
//        root.left.right = new TreeNode(3);
//        root.right.left = new TreeNode(6);
//        root.right.right = new TreeNode(9);

//        Solution sol = new Solution();
//        sol.InvertTree(root);
//    }
//}