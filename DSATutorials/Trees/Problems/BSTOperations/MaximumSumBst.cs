/// LeetCode 1373: Maximum Sum BST in Binary Tree
/// https://leetcode.com/problems/maximum-sum-bst-in-binary-tree/
///
/// Problem:
///   Given a binary tree, find the maximum sum of all keys of any subtree
///   which is also a valid Binary Search Tree (BST).
///
/// Approach – Post-order DFS with NodeInfo propagation:
///   We traverse the tree bottom-up (post-order). For each node, we collect
///   information from its left and right subtrees: min value, max value,
///   whether the subtree is a valid BST, and the sum of node values.
///
///   A node forms a valid BST if:
///     1. Both left and right subtrees are valid BSTs.
///     2. The max value in the left subtree is less than the current node's value.
///     3. The min value in the right subtree is greater than the current node's value.
///
///   If valid, we compute the sum of the subtree and update the global max.
///
/// Time  Complexity: O(n) – we visit every node exactly once in the post-order traversal.
/// Space Complexity: O(h) – recursion stack depth, where h is the height of the tree.
///                   O(n) in the worst case for a skewed tree, O(log n) for a balanced tree.

public class TreeNode
{
    public TreeNode left;
    public TreeNode right;
    public int val;

    public TreeNode(int data)
    {
        val = data;
    }
}

/// <summary>
/// Holds information about a subtree that is passed upward during post-order traversal.
/// Min/Max track the value range, IsBst flags validity, and nodeVal holds the subtree sum.
/// </summary>
public class NodeInfo
{
    public int Min;      // smallest value in this subtree
    public int Max;      // largest value in this subtree
    public bool IsBst;   // whether this subtree is a valid BST
    public int nodeVal;  // sum of all node values in this subtree

    public NodeInfo(int min, int max, bool bst, int total)
    {
        Min = min;
        Max = max;
        IsBst = bst;
        nodeVal = total;
    }
}

public class Solution
{
    public int MaxSumBST(TreeNode root)
    {
        // maxTotal tracks the best BST sum found so far across the entire tree
        int maxTotal = 0;

        // kick off the post-order traversal; maxTotal is updated via ref
        Solve(root, ref maxTotal);

        return maxTotal;
    }

    private NodeInfo Solve(TreeNode root, ref int maxTotal)
    {
        // Base case: a null node is a valid BST with sum 0.
        // Min = int.MaxValue so any parent's val will be greater (satisfies left.Max < root.val).
        // Max = int.MinValue so any parent's val will be smaller (satisfies root.val < right.Min).
        if (root == null)
        {
            return new NodeInfo(int.MaxValue, int.MinValue, true, 0);
        }

        // Recurse into left and right children first (post-order)
        NodeInfo left = Solve(root.left, ref maxTotal);
        NodeInfo right = Solve(root.right, ref maxTotal);

        // Check BST validity: both children must be BSTs
        bool isBst = left.IsBst && right.IsBst;

        // BST range check: all values in the left subtree must be < current node,
        // and all values in the right subtree must be > current node
        bool areValuesInRange = left.Max < root.val && root.val < right.Min;

        if (isBst && areValuesInRange)
        {
            // This subtree is a valid BST — compute its range and sum

            // The overall min is either the current node or the smallest in the left subtree
            int currentMin = Math.Min(root.val, left.Min);

            // The overall max is either the current node or the largest in the right subtree
            int currentMax = Math.Max(root.val, right.Max);

            // Total sum of this BST subtree = left sum + current node + right sum
            int size = left.nodeVal + root.val + right.nodeVal;

            // Update global maximum if this BST subtree has a larger sum
            maxTotal = Math.Max(size, maxTotal);

            // Return this subtree's info upward for the parent to use
            return new NodeInfo(currentMin, currentMax, isBst, size);
        }

        // If not a valid BST, return false so no ancestor can form a BST through this node.
        // Min/Max values don't matter here since IsBst is false.
        return new NodeInfo(0, 0, false, 0);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        // Example from LeetCode 1373:
        //        1
        //       / \
        //      4   3        <-- subtree rooted at 3 is a valid BST
        //     / \ / \
        //    2  4 2   5
        //            / \
        //           4   6
        // Input: root = [1,4,3,2,4,2,5,null,null,null,null,null,null,4,6]
        // The largest BST subtree is rooted at node 3: {3, 2, 5, 4, 6}
        // Sum = 3 + 2 + 5 + 4 + 6 = 20
        // Expected output: 20

        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(4);
        root.right = new TreeNode(3);
        root.left.left = new TreeNode(2);
        root.left.right = new TreeNode(4);
        root.right.left = new TreeNode(2);
        root.right.right = new TreeNode(5);
        root.right.right.left = new TreeNode(4);
        root.right.right.right = new TreeNode(6);

        Solution sol = new Solution();
        int result = sol.MaxSumBST(root);
        Console.WriteLine($"Maximum Sum BST: {result}"); // Output: 20
    }
}