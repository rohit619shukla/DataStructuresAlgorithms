//public class Solution
//{
//    public bool CanFinish(int numCourses, int[][] prerequisites)
//    {
//        int rows = prerequisites.Length;

//        List<int>[] adjList = new List<int>[numCourses];

//        for (int i = 0; i < numCourses; i++)
//        {
//            adjList[i] = new List<int>();
//        }

//        int[] indegree = new int[numCourses];

//        for (int i = 0; i < rows; i++)
//        {
//            AddEdges(prerequisites[i][0], prerequisites[i][1], adjList);
//            indegree[prerequisites[i][1]]++;
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

//        while (q.Count > 0)
//        {
//            int node = q.Dequeue();

//            count++;

//            foreach (var neighbors in adjList[node])
//            {
//                indegree[neighbors]--;
//                if (indegree[neighbors] == 0)
//                {
//                    q.Enqueue(neighbors);
//                }
//            }
//        }
//        return count == numCourses ? true : false;
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
//        int numCourses = 2;

//        int[][] prerequisites = {
//            new int[] {1,0 }
//        };

//        Solution s = new Solution();

//        Console.WriteLine(s.CanFinish(numCourses, prerequisites));
//    }
//}
////Time Complexity: O(V + E), where V is the number of vertices and E is the number of edges.
////Auxiliary Space: O(V + E)