//using System;
//using System.Reflection.Emit;

//class Addition
//{
//    public void AddTwoNumbers(string str1, string str2)
//    {
//        // base conditions
//        if (string.IsNullOrWhiteSpace(str1) && !string.IsNullOrWhiteSpace(str2))
//        {
//            Console.WriteLine($"{str2}");
//        }
//        else if (!string.IsNullOrWhiteSpace(str1) && string.IsNullOrWhiteSpace(str2))
//        {
//            Console.WriteLine($"{str1}");
//        }
//        else if (string.IsNullOrWhiteSpace(str1) && string.IsNullOrWhiteSpace(str2))
//        {
//            Console.WriteLine("Nothing to add");
//            return;
//        }
//        else
//        {
//            int diff = 0;
//            // make sure length of str1 is larger than str2
//            if (str1.Length < str2.Length)
//            {
//                diff = str1.Length - str2.Length;
//                Swap(str1, str2);
//            }

//            char[] s1 = ReverseString(str1, 0, str1.Length - 1).ToCharArray();
//            char[] s2 = ReverseString(str2, 0, str2.Length - 1).ToCharArray();

//            if (diff != 0)
//            {
//                Array.Resize(ref s2, s2.Length + diff);
//            }
//            string output = "";

//            int addition = 0, remainder = 0, carry = 0;

//            // Do addition till length of second string limit is reached
//            for (int i = 0; i < s2.Length; i++)
//            {
//                addition = (s1[i] - 48) + (s2[i] - 48);
//                if (carry > 0)
//                {
//                    addition += carry;
//                }
//                remainder = addition % 10;
//                carry = addition / 10;

//                output += remainder;

//            }

//            output = ReverseString(output, 0, output.Length - 1);

//            // Add remaining digits of string 1 back to output
//            for (int i = diff - 1; i >= 0; i--)
//            {
//                if (carry > 0)
//                {
//                    addition = (str1[i] - 48) + carry;
//                    remainder = addition % 10;
//                    carry = addition / 10;
//                    output = remainder + output;
//                }
//                else
//                {
//                    output = (str1[i] + output);
//                }
//            }

//            // If any carry is left add it back to output
//            if (carry > 0)
//            {
//                Console.WriteLine($"{output = carry + output}");

//            }
//            else
//            {
//                Console.WriteLine($"{output}");
//            }
//        }

//    }
//    private void Swap(string s1, string s2)
//    {
//        string temp = s1;
//        s1 = s2;
//        s2 = temp;
//    }

//    private string ReverseString(string str, int lb, int ub)
//    {
//        char[] ch = str.ToCharArray();

//        while (lb < ub)
//        {
//            char temp = ch[lb];
//            ch[lb] = ch[ub];
//            ch[ub] = temp;

//            lb++;
//            ub--;
//        }

//        return new string(ch);
//    }
//}
//class Program
//{
//    public static void Main()
//    {

//        //string s1 = "7777555511111111";
//        //string s2 = "3332222221111";

//        string s1 = "997123";
//        string s2 = "99999";
//        Addition add = new Addition();
//        add.AddTwoNumbers(s1, s2);

//    }
//}