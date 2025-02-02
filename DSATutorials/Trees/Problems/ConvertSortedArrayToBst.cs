
//public class Helper
//{

//    public TNode ConvertArrayToBst(int[] arr, int lb, int ub)
//    {
//        if (arr.Length == 0)
//        {
//            return null;
//        }

//        if (lb > ub)
//        {
//            return null;
//        }

//        int mid = (lb + ub) / 2;

//        TNode root = new TNode(arr[mid]);

//        root.left = ConvertArrayToBst(arr, lb, mid - 1);
//        root.right = ConvertArrayToBst(arr, mid + 1, ub);

//        return root;
//    }
//    public void PreOrder(TNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Console.Write($"{root.data}" + " ");
//        PreOrder(root.left);
//        PreOrder(root.right);
//    }
//}
//class ConvertSortedArrayToBst
//{
//    public static void Main()
//    {
//        Helper h = new Helper();
//        int[] arr = { 1, 2, 3, 4, 5, 6, 7 };

//        TNode root = h.ConvertArrayToBst(arr, 0, arr.Length - 1);
//        h.PreOrder(root);
//    }
//}

//// Complexity : O(N) as each element of the array is processed exactly once and we have n elements, space : O(N)