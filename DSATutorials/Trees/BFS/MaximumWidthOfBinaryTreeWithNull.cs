
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
//    public int WidthOfBinaryTree(TreeNode root)
//    {
//        // we will be storing node and its index
//        Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)>();

//        q.Enqueue((root, 0));

//        int min = -1;
//        int max = -1;

//        int result = int.MinValue;
//        while (q.Count > 0)
//        {
//            int size = q.Count;

//            for (int i = 0; i < size; i++)
//            {
//                (TreeNode node, int index) = q.Dequeue();

//                if (i == 0)
//                {
//                    min = index;
//                }

//                if (i + 1 == size)
//                {
//                    max = index;
//                }

//                if (node.left != null)
//                {
//                    q.Enqueue((node.left, 2 * index + 1));
//                }

//                if (node.right != null)
//                {
//                    q.Enqueue((node.right, 2 * index + 2));
//                }

//            }

//            result = Math.Max(result, (max - min) + 1);
//        }

//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        TreeNode root = new TreeNode(1);
//        root.left = new TreeNode(3);
//        root.right = new TreeNode(2);
//        root.left.left = new TreeNode(5);
//        root.left.right = new TreeNode(3);
//        root.right.right = new TreeNode(9);

//        Solution s = new Solution();

//        Console.WriteLine(s.WidthOfBinaryTree(root));

//    }
//}

//// Time : O(n) , space : O(n)