using System;

namespace DS2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            ex1();
            ex5();
            Console.WriteLine("Hello World!");
        }

        static void ex1() 
        {
            Graph<string> graph = new Graph<string>();
            graph.AddNode("Martha");
            graph.AddNode("Anna");
            graph.AddNode("Elsa");
            graph.AddNode("Maria");
            graph.AddNode("Susie");


            graph.AddEdge("Maria","Martha");
            graph.AddEdge("Martha", "Anna");
            graph.AddEdge("Martha", "Elsa");
            graph.AddEdge("Martha", "Susie");
            graph.print();

            //graph.RemoveNode("Anna");
            //graph.print();

            //graph.RemoveEdge("Martha","Elsa");
            //graph.print();

            //ex2
            graph.TraversalDepthFirst();
            graph.TraversalDepthFirstIterative("Maria");
            //ex3
            graph.TraversalBreadthFirstIterative("Maria");
            //ex4
            var result = graph.TopologicalSorting();
            Console.WriteLine(result);
        }

        public static void ex5()
        {
            Graph<string> graph = new Graph<string>();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");

            graph.AddEdge("D", "A");
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            //graph.AddEdge("C", "A");
            
            Console.WriteLine(graph.HasCycle());
        }



    }
}
