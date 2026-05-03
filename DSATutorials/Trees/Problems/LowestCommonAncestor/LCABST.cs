
//class Helper
//{
//    // Time : O(H), space : O(1)
//    public TNode Solve(TNode root, TNode p, TNode q)
//    {
//        TNode result = null;

//        while (root != null)
//        {
//            result = root;

//            if (root.data > p.data && root.data > q.data)
//            {
//                root = root.left;
//            }
//            else if (root.data < p.data && root.data < q.data)
//            {
//                root = root.right;
//            }
//            else
//            {
//                break;
//            }
//        }

//        return result;
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = new TNode(6);
//        root.left = new TNode(2);
//        root.right = new TNode(8);
//        root.left.left = new TNode(0);
//        root.left.right = new TNode(4);
//        root.left.right.left = new TNode(3);
//        root.left.right.right = new TNode(5);
//        root.right.left = new TNode(7);
//        root.right.right = new TNode(8);


//        TNode p = new TNode(2);
//        TNode q = new TNode(8);

//        var result = h.Solve(root, p, q);

//        Console.WriteLine(result.data);
//    }
//}