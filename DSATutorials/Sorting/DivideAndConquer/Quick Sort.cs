
//class Solution
//{
//    private Random rnd = new Random(); // Single Random instance for better randomness.
//    public void QuickSort(int[] arr, int lb, int ub)
//    {
//        if (lb < ub)
//        {
//            int location = Partition(arr, lb, ub);
//            QuickSort(arr, lb, location - 1);
//            QuickSort(arr, location + 1, ub);
//        }
//    }

//    private int Partition(int[] arr, int lb, int ub)
//    {
//        RandomNumber(arr, lb, ub);

//        int start = lb;
//        int end = ub;
//        int pivot = arr[lb];


//        while (start < end)
//        {
//            while (arr[start] <= pivot && start <= ub - 1)
//            {
//                start++;
//            }

//            while (arr[end] > pivot && end >= lb + 1)
//            {
//                end--;
//            }

//            if (start < end)
//            {
//                Swap(arr, start, end);
//            }
//        }

//        Swap(arr, lb, end);

//        return end;
//    }

//    private void RandomNumber(int[] arr, int lb, int ub)
//    {
//        int num = rnd.Next(lb, ub + 1);

//        Swap(arr, lb, num);
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
//        //int[] arr = { 7, 6, 10, 5, 9, 2, 1, 15, 7 };
//        int[] arr = { 1, 2, 3, 4, 5, 6 };

//        Solution s = new Solution();

//        s.QuickSort(arr, 0, arr.Length - 1);

//        foreach (int i in arr)
//        {
//            Console.Write($"{i}" + " ");
//        }
//    }
//}

//// Time : 
//// Best : O(nlogn) : when then order of element in the array is not sorted mostly
//// Worst : O(n^2): when the arrays is sorted in decreasing or non decreasing order, we could minimize this O(nlogn) using Randominzed quick sort
//// Why n^2 : (n-1) + (n-2) + (n-3) +...+1 =>  n(n-1)/2 => Sum of positive numbers upto n.
//// Basically if the array is sorted and we chose smallest number as pivot then first part will be empty and second part will contain (n-1) elements