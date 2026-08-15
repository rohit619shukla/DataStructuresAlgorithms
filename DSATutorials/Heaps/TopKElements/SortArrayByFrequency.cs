
//class Node
//{
//    public int val;
//    public int freq;

//    public Node(int data, int f)
//    {
//        val = data;
//        freq = f;
//    }
//}

//class Solution
//{
//    public int[] FrequencySort(int[] arr)
//    {
//        // 1. Create frequency map
//        Dictionary<int, int> map = new Dictionary<int, int>();
//        foreach (int i in arr)
//        {
//            if (map.ContainsKey(i))
//                map[i]++;
//            else
//                map[i] = 1;
//        }

//        // 2. Build Min-heap to sort by freq in asc, and by value in desc when freq is the same
//        List<Node> pq = new List<Node>();
//        foreach (var item in map)
//        {
//            BuildMinHeap(pq, item.Key, item.Value);
//        }

//        List<int> result = new List<int>();

//        // 3. Extract elements from Min heap until empty
//        while (pq.Count > 0)
//        {
//            Node temp = Dequeue(pq);
//            for (int i = 0; i < temp.freq; i++)
//                result.Add(temp.val);
//        }

//        return result.ToArray();
//    }

//    private void BuildMinHeap(List<Node> pq, int val, int freq)
//    {
//        Node node = new Node(val, freq);
//        pq.Add(node);
//        int index = pq.Count - 1;

//        while (index > 0 && Compare(pq[(index - 1) / 2], pq[index]))
//        {
//            Swap((index - 1) / 2, index, pq);
//            index = (index - 1) / 2;
//        }
//    }

//    private Node Dequeue(List<Node> pq)
//    {
//        Node temp = pq[0];
//        pq[0] = pq[pq.Count - 1];
//        pq.RemoveAt(pq.Count - 1);
//        Heapify(pq, 0);
//        return temp;
//    }

//    private void Heapify(List<Node> pq, int top)
//    {
//        int smallest = top;
//        int size = pq.Count;

//        while (true)
//        {
//            int left = 2 * top + 1;
//            int right = 2 * top + 2;

//            if (left < size && Compare(pq[smallest], pq[left]))
//                smallest = left;

//            if (right < size && Compare(pq[smallest], pq[right]))
//                smallest = right;

//            if (smallest != top)
//            {
//                Swap(top, smallest, pq);
//                top = smallest;
//            }
//            else
//            {
//                break;
//            }
//        }
//    }

//    private bool Compare(Node n1, Node n2)
//    {
//        // Return true if n1 should come after n2, meaning n2 has higher priority
//        if (n1.freq == n2.freq)
//        {
//            return n1.val < n2.val; 
//        }
//        else
//        {
//            return n1.freq > n2.freq;  // Lower frequency has higher priority
//        }
//    }

//    private void Swap(int n1, int n2, List<Node> pq)
//    {
//        Node temp = pq[n1];
//        pq[n1] = pq[n2];
//        pq[n2] = temp;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 2, 3, 1, 3, 2 };
//        Solution s = new Solution();
//        var result = s.FrequencySort(arr);

//        foreach (int item in result)
//        {
//            Console.Write($"{item} ");
//        }
//    }
//}


//// Time : O(nlogn) , space : O(n)