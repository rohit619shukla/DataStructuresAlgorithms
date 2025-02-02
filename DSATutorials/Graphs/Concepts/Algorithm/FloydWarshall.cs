//using System;

//class Graph
//{
//    public int v;
//    public Graph(int vertices)
//    {
//        v = vertices;
//    }

//    public void FlyodWarshall(int[,] adj)
//    {
//        for (int k = 0; k < v; k++)
//        {
//            for (int i = 0; i < v; i++)
//            {
//                for (int j = 0; j < v; j++)
//                {
//                    adj[i, j] = Math.Min(adj[i, j], adj[i, k] + adj[k, j]);
//                }
//            }
//        }

//        for (int i = 0; i < v; i++)
//        {
//            for (int j = 0; j < v; j++)
//            {
//                Console.Write($"{adj[i, j]}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(4);

//        int[,] adj = {
//            { 0, 5, 99999, 10},
//            { 99999, 0, 3, 99999},
//            { 99999, 99999, 0,1},
//            { 99999, 99999, 99999,0}
//        };
//        g.FlyodWarshall(adj);
//    }
//}

////Time Complexity: O(V3)
////Auxiliary Space: O(V2)

//// This algo can also help to find cycle, since the distance of node to itself is 0 and if we have a path 
//// starting and ending a 0 less than 0 then there is a cycle