

//class Helper
//{
//    // using Morris traversal
//    // Time : O(n), space : O(1)
//    public int Solve(TNode root, int k)
//    {
//        if (root == null)
//        {
//            return 0;
//        }

//        TNode current = root;
//        TNode prev = null;

//        int count = 0;

//        while (current != null)
//        {
//            if (current.left == null)
//            {
//                count++;
//                if (count == k)
//                {
//                    break;
//                }

//                current = current.right;
//            }
//            else
//            {
//                prev = current.left;

//                while (prev.right != null && prev.right != current)
//                {
//                    prev = prev.right;
//                }

//                if (prev.right == null)
//                {
//                    prev.right = current;
//                    current = current.left;
//                }
//                else
//                {
//                    prev.right = null;
//                    count++;
//                    if (count == k)
//                    {
//                        break;
//                    }
//                    current = current.right;
//                }
//            }
//        }

//        return current.data;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = new TNode(5);
//        root.left = new TNode(3);
//        root.right = new TNode(6);
//        root.left.left = new TNode(2);
//        root.left.left.left = new TNode(1);
//        root.left.right = new TNode(4);

//        Console.WriteLine(h.Solve(root, 3));
//    }
//}

////Time: O(N), space: O(1)