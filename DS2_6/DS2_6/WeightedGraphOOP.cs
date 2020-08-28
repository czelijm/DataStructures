using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DS2_6
{
    class WeightedGraphOOP<T1, T2> where T2 : IComparable<T2>
    {
        private Dictionary<T1, Node> Nodes { get; set; }

        public WeightedGraphOOP()
        {
            Nodes = new Dictionary<T1, Node>();
        }

        public void AddNode(T1 n)
        {
            Nodes.Add(n, new Node { Value = n });
        }

        public void AddEdge(T1 from, T1 to, T2 w)
        {
            if (!Nodes.ContainsKey(from) || !Nodes.ContainsKey(to) || w is null)
            {
                throw new Exception("Node don't exist");
            }
            var fromNode = Nodes[from];
            var toNode = Nodes[to];

            fromNode.ConnectTo(toNode, w);

        }

        public void print()
        {
            foreach (var item in Nodes.Values)
            {
                Console.Write(item.ToString());
            }
        }

        private class Node
        {
            public T1 Value;
            public Dictionary<T1, LinkedList<Edge>> Edges { get; set; }

            public Node()
            {
                Edges = new Dictionary<T1, LinkedList<Edge>>();
            }
            public Node(T1 t)
            {
                Value = t;
                Edges = new Dictionary<T1, LinkedList<Edge>>();
            }

            public void ConnectTo(Node n, T2 w)
            {
                if (n is null) throw new Exception();
                if (!this.Edges.ContainsKey(n.Value))
                {
                    this.Edges.Add(n.Value, new LinkedList<Edge>());
                }
                if (!n.Edges.ContainsKey(this.Value))
                {
                    n.Edges.Add(this.Value, new LinkedList<Edge>());
                }

                this.Edges[n.Value].AddLast(new Edge { From = this, To = n, Weigth = w });
                n.Edges[this.Value].AddLast(new Edge { From = n, To = this, Weigth = w });
            }

            public override string ToString()
            {
                string result = "";
                foreach (var item1 in Edges.Values)
                {
                    foreach (var item in item1)
                    {
                        result += item.From.Value + " --- " + item.Weigth + " --- " + item.To.Value + "\n";
                    }
                }
                return result;
            }

        }
        private class Edge
        {
            public Node From { get; set; }
            public Node To { get; set; }
            public T2 Weigth { get; set; }

        }

        private class NodePriorityQueue : FastPriorityQueueNode
        {
            public Node Node { get; set; }
            public Node Source { get; set; }

            public T2 Weight { get; set; }

            public NodePriorityQueue(Node n, Node s, T2 p)
            {
                Node = n;
                Source = s;
                Weight = p;
            }

        }

        private class DijsktraTable
        {
            public Dictionary<T1, T2> Distances;
            public Dictionary<T1, T1> PerviosNodes;

            public static DijsktraTable MakeDijkstra(T1 from, T1 to, Dictionary<T1, Node> Nodes) 
            {
                SimplePriorityQueue<NodePriorityQueue, T2> queue = new SimplePriorityQueue<NodePriorityQueue, T2>();
                Dictionary<T1, T2> distances = new Dictionary<T1, T2>();
                Dictionary<T1, T1> perviosNodes = new Dictionary<T1, T1>();
                ISet<T1> visited = new HashSet<T1>();

                var start = Nodes[from];

                //dynamic tmp = 0;
                distances.Add(start.Value, default(T2));
                perviosNodes.Add(start.Value, default(T1));
                queue.Enqueue(new NodePriorityQueue(start, null, default(T2)), default(T2));

                while (queue.Count != 0)
                {
                    var queueNode = queue.Dequeue();
                    var node = queueNode.Node;
                    if (visited.Contains(node.Value))
                    {
                        continue;
                    }

                    dynamic tmpDistance = queueNode.Weight;

                    if (distances.ContainsKey(node.Value))
                    {
                        if (tmpDistance < distances[node.Value])
                        {
                            distances[node.Value] = (T2)tmpDistance;
                            perviosNodes[node.Value] = queueNode.Source.Value; //node.Edges[
                                                                               //node.Edges[node.Value].Where(n => n.From.Value.Equals(node.Value)).FirstOrDefault().To.Value;
                        }
                    }
                    else
                    {
                        distances.Add(node.Value, (T2)tmpDistance);
                        perviosNodes.Add(node.Value, queueNode.Source.Value);
                    }

                    foreach (var list in node.Edges.Values)
                    {
                        foreach (var item in list)
                        {
                            dynamic dist = item.Weigth;
                            dist += distances[node.Value];
                            T2 x = dist;
                            //float distanceFloat = BitConverter.ToSingle(dist);
                            queue.Enqueue(new NodePriorityQueue(item.To, item.From, x), x);//BitConverter.GetBytes((dist)));                       
                        }
                    }

                    visited.Add(node.Value);

                }
                return new DijsktraTable { Distances = distances, PerviosNodes = perviosNodes };
            }

        }

        public T2 GetShortestDistance(T1 from, T1 to) 
        {
            DijsktraTable dijsktraTable = DijsktraTable.MakeDijkstra(from, to, Nodes);
            return dijsktraTable.Distances[to];

        }

        public IList<T1> GetShortestPath(T1 from, T1 to) 
        {
            DijsktraTable dijsktraTable = DijsktraTable.MakeDijkstra(from, to, Nodes);
            //IList<T1> list = new List<T1>();
            Stack<T1> stack = new Stack<T1>();
            stack.Push(to);
            while (!stack.Peek().Equals(from))
            {
                stack.Push(dijsktraTable.PerviosNodes[stack.Peek()]);
            }
            return stack.ToList<T1>();
        }

        private class CycleNode 
        {
            public T1 Node;
            public T1 Parent;

            public CycleNode(T1 n, T1 p)
            {
                Node = n;
                Parent = p;
            }
        }

        public bool HasCycle() 
        {
            ISet<T1> visited = new HashSet<T1>();

            var nodeToStart = Nodes.Values.FirstOrDefault();

            Stack<CycleNode> toVisitNodes = new Stack<CycleNode>();

            //foreach (var item in nodesToSearch)
            //{
                
                toVisitNodes.Push(new CycleNode(nodeToStart.Value, default));
            //}


            while (toVisitNodes.Count!=0)
            {
                var n = toVisitNodes.Pop();
                //if (visited.Contains(n.Node) && !(n.Parent is null) && n.Parent.Equals())
                //{
                //    return true;
                //}

                visited.Add(n.Node);

                foreach (var list in Nodes[n.Node].Edges.Values)
                {
                    foreach (var item in list)
                    {
                        if (!(n.Parent is null) && n.Parent.Equals(item.To.Value))
                        {
                            continue;
                        }
                        if (visited.Contains(item.To.Value))
                        {
                            return true;
                        }

                        toVisitNodes.Push(new CycleNode(item.To.Value,n.Node));

                    }
                }
            }

            return false;
        }

        public WeightedGraphOOP<T1, T2> MakeSpanningTree()
        {
            WeightedGraphOOP<T1, T2> spanningTree = new WeightedGraphOOP<T1, T2>();
            SimplePriorityQueue<NodePriorityQueue> queue = new SimplePriorityQueue<NodePriorityQueue>();

            var startNode = Nodes.Values.FirstOrDefault();
            if (startNode is null)
            {
                throw new NullReferenceException();
            }

            queue.Enqueue(new NodePriorityQueue(startNode, null, default),0);

            while (spanningTree.Nodes.Count<Nodes.Count)
            {
                var n = queue.Dequeue();
                if (spanningTree.Nodes.ContainsKey(n.Node.Value))
                {
                    continue;
                }
                spanningTree.AddNode(n.Node.Value);
                if (!(n.Source is null))
                {
                    spanningTree.AddEdge(n.Source.Value, n.Node.Value, n.Weight);
                }
                foreach (var list in n.Node.Edges.Values)
                {
                    foreach (var item in list)
                    {
                        dynamic priority = item.Weigth;
                        queue.Enqueue(new NodePriorityQueue(item.To, item.From, item.Weigth), priority);
                    }
                }
            }

            return spanningTree;
        }

    }
}
