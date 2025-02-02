
//class TrieNode
//{
//    public TrieNode[] nodeArray;
//    public bool eow;

//    public TrieNode()
//    {
//        nodeArray = new TrieNode[26];
//    }
//}

//class Trie
//{
//    public const int AlphabetSize = 26;

//    // Time : O(L) , space : O(L) we are creating L nodes in worst case
//    public void InsertNode(string word, TrieNode root)
//    {
//        // base case
//        if (root == null || word == null)
//        {
//            return;
//        }

//        TrieNode node = root;

//        for (int i = 0; i < word.Length; i++)
//        {
//            // Get the index of the current word
//            int index = word[i] - 'a';

//            // If for a given node the given characters space is empty then add a new char space there
//            if (node.nodeArray[index] == null)
//            {
//                node.nodeArray[index] = new TrieNode();  // this takes constant time
//            }

//            // now make the current node as root for further iteration
//            node = node.nodeArray[index];
//        }

//        // mark the last node as eow
//        node.eow = true;
//    }

//    // Time : O(L) , space : O(1)
//    public bool SearchNode(TrieNode root, string word)
//    {
//        // base case
//        if (root == null || word == null)
//        {
//            return false;
//        }

//        TrieNode node = root;

//        for (int i = 0; i < word.Length; i++)
//        {
//            int index = word[i] - 'a';

//            if (node.nodeArray[index] == null)
//            {
//                return false;
//            }

//            node = node.nodeArray[index];
//        }

//        return node.eow;
//    }

//    // Time : O(L) , space : O(L) there will be L recursive calls
//    // Note : we can delete a node only if its marked as false for eow and it does not have any child
//    public TrieNode RemoveNode(TrieNode root, string word, int depth)
//    {
//        // base case
//        if (root == null)
//        {
//            return null;
//        }

//        // we have reached last word
//        if (word.Length == depth)
//        {
//            // mark the node as false first
//            if (root.eow)
//            {
//                root.eow = false;
//            }

//            // If the given node is empty, then we can delete it and free some space
//            if (IsEmpty(root))
//            {
//                root = null;
//            }

//            return root;
//        }

//        int index = word[depth] - 'a';

//        root.nodeArray[index] = RemoveNode(root.nodeArray[index], word, depth + 1);

//        if (IsEmpty(root) && root.eow == false)    
//        {
//            root = null;
//        }

//        return root;
//    }

//    // Time :O(1) , since we are iterating over fix set of alphabet size
//    private bool IsEmpty(TrieNode root)
//    {
//        for (int i = 0; i < AlphabetSize; i++)
//        {
//            if (root.nodeArray[i] != null)
//            {
//                return false;
//            }
//        }

//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string[] keys = { "abc", "abd", "bad", "ead", "cad" };

//        TrieNode root = new TrieNode();

//        Trie t = new Trie();

//        foreach (var item in keys)
//        {
//            t.InsertNode(item, root);
//        }

//        string[] searchKeys = { "c", "abd", "cad", "d" };

//        foreach (var item in searchKeys)
//        {
//            if (t.SearchNode(root, item))
//            {
//                Console.WriteLine($"Key: {item} found");
//            }
//            else
//            {
//                Console.WriteLine($"Key: {item} not found");
//            }
//        }

//        t.RemoveNode(root, "abd", 0);

//        string searchKey = "abd";

//        if (t.SearchNode(root, "item"))
//        {
//            Console.WriteLine($"Key: {searchKey} found");
//        }
//        else
//        {
//            Console.WriteLine($"Key: {searchKey} not found");
//        }
//    }
//}


//// Note : a word is said to exist only it has eow marked as true;