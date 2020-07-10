using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace DS1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            ex1();
            ex2();
            Console.WriteLine("Hello World!");
            ex3();
        }

        public static void ex1()
        {
            FirstNonReapetedCharacterFinder finder = new FirstNonReapetedCharacterFinder();
            Console.WriteLine(finder.FindFirstNonReapetedCharacter("A Green Apple"));
        }

        public static void ex2() 
        {
            Console.WriteLine(FirstReapetedCharacterFinder.FindFirstReapetedCharacterHashSet("A Green Apple"));
            Console.WriteLine(FirstReapetedCharacterFinder.FindFirstReapetedCharacterHashSet("ABC"));
        }

        public static void ex3() 
        {
            HashTable hashTable = new HashTable();
            hashTable.Put(1, "Value 1");
            hashTable.Put(8, "Value 8");
            Console.WriteLine(hashTable.Get(1));
            Console.WriteLine(hashTable.Get(8));
            hashTable.Remove(1);
            Console.WriteLine(hashTable.Get(1));
            Console.WriteLine(hashTable.Get(8));

        }
    }
}
