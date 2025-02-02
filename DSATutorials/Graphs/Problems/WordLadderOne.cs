//public class Solution
//{
//    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
//    {
//        if (beginWord == null || endWord == null || wordList == null || wordList.Count == 0)
//        {
//            return 0;
//        }
//        // Create a set for storing only non visited word
//        HashSet<string> set = new HashSet<string>(wordList);

//        // If any word is not part of set then transformation not possible
//        if (!set.Contains(endWord))
//        {
//            return 0;
//        }

//        // Create a Queue for levelorder traversal
//        Queue<(string, int)> q = new Queue<(string, int)>();

//        // Add the start word to queue
//        q.Enqueue((beginWord, 1));

//        // Remove the word from set as it is now explored
//        set.Remove(beginWord);

//        // BFS
//        while (q.Count > 0)   // N
//        {
//            (string currentWord, int level) = q.Dequeue();

//            if (currentWord == endWord)
//            {
//                return level;
//            }
//            // Iterate over word length
//            for (int i = 0; i < currentWord.Length; i++)   // M
//            {
//                // Iterate over all 26 character to see if match is possible
//                for (int j = 0; j < 26; j++)  // 26
//                {
//                    char[] charArray = currentWord.ToCharArray();
//                    charArray[i] = (char)('a' + j);
//                    string newWord = new string(charArray);

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
//        string beginWord = "hit";
//        string endWord = "cog";
//        IList<string> wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };

//        Solution s = new Solution();
//        Console.WriteLine(s.LadderLength(beginWord, endWord, wordList));
//    }
//}

//// Time : O(N*M*26) , space : O(N)