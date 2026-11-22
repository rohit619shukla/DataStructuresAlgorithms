

// public class Solution
// {

//     // Time : O(n) , space : O(k) for only -ve elements
//     public List<int> FirstNegInt(int[] arr, int k)
//     {
//         // We will uae queue to store and retrive first -ve
//         Queue<int> q = new Queue<int>();

//         List<int> result = new List<int>();

//         int start = 0, end = 0, size = arr.Length;

//         while (end < size)
//         {
//             // Only if the current element at 'end' is -ve we will add to queue
//             // Queue will hold all the -ves
//             if (arr[end] < 0)
//             {
//                 q.Enqueue(arr[end]);
//             }


//             // Check if we have encountered a window
//             if (end - start + 1 == k)
//             {
//                 // Before moving the window, we must check and do following:
//                 // 1. If the front of queue contains a -ve, then that is your first -ve in the window, add to result
//                 if (q.Count > 0 && q.Peek() < 0)
//                 {
//                     result.Add(q.Peek());
//                 }
//                 else
//                 {
//                     // No -ve found in the current window
//                     result.Add(0);
//                 }

//                 // 2. If the current start is -ve remove the front as it will be pointing to same -ve number at start, as we dont want to use the same again
//                 if (arr[start] < 0)
//                 {
//                     q.Dequeue();
//                 }
//                 start++;
//             }

//             end++;
//         }

//         return result;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();

//         int[] arr = { 12, 1, 3, 5 };

//         int k = 3;

//         var result = s.FirstNegInt(arr, k);

//         foreach (int item in result)
//         {
//             Console.Write($"{item}" + " ,");
//         }
//     }
// }