
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
//    public int MaxDepth(TreeNode root)
//    {
//        if (root == null)
//        {
//            return 0;
//        }

//        int leftDepth = MaxDepth(root.left);
//        int rightDepth = MaxDepth(root.right);

//        return 1 + Math.Max(leftDepth, rightDepth);
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

//        Console.WriteLine($"{s.MaxDepth(root)}");

//    }
//}


//// Time : O(N) , space : O(N)