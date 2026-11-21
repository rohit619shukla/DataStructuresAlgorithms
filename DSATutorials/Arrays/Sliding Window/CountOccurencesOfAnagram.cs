// class Solution
// {
//     // Time : O(n) , space :O(1)
//     public int search(string pat, string txt)
//     {
//         // code here

//         // This is a problem of Sliding window :
//         // 1. The size of window is pattern length itself
//         // 2. We are operating on chars of string
//         // 3. Anangrams are nothing but jumbled word, but needed to be contigous


//         // We will create a arryf of fixed size to store all the frequency of all the chars in the pattern string
//         int[] frequency = new int[26];

//         int k = pat.Length;

//         // Log the frequency of each char from pattern
//         for (int i = 0; i < pat.Length; i++)
//         {
//             frequency[pat[i] - 'a']++;
//         }

//         // Initialize start and end pointers for Sliding window
//         int start = 0, end = 0;

//         int size = txt.Length;

//         int resultCount = 0;

//         while (end < size)
//         {
//             // Whatever the char is right now at end, just reduce its frequency as we have seen this char
//             frequency[txt[end] - 'a']--;

//             // Check if we have encountered the window of 
//             if (end - start + 1 == k)
//             {
//                 // Check if all the chars in frquency array are 0
//                 if (AreAllZero(frequency))
//                 {
//                     // We have got a valid anagram
//                     resultCount++;
//                 }

//                 // before we expand the window size further, we must restore the frequency of the removing element from the start of window so atht it could be used again
//                 frequency[txt[start] - 'a']++;

//                 // increment the star counter
//                 start++;
//             }

//             // end will keep on incrementing
//             end++;
//         }

//         return resultCount;
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
//         string txt = "forxxorfxdofr";

//         string pat = "for";

//         Solution s = new Solution();

//         Console.WriteLine($"{s.search(pat, txt)}");
//     }
// }