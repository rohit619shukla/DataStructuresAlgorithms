// public class Solution
// {
//     public int MostFrequentEven(int[] nums)
//     {

//         // we wil lstore the element and its count of occurence
//         Dictionary<int, int> map = new Dictionary<int, int>();

//         // we will do this in single pass only
//         int maxFreqElement = -1, maxFreq = 0;

//         for (int i = 0; i < nums.Length; i++)
//         {
//             if (nums[i] % 2 == 0)
//             {
//                 if (map.ContainsKey(nums[i]))
//                 {
//                     // already seen increase the frequency
//                     map[nums[i]]++;
//                 }
//                 else
//                 {
//                     // seeing first time
//                     map[nums[i]] = 1;
//                 }

//                 // get the currentElement's freq
//                 int currFreq = map[nums[i]];

//                 // 1. If the frequency of current number is greater than max numbs' freq
//                 // 2. If the freq for both are same , we will chose the smallest number
//                 if (currFreq > maxFreq || (currFreq == maxFreq && nums[i] < maxFreqElement))
//                 {
//                     maxFreq = currFreq;
//                     maxFreqElement = nums[i];
//                 }
//             }
//         }

//         return maxFreqElement;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 0, 1, 2, 2, 4, 4, 1 };

//         Solution s = new Solution();

//         Console.WriteLine(s.MostFrequentEven(nums));
//     }
// }