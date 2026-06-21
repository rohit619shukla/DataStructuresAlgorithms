

//public class Solution
//{
//    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
//    {
//        var result = new List<IList<string>>();

//        int n = accounts.Count;
//        int[] parent = new int[n];
//        int[] size = new int[n];

//        // O(N)
//        for (int i = 0; i < accounts.Count; i++)
//        {
//            parent[i] = i;
//            size[i] = 1;
//        }

//        // Step 1: We need to have a node level structure to represent each name so that we can apply DSU
//        // Lets create a Map to store who belong which index

//        Dictionary<string, int> map = new Dictionary<string, int>();

//        // O(N)
//        for (int i = 0; i < accounts.Count; i++)
//        {
//            // O(K)
//            for (int j = 1; j < accounts[i].Count; j++)
//            {
//                if (!map.ContainsKey(accounts[i][j]))
//                {
//                    map[accounts[i][j]] = i;
//                }
//                else
//                {
//                    // Perform union which will help us retrieve and merge effeciently in upcoming steps
//                    // Inverse akerman
//                    UnionBySize(i, map[accounts[i][j]], parent, size);
//                }
//            }
//        }

//        // Step 2 : Now lets iterate over the map and start adding the names to right index in list in sorted order
//        Dictionary<int, List<string>> unsortedList = new Dictionary<int, List<string>>();
//        // O(N)
//        foreach (var item in map)
//        {
//            string key = item.Key;
//            int value = item.Value;

//            // Get ulimate parent of each node to add correctly
//            // Inverse ackerman
//            int ulitmateParent = FindParent(value, parent);

//            if (!unsortedList.ContainsKey(ulitmateParent))
//            {
//                unsortedList.Add(ulitmateParent, new List<string> { key });
//            }
//            else
//            {
//                unsortedList[ulitmateParent].Add(key);
//            }

//        }

//        // Step 3 : Now sort all the arrays individually and append to final result
//        // O(N)
//        foreach (var nameList in unsortedList)
//        {
//            int key = nameList.Key;
//            List<string> names = nameList.Value;

//            // O(NLogN)
//            names.Sort(String.CompareOrdinal);
//            names.Insert(0, accounts[key][0]);

//            result.Add(names);
//        }
//        return result;
//    }

//    private int FindParent(int i, int[] parent)
//    {
//        if (i == parent[i])
//        {
//            return i;
//        }

//        return parent[i] = FindParent(parent[i], parent);
//    }

//    private void UnionBySize(int u, int v, int[] parent, int[] size)
//    {
//        int p_U = FindParent(u, parent);
//        int p_V = FindParent(v, parent);

//        if (p_U == p_V)
//        {
//            return;
//        }

//        if (size[p_U] > size[p_V])
//        {
//            size[p_U] += size[p_V];
//            parent[p_V] = p_U;
//        }
//        else
//        {
//            size[p_V] += size[p_U];
//            parent[p_U] = p_V;
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        var accounts = new List<IList<string>>();

//        accounts.Add(new List<string> { "Ram", "ram1@mail", "ram2@mail" });
//        accounts.Add(new List<string> { "Ram", "ram2@mail", "ram3@mail" });
//        accounts.Add(new List<string> { "Sam", "sam1@mail" });

//        var result = s.AccountsMerge(accounts);

//        foreach (var item in result)
//        {
//            foreach (var i in item)
//            {
//                Console.Write($"{i}" + " ");
//            }

//            Console.WriteLine();
//        }
//    }

//}

//// Time : O(N * KLogK))