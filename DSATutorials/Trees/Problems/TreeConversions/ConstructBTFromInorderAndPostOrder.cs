
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
//    public TreeNode BuildTree(int[] inorder, int[] postorder)
//    {
//        // We will use inorder array to search the nodes location
//        Dictionary<int, int> map = new Dictionary<int, int>();
//        for (int i = 0; i < inorder.Length; i++)
//        {
//            map[inorder[i]] = i;
//        }

//        int idx = postorder.Length - 1;

//        return Solve(map, postorder, 0, postorder.Length - 1, ref idx);
//    }

//    private TreeNode Solve(Dictionary<int, int> map, int[] postorder, int start, int end, ref int idx)
//    {
//        if (start > end) return null;

//        // 1. Since this is postorder we will pcik the last node as root to start from as the root always come at last
//        int currentRoot = postorder[idx];

//        // 2. Get the index of this node in inorder map we created to left and right node
//        int i = map[currentRoot];

//        // Move to next node in postorder array to get root for next level
//        idx--;

//        // 3. Create root node
//        TreeNode root = new TreeNode(currentRoot);

//        root.right = Solve(map, postorder, i + 1, end, ref idx);
//        root.left = Solve(map, postorder, start, i - 1, ref idx);

//        return root;
//    }
//}


//class Program
//{
//    public static void Main(string[] args)
//    {

//        int[] inorder = { 9, 3, 15, 20, 7 };
//        int[] postorder = { 9, 15, 7, 20, 3 };

//        Solution sol = new Solution();
//        TreeNode root = sol.BuildTree(inorder, postorder);

//        Console.WriteLine("Root: " + root.val);
//    }
//}