

//using System.Timers;

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
//        // We have been given address of the first node in original graph

//        // Step 1 : Create a clone copy of the root node
//        Node cloneRoot = new Node(node.val);

//        // Step 2 : Create a map to store what nodes have been created already and not to be created again
//        // This will also act as a visited array
//        Dictionary<Node, Node> map = new Dictionary<Node, Node>();

//        // Step 3 : Store the create clone node in map
//        map.Add(node, cloneRoot);

//        // Step 4 : We need traversal , so we will go with BFS
//        Queue<Node> q = new Queue<Node>();

//        // Step 5 : Add the root node to the queue
//        q.Enqueue(node);

//        while (q.Count > 0)
//        {
//            Node currentNode = q.Dequeue();

//            // Explore the neigbors 
//            foreach (var neighNodes in currentNode.neighbors)
//            {
//                // Check if the cloned version of neigbhors of this node's clone exist or not
//                if (!map.ContainsKey(neighNodes))
//                {
//                    // Create a clone of this node
//                    Node neighClone = new Node(neighNodes.val);
//                    map.Add(neighNodes, neighClone);
//                    map[currentNode].neighbors.Add(neighClone);
//                    q.Enqueue(neighNodes);
//                }
//                else
//                {
//                    // the clone already exist so perform the join
//                    map[currentNode].neighbors.Add(map[neighNodes]);
//                }
//            }
//        }

//        return cloneRoot;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        Node n1 = new Node(1);
//        Node n2 = new Node(2);
//        Node n3 = new Node(3);
//        Node n4 = new Node(4);

//        n1.neighbors = new List<Node> { n2, n4 };
//        n2.neighbors = new List<Node> { n1, n3 };
//        n3.neighbors = new List<Node> { n4, n2 };
//        n4.neighbors = new List<Node> { n1, n3 };

//        var result = s.CloneGraph(n1);

//    }
//}

////Time and space : O(V + E)