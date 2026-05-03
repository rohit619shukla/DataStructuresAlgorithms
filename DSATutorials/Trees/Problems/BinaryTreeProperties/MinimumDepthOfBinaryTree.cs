

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
//    public int MinDepth(TreeNode root)
//    {
//        Queue<TreeNode> q = new Queue<TreeNode>();

//        TreeNode head = root;

//        q.Enqueue(head);

//        int level = 0;
//        int count = 0;

//        while (q.Count > 0)
//        {
//            int size = q.Count();

//            level++;
//            for (int i = 0; i < size; i++)
//            {
//                TreeNode temp = q.Dequeue();

//                if (temp.left == null && temp.right == null)
//                {
//                    count++;
//                    break;
//                }
//                if (temp.left != null)
//                {
//                    q.Enqueue(temp.left);
//                }

//                if (temp.right != null)
//                {
//                    q.Enqueue(temp.right);
//                }
//            }

//            if (count != 0)
//            {
//                break;
//            }
//        }

//        return level;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        TreeNode root = new TreeNode(3);
//        root.left = new TreeNode(9);
//        root.right = new TreeNode(20);
//        root.right.left = new TreeNode(15);
//        root.right.right = new TreeNode(7);

//        Console.WriteLine($"{s.MinDepth(root)}");
//    }
//}

//// Level order travseral is used here although we need to find depth because, we need to immediately break at point in level when we find a leaf node,
//// and that level becomes the min depth