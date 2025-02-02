
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
//        // base case
//        if (root == null || word == null)
//        {
//            return;
//        }

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

//    public TrieNode SearchNode(TrieNode root, string word)
//    {
//        // base case
//        if (root == null || word == null)
//        {
//            return null;
//        }

//        TrieNode node = root;

//        for (int i = 0; i < word.Length; i++)
//        {
//            int index = word[i] - 'a';

//            if (node.NodeArray[index] == null)
//            {
//                return null;
//            }

//            node = node.NodeArray[index];
//        }

//        // Since we maybe sometime searching for partial string hence its quiet possible that the word is not eow, hence return the node
//        return node;
//    }

//    public bool IsLastNode(TrieNode root)
//    {
//        for (int i = 0; i < 26; i++)
//        {
//            if (root.NodeArray[i] != null)
//            {
//                return false;
//            }
//        }

//        return true;
//    }

//    // Tim e: O(n * m) , space : O(n)
//    public void PrintSuggestions(TrieNode root, StringBuilder str)
//    {
//        // Given node is one complete word in it self
//        if (root.Eow)
//        {
//            Console.WriteLine($"{str.ToString()}");
//        }

//        // Now search for all char after that word for their presence in trie
//        for (int i = 0; i < 26; i++)
//        {
//            if (root.NodeArray[i] != null)
//            {
//                char c = (char)(i + 'a');

//                PrintSuggestions(root.NodeArray[i], str.Append(c));

//                str.Length--;
//            }
//        }
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        string[] keys = { "hello", "dog", "hell", "cat", "a", "hel", "help", "helps", "helping" };

//        TrieNode root = new TrieNode();

//        Trie t = new Trie();

//        foreach (var item in keys)
//        {
//            t.InsertNode(root, item);
//        }

//        string searchKey = "help";

//        // First check if the searchKey itself is Present or not
//        TrieNode node = t.SearchNode(root, searchKey);

//        // Is the given node last node for the given key 
//        if (t.IsLastNode(node))
//        {
//            Console.WriteLine($"{searchKey}");
//        }
//        else
//        {
//            // Print all words which has this given word as prefix
//            t.PrintSuggestions(node, new StringBuilder(searchKey));
//        }


//    }
//}

//// Complexity : O(N*L)