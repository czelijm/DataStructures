using System;
using System.Collections.Generic;
using System.Text;

namespace DS1_4
{
    class StackQueue
    {
        private Stack<Object> stackEnqueue { get; set; }
        private Stack<Object> stackDequeue { get; set; }
        private bool WasDequue { get; set; }
        public int Length { get; private set; }

        private bool IsEmptyEnqueue { get { return stackEnqueue.Count == 0; } }
        private bool IsEmptyDequeue { get { return stackDequeue.Count == 0; } }
        public bool IsEmpty { get { return IsEmptyEnqueue && IsEmptyDequeue; } }

        public StackQueue()
        {
            stackEnqueue = new Stack<object>();
            stackDequeue = new Stack<object>();
            Length = 0;
        }

        public void Enqueue(Object o) 
        {
            stackEnqueue.Push(o);
            Length++;
        }

        public Object Peek() 
        {
            if (!IsEmpty) 
            {
                if (IsEmptyDequeue && !IsEmptyEnqueue)
                {
                    FromEnqueueToDequeue();

                }
                return stackDequeue.Peek();
                
            }
            throw new InvalidOperationException();
        }

        public Object Dequeue() 
        {
            if (!IsEmpty)
            {
                if (IsEmptyDequeue && !IsEmptyEnqueue)
                {
                    FromEnqueueToDequeue();

                }
                Length--;
                return stackDequeue.Pop();

            }
            throw new InvalidOperationException();
        }

        private void FromStackToStack(Stack<Object> s1, Stack<Object> s2) 
        {
            while (s2.Count>0)
            {
                s1.Push(s2.Pop());
            }
        }

        private void FromDequeueToEnqueue() 
        {
            FromStackToStack(stackEnqueue, stackDequeue);
        }
        private void FromEnqueueToDequeue()
        {
            FromStackToStack(stackDequeue, stackEnqueue);
        }

        public override string ToString()
        {
            string result = "";
            //foreach (var item in stackDequeue)
            //{
            //    result += (result + " ");
            //}
            //foreach (var item in stackEnqueue)
            //{
            //    result += (result + " ");
            //}
            result += stackDequeue+"";
            result += stackEnqueue + "";
            return result;
        }

    }
}
