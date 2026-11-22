// public class Solution
// {

//     // Time : O(n) , space : O(1)
//     public bool CheckInclusion(string s1, string s2)
//     {

//         // base case :
//         if (s1.Length > s2.Length)
//         {
//             return false;
//         }

//         // create an array of 26 chars as it is guaranteed to have only lower case english char
//         int[] charArray = new int[26];

//         // Fill the array for s1 to hold its frequencies
//         for (int i = 0; i < s1.Length; i++)
//         {
//             charArray[s1[i] - 'a']++;
//         }

//         int start = 0, end = 0, size = s2.Length;
//         int k = s1.Length;

//         while (end < size)
//         {
//             // reduce the freq when the char is encountered
//             charArray[s2[end] - 'a']--;

//             // check if we have encountered the window
//             // Here we have fixed size sliding window which depends on s1
//             if (end - start + 1 == k)
//             {
//                 // Firect check if this window is what we need
//                 if (AreAllZero(charArray))
//                 {
//                     return true;
//                 }

//                 // Otehrwise , revert back value of start from the array for next window check before moving
//                 charArray[s2[start] - 'a']++;

//                 start++;
//             }
//             end++;

//         }
//         return false;
//     }

//     private bool AreAllZero(int[] charArray)
//     {
//         for (int i = 0; i < 26; i++)
//         {
//             if (charArray[i] != 0)
//             {
//                 return false;
//             }
//         }

//         return true;
//     }
// }
// class Program
// {
//     public static void Main()
//     {
//         Solution solution = new Solution();
//         string s1 = "ab";
//         string s2 = "eidbaooo";
//         bool result = solution.CheckInclusion(s1, s2);
//         Console.WriteLine(result);
//     }
// }