

//class Solution
//{
//    public void Kruskals(int v, int[][] edges)
//    {
//        // 1. Sort the edges based on weight
//        Array.Sort(edges, (e1, e2) => e1[2].CompareTo(e2[2]));

//        // 2. keep a sum for mimum weight edges we will include
//        int cost = 0;

//        int count = 0;

//        // 3. keep track of parent and size for DSU operation
//        int[] parent = new int[v];
//        int[] size = new int[v];

//        for (int i = 0; i < v; i++)
//        {
//            parent[i] = i;
//            size[i] = 1;
//        }

//        // Start algorithm : As per the algo we will only consider v-1 edges
//        for (int i = 0; i < edges.Length; i++)
//        {
//            int[] currentEdge = edges[i];

//            // Make sure we dont have cycle
//            if (FindParent(currentEdge[0], parent) != FindParent(currentEdge[1], parent))
//            {
//                Console.WriteLine($"{currentEdge[0]} - {currentEdge[1]} - {currentEdge[2]}");

//                cost += currentEdge[2];
//                // Join the components
//                UnionBySize(currentEdge[0], currentEdge[1], parent, size);

//                if (++count == v - 1)
//                {
//                    break;
//                }
//            }
//        }

//        Console.WriteLine($"{cost}");
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
//        int[][] edges = {
//            new int[] {0, 1, 10},
//            new int[] {1, 3, 15},
//            new int[] {2, 3, 4},
//            new int[] {2, 0, 6},
//            new int[] {0, 3, 5}
//        };

//        Solution s = new Solution();

//        s.Kruskals(4, edges);
//    }
//}

////Time Complexity: O(E * logE) or O(E* logV)

////Sorting of edges takes O(E * logE) time.
////After sorting, we iterate through all edges and apply the find-union algorithm. The find and union operations can take at most O(logV) time.
////So overall complexity is O(E * logE + E * logV) time.
////The value of E can be at most O(V2), so O(logV) and O(logE) are the same. Therefore, the overall time complexity is O(E * logE) or O(E* logV)
////Auxiliary Space: O(V + E), where V is the number of vertices and E is the number of edges in the graph.  