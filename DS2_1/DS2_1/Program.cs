using System;

namespace DS2_1
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
            Tree tree = new Tree();
            Tree treeImpostor = new Tree();

            tree.Add(5);
            tree.Add(4);
            tree.Add(6);
            tree.Add(7);
            tree.Add(3);
            tree.Add(10);

            treeImpostor.Add(5);
            treeImpostor.Add(4);
            treeImpostor.Add(6);
            treeImpostor.Add(7);
            treeImpostor.Add(3);
            treeImpostor.Add(2);
            //Console.WriteLine(tree.Find(6));
            //Console.WriteLine(tree.Find(4));
            //Console.WriteLine(tree.Find(7));
            tree.TraversePreOrder();
            tree.TraverseInOrder();
            tree.TraversePostOrder();
            Console.WriteLine(tree.Equals(treeImpostor));
            Console.WriteLine(tree.IsBinarySearchTree());
            tree.SwapRoot();
            Console.WriteLine(tree.IsBinarySearchTree());

        }
    }


}
