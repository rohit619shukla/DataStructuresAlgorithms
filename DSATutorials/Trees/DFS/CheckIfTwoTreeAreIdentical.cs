
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
//    public bool IsSameTree(TreeNode p, TreeNode q)
//    {
//        // Both nodes are null, we are fine
//        if (p == null && q == null)
//        {
//            return true;
//        }

//        // Either is null , not acceptable
//        if (p == null || q == null)
//        {
//            return false;
//        }

//        // Maybe values are not same
//        if (p.val != q.val)
//        {
//            return false;
//        }

//        // Go to same direction in both trees while traversing
//        return IsSameTree(p.left, q.left) &&
//            IsSameTree(p.right, q.right);
//    }

//}


//class Program
//{
//    public static void Main()
//    {
//        Solution h = new Solution();

//        TreeNode root1 = new TreeNode(1);
//        root1.left = new TreeNode(2);
//        root1.right = new TreeNode(3);
//        root1.left.left = new TreeNode(4);
//        root1.left.right = new TreeNode(5);

//        TreeNode root2 = new TreeNode(1);
//        root2.left = new TreeNode(2);
//        root2.right = new TreeNode(3);
//        root2.left.left = new TreeNode(4);
//        root2.left.right = new TreeNode(6);

//        Console.WriteLine($"{h.IsSameTree(root1, root2)}");
//    }
//}

//// Time : O(N) , sapce : O(N) in worst case of skewed
