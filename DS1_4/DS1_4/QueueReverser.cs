using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS1_4
{
    public static class QueueReverser<T>
    {
        public static ICollection Reverse(ICollection queue)
        {
            Stack<T> stack = new Stack<T>();

            foreach (var item in queue)
            {
                stack.Push((T)item);
            }

            return new Queue<T>(stack);
        }
    }
}
