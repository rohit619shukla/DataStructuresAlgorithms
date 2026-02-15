//class Solution
//{
//    public string FindOrder(string[] words)
//    {
//        string result = "";

//        // Since something has to appear something and we maintain a chain we will apply topo sort
//        // Since we have not been given the number of vertices,we will deduce it
//        // The set will store all distinct char in word as vertices
//        HashSet<char> set = new HashSet<char>();

//        // Time : O(N*L) , for each word in list of N words we iterate over L length
//        foreach (string word in words)
//        {
//            foreach (char ch in word)
//            {
//                set.Add(ch);
//            }
//        }

//        // Create a adj list
//        List<int>[] adjList = new List<int>[26];

//        for (int i = 0; i < 26; i++)
//        {
//            adjList[i] = new List<int>();
//        }

//        bool mismatchFound = false;
//        int[] indegree = new int[26];

//        // Create edges
//        for (int i = 0; i < words.Length - 1; i++)   // O(N)
//        {
//            string word1 = words[i];
//            string word2 = words[i + 1];

//            // We will iterate over minimum length of two words
//            int minLength = Math.Min(word1.Length, word2.Length);
//            for (int j = 0; j < minLength; j++)   // O(L)
//            {
//                if (word1[j] != word2[j])
//                {
//                    AddEdge(word1[j] - 'a', word2[j] - 'a', adjList);
//                    indegree[word2[j] - 'a']++;
//                    mismatchFound = true;
//                    break;
//                }
//            }

//            // Rules :
//            // 1. So long as we got a difference we dont care much
//            // 2. Only if a difference is not found and word1 > word2 then we have invalid case and need to return
//            // 3. This is becoz if we dont have mismatch and word1> word2 then we will not have a sequecne with all the char in the word
//            if (!mismatchFound && word1.Length > word2.Length)
//            {
//                return "";
//            }
//            mismatchFound = false;
//        }

//        // store all nodes with indegree 0 in queue
//        Queue<int> q = new Queue<int>();

//        foreach (char ch in set)
//        {
//            if (indegree[ch - 'a'] == 0)
//            {
//                q.Enqueue(ch - 'a');
//            }
//        }

//        int count = 0;

//        // start BFS
//        while (q.Count > 0)
//        {
//            int node = q.Dequeue();
//            count++;

//            result += (char)(node + 'a');
//            foreach (var neighbor in adjList[node])
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

//    private void AddEdge(int src, int dest, List<int>[] adjList)
//    {
//        adjList[src].Add(dest);
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

//// Time : O(N*L) , space: O(1) : as we will only store unique chars in queue