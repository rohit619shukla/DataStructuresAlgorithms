//using System;
//using System.Threading.Channels;

//class ConvertToUpperHelper
//{
//    public void ConvertToUpper(string str)
//    {
//        if (string.IsNullOrWhiteSpace(str))
//        {
//            Console.WriteLine("empty string found");
//            return;
//        }

//        char[] ch = str.ToCharArray();

//        for (int i = 0; i < ch.Length; i++)
//        {
//            if (ch[i] >= 97 && ch[i] <= 122)
//            {
//                ch[i] = (char)(ch[i] - 32);
//            }
//            else if (ch[i] >= 65 && ch[i] <= 90)
//            {
//                continue;
//            }
//            else
//            {
//                Console.WriteLine($"invalid character detected : {ch[i]}");
//                return;
//            }
//        }

//        Console.WriteLine($"Converted string is : {new string(ch)}");
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Console.WriteLine("Enter a string to convert");
//        string str = Console.ReadLine();

//        ConvertToUpperHelper c = new ConvertToUpperHelper();
//        c.ConvertToUpper(str);
//    }
//}

// Complexity : O(N)