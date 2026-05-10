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
//    public void BoundaryTraversal(TreeNode root)
//    {
//        if (root == null) return;

//        // Print the root always to start with
//        Console.Write($"{root.val}" + " ");

//        // We will visit left side first
//        PrintLeftSide(root.left);

//        // Proceed to go for leaf nodes for left side
//        PrintLeafOnly(root.left);

//        // then for leaf nodes for right side
//        PrintLeafOnly(root.right);

//        PrintRightSide(root.right);
//    }

//    private void PrintLeftSide(TreeNode root)
//    {
//        if (root == null) return;

//        // Out target is left is we will only prioritze left first
//        if (root.left != null)
//        {
//            Console.Write($"{root.val}" + " ");
//            PrintLeftSide(root.left);
//        }
//        else if (root.right != null)
//        {
//            // It could be possible that left dont exist for root, then we will try to see if we can get any left node via right of root
//            Console.Write($"{root.val}" + " ");
//            PrintLeftSide(root.right);
//        }
//    }

//    private void PrintLeafOnly(TreeNode root)
//    {
//        if (root == null) return;

//        PrintLeafOnly(root.left);
//        PrintLeafOnly(root.right);

//        if (root.left == null && root.right == null)
//        {
//            Console.Write($"{root.val}" + " ");
//        }
//    }

//    private void PrintRightSide(TreeNode root)
//    {
//        if (root == null) return;

//        if (root.right != null)
//        {
//            PrintRightSide(root.right);
//        }
//        else if (root.left != null)
//        {
//            PrintRightSide(root.left);
//        }

//        if (root.left != null && root.right != null)
//        {
//            Console.Write($"{root.val}" + " ");
//        }
//    }
//}

//class Program
//{
//    public static void Main(string[] args)
//    {
//        // Building the tree from your image:
//        //          1
//        //        /   \
//        //       2     3
//        //      / \   / \
//        //     4   5 6   7
//        //        / \
//        //       8   9

//        TreeNode root = new TreeNode(1);

//        // Left subtree
//        root.left = new TreeNode(2);
//        root.left.left = new TreeNode(4);
//        root.left.right = new TreeNode(5);
//        root.left.right.left = new TreeNode(8);
//        root.left.right.right = new TreeNode(9);

//        // Right subtree
//        root.right = new TreeNode(3);
//        root.right.left = new TreeNode(6);
//        root.right.right = new TreeNode(7);

//        Solution h = new Solution();
//        Console.WriteLine("Boundary Traversal Output:");
//        h.BoundaryTraversal(root);
//    }
//}
