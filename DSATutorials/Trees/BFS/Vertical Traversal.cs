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
//    public IList<IList<int>> VerticalTraversal(TreeNode root)
//    {
//        IList<IList<int>> result = new List<IList<int>>();

//        // We will create a flat list for convenience, which could be used to sort later
//        // The ordering is row, column and then value
//        List<(int row, int col, int val)> nodeList = new List<(int, int, int)>();

//        // Also we need a queue for BFS traversal
//        Queue<(TreeNode, int, int)> q = new Queue<(TreeNode, int, int)>();

//        // Start BFS
//        q.Enqueue((root, 0, 0));

//        while (q.Count > 0)
//        {
//            (TreeNode head, int row, int col) = q.Dequeue();

//            // Add straight to flat list
//            nodeList.Add((row, col, head.val));

//            // perform the direction assignment as requested
//            if (head.left != null)
//            {
//                q.Enqueue((head.left, row + 1, col - 1));
//            }

//            if (head.right != null)
//            {
//                q.Enqueue((head.right, row + 1, col + 1));
//            }
//        }

//        // Now our nodelist is having the data in flat order which is order of travserse.
//        // However we need to respect the condition being asked in LC 987.
//        // In order to make sure the requested condition is met :
//        // 1) we need to first make sure the columns are sorted/arranged left to right
//        // 2) Once columns are sorted , then for each of those simialr columns , sort the rows from top to bottom
//        // 3) Then we will go for value comparison

//        nodeList.Sort((a, b) =>
//        {
//            if (a.col != b.col)
//            {
//                return a.col.CompareTo(b.col);
//            }
//            else if (a.row != b.row)
//            {
//                return a.row.CompareTo(b.row);
//            }

//            return a.val.CompareTo(b.val);
//        });

//        // Now we will add them to list as they are already sorted
//        int i = 0;

//        while (i < nodeList.Count)
//        {
//            // Get the current node column
//            int currentColumn = nodeList[i].col;

//            List<int> temp = new List<int>();

//            while (i < nodeList.Count && nodeList[i].col == currentColumn)
//            {
//                temp.Add(nodeList[i].val);
//                i++;
//            }

//            result.Add(temp);
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
//        root.left = new TreeNode(2);
//        root.right = new TreeNode(3);
//        root.left.left = new TreeNode(4);
//        root.left.right = new TreeNode(6);
//        root.right.left = new TreeNode(5);
//        root.right.right = new TreeNode(7);

//        var result = s.VerticalTraversal(root);

//        foreach (var items in result)
//        {
//            foreach (var item in items)
//            {
//                Console.Write($"{item}" + " ");
//            }
//        }
//    }
//}