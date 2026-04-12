//public class Solution
//{
//    public int[] FindOrder(int numCourses, int[][] prerequisites)
//    {
//        int[] result = new int[numCourses];

//        int rows = prerequisites.Length;

//        List<int>[] adjList = new List<int>[numCourses];

//        for (int i = 0; i < numCourses; i++)
//        {
//            adjList[i] = new List<int>();
//        }

//        int[] indegree = new int[numCourses];

//        for (int i = 0; i < rows; i++)
//        {
//            AddEdges(prerequisites[i][1], prerequisites[i][0], adjList);
//            indegree[prerequisites[i][0]]++;
//        }

//        Queue<int> q = new Queue<int>();

//        for (int i = 0; i < indegree.Length; i++)
//        {
//            if (indegree[i] == 0)
//            {
//                q.Enqueue(i);
//            }
//        }

//        int count = 0;

//        int k = 0;

//        while (q.Count > 0)
//        {
//            int node = q.Dequeue();

//            count++;

//            result[k] = node;
//            k++;

//            foreach (var neighbors in adjList[node])
//            {
//                indegree[neighbors]--;
//                if (indegree[neighbors] == 0)
//                {
//                    q.Enqueue(neighbors);
//                }
//            }
//        }

//        if (count == numCourses)
//        {
//            return result;
//        }
//        else
//        {
//            return [];
//        }
//    }

//    private void AddEdges(int src, int dest, List<int>[] adjList)
//    {
//        adjList[src].Add(dest);
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int numCourses = 4;

//        int[][] prerequisites = {
//            new int[] {1,0 },
//            new int[] {2,0 },
//            new int[] {3,1 },
//            new int[] {3,2},
//        };

//        Solution s = new Solution();

//        var result = s.FindOrder(numCourses, prerequisites);

//        foreach (var node in result)
//        {
//            Console.Write($"{node}" + " ");
//        }

//    }
//}
////Time Complexity: O(V + E), where V is the number of vertices and E is the number of edges.
////Auxiliary Space: O(V + E)