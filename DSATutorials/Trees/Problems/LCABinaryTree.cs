


//class Helper
//{
//    // Time : O(N) , space : O(N)
//    public TNode Solve(TNode root, TNode p, TNode q)
//    {
//        // If the root is null, return from here
//        if (root == null)
//        {
//            return null;
//        }

//        // If from the list of searching nodes, we found any node return it, no need to go further
//        if (root.data == p.data || root.data == q.data)
//        {
//            return root;
//        }

//        // Iterate left and right side
//        TNode leftSide = Solve(root.left, p, q);
//        TNode rightSide = Solve(root.right, p, q);

//        if (leftSide == null)
//        {
//            return rightSide;
//        }
//        else if (rightSide == null)
//        {
//            return leftSide;
//        }
//        else
//        {
//            return root;
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {

//        Helper h = new Helper();

//        TNode root = new TNode(3);
//        root.left = new TNode(5);
//        root.right = new TNode(1);
//        root.left.left = new TNode(6);
//        root.left.right = new TNode(2);
//        root.left.right.left = new TNode(7);
//        root.left.right.right = new TNode(4);
//        root.right.left = new TNode(0);
//        root.right.right = new TNode(8);

//        TNode p = new TNode(5);
//        TNode q = new TNode(4);

//        var result = h.Solve(root, p, q);

//        Console.WriteLine(result.data);
//    }
//}

//// Time : O(N) , space : O(N)
