
//class Solution
//{
//    public int[] arr;
//    public int currSize;
//    public int maxSize;

//    public Solution(int capacity)
//    {
//        maxSize = capacity;
//        arr = new int[capacity];
//    }

//    public void InsertNode(int val)
//    {
//        // base case
//        if (currSize == maxSize)
//        {
//            Console.WriteLine("Heap overflow");
//            return;
//        }

//        int index = currSize;

//        // Add the new node to end of the heap
//        arr[currSize] = val;


//        while (index > 0 && arr[(index - 1) / 2] > arr[index])
//        {
//            Swap((index - 1) / 2, index);
//            index = (index - 1) / 2;
//        }

//        // Increase size of heap
//        currSize++;

//        Console.WriteLine($"Node inserted in heap is : {val}");
//    }

//    private void Swap(int a, int b)
//    {
//        int temp = arr[a];
//        arr[a] = arr[b];
//        arr[b] = temp;
//    }

//    public void Delete()
//    {
//        // base case
//        if (currSize < 0)
//        {
//            Console.WriteLine("Heap underflow");
//            return;
//        }

//        // store the last element to be removed and returned
//        int firstNode = arr[0];

//        // move last element to first node location
//        arr[0] = arr[currSize - 1];

//        // reduce size of heap
//        currSize--;

//        Heapify(0);

//        Console.WriteLine();
//        Console.WriteLine($"Node removed is : {firstNode}");
//    }

//    private void Heapify(int top)
//    {
//        int smallest = top;
//        int left = 2 * top + 1;
//        int right = 2 * top + 2;

//        if (left < currSize && arr[left] < arr[smallest])
//        {
//            smallest = left;
//        }

//        if (right < currSize && arr[right] < arr[smallest])
//        {
//            smallest = right;
//        }

//        if (smallest != top)
//        {
//            Swap(smallest, top);
//            Heapify(smallest);
//        }
//    }

//    public void PrintHeap()
//    {
//        for (int i = 0; i < currSize; i++)
//        {
//            Console.Write($"{arr[i]}" + " ");
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution(10);
//        s.InsertNode(5);
//        s.InsertNode(3);
//        s.InsertNode(17);
//        s.InsertNode(10);
//        s.InsertNode(2);
//        s.InsertNode(19);
//        s.PrintHeap();
//        s.Delete();
//        s.PrintHeap();
//        s.Delete();
//        s.PrintHeap();
//    }
//}

//// Time : O(Logn), space : O(n)