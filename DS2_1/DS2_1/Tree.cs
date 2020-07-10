using System;
using System.Collections.Generic;
using System.Text;

namespace DS2_1
{
    public class Tree
    {
        public class Node //: IComparable
        {
            public object LeftChild { get; set; }
            public object RightChild { get; set; }
            public object Parent { get; set; }
            public object Value { get; set; }

            //public int CompareTo(object obj)
            //{
            //    return
            //}
            //IComparable comparable = (IComparable)actualPropertyValue;
            //return comparable != null && comparable.CompareTo(Value) > 0;

            //public bool Equals(Node obj)
            //{
            //    return this.Value==obj.Value;
            //}
        }

        public Node Root { get; set; }

        private Object FindNodeToAdd(IComparable v) 
        {
            Node tmpNode = Root;
            while (!(tmpNode is null) && tmpNode.Value != v)
            {

                if (((IComparable)tmpNode.Value).CompareTo(v) < 0)
                {
                    if (tmpNode.RightChild is null)
                    {
                        return tmpNode;
                    }
                    else
                    {
                        tmpNode = (Node)tmpNode.RightChild;
                    }
                }
                else 
                {
                    if (tmpNode.LeftChild is null)
                    {
                        return tmpNode;
                    }
                    else
                    {
                        tmpNode = (Node)tmpNode.LeftChild;
                    }

                }
                //tmpNode = (Node) (((IComparable)tmpNode.Value).CompareTo(v)>0? tmpNode.RightChild : tmpNode.LeftChild);
            }
            return tmpNode;
        }

        private Object FindValue(IComparable v) 
        {
            Node tmpNode = Root;
            while (!(tmpNode is null))
            {
                int compare = ((IComparable)tmpNode.Value).CompareTo(v);
                if (compare < 0)
                {
                    tmpNode = (Node)tmpNode.RightChild;
                }
                else if (compare == 0)
                {
                    return tmpNode.Value;
                }
                else
                {
                    tmpNode = (Node)tmpNode.LeftChild;
                }
                
            }

            return null;
        }

        

        public Object Find(Object v) 
        {
            return (FindValue((IComparable)v));
        }


        public void Add(Object v) 
        {
            var result =(Node)FindNodeToAdd((IComparable)v);
            if (result==null)
            {
                if (Root != null) return;
                Root = new Node() { Value=v };
                return;
            }
            int compare = ((IComparable)result.Value).CompareTo(v);
            if (((IComparable)result.Value).CompareTo((IComparable)v)<0) 
            {
                result.RightChild = new Node() { Value=v};
            }
            else
            {
                result.LeftChild = new Node() { Value = v };
            }

        }
        public void TraversePreOrder() 
        {
            TraversePreOrder(Root);
        }

        private void TraversePreOrder(Node root) 
        {
            if (root is null)
            {
                return;
            }

            Console.WriteLine(root.Value);
            TraversePreOrder((Node)root.LeftChild);
            TraversePreOrder((Node)root.RightChild);
        }
        public void TraverseInOrder() 
        {
            TraverseInOrder(Root);
        }

        private void TraverseInOrder(Node root) 
        {
            if (root is null)
            {
                return;
            }

            
            TraverseInOrder((Node)root.LeftChild);
            Console.WriteLine(root.Value);
            TraverseInOrder((Node)root.RightChild);
        }
        
        public void TraversePostOrder() 
        {
            TraversePostOrder(Root);
        }

        private void TraversePostOrder(Node root) 
        {
            if (root is null)
            {
                return;
            }

            
            TraversePostOrder((Node)root.LeftChild);
            TraversePostOrder((Node)root.RightChild);
            Console.WriteLine(root.Value);
        }

        public bool Equals(Tree obj)
        {
            return Equals(obj.Root,this.Root);
        }

        private bool Equals(Node r, Node n) 
        {
            if (r is null && !(n is null) || n is null && !(r is null))
            {
               return false;
            }
            if (r is null && n is null)
            {
                return true;
            }

            if (r.RightChild==null && r.LeftChild==null && n.RightChild == null && n.LeftChild == null)
            {
                if (!r.Value.Equals(n.Value))
                    return false;
                else
                    return true;
            }
            return Equals((Node)r.LeftChild,(Node)n.LeftChild) && Equals((Node)r.RightChild,(Node)n.RightChild);
            
        }

        public bool IsBinarySearchTree() 
        {
            return IsBinarySearchTree(Root,Int32.MaxValue,null);
        }

        public bool IsBinarySearchTree(Node n, IComparable upper, IComparable lower) 
        {
            var result = true;

            if (n is null)
            {
                return true;
            }
            
            if (n.LeftChild is null && n.RightChild is null)
            {
                return ((IComparable)n.Value).CompareTo(upper) < 0 && ((IComparable)n.Value).CompareTo(lower) > 0;
            }
            result &= IsBinarySearchTree((Node)n.LeftChild, (IComparable)n.Value, lower);
            result &= IsBinarySearchTree((Node)n.RightChild, upper, (IComparable)n.Value);
            return result;
        }

        public void SwapRoot()
        {
            var tmp = Root.LeftChild;
            Root.LeftChild = Root.RightChild;
            Root.RightChild = tmp;
        }
    }


}
