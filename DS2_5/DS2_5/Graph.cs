using System;
using System.Collections.Generic;
using System.Linq;


namespace DS2_5
{
    public class Graph<T>
    {
        private Dictionary<T, LinkedList<Node>> Neightbors { get; set; }

        public Graph()
        {
            Neightbors = new Dictionary<T, LinkedList<Node>>();
        }

        private class Node
        {
            public T Value { get; set; }
            //public Node Next { get; set; }

            public Node()
            {

            }

            public Node(T t)
            {
                Value = t;
            }
        }

        public void AddNode(T t)
        {
            if (Neightbors.ContainsKey(t) || t is null) return;
            Neightbors.Add(t, new LinkedList<Node>());
            Neightbors[t].AddFirst(new Node(t));
        }
        public void RemoveNode(T t)
        {
            foreach (var item in Neightbors.Values)
            {
                var nodeToDelete = item.SingleOrDefault(n => n.Value.Equals(t));
                if (nodeToDelete != null)
                {
                    item.Remove(nodeToDelete);
                }
            }
            Neightbors.Remove(t);
        }


        public void AddEdge(T source, T destination)
        {
            if (source.Equals(destination) || !(Neightbors.ContainsKey(source)) || !(Neightbors.ContainsKey(destination))) return;
            Neightbors[source].AddLast(new Node(destination));
        }

        public void RemoveEdge(T source, T destination)
        {
            if (source.Equals(destination) || !(Neightbors.ContainsKey(source)) || !(Neightbors.ContainsKey(destination))) return;
            var item = Neightbors[source].SingleOrDefault(x => x.Value.Equals(destination));
            if (item != null)
            {
                Neightbors[source].Remove(item);
            }
        }

        public void print()
        {
            foreach (var list in Neightbors.Values)
            {
                var node = list.First;
                var neigthbor = node;
                Console.Write(node.Value.Value + " is connected to ");

                while (!(neigthbor.Next is null))
                {
                    neigthbor = neigthbor.Next;
                    Console.Write(neigthbor.Value.Value + " ");
                }
                Console.Write("\n");

            }
        }

        public void TraversalDepthFirst()
        {
            ISet<T> set = new HashSet<T>();
            foreach (var item in Neightbors.Values.AsEnumerable())
            {

                set = TraversalDepthFirst(item.FirstOrDefault().Value, set);
            }
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }

        private ISet<T> TraversalDepthFirst(T t, ISet<T> s)
        {
            if (s.Contains(t))
            {
                return s;
            }

            //if (!(Neightbors[t].Count>1))
            //{
            //    return;
            //}


            s.Add(t);
            //Console.WriteLine(t);

            foreach (var item in Neightbors[t].Skip(1))
            {
                s = TraversalDepthFirst(item.Value, s);
            }

            return s;
        }
        private Stack<T> TraversalDepthFirst(T t, ISet<T> visited, Stack<T> ts)
        {
            if (visited.Contains(t))
            {
                return ts;
            }

            //if (!(Neightbors[t].Count>1))
            //{
            //    return;
            //}



            //Console.WriteLine(t);

            foreach (var item in Neightbors[t].Skip(1))
            {
                ts = TraversalDepthFirst(item.Value, visited, ts);
            }
            ts.Push(t);
            visited.Add(t);

            return ts;
        }

        public void TraversalDepthFirstIterative(T t)
        {
            if (!(Neightbors.ContainsKey(t)) || t is null)
            {
                return;
            }
            ISet<T> set = new HashSet<T>();
            Stack<T> stack = new Stack<T>();
            set.Add(t);
            stack.Push(t);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                Console.WriteLine(current);
                foreach (var item in Neightbors[current].Skip(1))
                {
                    var value = item.Value;
                    if (!set.Contains(value))
                    {
                        stack.Push(value);
                        set.Add(value);
                    }
                }
            }

        }



        public void TraversalBreadthFirstIterative(T t)
        {
            if (!(Neightbors.ContainsKey(t)) || t is null)
            {
                return;
            }
            ISet<T> set = new HashSet<T>();
            Queue<T> queue = new Queue<T>();
            //Stack<T> stack = new Stack<T>();
            set.Add(t);
            //stack.Push(t);
            queue.Enqueue(t);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current);
                foreach (var item in Neightbors[current].Skip(1))
                {
                    var value = item.Value;
                    if (!set.Contains(value))
                    {
                        queue.Enqueue(value);
                        set.Add(value);
                    }
                }
            }

        }

        public IList<T> TopologicalSorting()
        {
            IList<T> ts = new List<T>();
            Stack<T> ts1 = new Stack<T>();
            ISet<T> ts2 = new HashSet<T>();

            foreach (var item in Neightbors.Values.AsEnumerable())
            {
                ts1 = TraversalDepthFirst(item.FirstOrDefault().Value, ts2, ts1);
            }
            while (ts1.Count > 0)
            {
                ts.Add(ts1.Pop());
            }
            return ts;

        }

        public bool HasCycle()
        {
            Stack<T> all = KeysToStack();
            ISet<T> visiting = new HashSet<T>();
            ISet<T> visited = new HashSet<T>();
            bool cycleFound = false;

            while (all.Count>0 && !cycleFound)
            {
                T node = all.Pop();


                //visiting.Add(node);
                cycleFound = HasCycle(node,visiting,visited);


            }

            return cycleFound;
        }

        private bool HasCycle(T node, ISet<T> visiting, ISet<T> visited) 
        {

            if (visiting.Contains(node))
            {
                return true;
            }

            visiting.Add(node);
            foreach (var item in Neightbors[node].Skip(1))
            {
                if (HasCycle(item.Value,visiting,visited))
                {
                    return true;
                }
                visiting.Remove(node);
                visited.Add(node);
            }
            visiting.Remove(node);
            visited.Add(node);

            return false;
        }

        private Stack<T> KeysToStack() 
        {
            Stack<T> all = new Stack<T>();
            foreach (var item in Neightbors.Keys.ToArray().Reverse())
            {
                all.Push(item);
            }
            return all;
        }

    }
}
