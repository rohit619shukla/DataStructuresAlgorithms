
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
//    public bool CheckTree(TreeNode root)
//    {
//        if (root.left != null && root.right != null)
//        {
//            return root.left.val + root.right.val == root.val ? true : false;
//        }
//        else 
//        {
//            return false;
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        TreeNode root = new TreeNode(5);
//        root.left = new TreeNode(3);
//        root.right = new TreeNode(1);

//        Solution s = new Solution();

//        Console.WriteLine(s.CheckTree(root));
//    }
//}

//// Time : O(1), sapce (1)