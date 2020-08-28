using System;

namespace DS2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ex1();
            Console.WriteLine("Hello World!");
        }

        public static void ex1() 
        {
            AVLTree tree = new AVLTree();
            tree.Insert(5);
            tree.Insert(2);
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(1);
            tree.Insert(8);
            tree.Insert(9);

            AVLTree t = new AVLTree();
            t.Insert(10);
            t.Insert(30);
            t.Insert(20);
            
            AVLTree t1 = new AVLTree();
            t1.Insert(10);
            t1.Insert(20);
            t1.Insert(11);

        }
    }
}
