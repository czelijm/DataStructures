using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS3_1
{
    class StringManipulationAlgorithms
    {
        public static int NumberOfVovels(string s)
        {
            ISet<char> set = new HashSet<char>();
            set.Add('a');
            set.Add('e');
            set.Add('i');
            set.Add('o');
            set.Add('u');

            int number = 0;
            foreach (var item in s.ToCharArray())
            {
                if (set.Contains(Char.ToLower(item))) number++;
            }
            return number;
        }
        public static string ReverseString(string s)
        {
            string result = default;
            Stack<char> stack = new Stack<char>();

            foreach (var item in s.ToCharArray())
            {
                stack.Push(item);
            }

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }

        public static string ReverseWordsInSentenceNasty(string s)
        {
            if (s is null) return null;

            Stack<string> stack = new Stack<string>();

            string tmpString = default;

            foreach (var item in s.ToCharArray())
            {
                if (item == ' ' && !(tmpString is null))
                {
                    stack.Push(tmpString);
                    tmpString = default;
                    continue;
                }
                tmpString += item;
            }

            if (!(tmpString is null)) stack.Push(tmpString);

            tmpString = default;

            while (stack.Count > 0)
            {
                tmpString += (stack.Pop() + ' ');
            }

            return tmpString;
        }

        public static string ReverseWordsInSentence(string s)
        {
            return s is null ? null : String.Join(' ', s.Split().Where(x => !x.Equals("")).Reverse().ToArray());
        }


        public static bool IsRotation(string source, string s)
        {

            char[] sourceAsArray = source.ToCharArray();
            char[] sAsArray = s.ToCharArray();
            //LinkedList<char> charLinkedList = new LinkedList<char>(sAsList);
            //var x = charLinkedList.Last;
            IDictionary<char, IList<char>> perviousChar = new Dictionary<char, IList<char>>();

            if (!perviousChar.ContainsKey(sourceAsArray[0]))
            {
                perviousChar.Add(sourceAsArray[0], new List<char>());
            }
            perviousChar[sourceAsArray[0]].Add(sourceAsArray[sourceAsArray.Length - 1]);

            for (int i = 1; i < sourceAsArray.Length; i++)
            {
                if (!perviousChar.ContainsKey(sourceAsArray[i]))
                {
                    perviousChar.Add(sourceAsArray[i], new List<char>());
                }
                perviousChar[sourceAsArray[i]].Add(sourceAsArray[i - 1]);
            }

            for (int i = 1; i < sAsArray.Length; i++)
            {
                var item = sAsArray[i];
                foreach (var character in perviousChar[item])
                {
                    if (character != sAsArray[i - 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static string RemoveDuplicatLetters(string s)
        {
            ISet<char> set = new HashSet<char>();
            foreach (var item in s)
            {
                set.Add(item);
            }       

            return String.Concat(set.ToArray());
        }

        public static char FindMostRepeatedCharacter(string s)
        {
            IDictionary<char, int> characters = new Dictionary<char, int>();
            foreach (var item in s.ToCharArray())
            {
                if (!characters.ContainsKey(item))
                {
                    characters.Add(item, 0);
                }
                characters[item]++;
            }
            return characters.OrderBy(x => x.Value).LastOrDefault().Key;
        }

        public static char FindMostRepeatedCharacterMod(string s)
        {
            const int MAX_ASCII_SIZE = 256;
            int[] frequencies = new int[MAX_ASCII_SIZE];

            foreach (var item in s.ToCharArray())
            {
                frequencies[item]++;
            }

            int max = 0;
            int character = 0;
            for (int i = 0; i < frequencies.Length; i++)
            {
                if (frequencies[i]>max)
                {
                    max = frequencies[i];
                    character = i;
                }
            }

            return (char)character;
        }

        public static string CapitalizeAllWords(string s)
        {
            return String.Join(' ', s.Split().Where(x => !x.Equals("")).
                Select(x => 
                {
                    var y = x.ToCharArray();
                    return (y[0] < 65 && y[0] > 90) ? x : new string(Capitalize(y));
                }).ToArray());
            }

        private static char[] Capitalize(char[] s)
        {
            s[0] = (char)(s[0] - 32);
            return s;
        }


        public static bool IsAnagram(string s1, string s2)
        {
            return CalculateASCIISumCapitalizeInvariant(s1)==CalculateASCIISumCapitalizeInvariant(s2);
        }

        private static int CalculateASCIISumCapitalizeInvariant(string s)
        {
            int result = 0;

            foreach (var item in s.ToLower().ToCharArray())
            {
                result += item;
            }

            return result;
        }


        public static bool IsPalindrome(string s)
        {
            var arr = s.ToCharArray();
            for (int i = 0; i < (arr.Length)/2; i++)
            {
                if (arr[i]!= arr[arr.Length-1-i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
