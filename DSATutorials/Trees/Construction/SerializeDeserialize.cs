
//using System.Text;

//public class TreeNode
//{
//    public TreeNode left;
//    public TreeNode right;
//    public int val;

//    public TreeNode(int data)
//    {
//        val = data;
//    }
//}

//public class Codec
//{

//    // Encodes a tree to a single string.
//    public string serialize(TreeNode root)
//    {
//        StringBuilder st = new StringBuilder();

//        // 1. We will performa a level order traversal to store the nodes in stringbuilder
//        Queue<TreeNode> q = new Queue<TreeNode>();

//        q.Enqueue(root);
//        st.Append(root.val).Append(",");

//        while (q.Count > 0)
//        {
//            TreeNode head = q.Dequeue();

//            if (head.left != null)
//            {
//                // We will add the node to builder while we are exploring
//                q.Enqueue(head.left);
//                st.Append(head.left.val).Append(",");
//            }
//            else
//            {
//                // We cannot add to queue, but directly to builder
//                st.Append("#,");
//            }

//            if (head.right != null)
//            {
//                q.Enqueue(head.right);
//                st.Append(head.right.val).Append(",");
//            }
//            else
//            {
//                st.Append("#,");
//            }
//        }

//        st.Length--;

//        return st.ToString();
//    }

//    //// Decodes your encoded data to tree.
//    public TreeNode deserialize(string data)
//    {
//        TreeNode root = null;

//        if (string.IsNullOrEmpty(data))
//        {
//            return root;
//        }

//        string[] arr = data.Split(",");

//        // We will take the very first character of the string and make it as root
//        root = new TreeNode(Convert.ToInt32(arr[0]));

//        Queue<TreeNode> q = new Queue<TreeNode>();
//        q.Enqueue(root);

//        // We start with 1 as we have already created root out of the first char
//        // This is a special BFS using for loop rather than while loop
//        for (int i = 1; i < arr.Length; i++)
//        {
//            TreeNode head = q.Dequeue();

//            if (arr[i] != "#")
//            {
//                head.left = new TreeNode(Convert.ToInt32(arr[i]));
//                q.Enqueue(head.left);
//            }

//            if (arr[++i] != "#")
//            {
//                head.right = new TreeNode(Convert.ToInt32(arr[i]));
//                q.Enqueue(head.right);
//            }
//        }

//        return root;

//    }

    
//}

//class Program
//{
//    public static void Main(string[] args)
//    {
//        //        1
//        //       / \
//        //      2   3
//        //         / \
//        //        4   5
//        TreeNode root = new TreeNode(-1);
//        root.left = new TreeNode(0);
//        root.right = new TreeNode(1);
//        //root.right.left = new TreeNode(4);
//        //root.right.right = new TreeNode(5);

//        Codec codec = new Codec();
//        string serialized = codec.serialize(root);
//        Console.WriteLine("Serialized: " + serialized);

//        TreeNode deserialized = codec.deserialize(serialized);
//        string reSerialized = codec.serialize(deserialized);
//        Console.WriteLine("Re-serialized: " + reSerialized);
//    }
//}

//// Time : O(n), space : O(n)