

//public class GraphColoring
//{
//    public bool Solve(List<int>[] adjList, int m, int v, int startNode, int[] color)
//    {
//        // Base case: if all nodes are colored, return true
//        if (startNode == v)
//        {
//            return true;
//        }

//        // Try to color the current node with all possible colors
//        for (int i = 1; i <= m; i++)
//        {
//            if (IsPossible(adjList, i, color, startNode))
//            {
//                // Assign the color to the current node
//                color[startNode] = i;

//                // Recur to color the next node
//                if (Solve(adjList, m, v, startNode + 1, color))
//                {
//                    return true;
//                }

//                // Backtrack: if it was not possible to color the node, reset the color
//                color[startNode] = 0;
//            }
//        }

//        return false; // No color assignment is possible
//    }

//    private bool IsPossible(List<int>[] adjList, int toBeColor, int[] color, int currentNode)
//    {
//        // Check all neighbors of the current node
//        foreach (var neighbor in adjList[currentNode])
//        {
//            if (color[neighbor] == toBeColor)
//            {
//                return false; // If any neighbor has the same color, return false
//            }
//        }
//        return true;
//    }

//    public static void Main()
//    {
//        // Example graph with 4 vertices (0-based index)
//        int v = 4;
//        List<int>[] adjList = new List<int>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adjList[i] = new List<int>();
//        }

//        // Add edges to the graph
//        adjList[0].Add(1);
//        adjList[1].Add(0);
//        adjList[1].Add(2);
//        adjList[2].Add(1);
//        adjList[2].Add(3);
//        adjList[3].Add(2);

//        // Number of colors
//        int m = 3;

//        // Array to store colors assigned to each node
//        int[] color = new int[v];

//        GraphColoring gc = new GraphColoring();

//        if (gc.Solve(adjList, m, v, 0, color))
//        {
//            Console.WriteLine("Solution exists with the following colors:");
//            for (int i = 0; i < v; i++)
//            {
//                Console.WriteLine($"Vertex {i}: Color {color[i]}");
//            }
//        }
//        else
//        {
//            Console.WriteLine("No solution exists.");
//        }
//    }
//}


//// Time : O(M^V *V) , for each verstx v we can have m possibilities.
//// Space : O(V+E) dues to adjacency List