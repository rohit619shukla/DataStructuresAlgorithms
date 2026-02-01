

//class Solution
//{
//    public IList<IList<string>> FindLadders(string startWord, string targetWord, IList<string> wordList)
//    {
//        IList<IList<string>> result = new List<IList<string>>();

//        // Convert the list to set for O(1) lookup
//        HashSet<string> set = new HashSet<string>(wordList);

//        // If the endword itself is missing in set leave
//        if (!set.Contains(targetWord)) return result;

//        // We will use a map to keep track of the path words and their level
//        Dictionary<string, int> map = new Dictionary<string, int>();

//        // Apply word ladder 1 algorithm to create a Map wof words being found at level
//        BFS(map, startWord, targetWord, set);

//        if (map.ContainsKey(targetWord))
//        {

//            DFS(map, targetWord, startWord, result, new List<string> { targetWord });
//        }

//        return result;
//    }

//    private void BFS(Dictionary<string, int> map, string startWord, string targetWord, HashSet<string> set)
//    {

//        Queue<(string, int)> q = new Queue<(string, int)>();

//        q.Enqueue((startWord, 0));
//        map[startWord] = 0;

//        if (set.Contains(startWord))
//        {
//            set.Remove(startWord);
//        }

//        while (q.Count > 0)
//        {
//            (string currentWord, int level) = q.Dequeue();

//            if (currentWord == targetWord) break;

//            // Iterate over the word and check if we can find match in the set
//            for (int i = 0; i < currentWord.Length; i++)
//            {
//                char[] currentWordArray = currentWord.ToCharArray();

//                for (char ch = 'a'; ch <= 'z'; ch++)
//                {
//                    // replace the first char
//                    currentWordArray[i] = ch;
//                    string newWord = new string(currentWordArray);

//                    // check if the newly formed word is in the set
//                    if (set.Contains(newWord))
//                    {
//                        q.Enqueue((newWord, level + 1));
//                        map[newWord] = level + 1;
//                        set.Remove(newWord);
//                    }
//                }
//            }
//        }
//    }

//    private void DFS(Dictionary<string, int> map, string startWord, string targetWord, IList<IList<string>> result, IList<string> tempList)
//    {
//        // base case , we are going in reverse
//        if (targetWord == startWord)
//        {
//            result.Add(new List<string>(tempList.Reverse()));
//            return;
//        }

//        int level = map[startWord];

//        for (int i = 0; i < startWord.Length; i++)
//        {
//            char[] currentWordArray = startWord.ToCharArray();

//            char old = currentWordArray[i];

//            for (char ch = 'a'; ch <= 'z'; ch++)
//            {
//                // replace the first char
//                currentWordArray[i] = ch;
//                string newWord = new string(currentWordArray);

//                // We will insert a word in queue if it is a level-1 than current word, as we are going for optimality
//                // here we will not check in set , but rather the map
//                if (map.ContainsKey(newWord) && map[newWord] == level - 1)
//                {
//                    tempList.Add(newWord);
//                    DFS(map, newWord, targetWord, result, tempList);
//                    tempList.RemoveAt(tempList.Count - 1);
//                }
//            }

//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        IList<string> wordList = new List<string> { "hot", "dog" };
//        string startWord = "hot";
//        string targetWord = "dog";

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