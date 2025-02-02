//using System;

//class ConvertToLowerCaseHelper
//{
//    public void ConvertToLowerCase(string str)
//    {
//        if (string.IsNullOrWhiteSpace(str))
//        {
//            Console.WriteLine("Empty string found");
//            return;
//        }

//        char[] ch = str.ToCharArray();

//        for (int i = 0; i < ch.Length; i++)
//        {
//            if (ch[i] >= 65 && ch[i] <= 90)
//            {
//                ch[i] = (char)(ch[i] + 32);
//            }
//            else if (ch[i] >= 97 && ch[i] <= 122)
//            {
//                continue;
//            }
//            else
//            {
//                Console.WriteLine($"invalid charcater found :{ch[i]}");
//                return;
//            }
//        }

//        Console.WriteLine($"String converted is : {new string(ch)}");
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Console.WriteLine("Enter a string to convert :");
//        string str = Console.ReadLine();

//        ConvertToLowerCaseHelper c = new ConvertToLowerCaseHelper();
//        c.ConvertToLowerCase(str);
//    }
//}

////Complexity: O(N)