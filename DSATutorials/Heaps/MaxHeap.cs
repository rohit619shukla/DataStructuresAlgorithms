



//class Solution
//{
//    public int[] arr;   // will store the heap
//    public int currsize;  // curr size of the array
//    public int totSize;  // total size of the array

//    public Solution(int maxSize)
//    {
//        totSize = maxSize;
//        arr = new int[maxSize];
//    }

//    public void InsertNode(int val)
//    {
//        // base case
//        if (currsize == totSize)
//        {
//            Console.WriteLine("Heap overflow");
//            return;
//        }

//        // Add the node at last position in heap
//        arr[currsize] = val;

//        int index = currsize;
//        // Make sure heap is aligned by moving the newly inserted node from bottom to up
//        while (index > 0 && arr[(index - 1) / 2] < arr[index])
//        {
//            Swap((index - 1) / 2, index);
//            index = (index - 1) / 2;
//        }

//        //increase size of the heap by 1
//        currsize++;

//        Console.WriteLine($"Element inserted in heap: {val}");
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
//        if (currsize < 0)
//        {
//            Console.WriteLine("Heap underflow");
//            return;
//        }

//        // hold the first element to print
//        int temp = arr[0];

//        // put the last node in heap in first node
//        arr[0] = arr[currsize - 1];

//        // reduce the size of the heap
//        currsize--;

//        // Perform heapify from top
//        Heapify(0);

//        Console.WriteLine();
//        Console.WriteLine($"Node deleted from heap: {temp}");
//    }

//    private void Heapify(int top)
//    {
//        int largest = top;
//        int leftChild = 2 * top + 1;
//        int rightChild = 2 * top + 2;

//        // Since we are going downwards we need to make sure there is no heap overflow as well as we respect heap
//        if (leftChild < currsize && arr[largest] < arr[leftChild])
//        {
//            largest = leftChild;
//        }

//        if (rightChild < currsize && arr[largest] < arr[rightChild])
//        {
//            largest = rightChild;
//        }

//        // If above two if conditions are not satisfied then we have reached a point where the node is last in heap and no further comparison possible
//        // or heap overflow already happened
//        if (largest != top)
//        {
//            Swap(largest, top);
//            Heapify(largest);
//        }
//    }

//    public void PrintHeap()
//    {
//        Console.WriteLine("Current Heap is:");
//        for (int i = 0; i < currsize; i++)
//        {
//            Console.Write($"{arr[i]}" + " ");
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution(1000);
//        s.InsertNode(5);
//        s.InsertNode(3);
//        s.InsertNode(17);
//        s.InsertNode(10);
//        s.InsertNode(84);
//        s.InsertNode(19);
//        s.PrintHeap();
//        s.Delete();
//        s.PrintHeap();
//        s.Delete();
//        s.PrintHeap();
//    }
//}

//// Time : O(Logn), space : O(n)