using System;
using System.Collections;

namespace DS3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ex1();
            ex2();
            ex3();
            Console.WriteLine("Hello World!");
        }

        public static void ex1()
        {
            int[] a = {1,5,23,12,3,6,8,7};
            //SortingAlgorithms<int>.BubbleSorting(a);
            //SortingAlgorithms<int>.SelectionSorting(a);
            //SortingAlgorithms<int>.InsertionSorting(a);
            //SortingAlgorithms<int>.MergeSorting(a);
            //SortingAlgorithms<int>.QuickSorting(a);
            //SortingAlgorithms<int>.CountingSorting(a);
            SortingAlgorithms<int>.BucketSort(a);
        }

        public static void ex2()
        {
            int[] a = { 1, 5, 23, 12, 3, 6, 8, 7 };
            Console.WriteLine(SearchingAlgoritms<int>.LinearSearch(a, 7));
            Console.WriteLine(a[SearchingAlgoritms<int>.BiniarySearchIterativeWithSorting(ref a, 7)]);
            Console.WriteLine(SearchingAlgoritms<int>.BiniarySearchRecursionWithSorting(ref a, 7));
            Console.WriteLine(SearchingAlgoritms<int>.TenarySearchRecursionWithSorting(a, 7));
            Console.WriteLine(SearchingAlgoritms<int>.TenarySearchIterativeWithSorting(a, 7));
            Console.WriteLine(SearchingAlgoritms<int>.JumpSearchWithSorting(a, 25));
            Console.WriteLine(SearchingAlgoritms<int>.ExponentialSearchWithSorting(a, 7));

        }

        public static void ex3()
        {
            Console.WriteLine(StringManipulationAlgorithms.NumberOfVovels("hello"));
            Console.WriteLine(StringManipulationAlgorithms.ReverseString("hello"));
            Console.WriteLine(StringManipulationAlgorithms.ReverseWordsInSentence("hello my sunshine "));
            Console.WriteLine(StringManipulationAlgorithms.IsRotation("ABCD", "DABC"));
            Console.WriteLine(StringManipulationAlgorithms.IsRotation("ABCD", "CDAB"));
            Console.WriteLine(StringManipulationAlgorithms.IsRotation("ABCD", "ADBC"));
            Console.WriteLine(StringManipulationAlgorithms.RemoveDuplicatLetters("HeeloooH!!"));
            Console.WriteLine(StringManipulationAlgorithms.FindMostRepeatedCharacter("HeeloooH!!"));
            Console.WriteLine(StringManipulationAlgorithms.FindMostRepeatedCharacterMod("HeeloooH!!"));
            Console.WriteLine(StringManipulationAlgorithms.CapitalizeAllWords("hello general kenobi!"));
            Console.WriteLine(StringManipulationAlgorithms.IsAnagram("ABCD", "DABC"));
            Console.WriteLine(StringManipulationAlgorithms.IsAnagram("ABCD", "BABC"));
            Console.WriteLine(StringManipulationAlgorithms.IsPalindrome("ABCD"));
            Console.WriteLine(StringManipulationAlgorithms.IsPalindrome("AAAA"));
            Console.WriteLine(StringManipulationAlgorithms.IsPalindrome("ABA"));
            Console.WriteLine(StringManipulationAlgorithms.IsPalindrome("ABAB"));
            Console.WriteLine(StringManipulationAlgorithms.IsPalindrome("ABCA"));
        }

    }


}
