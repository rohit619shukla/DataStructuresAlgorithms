
//public class Solution
//{
//    // Time : O(n) and space : O(n), but multiple passes are required
//    // We will solve this problem using Next Smallest element
//    //public int LargestRectangleArea(int[] heights)
//    //{
//    //    int ans = int.MinValue;

//    //    // Create 2 arrays to store NSL and NSR values for every value
//    //    int[] nextSmallerValueToLeft = new int[heights.Length];
//    //    int[] nextSmallerValueToRight = new int[heights.Length];

//    //    Array.Fill(nextSmallerValueToRight, heights.Length);
//    //    Array.Fill(nextSmallerValueToLeft, -1);
//    //    // Stack to store the next smallest values
//    //    Stack<int> st = new Stack<int>();

//    //    // Start filling the value for each array in 2 passes
//    //    // Pass 1:For next smallest to right
//    //    for (int i = 0; i < heights.Length; i++)
//    //    {
//    //        while (st.Count > 0 && heights[st.Peek()] > heights[i])
//    //        {
//    //            nextSmallerValueToRight[st.Pop()] = i;
//    //        }
//    //        st.Push(i);
//    //    }

//    //    // CLear the stack for next operation
//    //    st.Clear();

//    //    // Pass 2:For next smallest to left
//    //    for (int i = heights.Length - 1; i >= 0; i--)
//    //    {
//    //        while (st.Count > 0 && heights[st.Peek()] > heights[i])
//    //        {
//    //            nextSmallerValueToLeft[st.Pop()] = i;
//    //        }
//    //        st.Push(i);
//    //    }

//    //    // Compute final answer in final pass
//    //    for (int i = 0; i < heights.Length; i++)
//    //    {
//    //        ans = Math.Max(ans, heights[i] * (nextSmallerValueToRight[i] - nextSmallerValueToLeft[i] - 1));
//    //    }

//    //    return ans;
//    //}

//    // In one pass , time :O(n) , space:O(n)
//    public int LargestRectangleArea(int[] heights)
//    {
//        Stack<int> stack = new Stack<int>();
//        int maxArea = 0;
//        int n = heights.Length;

//        // we may have left over in stack hence iterate beyond last number
//        for (int i = 0; i <= n; i++)
//        {
//            // setting zero when list ehausted and still some nodes in stack
//            int currentHeight = (i == n) ? 0 : heights[i];

//            while (stack.Count > 0 && currentHeight < heights[stack.Peek()])
//            {
//                int height = heights[stack.Pop()];
//                // To process next smallest left when stack is empty we take 1 only
//                //basically i is NSR and NSL in case stack is empty
//                // In usual case i : NSR and st.peek is NSL
//                int width = (stack.Count == 0) ? i : i - stack.Peek() - 1;
//                maxArea = Math.Max(maxArea, height * width);
//            }

//            stack.Push(i);
//        }

//        return maxArea;
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        int[] heights = { 2, 1, 5, 6, 2, 3 };

//        Solution s = new Solution();

//        Console.WriteLine(s.LargestRectangleArea(heights));
//    }
//}