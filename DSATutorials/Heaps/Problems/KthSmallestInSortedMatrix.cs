
//class Node
//{
//    public int val;
//    public int rowCord;
//    public int colCord;

//    public Node(int v, int r, int c)
//    {
//        val = v;
//        rowCord = r;
//        colCord = c;
//    }
//}
//class Solution
//{
//    public List<Node> pq;
//    public Solution()
//    {
//        pq = new List<Node>();
//    }
//    public int KthSmallest(int[][] matrix, int k)
//    {
//        // Two step process
//        // 1. Build Heap
//        // 2. Remove k elements from heap

//        int rows = matrix.Length;
//        int cols = matrix[0].Length;

//        // First add all the first col elements in the heap

//        // Time: O(nlogn)
//        for (int row = 0; row < rows; row++)
//        {
//            Enqueue(matrix[row][0], row, 0);
//        }

//        // Time : O(klogn)
//        // Start extracting the elements from heap k times
//        for (int i = 0; i < k - 1; i++)
//        {
//            Node currNode = Dequeue();

//            // Check to see if the currentNode has any immediate adjacent element
//            if (currNode.colCord + 1 < cols)
//            {
//                Enqueue(matrix[currNode.rowCord][currNode.colCord + 1], currNode.rowCord, currNode.colCord + 1);
//            }
//        }

//        return Dequeue().val;
//    }


//    #region MinHeap

//    // Time : O(logn)
//    private void Enqueue(int val, int rowCord, int colCord)
//    {
//        Node n = new Node(val, rowCord, colCord);

//        pq.Add(n);

//        int index = pq.Count - 1;

//        while (index > 0 && pq[(index - 1) / 2].val > pq[index].val)
//        {
//            Swap((index - 1) / 2, index);
//            index = (index - 1) / 2;
//        }
//    }

//    // Time : O(logn)
//    private Node Dequeue()
//    {
//        Node temp = pq[0];

//        pq[0] = pq[pq.Count - 1];

//        pq.RemoveAt(pq.Count - 1);

//        Heapify(0);

//        return temp;
//    }

//    // Time : O(logn)
//    private void Heapify(int top)
//    {
//        int smallest = top;

//        int heapSize = pq.Count;

//        while (true)
//        {
//            int leftChild = 2 * top + 1;
//            int rightChild = 2 * top + 2;

//            if (leftChild < heapSize && pq[leftChild].val < pq[smallest].val)
//            {
//                smallest = leftChild;
//            }

//            if (rightChild < heapSize && pq[rightChild].val < pq[smallest].val)
//            {
//                smallest = rightChild;
//            }

//            if (smallest != top)
//            {
//                Swap(smallest, top);
//                top = smallest;
//            }
//            else
//            {
//                break;
//            }
//        }
//    }

//    // Time : O(1)
//    private void Swap(int a, int b)
//    {
//        Node temp = pq[a];
//        pq[a] = pq[b];
//        pq[b] = temp;
//    }

//    #endregion
//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] matrix = new int[][] {
//            new int[] {1,5,9 },
//            new int[] {10,11,13 },
//            new int[] {12,13,15},
//        };

//        Solution s = new Solution();

//        Console.WriteLine(s.KthSmallest(matrix, 8));
//    }
//}

//// Time : O(nlogn), space :O(n)