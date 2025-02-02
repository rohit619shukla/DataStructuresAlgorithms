
//class Solution
//{
//    public void Solve(int[] arr)
//    {
//        for (int i = 0; i < arr.Length - 1; i++)
//        {
//            int min = i;

//            for (int j = i + 1; j < arr.Length; j++)
//            {
//                if (arr[j] < arr[min])
//                {
//                    min = j;
//                }
//            }

//            if (min != i)
//            {
//                Swap(arr, min, i);
//            }
//        }
//    }

//    private void Swap(int[] arr, int n1, int n2)
//    {
//        int temp = arr[n1];
//        arr[n1] = arr[n2];
//        arr[n2] = temp;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };

//        Solution s = new Solution();

//        s.Solve(arr);

//        foreach (int i in arr)
//        {
//            Console.Write($"{i}" + " ");
//        }
//    }
//}

//// Complexity : 
//// Worst : O(n^2)
//// Best : O(n^2)