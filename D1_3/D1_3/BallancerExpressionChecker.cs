using System;
using System.Collections.Generic;
using System.Text;

namespace D1_3
{
    public class BallancerExpressionChecker
    {
        public Stack<char> vs = new Stack<char>();
        ICollection<CheckPairItem> BracleList;

        public BallancerExpressionChecker() 
        {
            BracleList = new List<CheckPairItem>();
            BracleList.Add(new CheckPairItem()
            {
                Item = '(',
                OppositeItem = ')'
            });
            BracleList.Add(new CheckPairItem()
            {
                Item = '{',
                OppositeItem = '}'
            });
            BracleList.Add(new CheckPairItem()
            {
                Item = '[',
                OppositeItem = ']'
            });
            BracleList.Add(new CheckPairItem()
            {
                Item = '<',
                OppositeItem = '>'
            });
        }

        public int Process(string s) 
        {
            //char[] str = s.ToCharArray();
            //foreach (var item in str)
            //{

            //    Console.WriteLine(item);
            //    vs.Push(item);
            //}


            //return 0;
            char[] str = s.ToCharArray();
            int i = 0;
            foreach (var item in str)
            {
                i++;
                if (vs.Count > 0 && item == vs.Peek())
                {
                    vs.Pop();
                    continue;
                }

                foreach (var bracle in BracleList)
                {
                    if (item == bracle.OppositeItem)
                    {
                        if(vs.Count<1 || bracle.OppositeItem!=vs.Peek())
                        return i-1;
                    }

                    if (bracle.Item==item)
                    {
                        vs.Push(bracle.OppositeItem);
                        continue;
                    }
                }
            }

            if (vs.Count!=0)
            {
                return i;
            }
            return -1;
        }

    }

    public class CheckPairItem 
    {
        public char Item { get; set; }
        public char OppositeItem { get; set; }
    }

}
