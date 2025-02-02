
//class TrieNode
//{
//    public TrieNode[] NodeArray;
//    public bool Eow;

//    public TrieNode()
//    {
//        NodeArray = new TrieNode[26];
//    }
//}


//public class Solution
//{
//    private void InsertNode(TrieNode root, string word)
//    {
//        TrieNode node = root;

//        for (int i = 0; i < word.Length; i++)
//        {
//            int index = word[i] - 'a';

//            if (node.NodeArray[index] == null)
//            {
//                node.NodeArray[index] = new TrieNode();
//            }

//            node = node.NodeArray[index];
//        }
//        node.Eow = true;
//    }

//    private bool SearchNode(TrieNode root, string word)
//    {
//        TrieNode node = root;

//        for (int i = 0; i < word.Length; i++)
//        {
//            int index = word[i] - 'a';

//            if (node.NodeArray[index] == null)
//            {
//                return false;
//            }

//            node = node.NodeArray[index];
//        }

//        return node.Eow;
//    }
//    public IList<string> WordBreak(string s, IList<string> wordDict)
//    {
//        // Create root node for Trie
//        TrieNode root = new TrieNode();

//        // Add all words from dictionary to Trie
//        foreach (var item in wordDict)
//        {
//            InsertNode(root, item);
//        }

//        List<string> resultString = new List<string>();

//        TrieNode node = root;

//        // Perform word break
//        PerformWordBreak(root, string.Empty, resultString, 0, s);

//        return resultString;
//    }

//    private void PerformWordBreak(TrieNode node, string currentString, List<string> resultString, int start, string intialString)
//    {
//        // base case
//        // We have reached end of string
//        if (start == intialString.Length)
//        {
//            resultString.Add(currentString);
//            return;
//        }

//        for (int end = start + 1; end <= intialString.Length; end++)
//        {
//            string subString = intialString.Substring(start, end - start);

//            if (SearchNode(node, subString))
//            {
//                if (currentString == string.Empty)
//                {
//                    PerformWordBreak(node, subString, resultString, end, intialString);
//                }
//                else
//                {
//                    PerformWordBreak(node, currentString + " " + subString, resultString, end, intialString);
//                }
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string str = "catsanddog";

//        List<string> wordDict = new List<string>() { "cat", "cats", "and", "sand", "dog" };

//        Solution s = new Solution();

//        var result = s.WordBreak(str, wordDict);

//        foreach (var item in result)
//        {
//            Console.WriteLine(item);
//        }
//    }
//}

////// Complexity :
////// Time : O(2^m * m * l), 2^m : because we have 2 choice to either take the substring or not take it, m*l for Searching n words words of lenght l /
////// Space : O(2^m *m) for seacrh + recursion and O(n*l) for insertion
///// The ide is simply take the subtsring at every interval and search if it exist in trie starting from root