//public class Solution
//{
//    // Time : O(n) , space : O(1)
//    public int MyAtoi(string str)
//    {
//        // To counter the condition of overflow and underflow we will take the result to be long
//        long result = 0;

//        // Step 1 : Check for leading space
//        int i = 0, sign = 1;
//        while (i < str.Length && str[i] == ' ')
//        {
//            // move i till we get a non space number
//            i++;
//        }

//        // Step 2 : Check for sign
//        if (i < str.Length && (str[i] == '-' || str[i] == '+'))
//        {
//            sign = (str[i] == '-' ? -1 : 1);
//            i++;
//        }

//        // Process digits manually without using char.IsDigit
//        while (i < str.Length && str[i] >= '0' && str[i] <= '9')
//        {
//            result = result * 10 + (str[i] - '0');
//            i++;

//            // 4. Clamp to 32-bit integer range
//            if (result * sign <= int.MinValue) return int.MinValue;
//            if (result * sign >= int.MaxValue) return int.MaxValue;
//        }

//        return (int)(sign * result);
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        string str = "42";

//        Solution s = new Solution();

//        Console.WriteLine(s.MyAtoi(str));
//    }
//}