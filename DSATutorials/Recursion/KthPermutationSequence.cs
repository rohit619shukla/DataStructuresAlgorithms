
//using System.Text;

//public class Solution
//{
//    public string GetPermutation(int n, int k)
//    {
//        StringBuilder sb = new StringBuilder();

//        // Create a list of numbers from range 1 to n to pick up from
//        List<int> temp = new List<int>();

//        int fact = 1;

//        for (int i = 1; i <= n; i++)
//        {
//            fact *= i;
//            temp.Add(i);
//        }

//        // Start intial porcess
//        k = k - 1;

//        // Get intial factorial number to start with by removing 1
//        fact /= n;

//        while (temp.Count > 1)
//        {
//            int position = k / fact;

//            sb.Append(temp[position]);

//            temp.RemoveAt(position);

//            k = k % fact;

//            n--;

//            fact /= n;
//        }

//        sb.Append(temp[0]);

//        return sb.ToString();
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int n = 4, k = 17;

//        Solution s = new Solution();

//        Console.WriteLine(s.GetPermutation(n, k));
//    }
//}

//// Time :O(n^2) , space :(n)