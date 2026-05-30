
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
//    public TreeNode BuildTree(int[] preorder, int[] inorder)
//    {
//        int idx = 0;

//        // Lets create a Map to store the node and its index from inorder map
//        Dictionary<int, int> map = new Dictionary<int, int>();
//        for (int i = 0; i < inorder.Length; i++)
//        {
//            map[inorder[i]] = i;
//        }

//        return Solve(preorder, 0, inorder.Length - 1, map, ref idx);
//    }

//    private TreeNode Solve(int[] preorder, int start, int end, Dictionary<int, int> map, ref int idx)
//    {
//        if (start > end) return null;

//        // 1. From the preorder array we will always pick the root node
//        // Becoz the preorder works in root, left , right way, so the next root will always be picked in sequnce

//        int currentRoot = preorder[idx];

//        // 2. Now using the root we have obtained lets figure out its position in inorder array
//        // Becoz the inorder stores the data in left, root, right. So we can easily get left and right side

//        int i = map[currentRoot];

//        idx++;

//        // 3. Create the root node now
//        TreeNode root = new TreeNode(currentRoot);

//        // 4. Now letc create its left and right recursively
//        root.left = Solve(preorder, start, i - 1, map, ref idx);
//        root.right = Solve(preorder, i + 1, end, map, ref idx);

//        return root;
//    }
//}

//class Program
//{
//    public static void Main(string[] args)
//    {
//        // Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
//        //        3
//        //       / \
//        //      9  20
//        //        /  \
//        //       15   7
//        int[] preorder = { 3, 9, 20, 15, 7 };
//        int[] inorder = { 9, 3, 15, 20, 7 };

//        Solution sol = new Solution();
//        TreeNode root = sol.BuildTree(preorder, inorder);

//        Console.WriteLine("Root: " + root.val);
//    }
//}

//// Time : O(n) , space :O(n)