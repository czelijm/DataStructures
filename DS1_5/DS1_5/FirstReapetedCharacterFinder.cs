using System;
using System.Collections.Generic;
using System.Text;

namespace DS1_5
{
    class FirstReapetedCharacterFinder
    {
        //public static Object FindFirstReapetedCharacterDictionary(string s)
        //{
        //    Dictionary<char, short> Dictionary = new Dictionary<char, short>();

        //    foreach (var item in s.ToCharArray())
        //    {
        //        if (Dictionary.ContainsKey(item))
        //        {
        //            Dictionary[item]++;
        //        }
        //        else
        //        {
        //            Dictionary.Add(item, 1);
        //        }
        //    }

        //    foreach (var item in Dictionary)
        //    {
        //        if (item.Value > 1)
        //        {
        //            return item.Key;
        //        }
        //    }
        //    return null;
        //}

        public static Object FindFirstReapetedCharacterHashSet(string s)
        {
            Dictionary<char, short> Dictionary = new Dictionary<char, short>();
            HashSet<char> Set = new HashSet<char>();

            foreach (var item in s.ToCharArray())
            {
                if (Set.Contains(item))
                {
                    return item;
                }
                Set.Add(item);
            }

            return null;
        }
    }
}
