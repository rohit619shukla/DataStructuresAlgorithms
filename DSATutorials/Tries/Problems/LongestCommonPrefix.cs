

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
//    public string LongestCommonPrefix(string[] strs)
//    {
//        string result = string.Empty;

//        TrieNode root = new TrieNode();

//        // Insert all words into the Trie
//        foreach (var word in strs)
//        {
//            InsertNode(root, word);
//        }

//        LongestPrefix(root, ref result);

//        return result;
//    }

//    private void InsertNode(TrieNode root, string word)
//    {
//        if (word == null || root == null)
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

//    private void LongestPrefix(TrieNode root, ref string result)
//    {
//        TrieNode node = root;

//        int index = 0;
//        // The node should not have more than 1 child
//        // It may be  possible that a branch dont exist and only 1 child exist, hence we need this additional check
//        while (DoesOnlyOneNodeExist(node, ref index) && !node.Eow)
//        {
//            char c = (char)(index + 'a');
//            result += c;
//            node = node.NodeArray[index];
//        }
//    }

//    private bool DoesOnlyOneNodeExist(TrieNode node, ref int index)
//    {
//        int count = 0;

//        for (int i = 0; i < 26; i++)
//        {
//            if (node.NodeArray[i] != null)
//            {
//                count++;
//                index = i;
//            }
//        }

//        return count == 1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string[] strs = { "flow", "flowing" };

//        Trie t = new Trie();

//        Console.WriteLine(t.LongestCommonPrefix(strs));
//    }
//}


//// Time Complexity: O(n * L + S) , where O(n*L) is for insert function for n nodes and S is for longest prefix function

//// Space : O(n * L + S)