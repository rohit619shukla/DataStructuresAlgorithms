


//class Helper
//{
//    // Time : O(N) , space : O(N)
//    public bool Solve(TNode root)
//    {
//        if (root == null || (root.left == null && root.right == null))
//            return true;

//        bool isSum = (root.data == root.left.data + root.right.data);

//        return isSum && Solve(root.left) && Solve(root.right);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = new TNode(10);
//        root.left = new TNode(4);
//        root.right = new TNode(6);
//        root.left.left = new TNode(2);
//        root.left.right = new TNode(2);

//        Console.WriteLine($"{h.Solve(root)}");
//    }
//}