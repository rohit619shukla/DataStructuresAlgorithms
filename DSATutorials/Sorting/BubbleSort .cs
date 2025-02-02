

//class Solution
//{
//    public void Solve(int[] arr)
//    {
//        bool flag = false;
//        for (int i = 0; i < arr.Length - 1; i++)
//        {

//            for (int j = 0; j < arr.Length - 1 - i; j++)
//            {
//                if (arr[j] > arr[j + 1])
//                {
//                    Swap(arr, j, j + 1);
//                    flag = true;
//                }
//            }

//            if (flag == false)
//            {
//                break;
//            }
//        }
//    }

//    private void Swap(int[] arr, int lb, int ub)
//    {
//        int temp = arr[lb];
//        arr[lb] = arr[ub];
//        arr[ub] = temp;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        //int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
//        int[] arr = { 1, 2, 3, 4, 5, 6 };
//        Solution s = new Solution();

//        s.Solve(arr);

//        foreach (int item in arr)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}

//// Complexity :
//// Worst : O(n^2)
//// Best : O(n) already sorted