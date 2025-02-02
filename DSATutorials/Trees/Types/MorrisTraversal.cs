
//class Solution
//{
//    public void Solve(TNode root)
//    {

//        TNode curr = root;
//        TNode temp = null;

//        while (curr != null)
//        {
//            if (curr.left == null)
//            {
//                Console.Write($"{curr.data}" + " ");
//                curr = curr.right;
//            }
//            else
//            {
//                temp = curr.left;

//                while (temp.right != null && temp.right != curr)
//                {
//                    temp = temp.right;
//                }
                    
//                if (temp.right == null)
//                {
//                    temp.right = curr;
//                    curr = curr.left;
//                }
//                else
//                {
//                    Console.Write($"{curr.data}" + " ");
//                    temp.right = null;
//                    curr = curr.right;
//                }
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution h = new Solution();

//        TNode root = new TNode(4);
//        root.left = new TNode(2);
//        root.right = new TNode(5);
//        root.left.left = new TNode(1);
//        root.left.right = new TNode(3);

//        h.Solve(root);
//    }
//}

// Timeo : O(2N) =: O(n+n) , as each node is processed ony twice, space : O(1)