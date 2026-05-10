
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
//    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
//    {
//        IList<IList<int>> result = new List<IList<int>>();

//        if (root == null) return result;

//        Queue<TreeNode> q = new Queue<TreeNode>();

//        q.Enqueue(root);

//        bool flag = false;

//        while (q.Count > 0)
//        {
//            int size = q.Count();

//            List<int> temp = new List<int>();

//            for (int i = 0; i < size; i++)
//            {
//                TreeNode head = q.Dequeue();

//                if (flag)
//                {
//                    // Right to Left
//                    temp.Insert(0, head.val);
//                }
//                else
//                {
//                    // Left to Right
//                    temp.Add(head.val);
//                }

//                if (head.left != null)
//                {
//                    q.Enqueue(head.left);
//                }

//                if (head.right != null)
//                {
//                    q.Enqueue(head.right);
//                }
//            }

//            result.Add(temp);

//            flag = !flag;
//        }

//        return result;
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



//        var result = s.ZigzagLevelOrder(root);

//        foreach (var items in result)
//        {
//            foreach (var item in items)
//            {
//                Console.Write($"{item}" + " ");
//            }
//        }
//    }
//}


//////Space Complexity: O(N)
//////Time Complexity: O(N) As outer while loops executes for N times and inner loops also goes over each node in tree only once.