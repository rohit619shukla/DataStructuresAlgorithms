
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
//    public int DiameterOfBinaryTree(TreeNode root)
//    {
//        int maxi = 0;

//        Solve(root, ref maxi);

//        return maxi;
//    }

//    private int Solve(TreeNode root, ref int maxi)
//    {
//        if (root == null)
//        {
//            return 0;
//        }

//        int leftHeight = Solve(root.left, ref maxi);
//        int rightHeight = Solve(root.right, ref maxi);

//        maxi = Math.Max(maxi, leftHeight + rightHeight);

//        return 1 + Math.Max(leftHeight, rightHeight);

//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        TreeNode root = new TreeNode(1);
//        root.left = new TreeNode(2);
//        root.right = new TreeNode(3);
//        root.left.left = new TreeNode(4);
//        root.left.right = new TreeNode(5);

//        Solution s = new Solution();

//        Console.WriteLine($"{s.DiameterOfBinaryTree(root)}");
//    }

//}

//// Time : O(N) , space :O(N)
/// Idea is at every node we will calcutae the Lh and Rh and then keep a max to know which node has biggest Lh+Rh