//public class Solution
//{
//    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
//    {

//        IList<IList<string>> result = new List<IList<string>>();

//        int n = accounts.Count;

//        int[] parent = new int[n];
//        int[] size = new int[n];

//        for (int i = 0; i < n; i++)
//        {
//            parent[i] = i;
//            size[i] = 1;
//        }

//        // Step1 : Create a map containig which email belon go to which node , if same email appear again then simply union them
//        Dictionary<string, int> emailMap = new Dictionary<string, int>();

//        for (int i = 0; i < n; i++)
//        {
//            for (int j = 1; j < accounts[i].Count; j++)
//            {
//                if (!emailMap.ContainsKey(accounts[i][j]))
//                {
//                    // Add the email to amp with its nodes where it belong
//                    emailMap.Add(accounts[i][j], i);
//                }
//                else
//                {
//                    // If the same email is found again in different node, then perform union
//                    UnionBySize(emailMap[accounts[i][j]], i, parent, size);
//                }
//            }
//        }

//        // Step 2 : Create a map containing which email finally belongs to which node afetr initial union in step1
//        Dictionary<int, List<string>> unSortedList = new Dictionary<int, List<string>>();

//        foreach (var pair in emailMap)
//        {
//            // We need to get the ultimate parent of the node the current email is
//            int root = FindParent(parent, emailMap[pair.Key]);

//            if (!unSortedList.ContainsKey(root))
//            {
//                unSortedList.Add(root, new List<string> { pair.Key });
//            }
//            else
//            {
//                unSortedList[root].Add(pair.Key);
//            }
//        }


//        // Step3 : Now for the nodes having email in sorted order add them to proper result with name of the account ebing the first  string
//        foreach (var act in unSortedList)
//        {
//            int key = act.Key;
//            List<string> temp = new List<string>();
//            temp.Add(accounts[key][0]);

//            List<string> emails = act.Value;
//            emails.Sort(StringComparer.Ordinal);

//            foreach (var mail in emails)
//            {
//                temp.Add(mail);
//            }
//            result.Add(temp);
//        }

//        return result;
//    }
//    private int FindParent(int[] parent, int i)
//    {
//        if (parent[i] == i)
//        {
//            return i;
//        }
//        return parent[i] = FindParent(parent, parent[i]);
//    }

//    private void UnionBySize(int u, int v, int[] parent, int[] size)
//    {
//        int parentU = FindParent(parent, u);
//        int parentV = FindParent(parent, v);

//        if (parentU == parentV)
//        {
//            return;
//        }

//        if (size[parentU] > size[parentV])
//        {
//            parent[parentV] = parentU;
//            size[parentU] += size[parentV];
//        }
//        else
//        {
//            parent[parentU] = parentV;
//            size[parentV] += size[parentU];
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        IList<IList<string>> accounts = new List<IList<string>>
//{
//    new List<string> { "David", "David0@m.co", "David4@m.co", "David3@m.co" },
//    new List<string> { "David", "David5@m.co", "David5@m.co", "David0@m.co" },
//    new List<string> { "David", "David1@m.co", "David4@m.co", "David0@m.co" },
//    new List<string> { "David", "David0@m.co", "David1@m.co", "David3@m.co" },
//    new List<string> { "David", "David4@m.co", "David1@m.co", "David3@m.co" }
//};


//        Solution s = new Solution();

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

//// Time : O(N*(ElogE + E))