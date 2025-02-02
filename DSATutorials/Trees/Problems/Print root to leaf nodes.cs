

//using System.Text;

//class Solution
//{
//    public IList<string> PrintRootToLeaf(TNode root)
//    {
//        List<string> resultList = new List<string>();
//        TNode head = root;
//        List<string> currentList = new List<string>();
//        currentList.Add(head.data.ToString());
//        Solve(head, resultList, currentList);

//        return resultList;
//    }

//    private void Solve(TNode head, List<string> resultList, List<string> currentList)
//    {
//        if (head.left == null && head.right == null)
//        {
//            string str = "";

//            for (int i = 0; i < currentList.Count - 1; i++)
//            {
//                str += currentList[i] + "->";
//            }

//            str += currentList[currentList.Count - 1];
//            resultList.Add(str);
//            return;
//        }

//        if (head.left != null)
//        {
//            currentList.Add(head.left.data.ToString());
//            Solve(head.left, resultList, currentList);
//            currentList.RemoveAt(currentList.Count - 1);
//        }

//        if (head.right != null)
//        {
//            currentList.Add(head.right.data.ToString());
//            Solve(head.right, resultList, currentList);
//            currentList.RemoveAt(currentList.Count - 1);
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        TNode root = new TNode(6);
//        root.left = new TNode(3);
//        root.left.left = new TNode(2);
//        root.left.right = new TNode(5);
//        root.left.right.left = new TNode(7);
//        root.left.right.right = new TNode(4);
//        root.right = new TNode(9);
//        root.right.right = new TNode(4);
//        Solution h = new Solution();

//        IList<string> str = h.PrintRootToLeaf(root);

//        foreach (var item in str)
//        {
//            Console.WriteLine(item);
//        }
//    }
//}

//// Complexity : O(N), spcae : O(N)