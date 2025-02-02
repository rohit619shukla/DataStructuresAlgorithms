//using System;

//class Trie
//{
//    public Trie[] children = new Trie[26];
//    public bool eow;

//    public Trie()
//    {
//        for (int i = 0; i < 26; i++)
//        {
//            children[i] = null;
//        }
//    }

//    // Time : O(n * l) , space :O(n *l)
//    public void Insert(Trie root, string key)
//    {
//        if (root == null || string.IsNullOrWhiteSpace(key))
//        {
//            return;
//        }

//        int index = -1;

//        for (int i = 0; i < key.Length; i++)
//        {
//            index = key[i] - 'a';

//            if (root.children[index] == null)
//            {
//                root.children[index] = new Trie();
//            }
//            root = root.children[index];
//        }

//        root.eow = true;
//    }

//    // Time : O(n * l) , space :O(L) , auxillary : O(1)
//    public bool Search(Trie root, string key)
//    {
//        if (root == null || string.IsNullOrWhiteSpace(key))
//        {
//            return false;
//        }

//        int index = -1;

//        for (int i = 0; i < key.Length; i++)
//        {
//            index = key[i] - 'a';

//            if (root.children[index] == null)
//            {
//                return false;
//            }

//            root = root.children[index];
//        }
//        return true;
//    }
//}
//class Program
//{

//    public static void Main()
//    {
//        Trie root = new Trie();

//        string[] inputs = { "apple", "app", "mango", "man", "woman" };

//        foreach (var item in inputs)
//        {
//            root.Insert(root, item);
//        }

//        Console.WriteLine(root.Search(root, "moon"));
//    }

    
//}