using System;
using System.Collections.Generic;
using System.Text;

namespace DS1_5
{
    class FirstNonReapetedCharacterFinder
    {
        public Dictionary<Char, Int16> Dictonary { get; set; }//= new Dictionary<string, short>();


        public FirstNonReapetedCharacterFinder()
        {
            Dictonary = new Dictionary<char, short>();
        }

        public Object FindFirstNonReapetedCharacter(string s)
        {
            
            foreach (var item in s.ToCharArray())
            {
                if (Dictonary.ContainsKey(item))
                {
                    Dictonary[item]++;
                }
                else
                {
                    Dictonary.Add(item, 1);
                }
            }

            foreach (var item in Dictonary)
            {
                if (item.Value == 1) 
                {
                    return item.Key;
                }
            }
            
            return null;
        }

    }
}
