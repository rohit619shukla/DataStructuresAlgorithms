
//public class Solution
//{
//    // Time: O(3N) , space :O(1)
//    //public void MoveZeroes(int[] nums)
//    //{
//    //    List<int> tempList = new List<int>();

//    //    // Pass 1 : get all non zero numbers and store in list 
//    //    for (int i = 0; i < nums.Length; i++)
//    //    {
//    //        if (nums[i] != 0)
//    //        {
//    //            tempList.Add(nums[i]);
//    //        }
//    //    }

//    //    // Pass 2: store all non zero number back in array
//    //    for (int i = 0; i < tempList.Count; i++)
//    //    {
//    //        nums[i] = tempList[i];
//    //    }

//    //    // Pass 3: assign zero to remaining places if any
//    //    for (int j = tempList.Count; j < nums.Length; j++)
//    //    {
//    //        nums[j] = 0;
//    //    }
//    //}

//    // Time :O(2N) , space :O(1)
//    public void MoveZeroes(int[] nums)
//    {
//        // Pass 1: Place all non negative number at start of array
//        int pos = 0;
//        for (int i = 0; i < nums.Length; i++)
//        {
//            if (nums[i] != 0)
//            {
//                nums[pos++] = nums[i];
//            }
//        }

//        // Pass 2: place all zeroes at end
//        for (int j = pos; j < nums.Length; j++)
//        {
//            nums[j] = 0;
//        }

//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 0, 1, 0, 3, 12 };

//        Solution s = new Solution();

//        s.MoveZeroes(arr);
//    }
//}