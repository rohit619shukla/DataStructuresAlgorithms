
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
//    public TreeNode ReverseOddLevels(TreeNode root)
//    {
//        if (root == null) return null;

//        Queue<TreeNode> q = new Queue<TreeNode>();
//        q.Enqueue(root);
//        int level = 0;

//        while (q.Count > 0)
//        {
//            int size = q.Count;
//            List<TreeNode> levelNodes = new List<TreeNode>();

//            for (int i = 0; i < size; i++)
//            {
//                TreeNode node = q.Dequeue();
//                if (level % 2 != 0) levelNodes.Add(node);

//                if (node.left != null) q.Enqueue(node.left);
//                if (node.right != null) q.Enqueue(node.right);
//            }

//            // reverse values across the entire odd level
//            if (levelNodes.Count > 0)
//            {
//                int left = 0, right = levelNodes.Count - 1;
//                while (left < right)
//                {
//                    int temp = levelNodes[left].val;
//                    levelNodes[left].val = levelNodes[right].val;
//                    levelNodes[right].val = temp;
//                    left++;
//                    right--;
//                }
//            }

//            level++;
//        }

//        return root;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        TreeNode root = new TreeNode(2);
//        root.left = new TreeNode(3);
//        root.right = new TreeNode(5);
//        root.left.left = new TreeNode(8);
//        root.left.right = new TreeNode(13);
//        root.right.left = new TreeNode(21);
//        root.right.right = new TreeNode(34);

//        s.ReverseOddLevels(root);
//    }
//}