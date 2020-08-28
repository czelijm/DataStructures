using System;
using System.Collections.Generic;

namespace DS2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //ex1();
            //ex2();
            //ex3();
            ex4();
            Console.WriteLine("Hello World!");
        }

        public static void ex1()
        {
            WeightedGraph<string, int> graph = new WeightedGraph<string, int>();
            WeightedGraphOOP<string, int> graphOOP = new WeightedGraphOOP<string, int>();


            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");

            graph.AddEdge("A","B",3);
            graph.AddEdge("A", "C", 5);

            graph.print();

        }
        public static void ex2()
        {
            WeightedGraphOOP<string, int> graph = new WeightedGraphOOP<string, int>();


            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");

            graph.AddEdge("A","B",3);
            graph.AddEdge("A", "C", 5);

            graph.print();

        }

        public static void ex3()
        {
            WeightedGraphOOP<string, int> graph = new WeightedGraphOOP<string, int>();


            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");

            graph.AddEdge("A","B",3);
            graph.AddEdge("A", "C", 5);
            graph.AddEdge("B", "C", 1);


            Console.WriteLine(graph.GetShortestDistance("A","C"));
            List<string> list = (List<string>)graph.GetShortestPath("A", "C");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

        }


        public static void ex4()
        {
            WeightedGraphOOP<string, int> graph = new WeightedGraphOOP<string, int>();


            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddNode("E");

            graph.AddEdge("A", "B", 3);
            graph.AddEdge("A", "C", 5);
            //graph.AddEdge("B", "C", 1);
            graph.AddEdge("C", "D", 1);
            graph.AddEdge("D", "E", 2);
            graph.AddEdge("E", "C", 7);




            Console.WriteLine(graph.HasCycle());

            var spanningTree = graph.MakeSpanningTree();

            spanningTree.print();



        }

    }
}
