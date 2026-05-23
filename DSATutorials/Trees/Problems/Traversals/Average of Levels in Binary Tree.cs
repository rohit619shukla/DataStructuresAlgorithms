
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
//    public IList<double> AverageOfLevels(TreeNode root)
//    {
//        IList<double> result = new List<double>();

//        Queue<TreeNode> q = new Queue<TreeNode>();
//        q.Enqueue(root);

//        while (q.Count > 0)
//        {
//            int size = q.Count;

//            double total = 0;

//            for (int i = 0; i < size; i++)
//            {
//                TreeNode head = q.Dequeue();
//                total += head.val;

//                if (head.left != null)
//                {
//                    q.Enqueue(head.left);
//                }

//                if (head.right != null)
//                {
//                    q.Enqueue(head.right);
//                }
//            }

//            double final = (total / size);
//            result.Add(final);
//        }


//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        TreeNode root = new TreeNode(3);
//        root.left = new TreeNode(9);
//        root.right = new TreeNode(20);
//        root.right.left = new TreeNode(15);
//        root.right.right = new TreeNode(7);

//        Solution s = new Solution();

//        var result = s.AverageOfLevels(root);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}