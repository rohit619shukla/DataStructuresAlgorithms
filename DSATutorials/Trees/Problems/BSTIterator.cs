
//class Solution
//{
//    private Stack<TNode> st;
//    public Solution(TNode root)
//    {
//        st = new Stack<TNode>();
//        PushData(root);
//    }

//    public void PushData(TNode root)
//    {
//        while (root != null)
//        {
//            st.Push(root);
//            root = root.left;
//        }
//    }

//    public bool HasNext()
//    {
//        return st.Count() > 0;
//    }

//    public TNode Next()
//    {
//        TNode node = st.Pop();
//        PushData(node.right);
//        return node;
//    }
//}
//class Program
//{
//    public static void Main()
//    {

//        TNode root = new TNode(7);
//        root.left = new TNode(3);
//        root.right = new TNode(15);
//        root.right.left = new TNode(9);
//        root.right.right = new TNode(20);

//        Solution s = new Solution(root);

//        while (s.HasNext())
//        {
//            Console.Write($"{s.Next().data}" + " ");
//        }
//    }
//}