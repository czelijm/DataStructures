using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DS2_3
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

        static void ex1() 
        {
            Heap heap = new Heap();
            heap.Insert(1);
            heap.Insert(2);
            heap.Insert(3);
            heap.Insert(20);
            heap.Insert(5);
            heap.Insert(4);
            heap.Remove();
            heap.Insert(30);

        }

        static void ex2()
        {
            int[] arr = {5,3,8,4,1,2};
            Object[] a = arr.Select(b => (object)b).ToArray();
            var arrHeapped = Heapify.heapify(a);
            foreach (var item in arrHeapped)
            {
                Console.WriteLine( Convert.ToInt32(item));
            }
            //Convert.ToInt32((Object[])arrHeapped);
        }

        static void ex3()
        {
            int[] arr = { 8, 4, 5, 3, 1, 2 };
            Object[] a = arr.Select(b => (object)b).ToArray();
            Console.WriteLine(Convert.ToInt32(Heapify.FindKthMaxValue(a, 4)));
            int[] arr1 = { 5, 3, 8, 4, 1, 2 };
            Object[] a1 = arr1.Select(b => (object)b).ToArray();
            Console.WriteLine(Convert.ToInt32(Heapify.FindKthMaxValueOldSchool(a1, 4)));
        }
    
    }
}
