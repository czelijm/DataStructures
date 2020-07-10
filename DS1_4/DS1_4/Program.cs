using System;
using System.Collections;
using System.Collections.Generic;

namespace DS1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ex1();
            ex2();
            ex3();
            ex4();
        }

        static void ex1() 
        {
            Queue queue = new Queue();
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            Queue<int> queueNew = (Queue<int>)QueueReverser<int>.Reverse(queue);
            foreach (var item in queueNew)
            {
                Console.WriteLine(item);
            }

        }

        static void ex2()
        {
            ArrayQueue array = new ArrayQueue(5);
            Console.WriteLine(array.IsEmpty());
            Console.WriteLine(array.IsFull());
            Console.WriteLine(array.ToString());
            array.Enqueue(10);
            Console.WriteLine(array.ToString());
            Console.WriteLine(array.Peek());
            Console.WriteLine(array.Dequeue());
            Console.WriteLine(array.IsEmpty());
            Console.WriteLine(array.IsFull());
            array.Enqueue(10);
            array.Enqueue(20);
            array.Enqueue(30);
            array.Enqueue(30);

            Console.WriteLine(array.ToString());
            Console.WriteLine(array.IsEmpty());
            Console.WriteLine(array.IsFull());
            Console.WriteLine(array.Dequeue()); 
            Console.WriteLine(array.ToString());
            Console.WriteLine(array.IsEmpty());
            Console.WriteLine(array.IsFull());
            Console.WriteLine(array.Dequeue());
            Console.WriteLine(array.Dequeue());
            Console.WriteLine(array.ToString());
            Console.WriteLine(array.IsEmpty());
            Console.WriteLine(array.IsFull());
        }

        public static void ex3() 
        {
            StackQueue queue = new StackQueue();
            queue.Enqueue(10);
            Console.WriteLine(queue.ToString());
            Console.WriteLine(queue.Length);
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Length);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Length);
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            Console.WriteLine(queue.Length);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Length);
            queue.Enqueue(50);
            queue.Enqueue(60);
            while (queue.Length>0)
            {
                Console.WriteLine(queue.Dequeue());
            }
            Console.WriteLine(queue.Length);

        }

        public static void ex4() 
        {
            PriorityQueue queue = new PriorityQueue();
            queue.Insert(10,10);
            queue.Insert(9,9);
            queue.Insert(11, 11);
            foreach (var item in queue.Array)
            {
                Console.WriteLine(item.Value);
            }
        }

    }
}
