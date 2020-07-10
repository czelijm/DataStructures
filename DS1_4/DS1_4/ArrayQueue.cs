using System;
using System.Collections.Generic;
using System.Text;

namespace DS1_4
{
    class ArrayQueue
    {
        private Object[] Array { get; set; }
        public int Length { get; }
        public int ItemsInArray { get; private set; }
        //public int ActualItemIndex { get; private set; }
        private int RIndex { get; set; }
        private int FIndex { get; set; }
        private Object F {get; set;}
        private Object R {get; set;}

        public ArrayQueue(int Length)
        {
            this.Length = Length;
            Array = new Object[Length];
            //ItemsInArray = 0;
            FIndex = -1;
            RIndex = - 1;
            //ActualItemIndex = -1;
        }

        public bool IsEmpty() 
        {
            return FIndex == -1|| FIndex>RIndex;
        }

        public bool IsFull()
        {
            return RIndex+1 == Length;
        }

        public Object Peek()
        {
            return F;
        }

        public void Enqueue(Object o) 
        {
            if (!IsFull())
            {
                RIndex++;
                Array[RIndex]=o;
                R = Array[RIndex];
                if (RIndex==0) 
                {
                    FIndex++;
                    F = Array[RIndex];
                }
                return;
            }
            throw new InvalidOperationException("Queue is full");
            
        }

        public Object Dequeue()
        {
            if (!IsEmpty())
            {
                var result = F;
                Array[FIndex] = null;
                FIndex++;
               
                if (IsEmpty())
                {
                    FIndex++;
                    F = Array[RIndex];
                }
                else
                {
                    F = Array[FIndex];
                }
                return result;
                
            }
            throw new InvalidOperationException("Queue is empty");

        }

        public override string ToString()
        {
            string result = "";
            foreach (var item in Array)
            {
                result+= item +" ";
            }
            return result;
        }


    }
}
