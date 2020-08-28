using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DS3_1
{
    class SortingAlgorithms<T> where T:IComparable<T>
    {
        public static IList<T> BubbleSorting(IList<T> t)
        {
            for (int i = 0; i < t.Count-1; i++)
            {
                bool isSorted = true;
                for (int j = 1; j < t.Count - i; j++)
                {
                    if (t[j-1].CompareTo(t[j]) == 1)
                    {
                        //T tmpVar = t[j - 1];
                        //t[j - 1] = t[j];
                        //t[j] = tmpVar;
                        Swamp(ref t,j-1,j);
                        isSorted = false;
                    }
                }
                if (isSorted) return t;
                
            }

            return t;
        }

        public static IList<T> SelectionSorting(IList<T> t) 
        {
            for (int i = 0; i < t.Count; i++)
            {   
                for (int j = i; j < t.Count; j++)
                {
                    if (t[j].CompareTo(t[i])==-1)
                    {
                        Swamp(ref t,j,i);
                    }

                }
            }

                    return t;
        }


        public static IList<T> InsertionSorting(IList<T> t)
        {
            for (int i = 0; i < t.Count; i++)
            {
                var tmpVal = t[i];
                //bool isSorted = false;
                for (int j = i-1; j > -1; j--)
                {
                    if (t[j].CompareTo(tmpVal) == 1)
                    {
                        t[j+1] = t[j];
                    }
                    else 
                    {
                        t[j+1] = tmpVal;
                        break;
                    }
                }
            }

            return t;
        }


        public static IList<T> MergeSorting(IList<T> t) 
        {
            MergeSorting(ref t);

            return t;
        }

        private static void MergeSorting(ref IList<T> l) 
        {
            if (l.Count == 2 && l[0].CompareTo(l[1]) == 1)
            {
                Swamp(ref l,0,1);
            }

            if (l.Count<3)
            {
                return;
            }

            int lSplit = l.Count / 2;

            IList<T> lSplitted1 = l.AsEnumerable().Take(lSplit).ToArray();
            IList<T> lSplitted2 = l.AsEnumerable().Skip(lSplit).ToArray();

            MergeSorting(ref lSplitted1);
            MergeSorting(ref lSplitted2);

            int i = 0;
            int j = 0;

            T tmpVal1=default;
            T tmpVal2=default;

            while (i+j<l.Count)
            {
                if (i < lSplitted1.Count())
                {
                    tmpVal1 = lSplitted1[i];
                }
                if (j < lSplitted2.Count())
                {
                    tmpVal2 = lSplitted2[j];
                }

                if (i < lSplitted1.Count() && tmpVal1.CompareTo(tmpVal2)==-1 || j >= lSplitted2.Count())
                {
                    l[i + j] = tmpVal1;
                    i++;
                }
                else if(j < lSplitted2.Count())
                {
                    l[i + j] = tmpVal2;
                    j++;
                }
            }
        }

        public static IList<T> QuickSorting(IList<T> t)
        {
            QuickSorting(ref t);
            return t;
        }

        private static void QuickSorting(ref IList<T> t) 
        {
            //int i = 0;
            int b = -1;
            int pivot = t.Count - 1;

            for (int i = 0; i < t.Count; i++)
            {
                if (t[i].CompareTo(t[pivot])==-1) 
                {
                    b++;
                    Swamp(ref t, b, i);
                }
            }

            b++;
            if (t[b].CompareTo(t[pivot])==1)
            {
                Swamp(ref t, b, pivot);
            }

            if (t.Count < 3)
            {
                return;
            }


            IList<T> tTmp = t.Take(b).ToArray();
            IList<T> tTmp0 = null;
            if (b > -1)
            {
                tTmp0 = t.Skip(b).ToArray();
                QuickSorting(ref tTmp0);
            }

            QuickSorting(ref tTmp);           
            
            t = tTmp0 is null? tTmp.ToArray(): tTmp.Concat(tTmp0).ToArray();
        }

        public static IList<T> CountingSorting(IList<T> t)
        {
            dynamic maxValue = t.Max();

            IList<T> count = new T[maxValue+1];

            foreach (dynamic item in t)
            {
                count[item]++;
            }

            int lastPosition = 0;
            for (dynamic i = 0; i < count.Count; i++)
            {
                dynamic tmpVar = count[i];
                if (tmpVar.CompareTo(0)>0)
                {
                    for (int j = 0; j < tmpVar; j++)
                    {
                        t[lastPosition++] = (T)i;
                    }
                    
                }
            }
            return t;
        }

        public static IList<T> BucketSort(IList<T> t, int numberOfBuckets=3) 
        {
            dynamic maxValue = t.Max();
            int numberOfBucketsFactor = (maxValue / numberOfBuckets) +1;
            IList<T>[] buckets = new IList<T>[numberOfBuckets];

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<T>();
            }
            
            foreach (dynamic item in t)
            {
                int tmpVal = (int)item;
                int bucketIndex = tmpVal / numberOfBucketsFactor;
                buckets[bucketIndex].Add(item);
            }

            for (int i = 0; i <buckets.Length; i++)
            {
                QuickSorting( ref buckets[i]);
            }

            int index = 0;
            foreach (var list in buckets)
            {
                foreach (var item in list)
                {
                    t[index++] = item;
                }
            }

            return t;
        }

        private static void Swamp(ref IList<T> array, int index1, int index2) 
        {
            T tmpItem = array[index1];
            array[index1] = array[index2];
            array[index2] = tmpItem;
        }

    }//end of class SortingAlgorithms<T>
}
