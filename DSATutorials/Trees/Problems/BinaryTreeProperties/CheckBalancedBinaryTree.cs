

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
//    public bool IsBalanced(TreeNode root)
//    {
//        if (root == null) return false;

//        var result = FindHeight(root);

//        if (result == -1)
//        {
//            return false;
//        }

//        return true;
//    }

//    private int FindHeight(TreeNode root)
//    {
//        if (root == null)
//        {
//            return 0;
//        }

//        int leftHeight = FindHeight(root.left);

//        if (leftHeight == -1)
//        {
//            return -1;
//        }

//        int rightHeight = FindHeight(root.right);

//        if (rightHeight == -1)
//        {
//            return -1;
//        }

//        if (Math.Abs(leftHeight - rightHeight) > 1)
//        {
//            return -1;
//        }
//        else
//        {
//            return 1 + Math.Max(leftHeight, rightHeight);
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        TreeNode root = new TreeNode(3);
//        root.left = new TreeNode(9);
//        root.right = new TreeNode(20);
//        root.right.left = new TreeNode(15);
//        root.right.right = new TreeNode(7);

//        Solution s = new Solution();

//        Console.WriteLine(s.IsBalanced(root));
//    }
//}



//// Time : O(N) , space : O(N)
/// The idea here is that you will try to compute height while traversing, rather than firts find heoght and then traverse. Which will take O(N^2) time