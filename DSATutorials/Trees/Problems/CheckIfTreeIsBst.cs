
//class Solution
//{
//    public bool IsValidBST(TNode root)
//    {
//        if (root == null)
//        {
//            return true;
//        }


//        TNode curr = root;
//        TNode prev = null;

//        int? tempNumber = null;

//        while (curr != null)
//        {
//            if (curr.left == null)
//            {
//                Console.Write($"{curr.data}" + " ");

//                if (tempNumber != null && tempNumber >= curr.data)
//                {
//                    return false;
//                }
//                tempNumber = curr.data;

//                curr = curr.right;
//            }
//            else
//            {
//                prev = curr.left;

//                while (prev.right != null && prev.right != curr)
//                {
//                    prev = prev.right;
//                }

//                if (prev.right == null)
//                {
//                    prev.right = curr;
//                    curr = curr.left;
//                }
//                else
//                {
//                    prev.right = null;
//                    Console.Write($"{curr.data}" + " ");

//                    if (tempNumber != null && tempNumber >= curr.data)
//                    {
//                        return false;
//                    }
//                    tempNumber = curr.data;

//                    curr = curr.right;
//                }
//            }
//        }

//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution h = new Solution();

//        TNode root = new TNode(5);
//        root.left = new TNode(2);
//        root.right = new TNode(4);
//        root.right.left = new TNode(3);
//        root.right.right = new TNode(6);

//        Console.WriteLine(h.IsValidBST(root));
//    }
//}


//// Time : O(N), space : O(1)

//// At any given point of time if the temp is grater then current we return false;
//// Whenever we are printing a number in Travseral just check above line, else assing temp with current number