
//public class Solution
//{
//    public int[] NextGreaterElement(int[] nums)
//    {
//        // 1. Create an array to store the result (same size as nums)
//        int[] result = new int[nums.Length];

//        // 2. Create a stack to store the indices of elements in nums
//        Stack<int> st = new Stack<int>();

//        // 3. Initialize result array to -1 (by default, no greater element)
//        Array.Fill(result, -1);

//        // 4. Iterate over nums twice to simulate circular behavior
//        for (int i = 0; i < 2 * nums.Length; i++)
//        {
//            int idx = i % nums.Length;  // Handle the circular nature

//            // 5. Update the next greater elements for the stack
//            while (st.Count > 0 && nums[st.Peek()] < nums[idx])
//            {
//                result[st.Pop()] = nums[idx];
//            }

//            // 6. Push the index to the stack only for the first pass (first n elements)
//            if (i < nums.Length)
//            {
//                st.Push(idx);
//            }
//        }

//        // 7. Return the result array
//        return result;
//    }


//}
//class Program
//{
//    public static void Main()
//    {
//        int[] nums = { 5, 4, 3, 2, 1 };

//        Solution s = new Solution();

//        int[] result = s.NextGreaterElement(nums);

//        foreach (int item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}