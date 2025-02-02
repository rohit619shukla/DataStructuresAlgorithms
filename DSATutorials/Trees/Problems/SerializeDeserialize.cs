

//using System.Text;

//// Time : O(n), space : O(n)
//class Helper
//{
//    // Serialize is a process of converting Tree Nodes to string
//    public string Serialize(TNode root)
//    {
//        StringBuilder st = new StringBuilder();

//        Queue<TNode> q = new Queue<TNode>();

//        q.Enqueue(root);

//        st.Append(root.data.ToString() + ",");

//        while (q.Count > 0)
//        {
//            TNode temp = q.Dequeue();

//            if (temp.left != null)
//            {
//                q.Enqueue(temp.left);
//                st.Append(temp.left.data.ToString() + ",");
//            }
//            else
//            {
//                st.Append("#,");
//            }

//            if (temp.right != null)
//            {
//                q.Enqueue(temp.right);
//                st.Append(temp.right.data.ToString() + ",");
//            }
//            else
//            {
//                st.Append("#,");
//            }
//        }

//        st.Length--;

//        return st.ToString();

//    }

//    public TNode DeSerialize(string serialzedString)
//    {
//        string[] strArray = serialzedString.Split(",");

//        TNode root = new TNode(Convert.ToInt32(strArray[0]));

//        Queue<TNode> q = new Queue<TNode>();

//        q.Enqueue(root);

//        // Special BFS. Here we are jumping 2 nodes kind of as there can be atmost 2 nodes in binary tree.
//        // We use queue to keep track of the fact like which node can be appended to left and right
//        for (int i = 1; i < strArray.Length; i++)
//        {
//            TNode temp = q.Dequeue();

//            if (strArray[i] != "#")
//            {
//                TNode left = new TNode(Convert.ToInt32(strArray[i]));
//                temp.left = left;
//                q.Enqueue(left);
//            }

//            if (strArray[++i] != "#")
//            {
//                TNode right = new TNode(Convert.ToInt32(strArray[i]));
//                temp.right = right;
//                q.Enqueue(right);
//            }
//        }

//        return root;

//    }
//    public void PreOrder(TNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Console.Write($"{root.data}" + " ");
//        PreOrder(root.left);
//        PreOrder(root.right);
//    }

//}


//class Program
//{
//    public static void Main()
//    {
//        TNode root = new TNode(1);
//        root.left = new TNode(2);
//        root.right = new TNode(3);
//        root.right.left = new TNode(4);
//        root.right.right = new TNode(5);

//        Helper h = new Helper();

//        string result = h.Serialize(root);

//        TNode deserializedRoot = h.DeSerialize(result);

//        h.PreOrder(deserializedRoot);
//    }
//}