

//public class Solution
//{
//    // Time : O(nlogn), space :O(N)
//    public int ReversePairs(int[] nums)
//    {
//        int[] temp = new int[nums.Length];

//        return MergeSort(nums, 0, nums.Length - 1, temp);
//    }

//    private int MergeSort(int[] arr, int lb, int ub, int[] temp)
//    {
//        int count = 0;

//        if (lb < ub)
//        {
//            int mid = lb + (ub - lb) / 2;
//            count += MergeSort(arr, lb, mid, temp);
//            count += MergeSort(arr, mid + 1, ub, temp);
//            count += CountPairs(arr, lb, mid, ub);
//            Merge(arr, lb, ub, mid, temp);
//        }

//        return count;
//    }

//    private void Merge(int[] arr, int lb, int ub, int mid, int[] temp)
//    {
//        int i = lb;
//        int j = mid + 1;
//        int k = lb;

//        while (i <= mid && j <= ub)
//        {
//            if (arr[i] < arr[j])
//            {
//                temp[k] = arr[i];
//                i++;
//            }
//            else
//            {
//                temp[k] = arr[j];
//                j++;
//            }
//            k++;
//        }

//        while (j <= ub)
//        {
//            temp[k] = arr[j];
//            j++;
//            k++;
//        }

//        while (i <= mid)
//        {
//            temp[k] = arr[i];
//            i++;
//            k++;
//        }

//        for (int x = lb; x <= ub; x++)
//        {
//            arr[x] = temp[x];
//        }
//    }

//    private int CountPairs(int[] arr, int lb, int mid, int ub)
//    {
//        int count = 0;

//        int j = mid + 1;

//        for (int i = lb; i <= mid; i++)
//        {
//            while (j <= ub && (long)arr[i] > (long)(2 * arr[j]))
//            {
//                j++;
//            }
//            count += j - (mid + 1);
//        }
//        return count;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 8, 3, 6, 2 };

//        Solution s = new Solution();

//        Console.WriteLine(s.ReversePairs(arr));
//    }
//}