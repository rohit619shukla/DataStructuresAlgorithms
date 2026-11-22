// public class Solution
// {
//     // Time : O(n) , sapce :O(n)
//     public int[] MaxSlidingWindow(int[] nums, int k)
//     {
//         LinkedList<int> dequeue = new LinkedList<int>();
//         List<int> result = new List<int>();


//         int size = nums.Length;

//         for (int i = 0; i < size; i++)
//         {
//             // Step 1 : As the window expands we need to make sure our dequeue dont have the value which is not part of window in it
//             if (dequeue.Count > 0 && dequeue.First.Value < i - k + 1)
//             {
//                 dequeue.RemoveFirst();
//             }

//             // Step 2: Now the incoming element should br greater than all the elements in front of it in the dequeue. If present remove those
//             while (dequeue.Count > 0 && nums[dequeue.Last.Value] < nums[i])
//             {
//                 dequeue.RemoveLast();
//             }

//             // Step 3 : Add this incoming one to the dequeue
//             dequeue.AddLast(i);

//             // Step 4 : The front of the dequeue by default will contain the latest value in it
//             // This condition is necessary to make sure we start considering values from dequeue only when the window is mature enough to start with
//             if (i >= k - 1)
//             {
//                 result.Add(nums[dequeue.First.Value]);
//             }
//         }
//         return result.ToArray();
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();

//         int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };

//         int k = 3;


//         var result = s.MaxSlidingWindow(nums, k);

//         foreach (int item in result)
//         {
//             Console.WriteLine(item);
//         }
//     }
// }