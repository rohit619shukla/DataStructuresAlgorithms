//using System;

//class KMP
//{
//    public bool DoesSubstringMatching(string str, string pattern)
//    {
//        char[] ptrn = pattern.ToCharArray();
//        int[] lps = new int[ptrn.Length];

//        int i = 0;   /* for given string*/
//        int j = 0;   /* for pattern*/

//        LPS(ptrn, lps);

//        while (i < str.Length)
//        {
//            if (str[i] == ptrn[j])
//            {
//                i++;
//                j++;
//            }
//            if (j == ptrn.Length - 1 && str[i] == ptrn[j])
//            {
//                Console.WriteLine($"pattern  {pattern} : found at position : {i - j} : {i} & {j}");
//                return true;
//            }
//            else if (str[i] != ptrn[j])
//            {

//                if (j == 0)
//                {
//                    i++;
//                }
//                else
//                {
//                    j = lps[j - 1];
//                }
//            }
//        }

//        Console.WriteLine($"pattern not found {pattern}");
//        return false;
//    }

//    private void LPS(char[] ptrn, int[] lps)
//    {
//        int i = 0;
//        int j = i + 1;

//        while (j < ptrn.Length)
//        {
//            if (ptrn[i] == ptrn[j])
//            {
//                lps[j] = i + 1;
//                i++;
//                j++;
//            }
//            else
//            {
//                if (i == 0)
//                {
//                    lps[j] = i;
//                    j++;
//                }
//                else
//                {
//                    i = lps[i - 1];
//                }
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "1 : MSF:MSF-014956, Manufacturer Part #:Arista, Quantity:1, Serial:SSJ17235206, Asset:8752817, TO #:bf6c789e-5c5d-465c-ae4c-5d833dfe9054      2 : MSF:MSF-014956, Manufacturer Part #:Arista, Quantity:1, Serial:SSJ17250805, Asset:8752822, TO #:bf6c789e-5c5d-465c-ae4c-5d833dfe9054      3 : MSF:MSF-014956, Manufacturer Part #:Arista, Quantity:1, Serial:SSJ17235247, Asset:8752823, TO #:bf6c789e-5c5d-465c-ae4c-5d833dfe9054      4 : MSF:MSF-014956, Manufacturer Part #:Arista, Quantity:1, Serial:SSJ17235449, Asset:8752824, TO #:bf6c789e-5c5d-465c-ae4c-5d833dfe9054      5 : MSF:MSF-014956, Manufacturer Part #:Arista, Quantity:1, Serial:SSJ17250795, Asset:8752825, TO #:bf6c789e-5c5d-465c-ae4c-5d833dfe9054      6 : MSF:MSF-014956, Manufacturer Part #:Arista, Quantity:1, Serial:SSJ17235299, Asset:8752827, TO #:bf6c789e-5c5d-465c-ae4c-5d833dfe9054      7 : MSF:MSF-014956, Manufacturer Part #:Arista, Quantity:1, Serial:SSJ16460092, Asset:8752828, TO #:bf6c789e-5c5d-465c-ae4c-5d833dfe9054      8 : MSF:MSF-014956, Manufacturer Part #:Arista, Quantity:1, Serial:SSJ17235249, Asset:8752819, TO #:bf6c789e-5c5d-465c-ae4c-5d833dfe9054      9 : MSF:MSF-012933, Manufacturer Part #:Cisco, Quantity:1, Serial:FOC2125R0MA, Asset:9166496, TO #:bf6c789e-5c5d-465c-ae4c-5d833dfe9054      10 : MSF:MSF-012933, Manufacturer Part #:Cisco, Quantity:1, Serial:FOC2122R01V, Asset:9166494, TO #:bf6c789e-5c5d-465c-ae4c-5d833dfe9054      11 : MSF:";

//        string[] pattern = { "8752817", "8752822", "8752823", "8752824", "8752825", "8752827", "8752828", "8752819", "9166496", "9166494", "916649723" };

//        KMP k = new KMP();

//        foreach (var item in pattern)
//        {
//            k.DoesSubstringMatching(str, item);
//        }
//    }
//}

////Complexity: O (N) => LPS  and O(M+P) for substring match => O(n)