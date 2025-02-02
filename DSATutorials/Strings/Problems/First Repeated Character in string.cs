//using System;
//using System.Collections.Generic;
//class StringHelper
//{
//    public void FindFirstRepeatedCharacterInString(string str)
//    {
//        if (string.IsNullOrWhiteSpace(str))
//        {
//            Console.WriteLine("Invalid string found");
//            return;
//        }

//        HashSet<char> map = new HashSet<char>();

//        for (int i = 0; i < str.Length; i++)
//        {
//            if (!map.Contains(str[i]))
//            {
//                map.Add(str[i]);
//            }
//            else
//            {
//                Console.WriteLine($"First repeated character is :  {str[i]}");
//                return;
//            }
//        }


//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "geeksforgeeks";

//        StringHelper st = new StringHelper();
//        st.FindFirstRepeatedCharacterInString(str);
//    }
//}

///* Complexity : O(N), Space : O(N)*/