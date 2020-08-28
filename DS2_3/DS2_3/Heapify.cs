using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Linq;

namespace DS2_3
{
    class Heapify
    {
        public static Object[] heapify(Object[] a)
        {

            //var a = Array.ConvertAll(arr, item => (IComparable[])item);

            var tmpArray = new IComparable[a.Length];


            for (int i = 0; i < a.Length; i++)
            {
                tmpArray[i] = (IComparable)a[i];
                int parentIndex = GetParentIndex(i);
                while (parentIndex>=0)
                {
                    if (tmpArray[i].CompareTo(tmpArray[parentIndex]) > 0)
                    {
                        var tmpVar = tmpArray[i];
                        tmpArray[i] = tmpArray[parentIndex];
                        tmpArray[parentIndex] = tmpVar;
                        parentIndex = GetParentIndex(parentIndex);
                    }
                    else 
                    {
                        break;
                    }
                    
                }



            }

            return tmpArray;
        }

        private static int GetParentIndex(int childsIndex)
        {
            return childsIndex == 0 ? -1 : (childsIndex - 1) / 2;
        }
        private static void swap(IComparable item1, IComparable item2) 
        {
            var tmpVar = item1;
            item1 = item2;
            item2 = tmpVar;
        }

        public static Object FindKthMaxValue(Object[] a, int k) 
        {
            //k in 1 to infinity 
            //num of row  : (int)log2(k) ,in 0 to infinity
            //ammount of numbers in row : 2^numberOfRow
            //index of first number in row : 2^(NumberOfRow)-1
            //index of last number in row  : 2^(NumberOfRow+1)-2  
            if (k==1)
            {
                return a[0];
            }
            int numberOfRow = (int)Math.Log2(k);
            int startIndex = (int)Math.Pow(2, numberOfRow)-1;
            int endIndex = (int)Math.Pow(2, numberOfRow+1)-2;//(int)Math.Pow(2, (int)Math.Log2(k) + 1);

            var result = a.Skip(startIndex).Take((int)Math.Pow(2, numberOfRow)).Max();


            return result;
        }

        public static Object FindKthMaxValueOldSchool(Object[] a, int k)
        {
            Heap h = new Heap();
            foreach (var item in a)
            {
                h.Insert((IComparable)item);
            }

            

            for (int i = 0; i < k-1; i++)
            {
                h.Remove();
            }

            return h.Remove();
        }

    }
}
