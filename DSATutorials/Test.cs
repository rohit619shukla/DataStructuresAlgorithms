
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
    public int GoodNodes(TreeNode root)
    {
        return Dfs(root, root.val);
    }

    private int Dfs(TreeNode node, int maxSoFar)
    {
        if (node == null) return 0;

        // 1 if current node is "good", 0 otherwise
        int isGood = node.val >= maxSoFar ? 1 : 0;

        // Update maxSoFar for the next level down
        maxSoFar = Math.Max(maxSoFar, node.val);

        // Sum up current node + left subtree + right subtree
        return isGood + Dfs(node.left, maxSoFar) + Dfs(node.right, maxSoFar);
    }
}


class Program
{
    public static void Main()
    {
        Solution s = new Solution();

        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(1);
        root.right = new TreeNode(4);
        root.left.left = new TreeNode(3);
        root.right.left = new TreeNode(1);
        root.right.right = new TreeNode(5);

        s.LevelOrderBottom(root);
    }
}