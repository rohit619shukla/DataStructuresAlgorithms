

//public class Solution
//{
//    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
//    {
//        IList<IList<string>> result = new List<IList<string>>();
//        HashSet<string> set = new HashSet<string>(wordList);
//        if (!set.Contains(endWord))
//            return result;
//        Dictionary<string, List<string>> adjList = new Dictionary<string, List<string>>();
//        Dictionary<string, int> levelMap = new Dictionary<string, int>();
//        BFS(adjList, beginWord, endWord, set, levelMap);
//        DFS(adjList, beginWord, endWord, result, new List<string> { beginWord });
//        return result;
//    }
//    private void BFS(Dictionary<string, List<string>> adjList, string startWord, string targetWord, HashSet<string> set, Dictionary<string, int> levelMap)
//    {
//        Queue<string> q = new Queue<string>();
//        q.Enqueue(startWord);
//        levelMap[startWord] = 1;
//        while (q.Count > 0)
//        {
//            string currentWord = q.Dequeue();
//            for (int i = 0; i < currentWord.Length; i++)
//            {
//                for (char ch = 'a'; ch <= 'z'; ch++)
//                {
//                    char[] charArray = currentWord.ToCharArray();
//                    charArray[i] = ch;
//                    string newWord = new string(charArray);
//                    if (set.Contains(newWord))
//                    {
//                        if (!levelMap.ContainsKey(newWord))
//                        {
//                            levelMap[newWord] = levelMap[currentWord] + 1;
//                            q.Enqueue(newWord);
//                            CreateAdjList(adjList, currentWord, newWord);
//                        }
//                        else if (levelMap[currentWord] + 1 == levelMap[newWord])
//                        {
//                            CreateAdjList(adjList, currentWord, newWord);
//                        }
//                    }
//                }
//            }
//        }
//    }
//    private void DFS(Dictionary<string, List<string>> adjList, string currentWord, string endWord, IList<IList<string>> result, List<string> currentList)
//    {
//        if (currentWord == endWord)
//        {
//            result.Add(new List<string>(currentList));
//            return;
//        }

//        if (adjList.ContainsKey(currentWord))
//        {
//            foreach (string newWord in adjList[currentWord])
//            {
//                currentList.Add(newWord);
//                DFS(adjList, newWord, endWord, result, currentList);
//                currentList.RemoveAt(currentList.Count - 1); // Backtrack here to remove the added word
//            }
//        }
//    }

//    private void CreateAdjList(Dictionary<string, List<string>> adjList, string parentWord, string childWord)
//    {
//        if (!adjList.ContainsKey(parentWord))
//        {
//            adjList.Add(parentWord, new List<string> { childWord });
//        }
//        else
//        {
//            adjList[parentWord].Add(childWord);
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

//// Time : O(M*N) for BFS and O(N) for DFS  , space : O(N) 