//using System.Text;

//public class TreeNode
//{
//    public int val;
//    public TreeNode left;
//    public TreeNode right;

//    public TreeNode(int data)
//    {
//        val = data;
//    }
//}


//public class Solution
//{
//    public IList<string> BinaryTreePaths(TreeNode root)
//    {
//        List<string> result = new List<string>();
//        List<int> temp = new List<int>();

//        temp.Add(root.val);

//        DFS(root, result, temp);

//        return result;
//    }

//    private void DFS(TreeNode root, List<string> result, List<int> temp)
//    {
//        // base case : we have found a leaf node
//        if (root.left == null && root.right == null)
//        {
//            StringBuilder str = new StringBuilder();

//            for (int i = 0; i < temp.Count - 1; i++)
//            {
//                str.Append(temp[i]).Append("->");
//            }

//            str.Append(temp[temp.Count - 1]);
//            result.Add(str.ToString());

//            return;
//        }


//        // Simple left and right travsersal
//        if (root.left != null)
//        {
//            temp.Add(root.left.val);
//            DFS(root.left, result, temp);
//            temp.RemoveAt(temp.Count - 1);
//        }

//        if (root.right != null)
//        {
//            temp.Add(root.right.val);
//            DFS(root.right, result, temp);
//            temp.RemoveAt(temp.Count - 1);
//        }
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
//        root.left.right = new TreeNode(5);

//        var result = s.BinaryTreePaths(root);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}

//// Time : O(N·H) — DFS visits all N nodes, and at each leaf we build the path string in O(H).
////   Balanced tree: H = log N → O(N·log N)
////   Skewed tree:   H = N → O(N²)
//// Auxiliary Space : O(H) — temp list storing current path
//// Space Complexity : O(H) — recursive stack space