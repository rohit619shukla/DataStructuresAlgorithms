
//using System.Text;

//public class Solution
//{
//    public string RemoveKdigits(string num, int k)
//    {
//        //base cases 
//        // String could be empty or length is same as k
//        if (num == null || num.Length == k)
//        {
//            return "0";
//        }
//        //string result = "";
//        // Iterate over entire string one by one.
//        // Idea is to maintain strictly increasing order in order to get smallest number
//        // Hints : Focus on place of each number like one, tens, hunderred, thousand and so on
//        // use stack to maintain the order in increasing
//        Stack<char> st = new Stack<char>();

//        for (int i = 0; i < num.Length; i++)
//        {
//            while (st.Count > 0 && st.Peek() > num[i] && k > 0)
//            {
//                st.Pop();
//                k--;
//            }

//            if (st.Count != 0 || num[i] > '0')
//            {
//                st.Push(num[i]);
//            }
//        }

//        // string is already sorted hence carefully delete leftover k elements
//        while (st.Count > 0 && k > 0)
//        {
//            st.Pop();
//            k--;
//        }
//        // whatever is left in stack add to result
//        char[] resultArray = new char[st.Count];
//        int index = resultArray.Length;

//        while (st.Count > 0)
//        {
//            resultArray[--index] = st.Pop();
//        }

//        return resultArray.Length == 0 ? "0" : new string(resultArray);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        //string num = "1432219";
//        string num = "547891";
//        //string num = "10200";
//        //string num = "123456";
//        //string num = "10";
//        int k = 3;

//        Solution s = new Solution();

//        Console.WriteLine(s.RemoveKdigits(num, k));
//    }
//}


//// Time : O(n) , space :O(n)