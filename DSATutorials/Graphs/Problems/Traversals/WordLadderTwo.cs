//class Solution
//{
//    public IList<IList<string>> FindLadders(string startWord, string targetWord, IList<string> wordList)
//    {
//        IList<IList<string>> result = new List<IList<string>>();

//        // Convert the list to set for O(1) lookup
//        HashSet<string> set = new HashSet<string>(wordList);

//        // If the endword itself is missing in set leave
//        if (!set.Contains(targetWord)) return result;

//        // parents map: child -> list of parents (built during BFS, reused in DFS)
//        Dictionary<string, List<string>> parents = new Dictionary<string, List<string>>();
//        Dictionary<string, int> map = new Dictionary<string, int>();

//        BFS(map, parents, startWord, targetWord, set);

//        if (map.ContainsKey(targetWord))
//        {
//            DFS(parents, targetWord, startWord, result, new List<string> { targetWord });
//        }

//        return result;
//    }

//    private void BFS(Dictionary<string, int> map, Dictionary<string, List<string>> parents, string startWord, string targetWord, HashSet<string> set)
//    {
//        Queue<(string, int)> q = new Queue<(string, int)>();

//        q.Enqueue((startWord, 0));
//        map[startWord] = 0;

//        while (q.Count > 0)
//        {
//            (string currentWord, int level) = q.Dequeue();

//            if (currentWord == targetWord) break;

//            for (int i = 0; i < currentWord.Length; i++)
//            {
//                char[] currentWordArray = currentWord.ToCharArray();

//                for (char ch = 'a'; ch <= 'z'; ch++)
//                {
//                    currentWordArray[i] = ch;
//                    string newWord = new string(currentWordArray);

//                    if (set.Contains(newWord))
//                    {
//                        // Never visited — valid new child, record parent link
//                        if (!map.ContainsKey(newWord))
//                        {
//                            map[newWord] = level + 1;
//                            q.Enqueue((newWord, level + 1));
//                            parents[newWord] = new List<string> { currentWord };
//                        }
//                        // Already visited but currentWord is a valid parent (exactly 1 level above) — allow additional parent for multiple shortest paths
//                        // Discards ancestors/same-level peers to avoid cycles or longer paths
//                        else if (map[newWord] == level + 1)
//                        {
//                            parents[newWord].Add(currentWord);
//                        }
//                    }
//                }
//            }
//        }
//    }

//    // DFS now simply traverses the parents adjacency list — no word generation needed
//    private void DFS(Dictionary<string, List<string>> parents, string word, string startWord, IList<IList<string>> result, IList<string> path)
//    {
//        if (word == startWord)
//        {
//            result.Add(new List<string>(path.Reverse()));
//            return;
//        }

//        foreach (string parent in parents[word])
//        {
//            path.Add(parent);
//            DFS(parents, parent, startWord, result, path);
//            path.RemoveAt(path.Count - 1);
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        IList<string> wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
//        string startWord = "hit";
//        string targetWord = "cog";

//        Solution s = new Solution();
//        var result = s.FindLadders(startWord, targetWord, wordList);

//        foreach (var paths in result)
//        {
//            foreach (var lst in paths)
//            {
//                Console.Write($"{lst} -> ");
//            }
//            Console.WriteLine();
//        }
//    }
//}

//// Time : O(N * L * 26) for BFS + O(P * D) for DFS
////        N = number of words, L = word length, P = number of shortest paths, D = path depth
////        DFS: Traverse D levels per path, copy/reverse path at leaf = O(D), repeated P times = O(P * D)
//// Space : O(N * L) for set + queue + map
////         O(N^2) worst case for parents (each word can have multiple parents from previous level)
////         O(P * D) for storing all result paths