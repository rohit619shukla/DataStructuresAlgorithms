
//public class Node
//{
//    public char ch;
//    public int freq;

//    public Node(char c, int val)
//    {
//        ch = c;
//        freq = val;
//    }
//}

//public class Solution
//{
//    public string ReorganizeString(string s)
//    {
//        // Priority Queue
//        List<Node> pq = new List<Node>();

//        // Build the frequency map 
//        Dictionary<char, int> map = BuildMap(s);

//        // Build Heap
//        foreach (var item in map)
//        {
//            Enqueue(item.Key, item.Value, pq);
//        }

//        // Solve the rearrangement
//        return Solve(pq, s);
//    }


//    // O(n)
//    private Dictionary<char, int> BuildMap(string str)
//    {
//        Dictionary<char, int> map = new Dictionary<char, int>();

//        for (int i = 0; i < str.Length; i++)
//        {
//            if (map.ContainsKey(str[i]))
//            {
//                map[str[i]]++;
//            }
//            else
//            {
//                map.Add(str[i], 1);
//            }
//        }

//        return map;
//    }

//    // O(log n)
//    private void Enqueue(char ch, int freq, List<Node> pq)
//    {
//        // Create a node to be added to pq
//        Node n = new Node(ch, freq);

//        // Add node to pq. By default Add will add the node to last only
//        pq.Add(n);

//        // Get the index of last element from pq
//        int index = pq.Count - 1;

//        // Prelocate this node towards up
//        while (index > 0 && pq[(index - 1) / 2].freq < pq[index].freq)
//        {
//            Swap(pq, (index - 1) / 2, index);
//            index = (index - 1) / 2;
//        }
//    }

//    // O(log n)
//    private Node Dequeue(List<Node> pq)
//    {
//        // Get the first Node from pq
//        Node firstNode = pq[0];

//        // Swap the first node with last node in pq
//        pq[0] = pq[pq.Count - 1];

//        // Remove the node from list
//        pq.RemoveAt(pq.Count - 1);

//        // Heapify
//        Heapify(0, pq);

//        return firstNode;
//    }


//    // O(log n)
//    private void Heapify(int top, List<Node> pq)
//    {
//        int largest = top;

//        int size = pq.Count;

//        while (true)
//        {
//            int leftChild = 2 * top + 1;
//            int rightChild = 2 * top + 2;

//            if (leftChild < size && pq[leftChild].freq > pq[largest].freq)
//            {
//                largest = leftChild;
//            }

//            if (rightChild < size && pq[rightChild].freq > pq[largest].freq)
//            {
//                largest = rightChild;
//            }

//            if (largest != top)
//            {
//                Swap(pq, largest, top);
//                top = largest;
//            }
//            else
//            {
//                break;
//            }
//        }

//    }

//    // O(1)
//    private void Swap(List<Node> pq, int n1, int n2)
//    {
//        Node temp = pq[n1];
//        pq[n1] = pq[n2];
//        pq[n2] = temp;
//    }

//    // O(n log n)
//    private string Solve(List<Node> pq, string str)
//    {
//        string result = "";

//        int prevFreq = -1;
//        char prevChar = '#';

//        while (pq.Count > 0)
//        {
//            // Get the first node from pq
//            Node n = Dequeue(pq);

//            int currFreq = n.freq;
//            char currChar = n.ch;

//            result += currChar;

//            // Reduce the frequency of alreadyutlized character
//            currFreq--;

//            // if the prev char still has some elements to be used then add it back with latest freq in queue
//            if (prevFreq > 0)
//            {
//                Enqueue(prevChar, prevFreq, pq);
//            }

//            // assign for next iteration
//            prevFreq = currFreq;
//            prevChar = currChar;
//        }

//        if (result.Length == str.Length)
//        {
//            return result;
//        }
//        else
//        {
//            return "";
//        }

//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string str = "aaabc ";

//        Solution s = new Solution();
//        Console.WriteLine(s.ReorganizeString(str));
//    }
//}

//// Time : O(n log n), space : O(n)