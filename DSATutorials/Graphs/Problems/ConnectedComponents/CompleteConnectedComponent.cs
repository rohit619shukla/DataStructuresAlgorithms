

//public class Solution
//{
//    public int CountCompleteComponents(int n, int[][] edges)
//    {
//        // Create a parent and size array
//        int[] parent = new int[n];
//        int[] size = new int[n];

//        // Map to store number of edges count per group post union find
//        Dictionary<int, int> map = new Dictionary<int, int>();

//        int result = 0;

//        for (int i = 0; i < n; i++)
//        {
//            parent[i] = i;
//            size[i] = 1;
//        }

//        for (int i = 0; i < edges.Length; i++)
//        {
//            // to fill the parent and size
//            UnionBySize(edges[i][0], edges[i][1], parent, size);
//        }

//        // Fill the map for how many edges per region
//        for (int i = 0; i < edges.Length; i++)
//        {
//            int[] currentEdge = edges[i];

//            int parentInCurrentEdge = FindParent(currentEdge[0], parent);
//            if (map.ContainsKey(parentInCurrentEdge))
//            {
//                map[parentInCurrentEdge]++;
//            }
//            else
//            {
//                map.Add(parentInCurrentEdge, 1);
//            }
//        }

//        for (int i = 0; i < n; i++)
//        {
//            int currentParent = FindParent(i, parent);

//            // Get how many vertices, per cluster
//            if (currentParent == i)
//            {
//                // Means it has more than 1 vertices per cluster
//                if (map.ContainsKey(currentParent))
//                {
//                    int currentEdges = map[currentParent];

//                    int vertices = size[currentParent];

//                    if (vertices * (vertices - 1) / 2 == currentEdges)
//                    {
//                        result++;
//                    }
//                }
//                else
//                {
//                    // An individual node is also a completely connected component
//                    result++;
//                }
//            }

//        }


//        return result;
//    }

//    private int FindParent(int node, int[] parent)
//    {
//        if (node == parent[node])
//        {
//            return node;
//        }

//        return parent[node] = FindParent(parent[node], parent);
//    }

//    private void UnionBySize(int node1, int node2, int[] parent, int[] size)
//    {
//        int parent1 = FindParent(node1, parent);
//        int parent2 = FindParent(node2, parent);

//        if (parent1 == parent2)
//        {
//            return;
//        }

//        if (size[parent1] > size[parent2])
//        {
//            size[parent1] += size[parent2];
//            parent[parent2] = parent1;
//        }
//        else
//        {
//            size[parent2] += size[parent1];
//            parent[parent1] = parent2;
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int n = 6;

//        int[][] edges = {
//            new int[] { 0,1},
//            new int[] { 0,2},
//            new int[] { 1,2},
//            new int[] { 3,4},
//            new int[] { 3,5}
//        };

//        Solution s = new Solution();

//        Console.WriteLine($"{s.CountCompleteComponents(n, edges)}");
//    }
//}

//// Time  : O(E * Aplha(v) + v)