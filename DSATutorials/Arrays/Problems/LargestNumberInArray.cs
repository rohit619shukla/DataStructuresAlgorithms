

//class Solution
//{
//    public int Solve(int[] arr)
//    {
//        if (arr == null || arr.Length == 0)
//        {
//            return -1;
//        }

//        int largest = arr[0];

//        for (int i = 1; i < arr.Length; i++)
//        {
//            largest = Math.Max(largest, arr[i]);
//        }

//        return largest;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 20, 10, 20, 4, 100 };

//        Solution s = new Solution();

//        Console.WriteLine(s.Solve(arr));
//    }
//}

//// Time : O(n) , space :O(1)