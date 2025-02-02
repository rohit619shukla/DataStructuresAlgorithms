

//class Helper
//{
//    // Time : O(n), space: O(n)
//    public int Solve(TNode root, ref int max)
//    {
//        if (root == null)
//        {
//            return 0;
//        }

//        int leftSum = Math.Max(0, Solve(root.left, ref max));
//        int rightSum = Math.Max(0, Solve(root.right, ref max));

//        max = Math.Max(max, leftSum + rightSum + root.data);

//        return root.data + Math.Max(leftSum, rightSum);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = new TNode(-3);
//        //root.left = new TNode(9);
//        //root.right = new TNode(20);
//        //root.right.left = new TNode(15);
//        //root.right.right = new TNode(7);

//        int max = int.MinValue;

//        h.Solve(root, ref max);

//        Console.WriteLine(max);
//    }
//}