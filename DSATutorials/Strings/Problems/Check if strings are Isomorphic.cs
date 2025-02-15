//public class Solution
//{
//    // Time :O(N) , space :O(N)
//    public bool IsIsomorphic(string s, string t)
//    {
//        // base case
//        if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t))
//        {
//            return false;
//        }

//        if (s.Length != t.Length)
//        {
//            return false;
//        }

//        Dictionary<char, char> map = new Dictionary<char, char>();
//        Dictionary<char, char> reverseMap = new Dictionary<char, char>();

//        for (int i = 0; i < s.Length; i++)
//        {
//            char sc = s[i];
//            char tc = t[i];

//            if (map.ContainsKey(sc))
//            {
//                if (map[sc] != tc)
//                {
//                    return false;
//                }
//            }
//            else
//            {
//                map[sc] = tc;
//            }

//            if (reverseMap.ContainsKey(tc))
//            {
//                if (reverseMap[tc] != sc)
//                {
//                    return false;
//                }
//            }
//            else
//            {
//                reverseMap[tc] = sc;
//            }
//        }

//        return true;
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        string s = "badc";
//        string t = "baba";

//        Solution sl = new Solution();

//        Console.WriteLine(sl.IsIsomorphic(s, t));
//    }
//}