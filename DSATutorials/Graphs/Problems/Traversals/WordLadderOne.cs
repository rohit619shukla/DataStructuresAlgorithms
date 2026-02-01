//public class Solution
//{
//    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
//    {

//        // Convert the list to set for O(1) lookup. will be used as visisted array
//        HashSet<string> set = new HashSet<string>(wordList);

//        // base check if te word is itself not in set
//        if (!set.Contains(endWord))
//        {
//            return 0;
//        }

//        // Create a queue for BFS traversal  : (Node, level)
//        Queue<(string, int)> q = new Queue<(string, int)>();

//        // Add the start word in queue
//        q.Enqueue((beginWord, 1));

//        // Remove the start node from set
//        if (set.Contains(beginWord)) set.Remove(beginWord);

//        while (q.Count > 0)
//        {
//            (string currentWord, int level) = q.Dequeue();

//            if (currentWord == endWord)
//            {
//                return level;
//            }

//            // Iterate over the word length for all set of chars between a - z
//            for (int i = 0; i < currentWord.Length; i++)
//            {
//                // Pick one letter and repacing it with each char in seqeunce and check
//                for (char ch = 'a'; ch <= 'z'; ch++)
//                {
//                    char[] currentWordArray = currentWord.ToCharArray();
//                    currentWordArray[i] = ch;
//                    string newWord = new string(currentWordArray);

//                    if (set.Contains(newWord))
//                    {
//                        q.Enqueue((newWord, level + 1));
//                        set.Remove(newWord);
//                    }
//                }
//            }
//        }

//        return 0;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        string[] wordList = { "hot", "dot", "dog", "lot", "log", "cog" };

//        Console.WriteLine(s.LadderLength("hit", "cog", wordList));
//    }
//}

//// Time : O(N*M*26) , space : O(N)