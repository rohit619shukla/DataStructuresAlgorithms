//// LeetCode 653: Two Sum IV - Input is a BST
//// https://leetcode.com/problems/two-sum-iv-input-is-a-bst/
////
//// Key Idea:
////   - Use a two-pointer approach on a BST via two BSTIterators:
////     s1 (forward/inorder) starts from the smallest node (leftmost),
////     s2 (reverse/inorder) starts from the largest node (rightmost).
////   - Compare sum of both pointers with target k:
////     sum == k → found the pair, return true
////     sum > k  → move the right pointer inward (Next2)
////     sum < k  → move the left pointer inward (Next1)
////   - Terminate when pointers cross (n1 >= n2) — no valid pair exists.
////
//// Why BSTIterator over array?
////   - Flattening the BST into a sorted array first would cost O(n) space.
////   - Using two stacks (one per direction), each stores at most O(h) nodes
////     at any time, giving us O(h) space overall.
////
//// Time:  O(n) total — each node is pushed/popped exactly once across all
////        Next1()/Next2() calls → O(1) amortized per call.
//// Space: O(h) — two stacks each holding at most h nodes (O(2h) = O(h))

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
//    public bool FindTarget(TreeNode root, int k)
//    {
//        if (root.left == null && root.right == null) return false;
//        // We could have done an inroder traversal and add the nodes in an arrayy and performed two sum stuff.
//        // But that would need additional space of size O(n)
//        // Hence will will go with the approach of BSTIterator
//        BSTIterator bst = new BSTIterator(root);

//        while (bst.s1.Count > 0 && bst.s2.Count > 0)
//        {
//            int n1 = bst.s1.Peek().val;
//            int n2 = bst.s2.Peek().val;

//            int sum = n1 + n2;

//            if (n1 >= n2) return false;

//            if (sum == k)
//            {
//                return true;
//            }

//            // Lower the greater part
//            if (sum > k)
//            {
//                bst.Next2();
//            }
//            else
//            {
//                // increase the lower part
//                bst.Next1();
//            }
//        }

//        return false;
//    }
//}

//public class BSTIterator
//{
//    public Stack<TreeNode> s1 = new Stack<TreeNode>();
//    public Stack<TreeNode> s2 = new Stack<TreeNode>();

//    public BSTIterator(TreeNode root)
//    {
//        // We will fill both the stack simultaneoulsy in opposite fashion
//        s1.Push(root);
//        s2.Push(root);

//        TreeNode temp1 = root;
//        TreeNode temp2 = root;

//        while (temp1.left != null)
//        {
//            s1.Push(temp1.left);
//            temp1 = temp1.left;
//        }

//        while (temp2.right != null)
//        {
//            s2.Push(temp2.right);
//            temp2 = temp2.right;
//        }
//    }

//    // When called will give the next from from left side onwards
//    public int Next1()
//    {
//        int result = 0;

//        if (s1.Count > 0)
//        {
//            TreeNode topNode = s1.Pop();

//            result = topNode.val;

//            if (topNode.right != null)
//            {
//                s1.Push(topNode.right);
//                TreeNode temp = topNode.right;

//                while (temp.left != null)
//                {
//                    s1.Push(temp.left);
//                    temp = temp.left;
//                }
//            }
//        }

//        return result;
//    }

//    // When called will give the next from from right side onwards
//    public int Next2()
//    {
//        int result = 0;
//        if (s2.Count > 0)
//        {
//            TreeNode topNode = s2.Pop();

//            result = topNode.val;

//            if (topNode.left != null)
//            {
//                s2.Push(topNode.left);
//                TreeNode temp = topNode.left;

//                while (temp.right != null)
//                {
//                    s2.Push(temp.right);
//                    temp = temp.right;
//                }
//            }
//        }

//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {


//        // Input: root = [2,null,3], k = 6
//        // Expected: false

//        TreeNode root = new TreeNode(2);
//        root.right = new TreeNode(3);

//        Solution sol = new Solution();
//        Console.WriteLine(sol.FindTarget(root, 6)); // False
//    }
//}
