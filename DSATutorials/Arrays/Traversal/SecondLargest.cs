

//class Soltuion
//{
//    // Brute force : O(nlogn) ,space :(1)
//    //public int Solve(int[] arr)
//    //{
//    //    if (arr == null || arr.Length < 2)
//    //    {
//    //        return -1;
//    //    }

//    //    Array.Sort(arr);


//    //    return arr[arr.Length - 1] == arr[arr.Length - 2] ? -1 : arr[arr.Length - 2];
//    //}


//    // Better force : O(2n) ,space :(1)
//    //public int Solve(int[] arr)
//    //{
//    //    if (arr == null || arr.Length < 2)
//    //    {
//    //        return -1;
//    //    }

//    //    int largest = arr[0];
//    //    int secondLargest = -1;

//    //    for (int i = 1; i < arr.Length; i++)
//    //    {
//    //        largest = Math.Max(arr[i], largest);
//    //    }

//    //    for (int j = 0; j < arr.Length; j++)
//    //    {
//    //        if (arr[j] < largest)
//    //        {
//    //            secondLargest = Math.Max(arr[j], secondLargest);
//    //        }
//    //    }

//    //    return secondLargest;
//    //}

//    // Optimal : O(n) , space :O(1)
//    public int Solve(int[] arr)
//    {
//        if (arr == null || arr.Length < 2)
//        {
//            return -1;
//        }

//        int firstLargest = arr[0];
//        int secondLargest = -1;

//        for (int i = 1; i < arr.Length; i++)
//        {
//            if (arr[i] > firstLargest)
//            {
//                secondLargest = firstLargest;
//                firstLargest = arr[i];
//            }
//            else if (arr[i] > secondLargest && arr[i] != firstLargest)
//            {
//                secondLargest = arr[i];
//            }
//        }

//        return secondLargest;
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        //int[] arr = { 12, 35, 1, 10, 34, 1 };
//        //int[] arr = { 12, 12, 12, 12, 12 };
//        int[] arr = { 1, 5, 7, 8, 3, 2, 9, 9 };

//        Soltuion s = new Soltuion();

//        Console.WriteLine(s.Solve(arr));
//    }
//}