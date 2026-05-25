
//using System.ComponentModel.DataAnnotations;

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
//    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
//    {
//        // 3. Now if we get a null we return
//        if (root == null)
//        {
//            return null;
//        }


//        // 4.But if i get any one of the searching node i return them immediately , no need to go further
//        if (root.val == p.val || root.val == q.val)
//        {
//            return root;
//        }

//        // 1. We will go left side first
//        TreeNode left = LowestCommonAncestor(root.left, p, q);

//        // 2. Then right
//        TreeNode right = LowestCommonAncestor(root.right, p, q);


//        // 5. We didnt found what we were searching, now we are returning from either direction, assuming any one may have data
//        if (left == null)
//        {
//            return right;
//        }
//        else if (right == null)
//        {
//            return left;
//        }
//        else
//        {
//            // 6. Right and left both returned something at same time, so this node is our answer
//            return root;
//        }

//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        TreeNode root = new TreeNode(3);
//        root.left = new TreeNode(5);
//        root.right = new TreeNode(1);
//        root.left.left = new TreeNode(6);
//        root.left.right = new TreeNode(2);
//        root.left.right.left = new TreeNode(7);
//        root.left.right.right = new TreeNode(4);
//        root.right.left = new TreeNode(0);
//        root.right.right = new TreeNode(8);

//        TreeNode p = root.left;
//        TreeNode q = root.right;

//        Solution s = new Solution();

//        var result = s.LowestCommonAncestor(root, p, q);

//        Console.Write($"{result.val}");

//    }
//}

//// Time : O(N) , space : O(N)
