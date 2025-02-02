
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
//        if (node == null)
//        {
//            return null;
//        }
//        Dictionary<Node, Node> map = new Dictionary<Node, Node>();
//        Queue<Node> q = new Queue<Node>();
//        q.Enqueue(node);
//        Node cloneNode = new Node(node.val);
//        map[node] = cloneNode;
//        while (q.Count > 0)
//        {
//            Node currentNode = q.Dequeue();
//            foreach (var neigh in currentNode.neighbors)
//            {
//                // If the node is not in map create its clone
//                if (!map.ContainsKey(neigh))
//                {
//                    Node neighCloneNode = new Node(neigh.val);
//                    map[neigh] = neighCloneNode;
//                    q.Enqueue(neigh);
//                }
//                map[currentNode].neighbors.Add(map[neigh]);
//            }
//        }
//        return cloneNode;
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

//        // lets  build connections
//        n1.neighbors = new List<Node> { n2, n4 };
//        n2.neighbors = new List<Node> { n1, n3 };
//        n3.neighbors = new List<Node> { n2, n4 };
//        n4.neighbors = new List<Node> { n3, n1 };

//        var root = s.CloneGraph(n1);
//    }
//}

//// Time and space : O(V+E)