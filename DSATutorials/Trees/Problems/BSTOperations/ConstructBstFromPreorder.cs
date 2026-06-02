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
//    // Preorder = Root -> Left -> Right
//    // In a BST, left children < root < right children
//    //
//    // Approach: Read preorder values one by one using a shared index.
//    // Pass an "upperBound" to decide if a value belongs in the current subtree.
//    //   - If value exceeds the bound, it doesn't belong here — backtrack (return null).
//    //   - The caller (parent/ancestor) will then try placing it on the right side.
//    public TreeNode BstFromPreorder(int[] preorder)
//    {
//        int index = 0;
//        return Build(preorder, int.MaxValue, ref index);
//    }

//    private TreeNode Build(int[] preorder, int upperBound, ref int index)
//    {
//        // Base case:
//        // 1. All values are placed (index out of bounds)
//        // 2. Current value exceeds the allowed upper bound — it doesn't fit in this subtree
//        if (index >= preorder.Length || preorder[index] > upperBound)
//        {
//            return null;
//        }

//        // Create node from current preorder value and move to the next
//        TreeNode node = new TreeNode(preorder[index]);
//        index++;

//        // Left subtree: bound tightens to node.val (all left descendants must be < current node)
//        node.left = Build(preorder, node.val, ref index);

//        // Right subtree: bound stays as parent's upperBound
//        // (right descendants can be > current node, but must still be < the ancestor's limit)
//        // e.g., node 7 (right of 5) can be > 5 but must be < 8 (ancestor), so bound = 8 not infinity
//        node.right = Build(preorder, upperBound, ref index);

//        return node;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        // Input: preorder = [8,5,1,7,10,12]
//        // Output:
//        //         8
//        //        / \
//        //       5   10
//        //      / \    \
//        //     1   7   12

//        Solution sol = new Solution();

//        int[] preorder = { 8, 5, 1, 7, 10, 12 };
//        TreeNode root = sol.BstFromPreorder(preorder);
//    }
//}

// Time : O(N), each node is visited exactly once via the index pointer.
// Space : O(H), recursion stack depth equals the height of the tree. Worst case O(N) for skewed trees.
