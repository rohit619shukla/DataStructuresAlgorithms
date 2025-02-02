//public class TrieNode
//{
//    public TrieNode[] NodeArray;
//    public bool Eow;

//    public TrieNode()
//    {
//        NodeArray = new TrieNode[26];
//    }
//}
//public class Trie
//{
//    public TrieNode root;
//    public Trie()
//    {
//        root = new TrieNode();
//    }

//    // Time : O(L) , space : O(L)
//    public void Insert(string word)
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

//    // Time : O(L) , space : O(1)
//    public bool Search(string word)
//    {
//        if (word == null || root == null)
//        {
//            return false;
//        }

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

//    // Time : O(L) , space : O(1)
//    public bool StartsWith(string prefix)
//    {
//        if (prefix == null || root == null)
//        {
//            return false;
//        }

//        TrieNode node = root;

//        for (int i = 0; i < prefix.Length; i++)
//        {
//            int index = prefix[i] - 'a';

//            if (node.NodeArray[index] == null)
//            {
//                return false;
//            }

//            node = node.NodeArray[index];
//        }

//        return true;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string[] keys = { "apple"};

//        Trie t = new Trie();

//        foreach (var item in keys)
//        {
//            t.Insert(item);
//        }

//        string key = "apple";

//        if (t.Search(key))
//        {
//            Console.WriteLine($"{key} found");
//        }
//        else
//        {
//            Console.WriteLine($"{key} not found");
//        }

//        key = "app";

//        if (t.Search(key))
//        {
//            Console.WriteLine($"{key} found");
//        }
//        else
//        {
//            Console.WriteLine($"{key} not found");
//        }

//        if (t.StartsWith(key))
//        {
//            Console.WriteLine($"{key} found");
//        }
//        else
//        {
//            Console.WriteLine($"{key} not found");
//        }

//        t.Insert(key);

//        if (t.Search(key))
//        {
//            Console.WriteLine($"{key} found");
//        }
//        else
//        {
//            Console.WriteLine($"{key} not found");
//        }
//    }

//}

// Note :For inserting n words it would n*l