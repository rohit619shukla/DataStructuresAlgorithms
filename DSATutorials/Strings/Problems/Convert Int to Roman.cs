//using System;

//class ConversionHelper
//{
//    public void ConvertToRoman(int num, int[] numArr, string[] strArr)
//    {
//        int i = numArr.Length - 1;   /* we start iterating from last element */

//        while (num > 0)       /* Iterate till we have something */
//        {
//            int quotient = num / numArr[i];       /* get how many times we need to print the Roman equivalent*/

//            num = num % numArr[i];      /* get next number in line */

//            while (quotient > 0)                 /* print the Roman equivalent of current value of string that many times*/
//            {
//                Console.Write($"{strArr[i]}");
//                quotient--;
//            }
//            i--;
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Console.WriteLine("Enter a number :");
//        int num = Convert.ToInt32(Console.ReadLine());

//        int[] numArr = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
//        string[] strArr = { "i", "iv", "v", "ix", "x", "xl", "l", "xc", "c", "cd", "d", "cm", "m" };

//        ConversionHelper c = new ConversionHelper();
//        c.ConvertToRoman(num, numArr, strArr);

//    }
//}

//// Complexity : Since we are calgculating the number in fixed range : 1  to 3,999,999 to complexity is O(1)