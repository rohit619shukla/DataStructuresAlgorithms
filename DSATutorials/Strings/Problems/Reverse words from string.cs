//using System.Reflection.Emit;

//public class Solution
//{
//    // Time : O(N) , space :O(N) for output array but Aux :O(1)
//    public string ReverseWords(string str)
//    {
//        // base cases
//        if (str == null)
//        {
//            return str;
//        }

//        // Step 1: Reverse the string completely
//        char[] chArray = str.ToCharArray();
//        Reverse(chArray, 0, str.Length - 1);  // O(n)

//        // Step 2: Reverse each word in the reversed string individualy
//        int i = 0, r = 0, l = 0;

//        while (i < str.Length)  //O(N)
//        {

//            // This is sequential loop as we dont over again atmost twice, hence O(N). This is unique case carwfully see the iteration
//            while (i < str.Length && chArray[i] != ' ')
//            {
//                // Assign value at index i to index r
//                chArray[r++] = chArray[i++];
//            }

//            if (l < r)
//            {
//                // Reverse all characters between l and r
//                // Here we reverse 1 word per string rather than whole string
//                Reverse(chArray, l, r - 1);

//                if (r < str.Length)
//                {
//                    // Add a space at index r
//                    chArray[r] = ' ';
//                }
//                // increment r
//                r++;

//                // Move l to r's location
//                l = r;

//            }

//            // increment i
//            i++;
//        }

//        str = new string(chArray);

//        return str.Substring(0, r - 1);
//    }

//    private void Reverse(char[] chArray, int lb, int ub)
//    {
//        while (lb < ub)
//        {
//            char temp = chArray[lb];
//            chArray[lb] = chArray[ub];
//            chArray[ub] = temp;

//            lb++;
//            ub--;
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string str = "a good   example";

//        Solution s = new Solution();

//        Console.WriteLine(s.ReverseWords(str));
//    }
//}