//using System;

//class TestClass
//{
//    /// <summary>
//    /// This is variation of Insertion sort with same complexity
//    /// </summary>
//    /// <param name="arr"></param>
//    public void Segregate(int[] arr)
//    {
//        for (int i = 1; i < arr.Length; i++)
//        {
//            int j = i - 1;
//            int temp = arr[i];

//            if (arr[i] > 0)             // If the given number is greater than 0 than continue;
//            {
//                continue;
//            }


//            while (j >= 0 && arr[j] > 0)
//            {
//                arr[j + 1] = arr[j];
//                j--;
//            }
//            arr[j + 1] = temp;
//        }

//        for (int i = 0; i < arr.Length; i++)
//        {
//            Console.Write($"{arr[i]}" + " ");
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        TestClass t = new TestClass();
//        int[] arr = { 12, 11, -13, -5, 6, -7, 5, -3, -6 };
//        t.Segregate(arr);
//    }
//}

// Complexity : O(N^2)