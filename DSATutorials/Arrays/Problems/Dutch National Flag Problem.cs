//public class Solution
//{
//    // Time :O(n) , space :O(1)
//    public void SortColors(int[] arr)
//    {
//        if (arr == null || arr.Length == 0)
//        {
//            return;
//        }

//        // Note : i = > denotes 0, j => denotes 1, k => denotes 2
//        int i = 0, j = 0, k = arr.Length - 1;

//        while (j <= k)
//        {
//            switch (arr[j])
//            {
//                case 0:
//                    Swap(arr, i, j);
//                    i++;
//                    j++;
//                    break;

//                case 1:
//                    j++;
//                    break;

//                case 2:
//                    Swap(arr, j, k);
//                    k--;
//                    break;

//                default:
//                    return;
//            }
//        }
//    }

//    private void Swap(int[] arr, int lb, int ub)
//    {
//        int temp = arr[lb];
//        arr[lb] = arr[ub];
//        arr[ub] = temp;

//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 2, 0, 2, 1, 1, 0 };

//        Solution s = new Solution();

//        s.SortColors(arr);
//    }
//}

////Note : Once an element is at right place what it denotes only move that variable