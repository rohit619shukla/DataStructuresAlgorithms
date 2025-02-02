
//class Solution
//{
//    public void Solve(int n, int k)
//    {
//        string result = "";

//        List<int> lst = new List<int>();

//        // Get initial factorial number
//        int fact = 1;

//        for (int i = 1; i <= n; i++)
//        {
//            fact *= i;
//            lst.Add(i);
//        }

//        // We will be starting with with 0 till k-1 index
//        k--;

//        fact /= n;

//        // The loop will run for n-1 times
//        while (true)
//        {

//            if (lst.Count == 1)
//            {
//                break;
//            }

//            // Get the position
//            int position = k / fact;

//            // Add the  number at this position to list
//            result += lst[position];

//            // Remove this number from list
//            // removal take O(n) times
//            lst.RemoveAt(position);

//            // Get next value of k
//            int nextK = k % fact;

//            // change values
//            k = nextK;

//            // reduce value fo n
//            n--;

//            // next value for fact
//            fact /= n;

//        }

//        result += lst[0];

//        Console.WriteLine(result);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int n = 4;
//        int k = 17;

//        Solution h = new Solution();
//        h.Solve(n, k);
//    }
//}

////Time : O(N^2) => While loops runs for O(n-1) times and remove operation in loop runs for O(n) times
//// Space : O(n) for storing the number in list and returning the final string