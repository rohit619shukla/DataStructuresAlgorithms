
//class Solution
//{
//    // Time : O(n) , space :O(n)
//    public bool AreSame(int[] arr1, int[] arr2)
//    {
//        if (arr1.Length != arr2.Length)
//        {
//            return false;
//        }

//        Dictionary<int, int> map = new Dictionary<int, int>();

//        foreach (int item in arr1)
//        {
//            if (!map.ContainsKey(item))
//            {
//                map[item] = 1;
//            }
//            else
//            {
//                map[item]++;
//            }
//        }


//        foreach (int item in arr2)
//        {
//            if (!map.ContainsKey(item))
//            {
//                return false;
//            }
//            else
//            {
//                map[item]--;
//            }
//        }

//        foreach (var item in map)
//        {
//            if (item.Value != 0)
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
//        int[] arr1 = { 1, 2, 5, 4, 0, 2, 1 };

//        int[] arr2 = { 2, 4, 5, 0, 1, 1, 2 };

//        Solution s = new Solution();

//        Console.WriteLine(s.AreSame(arr1, arr2));
//    }
//}