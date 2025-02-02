

//using System.Collections.Generic;

//public class Node
//{
//    public string Word;
//    public int Freq;

//    public Node(string word, int freq)
//    {
//        Word = word;
//        Freq = freq;
//    }

//}
//public class Solution
//{
//    public IList<string> TopKFrequent(string[] words, int k)
//    {
//        Dictionary<string, int> map = new Dictionary<string, int>();

//        // 1.Build Frequency map
//        foreach (string word in words)
//        {
//            if (map.ContainsKey(word))
//            {
//                map[word]++;
//            }
//            else
//            {
//                map[word] = 1;
//            }
//        }


//        // 2. Build Max heap
//        List<Node> pq = new List<Node>();

//        foreach (var item in map)
//        {
//            BuildMaxHeap(pq, item.Key, item.Value);
//        }

//        // 3. Extract k items
//        List<string> result = new List<string>();

//        int currCount = 0;

//        while (pq.Count > 0)
//        {
//            Node temp = Dequeue(pq);

//            result.Add(temp.Word);

//            currCount++;

//            if (currCount == k)
//            {
//                break;
//            }
//        }

//        return result;
//    }

//    private void BuildMaxHeap(List<Node> pq, string word, int freq)
//    {
//        Node node = new Node(word, freq);

//        pq.Add(node);

//        int index = pq.Count - 1;

//        while (index > 0 && Compare(pq[(index - 1) / 2], pq[index]))
//        {
//            Swap(pq, (index - 1) / 2, index);
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
//        int largest = top;

//        int size = pq.Count;

//        while (true)
//        {
//            int left = 2 * top + 1;
//            int right = 2 * top + 2;

//            if (left < size && Compare(pq[largest], pq[left]))
//            {
//                largest = left;
//            }

//            if (right < size && Compare(pq[largest], pq[right]))
//            {
//                largest = right;
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

//    private void Swap(List<Node> pq, int n1, int n2)
//    {
//        Node temp = pq[n1];
//        pq[n1] = pq[n2];
//        pq[n2] = temp;
//    }

//    private bool Compare(Node n1, Node n2)
//    {
//        if (n1.Freq == n2.Freq)
//        {
//            return n1.Word.CompareTo(n2.Word) == 1 ? true : false;
//        }
//        else
//        {
//            return n1.Freq < n2.Freq;
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string[] words = { "the","day","is","sunny","the","the","the","sunny","is","is" };

//        int k = 4;


//        Solution s = new Solution();

//        var result = s.TopKFrequent(words, k);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}

////Time : O(nlogn) , space : O(n)