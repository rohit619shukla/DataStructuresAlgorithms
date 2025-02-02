

// class Solution
// {
//    #region Sorting
//    // Time : O(nlogn), space : O(1)
//    //public int Solve(int[] arr, int k)
//    //{
//    //    // Sort the array
//    //    Array.Sort(arr);

//    //    // get the kth element
//    //    return arr[arr.Length - k];
//    //}
//    #endregion



//    #region MinHeap

//    // Time : O(n + klogn) , space : O(n)
//    public int Solve(int[] arr, int k)
//    {
//        int heapSize = arr.Length;

//        // 1. Build Min Heap
//        for (int i = heapSize / 2 - 1; i >= 0; i--)
//        {
//            Heapify(arr, i, heapSize);
//        }

//        int kthElement = 0;

//        // 2. Remove k elements from heap
//        for (int i = 0; i < k; i++)
//        {
//            kthElement = RemoveKElements(arr, ref heapSize);
//        }

//        return kthElement;
//    }

//    private int RemoveKElements(int[] arr, ref int heapSize)
//    {
//        // store the top element in a variable
//        int temp = arr[0];

//        // move last node to top
//        arr[0] = arr[heapSize - 1];

//        // reduce size of heap
//        heapSize--;

//        Heapify(arr, 0, heapSize);

//        return temp;

//    }
//    private void Heapify(int[] arr, int top, int heapSize)
//    {
//        int smallest = top;

//        while (true)
//        {
//            int leftChild = 2 * top + 1;
//            int rightChild = 2 * top + 2;

//            if (leftChild < heapSize && arr[smallest] > arr[leftChild])
//            {
//                smallest = leftChild;
//            }

//            if (rightChild < heapSize && arr[smallest] > arr[rightChild])
//            {
//                smallest = rightChild;
//            }

//            if (smallest != top)
//            {
//                Swap(smallest, top, arr);
//                top = smallest;
//            }
//            else
//            {
//                break;
//            }
//        }

//    }

//    private void Swap(int a, int b, int[] arr)
//    {
//        int temp = arr[a];
//        arr[a] = arr[b];
//        arr[b] = temp;
//    }

//    #endregion

//    #region QuickSelect
//    #endregion
// }
// class Program
// {
//    public static void Main()
//    {
//        int[] arr = { 7, 10, 4, 3, 20, 15 };

//        int k = 3;

//        Solution s = new Solution();
//        Console.WriteLine(s.Solve(arr, k));
//    }
// }