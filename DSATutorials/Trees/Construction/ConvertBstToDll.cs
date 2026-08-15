
//class Solution
//{
//    public void Solve(TNode root, ref TNode head)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        // Keep going right. We will build the DLL from reverse BST order starting in descending
//        Solve(root.right, ref head);

//        // Assign the head of DLL to the current root's right
//        root.right = head;

//        // if head exist buidl backward realtion with temp
//        if (head != null)
//        {
//            head.left = root;
//        }

//        // Make head from current root
//        head = root;

//        // keep going left
//        Solve(root.left, ref head);
//    }

//    public void PrintDLL(TNode root)
//    {
//        TNode temp = root;

//        while (temp != null)
//        {
//            Console.Write($"{temp.data}" + " ");
//            temp = temp.right;
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        TNode root = new TNode(13);
//        root.left = new TNode(8);
//        root.left.left = new TNode(5);
//        root.left.right = new TNode(12);
//        root.right = new TNode(20);
//        root.right.left = new TNode(14);
//        root.right.right = new TNode(22);

//        TNode head = null;

//        Solution h = new Solution();
//        h.Solve(root, ref head);

//        h.PrintDLL(head);
//    }
//}

//// Complexity : O(N), space :O(N)