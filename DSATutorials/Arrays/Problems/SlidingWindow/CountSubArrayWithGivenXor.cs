
//class Solution
//{

//    // Time : O(N^2) , space :O(1)
//    //public int CountSubArray(int[] arr, int k)
//    //{
//    //    int count = 0;

//    //    for (int i = 0; i < arr.Length; i++)
//    //    {
//    //        int currSum = 0;

//    //        for (int j = i; j < arr.Length; j++)
//    //        {
//    //            currSum ^= arr[j];

//    //            if (currSum == k)
//    //            {
//    //                count++;
//    //            }
//    //        }
//    //    }

//    //    return count;
//    //}


//    // Time :O(n) , space :O(n)
//    public int CountSubArray(int[] arr, int k)
//    {

//        Dictionary<int, int> map = new Dictionary<int, int>();

//        int cumSum = 0, count = 0;

//        for (int i = 0; i < arr.Length; i++)
//        {
//            cumSum ^= arr[i];

//            if (map.ContainsKey(cumSum ^ k))
//            {
//                count += map[cumSum ^ k];
//            }

//            if (map.ContainsKey(cumSum))
//            {
//                map[cumSum]++;
//            }
//            else
//            {
//                map.Add(cumSum, 1);
//            }
//        }

//        return count;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 4, 2, 2, 6, 4 };

//        Solution s = new Solution();

//        Console.WriteLine(s.CountSubArray(arr, 6));
//    }
//}