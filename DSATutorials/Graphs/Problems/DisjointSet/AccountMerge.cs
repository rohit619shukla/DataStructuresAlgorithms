
//public class DisjointSet
//{
//    public int[] parent;
//    public int[] size;
//    public int V;

//    public DisjointSet(int vertices)
//    {
//        V = vertices;
//        parent = new int[vertices];
//        size = new int[vertices];

//        for (int i = 0; i < V; i++)
//        {
//            parent[i] = i;
//            size[i] = 1;
//        }
//    }

//    public int FindParent(int i)
//    {
//        if (i == parent[i])
//        {
//            return i;
//        }
//        else
//        {
//            return parent[i] = FindParent(parent[i]);  // Path compression
//        }
//    }

//    public void UnionBySize(int u, int v)
//    {
//        int parentOfU = FindParent(u);
//        int parentOfV = FindParent(v);

//        if (parentOfU == parentOfV)
//        {
//            return;
//        }

//        if (size[parentOfU] < size[parentOfV])
//        {
//            parent[parentOfU] = parentOfV;
//            size[parentOfV] += size[parentOfU];
//        }
//        else
//        {
//            parent[parentOfV] = parentOfU;
//            size[parentOfU] += size[parentOfV];
//        }
//    }
//}

//public class Solution
//{
//    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
//    {
//        int n = accounts.Count;
//        DisjointSet dj = new DisjointSet(n);

//        // Dictionary to map each email to an account index (initially)
//        Dictionary<string, int> mailMap = new Dictionary<string, int>();

//        // Iterate over accounts and unify emails in the same account
//        for (int i = 0; i < n; i++)
//        {
//            var account = accounts[i];
//            for (int j = 1; j < account.Count; j++)
//            {
//                string email = account[j];
//                if (!mailMap.ContainsKey(email))
//                {
//                    mailMap[email] = i;  // Map email to this account index
//                }
//                else
//                {
//                    // Union the current account index with the previously seen account index for this email
//                    dj.UnionBySize(mailMap[email], i);
//                }
//            }
//        }

//        // Group emails by their root parent index
//        Dictionary<int, List<string>> components = new Dictionary<int, List<string>>();
//        foreach (var email in mailMap.Keys)
//        {
//            int root = dj.FindParent(mailMap[email]);

//            if (components.ContainsKey(root))
//            {
//                components[root].Add(email);
//            }
//            else
//            {
//                components.Add(root, new List<string> { email });
//            }
//        }

//        // Prepare the result in the required format
//        IList<IList<string>> result = new List<IList<string>>();
//        foreach (var component in components)
//        {
//            int accountIndex = component.Key;
//            List<string> emails = component.Value;
//            emails.Sort(StringComparer.Ordinal); // Sort emails lexicographically

//            // Add the account name followed by the emails
//            List<string> mergedAccount = new List<string> { accounts[accountIndex][0] };
//            mergedAccount.AddRange(emails);
//            result.Add(mergedAccount);
//        }

//        return result;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        IList<IList<string>> accounts = new List<IList<string>>();

//        accounts.Add(new List<string> { "John", "johnsmith@mail.com", "john_newyork@mail.com" });
//        accounts.Add(new List<string> { "John", "johnsmith@mail.com", "john00@mail.com" });
//        accounts.Add(new List<string> { "Mary", "mary@mail.com" });
//        accounts.Add(new List<string> { "John", "johnnybravo@mail.com" });


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

//// Time : O(n+m+nlogn) , space : O(n+m)