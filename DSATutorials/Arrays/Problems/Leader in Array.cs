
//class Solution
//{
//    // Time : O(n^2) , space :O(1)
//    //public List<int> Leaders(int[] arr)
//    //{
//    //    if (arr == null || arr.Length == 0)
//    //    {
//    //        return null;
//    //    }

//    //    List<int> result = new List<int>();
//    //    for (int i = 0; i < arr.Length; i++)
//    //    {
//    //        int j = 0;
//    //        for (j = i + 1; j < arr.Length; j++)
//    //        {
//    //            if (arr[i] < arr[j])
//    //            {
//    //                break;
//    //            }
//    //        }

//    //        // means no breakage in sequence was found
//    //        if (j == arr.Length)
//    //        {
//    //            result.Add(arr[i]);
//    //        }
//    //    }

//    //    return result;
//    //}

//    // Time : (n) , space :O(n), Auxillary :O(1)
//    public List<int> Leaders(int[] arr)
//    {
//        if (arr == null || arr.Length == 0)
//        {
//            return null;
//        }

//        List<int> result = new List<int>();

//        int leader = int.MinValue;

//        for (int i = arr.Length - 1; i >= 0; i--)
//        {
//            if (arr[i] > leader)
//            {
//                leader = arr[i];
//                result.Add(arr[i]);
//            }
//        }

//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 2, 3, 4, 5, 2 };

//        Solution s = new Solution();

//        List<int> result = s.Leaders(arr);

//        foreach (int item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}