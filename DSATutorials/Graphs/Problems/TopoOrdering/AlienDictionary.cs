//class Solution
//{
//    public string FindOrder(string[] words)
//    {
//        int w = 4;
//        string result = string.Empty;

//        // STEP 1: For a Topo sort to work properly we need to know how many nodes are there in graph
//        // Hence we create a Hashset for this to store all distinct nodes
//        HashSet<char> set = new HashSet<char>();
//        foreach (string word in words)
//        {
//            foreach (char ch in word)
//            {
//                set.Add(ch);
//            }
//        }

//        // We need to store 26 as we may have less distinct words but the index of the word may be greater than index of adjList , if we go with simple set
//        List<int>[] adjList = new List<int>[w];

//        for (int i = 0; i < w; i++)
//        {
//            adjList[i] = new List<int>();
//        }

//        bool misMatchFound = false;
//        int[] indegree = new int[w];

//        // STEP 2: Now we need to create a Adj list so that we could later apply topo sort on DAG
//        for (int i = 0; i < words.Length - 1; i++)
//        {
//            string word1 = words[i];
//            string word2 = words[i + 1];

//            // We need to know what is the minimum length word among both to proceed properly
//            int minLength = Math.Min(word1.Length, word2.Length);

//            // Now lets iterate over minimum length word only
//            for (int k = 0; k < minLength; k++)
//            {
//                if (word1[k] != word2[k])
//                {
//                    AddEdges(word1[k] - 'a', word2[k] - 'a', adjList);
//                    indegree[word2[k] - 'a']++;
//                    misMatchFound = true;
//                    break;
//                }
//            }

//            // It might be possible that no mismatch is found and word1.length > word2.length
//            if (misMatchFound == false && word1.Length > word2.Length)
//            {
//                return "";
//            }

//            // Lets reset for next iteration
//            misMatchFound = false;
//        }


//        // STEP 3 : Apply Topo sort
//        // Get all nodes with 0 indegree
//        Queue<int> q = new Queue<int>();
//        foreach (var ch in set)
//        {
//            if (indegree[ch - 'a'] == 0)
//            {
//                q.Enqueue(ch - 'a');
//            }
//        }

//        int count = 0;

//        while (q.Count > 0)
//        {
//            int node = q.Dequeue();

//            count++;
//            result += (char)(node + 'a');
//            foreach (int neighbor in adjList[node])
//            {
//                indegree[neighbor]--;
//                if (indegree[neighbor] == 0)
//                {
//                    q.Enqueue(neighbor);
//                }
//            }
//        }
//        return count == set.Count ? result : "";

//    }

//    private void AddEdges(int u, int v, List<int>[] adjList)
//    {
//        adjList[u].Add(v);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string[] word = { "baa", "abcd", "abca", "cab", "cad" };

//        Solution s = new Solution();

//        Console.WriteLine(s.FindOrder(word));
//    }
//}

//// Time : O(N*L) , space: O(k) =26 : as we will only store unique chars in queue