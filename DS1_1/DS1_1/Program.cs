using System;

namespace DS1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Array<int> array = new Array<int>();
            Console.WriteLine(array.Length);
            array.Add(10);
            array.Add(20);
            array.Add(30);
            array.Add(40);
            array.Add(50);
            array.print();
            array.RemoveAt(3);
            Console.WriteLine(array.Length);
            array.print();

            Console.WriteLine(array.IndexOf(50));
            Console.WriteLine(array.IndexOf(10));
            Console.WriteLine(array.IndexOf(100));
        }
    }
}
