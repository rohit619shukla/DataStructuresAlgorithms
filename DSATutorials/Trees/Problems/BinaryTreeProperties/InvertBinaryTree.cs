
public class TreeNode
{
    public TreeNode left;
    public TreeNode right;
    public int val;

    public TreeNode(int data)
    {
        val = data;
    }
}
public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {

    }

    static void Main(string[] args)
    {
        // Input: root = [4,2,7,1,3,6,9]
        TreeNode root = new TreeNode(4);
        root.left = new TreeNode(2);
        root.right = new TreeNode(7);
        root.left.left = new TreeNode(1);
        root.left.right = new TreeNode(3);
        root.right.left = new TreeNode(6);
        root.right.right = new TreeNode(9);

        Solution sol = new Solution();
        sol.InvertTree(root);
    }
}