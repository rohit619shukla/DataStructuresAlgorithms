
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
//    public int SumNumbers(TreeNode root)
//    {
//        return Solve(root, 0);
//    }

//    private int Solve(TreeNode root, int curr)
//    {
//        if (root == null)
//        {
//            return 0;
//        }
//        curr = curr * 10 + root.val;

//        // if the node is leaf we return whatever we have got in curr
//        if (root.left == null && root.right == null)
//        {
//            return curr;
//        }

//        // else Go to left and right paths
//        int left = Solve(root.left, curr);

//        int right = Solve(root.right, curr);

//        //while returning from give node retunr the sum of left and right
//        return left + right;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        TreeNode root = new TreeNode(4);
//        root.left = new TreeNode(9);
//        root.right = new TreeNode(0);
//        root.left.left = new TreeNode(5);
//        root.left.right = new TreeNode(1);

//        Console.Write($"{s.SumNumbers(root)}");
//    }
//}


//// Time : O(n), space : O(h) best case and  O(n) worst case
