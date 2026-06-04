

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

///// <summary>
///// LeetCode 99 - Recover Binary Search Tree
///// https://leetcode.com/problems/recover-binary-search-tree/
/////
///// Problem:
/////   Two nodes of a BST were swapped by mistake. Recover the tree
/////   without changing its structure.
/////
///// Approach – Morris In-order Traversal:
/////   Morris traversal lets us perform an in-order traversal in O(1) extra
/////   space by temporarily threading the tree (linking the in-order predecessor's
/////   right pointer back to the current node).
/////
/////   During traversal we compare each node with its in-order predecessor.
/////   A violation (prev.val > current.val) indicates a misplaced node.
/////
/////   Two cases arise:
/////     Case 1 – Adjacent swap (one violation):
/////       The two swapped nodes are neighbours in the in-order sequence.
/////       e.g. in-order: 1, [3], [2], 4  →  swap 3 and 2.
/////       We record the first violating pair and swap them at the end.
/////
/////     Case 2 – Non-adjacent swap (two violations):
/////       The two swapped nodes are far apart in the in-order sequence.
/////       e.g. in-order: 1, [7], 3, 4, [2], 6  →  swap 7 and 2.
/////       First violation gives us the larger misplaced node (7).
/////       Second violation gives us the smaller misplaced node (2).
/////
///// Time  Complexity: O(n) – even though this is a BST, we perform a
/////   Morris in-order traversal which visits every node in the tree.
///// Space Complexity: O(1) – only a fixed number of pointers are used;
/////   no recursion stack or auxiliary data structure is needed.
///// </summary>
//public class Solution
//{
//    public void RecoverTree(TreeNode root)
//    {
//        // We will use Morris traversal to perform inorder traversal.
//        // This will help us to get the count of abnormality
//        // There could be 2 cases :
//        // 1. More than 1 places having abnormality
//        // 2. Only 1 place have abnormality

//        TreeNode head = root;

//        // to keep track of number of violations, this will help in determining the above 2 cases
//        int count = 0;

//        TreeNode prev = null;
//        TreeNode prevViolatedNode = null;
//        TreeNode immediatedToPreToViolatedNode = null;
//        TreeNode nextViolatedNode = null;

//        while (head != null)
//        {
//            if (head.left != null)
//            {
//                TreeNode temp = head.left;

//                while (temp.right != null && temp.right != head)
//                {
//                    temp = temp.right;
//                }

//                if (temp.right == null)
//                {
//                    temp.right = head;
//                    head = head.left;
//                }
//                else
//                {
//                    temp.right = null;
//                    // wherever we print we keep incrementing the count
//                    TrackNodes(prev, head, ref prevViolatedNode, ref immediatedToPreToViolatedNode, ref nextViolatedNode, ref count);
//                    prev = head;
//                    Console.WriteLine($"{head.val}");
//                    head = head.right;
//                }
//            }
//            else
//            {
//                // wherever we print we keep incrementing the count
//                // wherever we print we keep incrementing the count
//                TrackNodes(prev, head, ref prevViolatedNode, ref immediatedToPreToViolatedNode, ref nextViolatedNode, ref count);
//                prev = head;
//                Console.WriteLine($"{head.val}");
//                head = head.right;
//            }
//        }

//        // Only adjacent violations exist
//        if (count == 1)
//        {
//            SwapNodes(prevViolatedNode, immediatedToPreToViolatedNode);
//        }
//        else
//        {
//            // Non adjacent violations exist
//            SwapNodes(prevViolatedNode, nextViolatedNode);
//        }
//    }

//    private void SwapNodes(TreeNode a, TreeNode b)
//    {
//        int temp = a.val;
//        a.val = b.val;
//        b.val = temp;
//    }

//    private void TrackNodes(TreeNode prev, TreeNode head, ref TreeNode prevViolatedNode, ref TreeNode immediatedToPreToViolatedNode, ref TreeNode nextViolatedNode, ref int count)
//    {
//        if (prev != null && prev.val > head.val && count == 0)
//        {
//            prevViolatedNode = prev;
//            immediatedToPreToViolatedNode = head;
//            count++;
//        }
//        else if (prev != null && prev.val > head.val && count == 1)
//        {
//            nextViolatedNode = head;
//            count++;
//        }
//    }
//}


//class Graph
//{
//    public static void Main()
//    {
//        Solution s = new Solution();
//        TreeNode root = new TreeNode(1);
//        //root.left = new TreeNode(10);
//        //root.right = new TreeNode(2);
//        //root.left.left = new TreeNode(1);
//        //root.left.right = new TreeNode(3);
//        //root.right.left = new TreeNode(7);
//        //root.right.right = new TreeNode(12);

//        root.left = new TreeNode(2);
//        root.right = new TreeNode(3);

//        s.RecoverTree(root);
//    }
//}