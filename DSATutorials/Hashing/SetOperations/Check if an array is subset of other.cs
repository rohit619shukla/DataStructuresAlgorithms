//class Solution
//{
//    // Time : O(m+n) , space : O(n)
//    public bool AreSubset(int[] arr1, int[] arr2)
//    {
//        if (arr2.Length > arr1.Length)
//            return false;

//        HashSet<int> set1 = new HashSet<int>(arr1);

//        foreach (int item in arr2)
//        {
//            if (!set1.Contains(item))
//            {
//                return false;
//            }
//        }

//        return true;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int[] arr1 = { 11, 1, 13, 21, 3, 7 };
//        int[] arr2 = { 11, 3, 7, 1 };


//        Solution s = new Solution();

//        Console.WriteLine(s.AreSubset(arr1, arr2));
//    }
//}