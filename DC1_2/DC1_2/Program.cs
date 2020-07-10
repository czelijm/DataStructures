using System;

namespace DC1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(new Node<int>(5));
            list.AddFirst(new Node<int>(4));
            list.AddFirst(new Node<int>(3));

            list.AddLast(new Node<int>(5));
            list.AddLast(new Node<int>(6));
            list.AddLast(new Node<int>(7));
            list.AddLast(new Node<int>(7));

            list.DeleteFirst();
            list.DeleteLast();

            Node<int> iterator = list.Head;
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(iterator.value);
                iterator = iterator.next;
            }
            Console.WriteLine(list.Contains(7));
            Console.WriteLine(list.Contains(2));
            Console.WriteLine(list.IndexOf(new Node<int>(7)));
            Console.WriteLine(list.IndexOf(new Node<int>(2)));

            int[] arr = list.ToList();

            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }


            list.Reverse();

            arr = list.ToList();

            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }


            Console.WriteLine(list.KthElementFromEnd(5).value);

        }
    }
}
