

//using System.Runtime.CompilerServices;
//using System.Text;

//class TrieNode
//{
//    public TrieNode[] NodeArray;
//    public bool Eow;

//    public TrieNode()
//    {
//        NodeArray = new TrieNode[26];
//    }
//}

//class Trie
//{
//    public void InsertNode(TrieNode root, string word)
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

//    public void LongestWordWithAllPrefix(TrieNode root, StringBuilder str, ref string result)
//    {
//        // We will start from first node in root and check if it forms a prefix   and go deep
//        // Then simultaneously we will move to next node prefix

//        for (int i = 0; i < 26; i++)
//        {
//            if (root.NodeArray[i] != null && root.NodeArray[i].Eow)
//            {
//                char c = (char)(i + 'a');

//                str.Append(c);

//                if (str.Length > result.Length)
//                {
//                    result = str.ToString();
//                }

//                LongestWordWithAllPrefix(root.NodeArray[i], str, ref result);

//                str.Length--;
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string[] keys = { "a", "banana", "app", "appl", "ap", "apply", "apple", "b", "ba", "ban", "bana", "banan" };

//        TrieNode root = new TrieNode();

//        Trie t = new Trie();

//        foreach (var item in keys)
//        {
//            t.InsertNode(root, item);
//        }

//        string result = string.Empty;

//        t.LongestWordWithAllPrefix(root, new StringBuilder(), ref result);

//        Console.WriteLine(result);
//    }
//}

//// Complexity : O(N) * O(l) for both Insertion and Determination