
//class Solution
//{
//    public IList<IList<int>> Solve(TNode root)
//    {
//        Queue<TNode> q = new Queue<TNode>();

//        IList<IList<int>> resultList = new List<IList<int>>();

//        q.Enqueue(root);

//        bool flag = true;

//        while (q.Count > 0)
//        {
//            List<int> currentList = new List<int>();

//            int queueCount = q.Count;

//            for (int i = 0; i < queueCount; i++)
//            {
//                TNode temp = q.Dequeue();

//                if (flag)
//                {
//                    // Add to end of the list
//                    currentList.Add(temp.data);
//                }
//                else
//                {
//                    // Add to start of list
//                    currentList.Insert(0, temp.data);
//                }

//                if (temp.left != null)
//                {
//                    q.Enqueue(temp.left);
//                }

//                if (temp.right != null)
//                {
//                    q.Enqueue(temp.right);
//                }
//            }

//            resultList.Add(currentList);
//            flag = !flag;
//        }

//        return resultList;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        TNode root = new TNode(1);
//        root.left = new TNode(2);
//        root.right = new TNode(3);
//        root.left.left = new TNode(4);
//        root.left.right = new TNode(5);
//        root.right.right = new TNode(6);


//        var result = s.Solve(root);

//        foreach (var items in result)
//        {
//            foreach (var item in items)
//            {
//                Console.Write($"{item}" + " ");
//            }
//        }
//    }
//}

////Space Complexity: O(N)
////Time Complexity: O(N) As outer while loops executes for N times and inner loops also goes over each node in tree only once.