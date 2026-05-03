

//class Helper
//{
//    // Time : O(n), space : O(h) best case and  O(n) worst case
//    public int Solve(TNode root, int val)
//    {
//        if (root == null)
//        {
//            return 0;
//        }

//        val = val * 10 + root.data;

//        if (root.left == null && root.right == null)
//        {
//            // What ever sum we have gathered till now just return
//            return val;
//        }

//        return Solve(root.left, val) + Solve(root.right, val);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = new TNode(1);
//        root.left = new TNode(2);
//        root.right = new TNode(3);
//        root.right.left = new TNode(4);
//        root.right.right = new TNode(5);


//        Console.WriteLine(h.Solve(root, 0));
//    }
//}