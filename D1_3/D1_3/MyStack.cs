using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D1_3
{
    public class MyStack<T>
    {
        public int LengthMax { get; private set; }
        private T[] Array;
        private int TopOfStackItemIndex;
        public int ActualLength { get => TopOfStackItemIndex + 1; }

        public MyStack(int LengthMax) 
        {
            this.LengthMax = LengthMax;
            Array = new T[this.LengthMax];
            TopOfStackItemIndex = -1;
        }

        public T Peek() 
        {
            return Array[TopOfStackItemIndex];
        }
        public T Pop() 
        {
            if (!IsEmpty())
            {
                T val = Peek();
                TopOfStackItemIndex--;
                return val;
            }
            throw new System.IndexOutOfRangeException();

        }
        public void Push(T val) 
        {
            if (TopOfStackItemIndex + 1 < LengthMax)
            {
                TopOfStackItemIndex++;
                Array[TopOfStackItemIndex] = val;
                return;
            }
            throw new System.StackOverflowException();  
        }

        public bool IsEmpty() 
        {
            return TopOfStackItemIndex < 0 ? true : false;
        }

        public override string ToString()
        {
            return String.Join(",", this.Array.Take(TopOfStackItemIndex).ToArray());
                
        }

    }
}
