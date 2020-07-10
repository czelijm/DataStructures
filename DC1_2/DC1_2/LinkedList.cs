using System;
using System.Collections.Generic;
using System.Text;

namespace DC1_2
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        public int Length { get; private set; }

        public LinkedList()
        {
            Length = 0;
            this.Head = null;
            this.Tail = null;

        }

        public void AddFirst(Node<T> node) 
        {
            Length++;
            if (Length == 1)
            {
                this.Tail = node;
                this.Head = node;
                node.next = null;
                this.Tail.pervious =null;
                return;
            }
            node.next = this.Head;
            this.Head.pervious = node;
            this.Head = node;
            this.Head.pervious = null;
        }

        public void AddLast(Node<T> node)
        {
            if (this.Tail != null)
            { 
                this.Tail.next = node;
                node.pervious = this.Tail;
            }
            this.Tail = node;
            this.Length++;
            if (Length == 1)
            {
                this.Head = node;
            }
            Tail.next = null;

        }

        public void DeleteFirst()
        {

            Length--;
            if (Length <= 0)
            {
                Tail = null;
                Head = null;
                //Tail.next = null;
                //Head.next = null;
            }

            if (Head != null)
            {
                Head = Head.next;
                Head.pervious = null;
            }
            //else 
            //{
            //    Head = node;
            //    Tail = node;
            //    Tail.next = null;
            //}
        }

        public void DeleteLast()
        {

            Length--;
            if (Length <= 0)
            {
                Tail = null;
                Head = null;
                Length = 0;
                return;
            }

            if (Head != null)
            {
                //var tmpNode=Head;
                //for (int i = 0; i < Length; i++)
                //{
                //    tmpNode = tmpNode.next;
                //}
                //Tail = tmpNode;
                //Tail.next = null;
                //var tmpNode = Tail;
                Tail = Tail.pervious;
                Tail.next = null;
            }
        }


        public bool Contains(T t) 
        {
            Node<T> iterator = Head;
            for (int i = 0; i < Length; i++)
            {
                if (iterator.value.Equals(t))
                {
                    return true;
                }

                iterator = iterator.next;
            }

            return false;
        }

        public int IndexOf(Node<T> t)
        {
            if (t==null)
            {
                return -1;
            }
            Node<T> iterator = Head;
            for (int i = 0; i < Length; i++)
            {
                if (iterator.value.Equals(t.value))
                {
                    return i;
                }

                iterator = iterator.next;
            }

            return -1;
        }

        public T[] ToList() 
        {
            Node<T> iterator = Head;
            T[] array = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                array[i] = iterator.value;
                iterator = iterator.next;
            }

            return array;
        }


        public void Reverse() 
        {

            if (Length==0)
            {
                return;
            }

            Node<T> iterator = Tail;
            for (int i = Length - 1; i > -1; i--)
            {
                Node<T> tmpNodePervious = iterator.pervious;
                //Node<T> tmpNodeNext = iterator.next;

                iterator.pervious = iterator.next;
                iterator.next = tmpNodePervious;

                iterator = iterator.next;
            }
            iterator = Tail;
            Tail = Head;
            Tail.next = null;
            Head = iterator;
            Head.pervious = null;
        }

        public Node<T> KthElementFromEnd(int k) 
        {
            Node<T> iterator = Tail;
            for (int i = Length-1; i > k-2; i--)
            {
                if (i==k-1)
                {
                    return iterator;
                }

                iterator = iterator.pervious;
            }

            return null;

        }

    }
}
