

//class Solution
//{
//    public void Solve(string str)
//    {
//        Permute(str.ToCharArray(), 0, str.Length - 1);
//    }

//    private void Permute(char[] chrArray, int lb, int ub)
//    {
//        // base case
//        if (lb == ub)
//        {
//            Console.WriteLine(new string(chrArray));
//            return;
//        }

//        for (int i = lb; i <= ub; i++)
//        {
//            Swap(ref chrArray[lb], ref chrArray[i]);

//            Permute(chrArray, lb + 1, ub);

//            Swap(ref chrArray[lb], ref chrArray[i]);
//        }
//    }

//    private void Swap(ref char a, ref char b)
//    {
//        char temp = a;
//        a = b;
//        b = temp;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "ABC";

//        Solution s = new Solution();
//        s.Solve(str);
//    }
//}

//// Time: O(n * n!), space : O(n)