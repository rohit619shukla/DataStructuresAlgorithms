
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
    public TreeNode ReverseOddLevels(TreeNode root)
    {
        if (root == null) return null;
        // We will perform a level order traversal and swap the nodes in doing so.
        // Idea is left becomes right and right becomes left after swap

        TreeNode head = root;

        Queue<TreeNode> q = new Queue<TreeNode>();

        q.Enqueue(head);
        int level = 0;
        while (q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode node = q.Dequeue();
                // only odd level nodes will be swapped
                if ((level + 1) % 2 != 0)
                {
                    if (node.left != null && node.right != null)
                    {
                        SwapNodes(ref node.left, ref node.right);
                    }
                }

                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
            level++;
        }

        return root;
    }

    private void SwapNodes(ref TreeNode n1, ref TreeNode n2)
    {
        int temp = n1.val;
        n1.val = n2.val;
        n2.val = temp;
    }
}

class Program
{
    public static void Main()
    {
        Solution s = new Solution();

        TreeNode root = new TreeNode(2);
        root.left = new TreeNode(3);
        root.right = new TreeNode(5);
        root.left.left = new TreeNode(8);
        root.left.right = new TreeNode(13);
        root.right.left = new TreeNode(21);
        root.right.right = new TreeNode(34);

        s.ReverseOddLevels(root);
    }
}