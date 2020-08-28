using System;
using System.Collections.Generic;
using System.Text;

namespace DS2_6
{
    public class WeightedGraph<T1,T2>
    {
        private Dictionary<T1,LinkedList<Edge>> Edges { get; set; }
        private Dictionary<T1,Node> Nodes { get; set; }

        public WeightedGraph()
        {
            Edges = new Dictionary<T1, LinkedList<Edge>>();
            Nodes = new Dictionary<T1, Node>();
        }

        public void AddNode(T1 n) 
        {
            Nodes.Add(n, new Node {Value=n });
        }

        public void AddEdge(T1 from, T1 to, T2 w)
        {
            if (!Nodes.ContainsKey(from) || !Nodes.ContainsKey(to) || w is null)
            {
                throw new Exception("Node don't exist");
            }
            var fromNode = Nodes[from];
            var toNode = Nodes[to];

            if (!Edges.ContainsKey(from))
            {
                Edges.Add(from,new LinkedList<Edge>());
            }
            if (!Edges.ContainsKey(to))
            {
                Edges.Add(to, new LinkedList<Edge>());
            }


            Edges[from].AddLast(new Edge { From=fromNode,To=toNode,Weigth=w});
            Edges[to].AddLast(new Edge { From=toNode,To=fromNode,Weigth=w});
        }

        public void print() 
        {
            foreach (var item1 in Edges.Values)
            {
                foreach (var item in item1)
                {
                    Console.WriteLine(item.From.Value + " --- " + item.Weigth + " --- " + item.To.Value);
                }
            }
        }

        private class Node
        {
            public T1 Value;

            public Node(){}
            public Node(T1 t)
            {
                Value = t;
            }

            //public void ConnectTo(Node n, T2 w) 
            //{
            //    if (n is null) throw new Exception();
            //    Edges.AddLast(new Edge{From=this,To=n,Weigth=w });
            //    n.Edges.AddLast(new Edge{From=n,To=this,Weigth=w });
            //}

        }

        private class Edge 
        {
            public Node From { get; set; }
            public Node To { get; set; }
            public T2 Weigth { get; set; }

        }
    }
}
