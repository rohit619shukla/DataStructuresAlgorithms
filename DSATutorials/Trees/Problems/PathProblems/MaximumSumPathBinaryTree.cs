
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
//    public int MaxPathSum(TreeNode root)
//    {

//        int max = int.MinValue;

//        Solve(root, ref max);

//        return max;
//    }

//    private int Solve(TreeNode root, ref int max)
//    {
//        if (root == null)
//        {
//            return 0;
//        }

//        int leftSide = Solve(root.left, ref max);

//        int rightSide = Solve(root.right, ref max);

//        // Here we will have 3 cases probably to choose from
//        int both_Paths_Best = leftSide + rightSide + root.val;

//        int eigther_Best = Math.Max(leftSide, rightSide) + root.val;

//        int neither_Best_But_Root = root.val;

//        max = Math.Max(max, Math.Max(both_Paths_Best, Math.Max(eigther_Best, neither_Best_But_Root)));

//        return Math.Max(eigther_Best, neither_Best_But_Root);   // We dont return the both_Paths_Best, becaause it has already got the best and it will never move up so no point in returning
//    }
//}

//class Program
//{
//    public static void Main()
//    {

//        Solution s = new Solution();

//        TreeNode root = new TreeNode(-3);
//        root.left = new TreeNode(9);
//        root.right = new TreeNode(20);
//        root.right.left = new TreeNode(15);
//        root.right.right = new TreeNode(7);

//        Console.WriteLine(s.MaxPathSum(root));
//    }
//}


//// Time : O(N) , space : O(N)