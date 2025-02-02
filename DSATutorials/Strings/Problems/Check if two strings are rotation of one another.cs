//using System;

//class CheckStringRotationHelper
//{
//    public bool AreRotation(string str1, string str2)
//    {

//        if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2))
//        {
//            return false;
//        }

//        int[] lps = new int[str2.Length];
//        LPS(str2, lps);

//        int i = 0, j = 0;

//        while (i < str1.Length - 1)
//        {
//            if (str1[i] == str2[j])
//            {
//                i++;
//                j++;
//            }

//            if (j == str2.Length - 1 && str1[i] == str2[j])
//            {
//                Console.WriteLine("Strings are rotations");
//                return true;
//            }
//            else if (str1[i] != str2[j])
//            {
//                if (j == 0)
//                {
//                    i++;
//                }
//                else
//                {
//                    j = lps[j - 1];
//                }
//            }
//        }

//        return false;
//    }

//    private void LPS(string str, int[] lps)
//    {
//        int i = 0;
//        int j = 1;

//        while (j < str.Length)
//        {
//            if (str[i] == str[j])
//            {
//                lps[j] = i + 1;
//                i++;
//                j++;
//            }
//            else if (str[i] != str[j])
//            {
//                if (i == 0)
//                {
//                    lps[j] = i;
//                    j++;
//                }
//                else
//                {
//                    i = lps[i - 1];
//                }
//            }
//        }
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        string str1 = "ABACD";
//        string str2 = "DABAC";

//        str1 += str1;

//        CheckStringRotationHelper c = new CheckStringRotationHelper();
//        c.AreRotation(str1, str2);
//    }
//}