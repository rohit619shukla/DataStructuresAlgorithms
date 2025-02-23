//using System.Text;

//public class Solution
//{
//    public string AddStrings(string str1, string str2)
//    {
//        int len1 = str1.Length, len2 = str2.Length;

//        int i = len1 - 1, j = len2 - 1, carry = 0;

//        string result = "";

//        while (i >= 0 || j >= 0)
//        {
//            int sum = 0;

//            if (i >= 0)
//            {
//                sum += str1[i] - '0';
//            }

//            if (j >= 0)
//            {
//                sum += str2[j] - '0';

//            }

//            sum += carry;

//            carry = sum / 10;

//            int remainder = sum % 10;

//            if (carry > 0)
//            {
//                result += remainder;
//            }
//            else
//            {
//                result += sum;
//            }

//            i--;
//            j--;
//        }

//        if (carry > 0)
//        {
//            result += carry;
//        }
//        result = ReverseString((result).ToCharArray(), 0, result.Length - 1);

//        return result;
//    }

//    private string ReverseString(char[] chr, int lb, int ub)
//    {
//        while (lb < ub)
//        {
//            char temp = chr[lb];
//            chr[lb] = chr[ub];
//            chr[ub] = temp;

//            lb++;
//            ub--;
//        }

//        return new string(chr);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string str1 = "11";

//        string str2 = "123";


//        Solution s = new Solution();

//        Console.WriteLine(s.AddStrings(str1, str2));
//    }
//}