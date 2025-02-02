//using System;
//class StringConversionHelper
//{
//    public void ConvertToInt(string str)
//    {
//        if (string.IsNullOrWhiteSpace(str))
//        {
//            Console.WriteLine("Empty string encountered");
//            return;
//        }

//        int output = 0;

//        for (int i = 0; i < str.Length; i++)
//        {
//            if (str[i] >= 48 && str[i] <= 57)
//            {
//                output = (str[i] - 48) + (output * 10);
//            }
//            else
//            {
//                Console.WriteLine($"Given character : {str[i]} is not a number");
//                return;
//            }
//        }

//        Console.WriteLine($"String converted to integer is : {output}");
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Console.WriteLine("Enter a string to convert :");
//        string str = Console.ReadLine();

//        StringConversionHelper s = new StringConversionHelper();
//        s.ConvertToInt(str);
//    }
//}

////Complexity: O(N)