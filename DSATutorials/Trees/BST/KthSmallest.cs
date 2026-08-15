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
//    public int KthSmallest(TreeNode root, int k)
//    {
//        // We will perform Morris Traversal, as traverses the tree in O(1) space and with inorder sequence which is good for BST

//        TreeNode head = root;

//        int count = 0;
//        while (head != null)
//        {
//            // check if the left side exist or not
//            if (head.left != null)
//            {
//                // Now put a pointer at left and move to left's right
//                TreeNode temp = head.left;

//                while (temp.right != null && temp.right != head)
//                {
//                    temp = temp.right;
//                }

//                // If the temp is  null means that we are visiting this first time
//                if (temp.right == null)
//                {
//                    temp.right = head;
//                    head = head.left;
//                }
//                else
//                {
//                    temp.right = null;
//                    // we print the head's value
//                    count++;
//                    if (count == k)
//                    {
//                        break;
//                    }
//                    head = head.right;
//                }
//            }
//            else
//            {
//                // No left exist
//                // Print the head and move to right
//                count++;
//                if (count == k)
//                {
//                    break;
//                }
//                head = head.right;
//            }
//        }

//        return head.val;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        // Input: root = [5,3,6,2,4,null,null,1], k = 3
//        TreeNode root = new TreeNode(5);
//        root.left = new TreeNode(3);
//        root.right = new TreeNode(6);
//        root.left.left = new TreeNode(2);
//        root.left.right = new TreeNode(4);
//        root.left.left.left = new TreeNode(1);

//        int k = 3;

//        Solution sol = new Solution();
//        int result = sol.KthSmallest(root, k);
//        Console.WriteLine($"Input: root = [5,3,6,2,4,null,null,1], k = {k}");
//        Console.WriteLine($"Output: {result}");
//    }
//}

////Time: O(N), space: O(1)