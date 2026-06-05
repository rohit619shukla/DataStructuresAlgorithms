///// LeetCode 108: Convert Sorted Array to Binary Search Tree
///// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
/////
///// Problem:
/////   Given an integer array sorted in ascending order, convert it to a
/////   height-balanced Binary Search Tree (BST).
/////
///// Approach – Recursive Binary Split (Divide and Conquer):
/////   Since the array is already sorted, the middle element naturally becomes
/////   the root to ensure the tree is height-balanced. We recursively do the
/////   same for the left half (left subtree) and right half (right subtree).
/////
///// Time  Complexity: O(n) – every element is visited exactly once to create a node.
///// Space Complexity: O(log n) – auxiliary space from the recursion stack.
/////                   The tree is height-balanced (always splitting at mid),
/////                   so the max recursion depth is log n.
/////                   (The O(n) output tree itself is excluded as it is the required output.)

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

public class Solution
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return Solve(nums, 0, nums.Length-1);
    }

    private TreeNode Solve(int[] nums, int start, int end)
    {
        // Base case: no elements in this range, return null (empty subtree)
        if (start > end) return null;

        // Pick the middle element as root to ensure height-balanced BST
        int mid = start + (end - start) / 2;
        TreeNode root = new TreeNode(nums[mid]);

        // Recursively build left subtree from left half and right subtree from right half
        root.left = Solve(nums, start, mid - 1);
        root.right = Solve(nums, mid + 1, end);

        return root;
    }
}

class Program
{
    public static void Main()
    {
        int[] nums = { -10, -3, 0, 5, 9 };


        Solution s = new Solution();

        var result = s.SortedArrayToBST(nums);
    }
}