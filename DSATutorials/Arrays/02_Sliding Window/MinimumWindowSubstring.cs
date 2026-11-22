// public class Solution
// {
//     // Assumes str and t are non-null, and t is non-empty.
//     // Expected time: O(n + m), where n = str.Length and m = t.Length.
//     // Building the map takes O(m); each window pointer advances at most n times.
//     // Auxiliary space: O(k), where k is the number of distinct characters in t.
//     // The returned substring additionally uses O(L) space, where L is its length.
//     public string MinWindow(string str, string t)
//     {
//         if(str.Length < t.Length) return "";
//         // Remaining required occurrences: positive = missing, zero = satisfied,
//         // negative = surplus copies in the current window.
//         Dictionary<char, int> map = new Dictionary<char, int>();

//         // Preserve duplicate requirements, e.g. t = "AAB" needs two A's and one B.
//         foreach (char ch in t)
//         {
//             if (map.ContainsKey(ch))
//             {
//                 map[ch]++;
//             }
//             else
//             {
//                 map[ch] = 1;
//             }
//         }

//         // Count required occurrences still missing from the window, including duplicates.
//         // For "AAB", this starts at 3 and decreases for both A's and the B.
//         int start = 0, end = 0, size = str.Length, countRequired = t.Length, min = int.MaxValue;
//         int startOfString = 0;

//         // Expand the inclusive window [start, end] one character at a time.
//         while (end < size)
//         {
//             // Characters absent from t do not affect whether the window is valid.
//             if (map.ContainsKey(str[end]))
//             {
//                 map[str[end]]--;

//                 // A frequency >= 0 after decrementing means this copy was still needed.
//                 // A negative frequency means it is a surplus copy, so the counter stays the same.
//                 if (map[str[end]] >= 0)
//                 {
//                     countRequired--;
//                 }
//             }

//             // All requirements are met. Shrink until removing a character makes
//             // the window invalid, recording each valid window before removal.
//             while (countRequired == 0)
//             {
//                 int windowSize = end - start + 1;

//                 if (windowSize < min)
//                 {
//                     // Keep the best length and starting index paired.
//                     min = windowSize;
//                     startOfString = start;
//                 }

//                 if (map.ContainsKey(str[start]))
//                 {
//                     // Restore the occurrence being removed from the left edge.
//                     map[str[start]]++;

//                     // A positive frequency means a required copy is now missing.
//                     // Removing a surplus copy leaves the window valid.
//                     if (map[str[start]] > 0)
//                     {
//                         countRequired++;
//                     }
//                 }
//                 start++;
//             }
//             end++;
//         }

//         return min == int.MaxValue ? string.Empty : str.Substring(startOfString, min);
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         string str = "ADOBECODEBANC";

//         string t = "ABC";

//         Solution s = new Solution();

//         Console.WriteLine(s.MinWindow(str, t));
//     }
// }
