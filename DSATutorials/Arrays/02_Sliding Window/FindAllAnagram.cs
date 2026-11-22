// public class Solution
// {
//     public IList<int> FindAnagrams(string str, string pat)
//     {

//         List<int> result = new List<int>();
//         int[] frequency = new int[26];

//         // window size
//         int k = pat.Length;


//         // Assign the frquency
//         for (int i = 0; i < k; i++)
//         {
//             frequency[pat[i] - 'a']++;
//         }


//         int start = 0, end = 0, size = str.Length;

//         while (end < size)
//         {
//             // as and when we encounter the char, just reduce its frequency
//             frequency[str[end] - 'a']--;

//             if (end - start + 1 == k)
//             {
//                 if (AreAllZero(frequency))
//                 {
//                     // stiore the frequence of the first char
//                     result.Add(start);

//                 }

//                 // Now before moving the window restore the freunece back for hlep needed later on
//                 frequency[str[start] - 'a']++;

//                 start++;
//             }

//             end++;
//         }

//         return result;
//     }

//     private bool AreAllZero(int[] frequency)
//     {
//         for (int i = 0; i < frequency.Length; i++)
//         {
//             if (frequency[i] != 0)
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
//         string str = "cbaebabacd";

//         string pat = "abc";

//         Solution s = new Solution();

//         var result = s.FindAnagrams(str, pat);

//         foreach (int item in result)
//         {
//             Console.WriteLine(item);
//         }
//     }
// }