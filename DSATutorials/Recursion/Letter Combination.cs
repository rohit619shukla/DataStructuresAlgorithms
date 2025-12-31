//using System;
//using System.Text;

//public class Solution
//{
//    // Time : O(n*4^n) , where n for creating a new string, 4^n for each char in orignal number we have 4 possibilites at most to try with, space :O(n)
//    public IList<string> LetterCombinations(string digits)
//    {
//        IList<string> result = new List<string>();

//        Dictionary<char, string> map = new Dictionary<char, string>();

//        map['2'] = "abc";
//        map['3'] = "def";
//        map['4'] = "ghi";
//        map['5'] = "jkl";
//        map['6'] = "mno";
//        map['7'] = "pqrs";
//        map['8'] = "tuv";
//        map['9'] = "wxyz";

//        Solve(digits, 0, map, result, new StringBuilder());

//        return result;
//    }

//    private void Solve(string digits, int index, Dictionary<char, string> map, IList<string> result, StringBuilder sb)
//    {
//        // base case
//        if (sb.Length >= digits.Length)
//        {
//            result.Add(sb.ToString());
//            return;
//        }

//        // Get the current char we are in
//        char ch = digits[index];

//        // Get the strings corresponding to the current char
//        string str = map[ch];

//        // Now iterate over each char in the given string
//        for (int i = 0; i < str.Length; i++)
//        {
//            // Take it
//            sb.Append(str[i]);

//            // Explore
//            Solve(digits, index + 1, map, result, sb);

//            // Backrack
//            sb.Length--;
//        }
//    }

//}


//class Program
//{
//    public static void Main()
//    {
//        string str = "23";

//        Solution s = new Solution();

//        var result = s.LetterCombinations(str);

//        foreach (var item in result)
//        {
//            Console.WriteLine(item);
//        }
//    }
//}