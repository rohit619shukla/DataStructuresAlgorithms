
//public class Solution
//{
//    // Time :O(n) , space :O(1)
//    public int MajorityElement(int[] arr)
//    {

//        int candidate = 0, count = 0;

//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (candidate == arr[i])
//            {
//                count++;
//            }
//            else if (count == 0)
//            {
//                candidate = arr[i];
//                count = 1;
//            }
//            else
//            {
//                count--;
//            }
//        }

//        return candidate;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 2, 2, 1, 1, 1, 2, 2 };

//        Solution s = new Solution();

//        Console.WriteLine(s.MajorityElement(arr));
//    }
//}