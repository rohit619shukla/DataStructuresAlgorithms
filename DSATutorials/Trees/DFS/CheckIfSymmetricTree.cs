

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
//    public bool IsSymmetric(TreeNode root)
//    {
//        // If root is null we are good in these kinds of questions
//        if (root == null)
//        {
//            return true;
//        }

//        // We will always start  with left and right nodes
//        return Solve(root.left, root.right);
//    }

//    private bool Solve(TreeNode root1, TreeNode root2)
//    {
//        // If both nodes are null we are good, becoz these nodes are running in opp direction in recursion
//        if (root1 == null && root2 == null)
//        {
//            return true;
//        }

//        // If any of them is null its not good as we need mirrors in opp direction
//        if (root1 == null || root2 == null)
//        {
//            return false;
//        }

//        // Now we need to check for values
//        if (root1.val != root2.val)
//        {
//            return false;
//        }

//        return Solve(root1.left, root2.right) &&
//            Solve(root1.right, root2.left);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        TreeNode root = new TreeNode(1);
//        root.left = new TreeNode(2);
//        root.right = null;
//        //    root.left.right = new TreeNode(3);
//        //    root.right.right = new TreeNode(3);
//        //root.left.left = new TreeNode(3);
//        //root.left.right = new TNTreeNodeode(4);
//        //root.right.left = new TreeNode(4);
//        //root.right.right = new TreeNode(3);

//        Solution h = new Solution();

//        Console.WriteLine(h.IsSymmetric(root));
//    }
//}