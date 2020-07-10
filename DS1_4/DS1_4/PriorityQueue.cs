using System;
using System.Collections.Generic;
using System.Text;

namespace DS1_4
{
    class PriorityQueue
    {
        public PriorityItem[] Array { get; private set; }
        public int Length { get; private set; }
        public int MaxLength { get; private set; }

        public PriorityQueue()
        {
            //Array = new PriorityItem[1];
            MaxLength = 1;
            Length = 0;
        }
        //public PriorityQueue(int length)
        //{
        //    MaxLength = length;
        //    Length = 0;
        //    Array = new PriorityItem[Length];
        //}

        public void Insert(Object value, int priority) 
        {
            PriorityItem itemToInsert = new PriorityItem(value, priority);
                //MaxLength++;
            PriorityItem[] newArray = new PriorityItem[Length+1];
            for (int i = Length-1; i > -1; i--)
            {
                newArray[i] = Array[i];
            }
            Array = newArray;

            for (int i = Length; i > -1; i--)
            {
                if (i - 1 == -1 || Array[i - 1]==null || Array[i-1].Priority <= itemToInsert.Priority)
                {
                    Array[i] = itemToInsert;
                    break;
                }
                else
                {
                    Array[i] = Array[i - 1];
                }
                //newArray[i] = Array[i];
            }

            Length++;
        }
        public class PriorityItem
        {
            public int Priority { get; set; }
            public Object Value { get; set; }

            public PriorityItem(Object value, int priority)
            {
                Priority = priority;
                Value = value;
            }
        }
    }

}
