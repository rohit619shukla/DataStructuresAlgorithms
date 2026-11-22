// public class Solution
// {
//     // Time: O(n) on average with O(1) dictionary operations; each pointer advances at most n times.
//     // Auxiliary space: O(n); if all n characters are unique, the dictionary stores them all.
//     public int LengthOfLongestSubstring(string str)
//     {
//         // Track each character's frequency in the current window [start, end].
//         Dictionary<char, int> map = new Dictionary<char, int>();

//         int start = 0, end = 0, max = 0, size = str.Length;

//         while (end < size)
//         {
//             // Include the next character in the window.
//             if (map.ContainsKey(str[end]))
//             {
//                 map[str[end]]++;
//             }
//             else
//             {
//                 map[str[end]] = 1;
//             }

//             // All characters are unique when the distinct count equals the window length.
//             if (map.Count == end - start + 1)
//             {
//                 max = Math.Max(max, end - start + 1);
//                 end++;
//             }
//             else if (map.Count < end - start + 1)
//             {
//                 // Shrink from the left until the window contains no repeated characters.
//                 while (map.Count < end - start + 1)
//                 {
//                     map[str[start]]--;

//                     if (map[str[start]] == 0)
//                     {
//                         // Remove absent characters so map.Count reflects the window's distinct count.
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
//         string str = "abcabcbb";

//         Solution s = new Solution();


//         Console.WriteLine($"{s.LengthOfLongestSubstring(str)}");
//     }
// }