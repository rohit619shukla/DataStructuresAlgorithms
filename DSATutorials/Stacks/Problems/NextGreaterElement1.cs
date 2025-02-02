//public class Solution
//{
//    public int[] NextGreaterElement(int[] nums1, int[] nums2)
//    {
//        // 1. Create a result array to store final result
//        int[] result = new int[nums1.Length];

//        // 2. Create a dictionary to store and get faster access to location
//        Dictionary<int, int> map = new Dictionary<int, int>();

//        // 3. Create a stack for store the order of elements
//        Stack<int> st = new Stack<int>();

//        foreach (int val in nums2)
//        {
//            if (st.Count == 0)
//            {
//                st.Push(val);
//            }
//            else
//            {
//                // Keep popping till we get a number smaller than top of stack
//                while (st.Count != 0 && st.Peek() < val)
//                {
//                    map[st.Pop()] = val;
//                }
//                st.Push(val);
//            }
//        }

//        // 4. for left over element in stack assign -1
//        while (st.Count != 0)
//        {
//            map[st.Pop()] = -1;
//        }

//        // 5. Assign result
//        for (int i = 0; i < nums1.Length; i++)
//        {
//            result[i] = map[nums1[i]];
//        }
//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        int[] n1 = { 4, 1, 2 };
//        int[] n2 = { 1, 3, 4, 2 };

//        int[] result = s.NextGreaterElement(n1, n2);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}


//// Time :O(n) , space :O(n)