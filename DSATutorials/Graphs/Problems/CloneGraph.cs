
//public class Node
//{
//    public int val;
//    public IList<Node> neighbors;

//    public Node(int _val)
//    {
//        val = _val;
//        neighbors = new List<Node>();
//    }
//}

//public class Solution
//{
//    public Node CloneGraph(Node node)
//    {
//        // Step 1 : Check if the node is itself empty or not
//        if (node == null)
//        {
//            return node;
//        }

//        // Step 2 : Clone the Root node to begin the cloning with
//        Node clonedRoot = new Node(node.val);

//        // Step 3 : Create a Map to store what nodes have been created and their cloned references
//        Dictionary<Node, Node> map = new Dictionary<Node, Node>();

//        // Step 4 : Add the root node already int set, the map also seves as a visited array
//        map[node] = clonedRoot;

//        // Step 5 : Create a queue for BFS
//        Queue<Node> q = new Queue<Node>();

//        q.Enqueue(node);

//        while (q.Count > 0)
//        {
//            Node root = q.Dequeue();

//            // Step 6 : Explore the neighbors of the given node
//            foreach (var neighNode in root.neighbors)
//            {
//                if (!map.ContainsKey(neighNode))
//                {
//                    // This is a fresh node in traversal
//                    Node clonedNeighNode = new Node(neighNode.val);
//                    map[neighNode] = clonedNeighNode;
//                    map[root].neighbors.Add(clonedNeighNode);
//                    q.Enqueue(neighNode);
//                }
//                else
//                {
//                    // clone already exist we just need to add the link
//                    map[root].neighbors.Add(map[neighNode]);
//                }
//            }
//        }

//        return clonedRoot;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Node n1 = new Node(1);
//        Node n2 = new Node(2);
//        Node n3 = new Node(3);
//        Node n4 = new Node(4);


//        n1.neighbors = new List<Node> { n2, n4 };
//        n2.neighbors = new List<Node> { n1, n3 };
//        n3.neighbors = new List<Node> { n4, n2 };
//        n4.neighbors = new List<Node> { n1, n3 };

//        Solution s = new Solution();

//        var result = s.CloneGraph(n1);

//    }
//}