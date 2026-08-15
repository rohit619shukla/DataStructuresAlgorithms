//// LeetCode 173: Binary Search Tree Iterator
//// https://leetcode.com/problems/binary-search-tree-iterator/
////
//// Key Idea:
////   - Inorder traversal of a BST gives nodes in sorted (ascending) order.
////   - Instead of flattening the entire tree upfront (O(n) space), we use a stack
////     to simulate the inorder traversal lazily — pushing only the left spine at a time.
////   - This keeps space at O(h) where h = height of the tree.
////
//// How it works:
////   1. Constructor: Push root and all its left children onto the stack.
////      Stack top is always the next smallest element.
////   2. Next(): Pop the top (smallest unvisited node). If it has a right child,
////      push that right child and its entire left spine — this sets up the next
////      smallest element.
////   3. HasNext(): Simply check if the stack is non-empty.
////
//// Time:  Next() — O(h) worst case for a single call (the while loop can push up to h nodes),
////                  but O(1) amortized across all N calls.
////                  Why? Each node is pushed exactly once and popped exactly once over the
////                  lifetime of the iterator. So total work = 2N across N calls → O(1) per call.
////        HasNext() — O(1)
//// Space: O(h) where h = height of the BST

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


//public class BSTIterator
//{
//    Stack<TreeNode> st = new Stack<TreeNode>();

//    public BSTIterator(TreeNode root)
//    {
//        // Push the root and its entire left spine onto the stack
//        st.Push(root);
//        while (root.left != null)
//        {
//            st.Push(root.left);
//            root = root.left;
//        }
//    }

//    public int Next()
//    {
//        int result = 0;

//        if (st.Count > 0)
//        {
//            // Pop the next smallest node
//            TreeNode node = st.Pop();
//            result = node.val;

//            // If it has a right subtree, push right child and its entire left spine
//            if (node.right != null)
//            {
//                st.Push(node.right);
//                TreeNode temp = node.right;

//                while (temp.left != null)
//                {
//                    st.Push(temp.left);
//                    temp = temp.left;
//                }
//            }
//        }

//        return result;
//    }

//    public bool HasNext()
//    {
//        return st.Count > 0 ? true : false;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        // Input: [7, 3, 15, null, null, 9, 20]
//        // Operations: ["BSTIterator", "next", "next", "hasNext", "next", "hasNext", "next", "hasNext", "next", "hasNext"]
//        // Expected:   [null, 3, 7, true, 9, true, 15, true, 20, false]

//        TreeNode root = new TreeNode(7);
//        root.left = new TreeNode(3);
//        root.right = new TreeNode(15);
//        root.right.left = new TreeNode(9);
//        root.right.right = new TreeNode(20);

//        BSTIterator iterator = new BSTIterator(root);
//        Console.WriteLine(iterator.Next());      // 3
//        Console.WriteLine(iterator.Next());      // 7
//        Console.WriteLine(iterator.HasNext());   // True
//        Console.WriteLine(iterator.Next());      // 9
//        Console.WriteLine(iterator.HasNext());   // True
//        Console.WriteLine(iterator.Next());      // 15
//        Console.WriteLine(iterator.HasNext());   // True
//        Console.WriteLine(iterator.Next());      // 20
//        Console.WriteLine(iterator.HasNext());   // False
//    }
//}