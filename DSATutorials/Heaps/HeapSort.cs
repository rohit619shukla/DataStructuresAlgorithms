

//class Solution
//{
//    public void HeapSort(int[] arr)
//    {
//        // 1. Build Max Heap
//        BuildMaxHeap(arr);

//        // Not required
//        Console.WriteLine("Original Array is: ");
//        PrintHeap(arr);

//        // 2. Perform Delete
//        Delete(arr);

//        // Not required
//        Console.WriteLine("\nSorted Array is: ");
//        PrintHeap(arr);
//    }

//    private void BuildMaxHeap(int[] arr)
//    {
//        int heapSize = arr.Length;

//        for (int i = heapSize / 2 - 1; i >= 0; i--)
//        {
//            Heapify(arr, i, heapSize);
//        }
//    }

//    private void Heapify(int[] arr, int top, int heapSize)
//    {
//        int largest = top;

//        while (true)
//        {
//            int leftChild = 2 * top + 1;
//            int rightChild = 2 * top + 2;

//            if (leftChild < heapSize && arr[leftChild] > arr[largest])
//            {
//                largest = leftChild;
//            }

//            if (rightChild < heapSize && arr[rightChild] > arr[largest])
//            {
//                largest = rightChild;
//            }

//            if (largest != top)
//            {
//                Swap(largest, top, arr);
//                top = largest;
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

//    private void Delete(int[] arr)
//    {
//        int heapSize = arr.Length;

//        for (int i = heapSize - 1; i > 0; i--)
//        {
//            Swap(0, i, arr);
//            Heapify(arr, 0, i);
//        }

//    }

//    private void PrintHeap(int[] arr)
//    {
//        for (int i = 0; i < arr.Length; i++)
//        {
//            Console.Write($"{arr[i]}" + " ");
//        }
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 9, 4, 3, 8, 10, 2, 5 };

//        Solution s = new Solution();
//        s.HeapSort(arr);
//    }
//}


//// Time : O(n) for building heap, O(nlogn) for deletion, total : O(nlogn), space : O(1)

//// Building heap takes O(n) time becoz we will start from n/2-1 index and move 1 step down in incremental level.
//// More refrence : coder army channel