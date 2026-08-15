
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
//    public IList<int> LargestValues(TreeNode root)
//    {
//        IList<int> result = new List<int>();

//        Queue<TreeNode> q = new Queue<TreeNode>();

//        q.Enqueue(root);

//        while (q.Count > 0)
//        {
//            int size = q.Count;

//            int max = int.MinValue;

//            for (int i = 0; i < size; i++)
//            {
//                TreeNode head = q.Dequeue();

//                if (head.left != null)
//                {
//                    q.Enqueue(head.left);
//                }

//                if (head.right != null)
//                {
//                    q.Enqueue(head.right);
//                }

//                max = Math.Max(max, head.val);
//            }

//            result.Add(max);
//        }

//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        TreeNode root = new TreeNode(1);
//        root.left = new TreeNode(3);
//        root.right = new TreeNode(2);
//        root.left.left = new TreeNode(5);
//        root.left.right = new TreeNode(3);
//        root.right.right = new TreeNode(9);

//        var result = s.LargestValues(root);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}