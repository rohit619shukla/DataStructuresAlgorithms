//using System;

//class Addition
//{
//    public void AddingOne(string number)
//    {
//        // 1. convert the string to a char-array
//        char[] num = number.ToCharArray();

//        // 2. Reverse array
//        ReverseArray(num, 0, num.Length - 1);

//        // 3. Add initial 1 to start process
//        int addition = ((num[0] - 48) + 1);
//        int carry = addition / 10;

//        if (carry == 0)
//        {
//            // No carry hence store the number + 1 as result
//            num[0] = (char)(((num[0] - 48) + 1) + '0');   // to store actual number in char array
//            ReverseArray(num, 0, num.Length - 1);
//            Console.WriteLine($"{new string(num)}");
//        }
//        else
//        {
//            for (int i = 0; i < num.Length; i++)
//            {
//                if (carry > 0)
//                {
//                    addition = (num[i] - 48) + carry;
//                    int remainder = addition % 10;
//                    num[i] = (char)(remainder + '0');
//                    carry = addition / 10;
//                }
//                else
//                {
//                    break;
//                }
//            }

//            if (carry > 0)
//            {
//                Array.Resize(ref num, num.Length + 1);
//                num[num.Length - 1] = (char)(carry + '0');
//            }

//            ReverseArray(num, 0, num.Length - 1);
//            Console.WriteLine($"{new string(num)}");
//        }


//    }

//    private void ReverseArray(char[] num, int lb, int ub)
//    {
//        while (lb < ub)
//        {
//            char temp = num[lb];
//            num[lb] = num[ub];
//            num[ub] = temp;

//            lb++;
//            ub--;
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string number = "978338999";
//        Addition add = new Addition();
//        add.AddingOne(number);
//    }
//}


///*
// *  A - Z : 65 - 90
// *  a - z : 97 - 122
// *  0 - 9 : 48 - 57 
// */