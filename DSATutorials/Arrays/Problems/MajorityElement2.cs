

//public class Solution
//{
//    // Time :O(n) , space :(1)
//    public IList<int> MajorityElement(int[] arr)
//    {
//        List<int> result = new List<int>();
//        int count1 = 0, count2 = 0, candidate1 = 0, candidate2 = 0;

//        // Phase1 : voting
//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (arr[i] == candidate1)
//            {
//                count1++;
//            }
//            else if (arr[i] == candidate2)
//            {
//                count2++;
//            }
//            else if (count1 == 0)
//            {
//                candidate1 = arr[i];
//                count1 = 1;
//            }
//            else if (count2 == 0)
//            {
//                candidate2 = arr[i];
//                count2 = 1;
//            }
//            else
//            {
//                count1--;
//                count2--;
//            }
//        }

//        // Phase 2 : verification of votes
//        int finalCount1 = 0, finalCount2 = 0;

//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (arr[i] == candidate1)
//            {
//                finalCount1++;
//            }
//            else if (arr[i] == candidate2)
//            {
//                finalCount2++;
//            }
//        }

//        if (finalCount1 > arr.Length / 3)
//        {
//            result.Add(candidate1);
//        }

//        if (finalCount2 > arr.Length / 3)
//        {
//            result.Add(candidate2);
//        }

//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 2, 1, 1, 3, 1, 4, 5, 6 };

//        Solution s = new Solution();

//        IList<int> result = s.MajorityElement(arr);

//        foreach (int item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}

//// Note : for n/3 there will be atmost 2 majority element. This is due to formula: for n/k => k-1 majority elements