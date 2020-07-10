using System;
using System.Collections.Generic;
using System.Text;

namespace DC1_2
{
    public class Node<T>
    {
        public T value { get; set; }
        public Node<T> next { get; set; }
        public Node<T> pervious { get; set; }


        public Node(T t)
        {
            value = t;
        }



    }
}
