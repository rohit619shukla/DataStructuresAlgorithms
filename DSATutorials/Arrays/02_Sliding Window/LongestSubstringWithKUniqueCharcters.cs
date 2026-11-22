// class Solution
// {
//     // Time :O(n) , space : O(n)
//     public int longestKSubstr(string str, int k)
//     {

//         int size = str.Length;

//         Dictionary<char, int> map = new Dictionary<char, int>();

//         int start = 0, end = 0, max = -1;

//         while (end < size)
//         {
//             if (map.ContainsKey(str[end]))
//             {
//                 map[str[end]]++;
//             }
//             else
//             {
//                 map[str[end]] = 1;
//             }

//             if (map.Count < k)
//             {
//                 end++;
//             }
//             else if (map.Count == k)
//             {
//                 max = Math.Max(max, end - start + 1);
//                 end++;
//             }
//             else if (map.Count > k)
//             {
//                 while (map.Count > k)
//                 {
//                     map[str[start]]--;

//                     if (map[str[start]] == 0)
//                     {
//                         map.Remove(str[start]);
//                     }

//                     start++;
//                 }
//                 end++;
//             }
//         }

//         return max;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         string str = "mlg";

//         int k = 1;

//         Solution s = new Solution();

//         Console.WriteLine(s.longestKSubstr(str, k));
//     }
// }