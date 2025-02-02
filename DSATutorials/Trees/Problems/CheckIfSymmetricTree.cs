
// class Helper
// {
//    // Time : O(N), space : O(N)
//    public bool Solve(TNode root)
//    {
//        if (root == null)
//        {
//            return true;
//        }

//        return CheckSymmetry(root.left, root.right);
//    }

//    private bool CheckSymmetry(TNode root1, TNode root2)
//    {
//        if (root1 == null || root2 == null)
//        {
//            return root1 == root2;
//        }

//        return (root1.data == root2.data
//        && CheckSymmetry(root1.left, root2.right)
//        && CheckSymmetry(root1.right, root2.left));
//    }
// }
// class Program
// {
//    public static void Main()
//    {
//        TNode root = new TNode(1);
//        root.left = new TNode(2);
//        root.left = new TNode(3);
//     //    root.left.right = new TNode(3);
//     //    root.right.right = new TNode(3);
//        //root.left.left = new TNode(3);
//        //root.left.right = new TNode(4);
//        //root.right.left = new TNode(4);
//        //root.right.right = new TNode(3);

//        Helper h = new Helper();

//        Console.WriteLine(h.Solve(root));
//    }
// }