
//public class Solution
//{
//    public void NextPermutation(int[] arr)
//    {
//        // 1. First find the gola index

//        int gola_index = -1;
//        for (int i = arr.Length - 1; i > 0; i--)
//        {
//            if (arr[i] > arr[i - 1])
//            {
//                gola_index = i - 1;
//                break;
//            }
//        }

//        // 2. Now finx the swap index. The index which is just greater than this golaindex element
//        if (gola_index != -1)
//        {
//            int swapIndex = -1;
//            for (int j = arr.Length - 1; j > gola_index; j--)
//            {
//                if (arr[j] > arr[gola_index])
//                {
//                    swapIndex = j;
//                    break;
//                }
//            }

//            Swap(arr, swapIndex, gola_index);
//        }


//        // 3. Now reverse all elements after gola index
//        Reverse(arr, gola_index + 1, arr.Length - 1);
//    }

//    private void Swap(int[] arr, int lb, int ub)
//    {
//        int temp = arr[lb];
//        arr[lb] = arr[ub];
//        arr[ub] = temp;
//    }

//    private void Reverse(int[] arr, int lb, int ub)
//    {
//        while (lb < ub)
//        {
//            Swap(arr, lb, ub);
//            lb++;
//            ub--;
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 3, 4, 5, 2 };

//        Solution s = new Solution();

//        s.NextPermutation(arr);
//    }
//}

//// Time : O(n) , sapce :O(1)