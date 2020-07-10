using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace D1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ex1();
            ex2();
            ex3();
        }


        public static void ex1() 
        {
            char[] str = "abcd".ToCharArray();
            Stack<char> stack = new Stack<char>();

            //stack.Push(stack.ToArray());

            foreach (var item in str)
            {
                Console.WriteLine(item);
                stack.Push(item);
            }

            char[] arrChar = stack.ToArray();
            Console.WriteLine(arrChar);
        }


        public static void ex2() 
        {
            BallancerExpressionChecker ballancerExpressionChecker = new BallancerExpressionChecker();
            Console.WriteLine(ballancerExpressionChecker.Process("([<1>+(2)])"));
            Console.WriteLine(ballancerExpressionChecker.Process("([<1]+(2)])"));
            Console.WriteLine(ballancerExpressionChecker.Process("([<1>+(2)]){"));
            Console.WriteLine(ballancerExpressionChecker.Process("([<1>+()2)])"));
            Console.WriteLine(ballancerExpressionChecker.Process("}([<1>+()2)])"));
        }

        public static void ex3() 
        {
            MyStack<int> stack = new MyStack<int>(5);
            Console.WriteLine(stack.ToString());
            Console.WriteLine(stack.IsEmpty());
            stack.Push(2);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.LengthMax);
            Console.WriteLine(stack.ActualLength);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Console.WriteLine(stack.ToString());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.ToString());

        }
    }
}
