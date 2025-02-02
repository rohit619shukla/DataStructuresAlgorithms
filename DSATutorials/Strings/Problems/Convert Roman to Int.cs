//using System;
//using System.Collections.Generic;
//class ConvertToInHelper
//{
//    public void ConvertToInt(string str, Dictionary<char, int> map)
//    {
//        if (string.IsNullOrWhiteSpace(str))
//        {
//            Console.WriteLine("Invalid string");
//            return;
//        }

//        if (map.Count == 0)
//        {
//            Console.WriteLine("Empty map found");
//            return;
//        }

//        int output = 0;

//        for (int i = 0; i <= str.Length; i++)
//        {
//            if ((i + 1 == str.Length) || map[str[i]] >= map[str[i + 1]])
//            {
//                output += map[str[i]];
//            }
//            else
//            {
//                output -= map[str[i]];
//            }
//        }

//        Console.WriteLine($"{output}");
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Console.WriteLine("Enter Roman number : ");
//        string str = Console.ReadLine();

//        Dictionary<char, int> map = new Dictionary<char, int>();
//        map.Add('I', 1);
//        map.Add('V', 5);
//        map.Add('X', 10);
//        map.Add('L', 50);
//        map.Add('C', 100);
//        map.Add('D', 500);
//        map.Add('M', 1000);

//        ConvertToInHelper c = new ConvertToInHelper();
//        c.ConvertToInt(str, map);
//    }
//}

////Time complexity – O(N)
////Auxiliary Space – O(1)   since the map is of fixed size