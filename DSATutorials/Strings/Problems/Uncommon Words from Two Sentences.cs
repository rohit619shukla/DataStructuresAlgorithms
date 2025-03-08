//public class Solution
//{
//    // Time : O(n) , space :O(N)
//    public string[] UncommonFromSentences(string s1, string s2)
//    {
//        Dictionary<string, int> map = new Dictionary<string, int>();

//        List<string> result = new List<string>();

//        string concat = s1 + ' ' + s2;

//        string[] str = concat.Split(' ');

//        foreach (string s in str)
//        {
//            if (!map.ContainsKey(s))
//            {
//                map[s] = 1;
//            }
//            else
//            {
//                map[s]++;
//            }
//        }

//        foreach (var val in map)
//        {
//            if (val.Value == 1)
//            {
//                result.Add(val.Key);
//            }
//        }

//        return result.ToArray();
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string s1 = "this apple is sweet";

//        string s2 = "this apple is sour";

//        Solution s = new Solution();

//        var result = s.UncommonFromSentences(s1, s2);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}