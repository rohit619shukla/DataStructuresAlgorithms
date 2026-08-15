

//class Solution
//{
//    public void InsertionSort(int[] arr)
//    {
//        for (int i = 1; i < arr.Length; i++)
//        {
//            int temp = arr[i];
//            int j = i - 1;

//            while (j >= 0 && arr[j] > temp)
//            {
//                arr[j + 1] = arr[j];
//                j--;
//            }
//            arr[j + 1] = temp;
//        }

//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        //int[] arr = { 5, 4, 10, 1, 6, 2 };
//        int[] arr = { 1, 2, 3, 4, 5, 6 };

//        Solution s = new Solution();

//        s.InsertionSort(arr);

//        foreach (int i in arr)
//        {
//            Console.Write($"{i}" + " ");
//        }
//    }
//}

//// Complexity : 
//// Worst : O(n^2)
//// Best : O(n)