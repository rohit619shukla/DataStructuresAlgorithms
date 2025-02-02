//using System;

//class StringHelper
//{
//    public string LongestCommonPrefix(string[] arr)
//    {
//        if (arr.Length == 0)
//        {
//            Console.WriteLine("Empty collection found");
//            return null;
//        }

//        string output = "";
//        string lcp = arr[0];

//        for (int i = 1; i < arr.Length; i++)
//        {
//            string current = arr[i];

//            int x = 0, y = 0;

//            while (x < lcp.Length && y < current.Length)
//            {
//                if (lcp[x] == current[y])
//                {
//                    output += lcp[x];
//                    x++;
//                    y++;
//                }
//                else
//                {
//                    break;
//                }
//            }
//            lcp = output;
//            output = "";
//        }

//        return (string.IsNullOrWhiteSpace(lcp) ? "" : lcp);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string[] arr = { "mint", "mini", "mineral" };

//        StringHelper h = new StringHelper();
//        Console.WriteLine(h.LongestCommonPrefix(arr));
//    }
//}

///* Complexity : O(N^2) and space : O(N) for resultant string*/