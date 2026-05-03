

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

//class Solution
//{
//    public void Solve(TreeNode root)
//    {
//        TreeNode currNode = root;

//        while (currNode != null)
//        {
//            if (currNode.left != null)
//            {
//                TreeNode temp = currNode.left;

//                while (temp.right != null && temp.right != currNode)
//                {
//                    temp = temp.right;
//                }

//                if (temp.right == null)
//                {
//                    temp.right = currNode;
//                    currNode = currNode.left;
//                }
//                else
//                {
//                    Console.Write($"{currNode.val}" + " ");
//                    temp.right = null;
//                    currNode = currNode.right;
//                }
//            }
//            else
//            {
//                Console.Write($"{currNode.val}" + " ");
//                currNode = currNode.right;
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution h = new Solution();

//        TreeNode root = new TreeNode(4);
//        root.left = new TreeNode(2);
//        root.right = new TreeNode(5);
//        root.left.left = new TreeNode(1);
//        root.left.right = new TreeNode(3);

//        h.Solve(root);

//    }
//}

////Time: O(2N) =: O(n + n) , as each node is processed ony twice, space : O(1)