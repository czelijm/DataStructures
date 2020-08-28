using System;
using System.Collections.Generic;

namespace DS2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            ex1();
            ex2();
            Console.WriteLine("Hello World!");
        }

        public static void ex1()
        {
            Tries trie = new Tries();
            trie.Insert("xD");
            Tries trie1 = new Tries();
            trie1.InsertLoopVersion("xD");
            TriesHashTable tHT = new TriesHashTable();
            tHT.InsertLoopVersion("xD");
            Console.WriteLine(tHT.Contains("xD"));
            tHT.Delete("xD");
        }

        static public void ex2()
        {
            TriesHashTable tHT = new TriesHashTable();
            tHT.InsertLoopVersion("car");
            tHT.InsertLoopVersion("care");
            tHT.InsertLoopVersion("card");
            tHT.InsertLoopVersion("careful");
            tHT.InsertLoopVersion("egg");
            List<string> words = tHT.Autocompletion("care");
            List<string> wordsEgg = tHT.Autocompletion("egg");
            List<string> wordsEggg = tHT.Autocompletion("eggg");

            foreach (var item in words)
            {
                Console.WriteLine(item);
            }

            foreach (var item in wordsEgg)
            {
                Console.WriteLine(item);
            }




        }
    }
}
