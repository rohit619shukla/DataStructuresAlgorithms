
//public class Solution
//{
//    public int[] AsteroidCollision(int[] asteroids)
//    {
//        Stack<int> st = new Stack<int>();

//        // Iterate over all the asteroids
//        for (int i = 0; i < asteroids.Length; i++)
//        {
//            int val = asteroids[i];

//            // Possibility of collission : 
//            // 1. There has to be atleast 1 element in stack
//            // 2. Top of stack should be a +ve number
//            // 3. Incoming value should be less than 0
//            while (st.Count > 0 && st.Peek() > 0 && val < 0)
//            {
//                int sum = st.Peek() + val;

//                // case 1: sum is ve
//                if (sum > 0)
//                {
//                    // knock the incoming number
//                    val = 0;
//                }
//                // case 2: sum is -ve
//                else if (sum < 0)
//                {
//                    st.Pop();
//                }
//                // case 3: sum is 0
//                else
//                {
//                    st.Pop();
//                    // Nothing to proceed as both are destroyed
//                    val = 0;
//                }

//            }

//            if (val != 0)
//            {
//                st.Push(val);
//            }
//        }
//        int[] result = new int[st.Count];
//        int index = result.Length;

//        while (st.Count != 0)
//        {
//            result[--index] = st.Pop();
//        }

//        return result;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 10, 2, 7, -5, -9 };

//        Solution s = new Solution();

//        int[] result = s.AsteroidCollision(arr);

//        foreach (int item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}

//// Time : O(n) , space :O(n)