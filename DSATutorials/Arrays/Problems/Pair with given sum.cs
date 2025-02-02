//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DS_Tutorials.Arrays
//{
//    class Pair_with_given_sum
//    {
//        public void FindSum(int[] arr, int sum)
//        {
//            Dictionary<int, int> m = new Dictionary<int, int>();
//            int count = 0;
//            for (int i = 0; i < arr.Length; i++)
//            {
//                int diff = sum - arr[i];

//                if (m.ContainsKey(diff))
//                {
//                    count += m[diff];
//                }

//                if (m.ContainsKey(arr[i]))
//                {
//                    m[arr[i]]++;
//                }
//                else
//                {
//                    m.Add(arr[i], 1);
//                }
//            }
//            Console.WriteLine($"{count}");

//            //for (int i = 0; i < arr.Length; i++)
//            //{
//            //    int diff = sum - arr[i];

//            //    if (map.ContainsKey(diff) && (sum - diff == map[diff]))
//            //    {
//            //        Console.WriteLine($"{diff}:{arr[i]}");
//            //    }
//            //    else
//            //    {
//            //        map.Add(arr[i], diff);
//            //    }
//            //}
//        }
//    }

//    class Programm
//    { 
//        public static void Main()
//        {
//            int[] arr = { 8, 7, 2, 5, 3, 1 };

//            int sum = 10;

//            //int[] arr = { 1, 1, 1, 1 };

//            //int sum = 2;



//            Pair_with_given_sum p = new Pair_with_given_sum();
//            p.FindSum(arr, sum);
//        }
//    }
//}

////Complexity: O(N), space: O(N)
