//using System;

//class TestClass
//{
//    public void MissingNumberInArray(int[] arr)
//    {
//        // XOR for all elements 1 to n
//        int result1 = 1;

//        /* number of elements in array + 1 */
//        for (int i = 2; i <= arr.Length + 1; i++)
//        {
//            result1 = result1 ^ i;
//        }

//        // XOR for all actual elements in array
//        int result2 = arr[0];

//        for (int i = 1; i < arr.Length; i++)
//        {
//            result2 = result2 ^ arr[i];
//        }

//        int final = result1 ^ result2;
//        Console.WriteLine(final);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        TestClass t = new TestClass();
//        int[] arr = { 1, 2, 4, 6, 3, 7, 8 };
//        t.MissingNumberInArray(arr);
//    }
//}

////Complexity : O(N), space : O(1)