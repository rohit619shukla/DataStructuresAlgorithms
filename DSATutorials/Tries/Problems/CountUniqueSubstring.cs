

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
//    public int CountUniqueSubstring(string str, TrieNode root)
//    {
//        // Idea here is take each characters from string and insert in trie.
//        // Keep doing this while we can. Every insertion of character will mark the node to be Eow

//        int count = 0;
//        for (int i = 0; i < str.Length; i++)
//        {
//            TrieNode node = root;

//            for (int j = i; j < str.Length; j++)
//            {
//                int index = str[j] - 'a';

//                if (node.NodeArray[index] == null)
//                {
//                    node.NodeArray[index] = new TrieNode();
//                    count++;
//                }
//                node = node.NodeArray[index];
//            }
//        }

//        return count;
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "abcd";

//        TrieNode root = new TrieNode();

//        Trie t = new Trie();

//        Console.WriteLine(t.CountUniqueSubstring(str, root));
//    }
//}

////// Visualization
////// a, ab, abc, abcd
////// b, bc, bcd
////// c, cd
////// d

////// Time  : O(N^2) := n(n+1)/2, space : O(n^2) as n(n+1)/2 distinct nodes will be created for distinct substrings
/////// Here the innner loop dominates outer loop :=> n + (n-1) + (n-2) +1 => o(N^2)