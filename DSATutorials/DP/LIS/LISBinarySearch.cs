

//class Solution
//{
//    public void Solve(int[] nums)
//    {
//        List<int> result = new List<int>();

//        foreach (int num in nums)
//        {
//            int lb = 0;
//            int ub = result.Count;

//            while (lb < ub)
//            {
//                int mid = lb + (ub - lb) / 2;

//                if (result[mid] < num)
//                {
//                    lb = mid + 1;
//                }
//                else
//                {
//                    //we are looking for the first element that is greater than or equal to the current number, rather than just finding an exact match

//                    ub = mid;
//                }
//            }

//            if (lb == result.Count)
//            {
//                //smallest index where the current number can fit
//                result.Add(num);
//            }
//            else
//            {
//                result[lb] = num;
//            }
//        }

//        foreach (int elem in result)
//        {
//            Console.Write($"{elem}" + " ");
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] nums = { 2, 5, 3, 7, 11, 8, 10, 13, 6 };

//        Solution s = new Solution();

//        s.Solve(nums);
//    }
//}

////Time Complexity: O(n \log n) , Space Complexity: O(n)