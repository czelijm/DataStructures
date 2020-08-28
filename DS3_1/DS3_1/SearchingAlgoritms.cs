using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace DS3_1
{
    class SearchingAlgoritms<T> where T : IComparable<T>
    {
        public static int LinearSearch(IList<T> tList, T t)
        {
            int i = 0;
            for (i = 0; i < tList.Count; i++)
            {
                if (tList[i].CompareTo(t) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int BiniarySearchIterativeWithSorting(ref T[] tList, T t)
        {
            tList = (T[])SortingAlgorithms<T>.QuickSorting(tList);
            int start = 0;
            int end = tList.Length - 1;
            while (end >= start)
            {
                int middle = (start + end) / 2;
                int compare = tList[middle].CompareTo(t);
                if (compare == 0) return middle;
                if (compare > 0)
                {
                    end = middle - 1;
                    continue;
                }
                if (compare < 0)
                {
                    start = middle + 1;
                    continue;
                }
            }
            return -1;
        }

        public static int BiniarySearchRecursionWithSorting(ref T[] tList, T t)
        {
            tList = (T[])SortingAlgorithms<T>.QuickSorting(tList);
            return BiniarySearchRecursionPrivate(tList, t);
        }

        private static int BiniarySearchRecursionPrivate(T[] tList, T t)
        {
            int start = 0;
            int end = tList.Length - 1;
            int middle = (start + end) / 2;
            if (tList.Length == 0)
            {
                return -1;
            }
            int compare = tList[middle].CompareTo(t);
            if (compare == 0) return middle;


            if (compare > 0)
            {
                return BiniarySearchRecursionPrivate(tList.Take(middle).ToArray(), t);
            }
            else if (compare < 0)
            {
                return BiniarySearchRecursionPrivate(tList.Skip(middle + 1).ToArray(), t) + middle + 1;
            }

            return -1;
        }


        public static int TenarySearchRecursionWithSorting(T[] tList, T t)
        {
            T[] array = (T[])SortingAlgorithms<T>.QuickSorting(tList);
            return TenarySearchRecursionPrivate(array, t, 0, tList.Length - 1);
        }

        private static int TenarySearchRecursionPrivate(T[] tList, T t, int left, int right)
        {
            if (left > right) return -1;

            int result = -1;

            int partitionSize = (right - left) / 3;
            int mid1 = left + partitionSize;
            int mid2 = right - partitionSize;

            int comparision1 = t.CompareTo(tList[mid1]);
            int comparision2 = t.CompareTo(tList[mid2]);
            if (comparision1 == 0) return mid1;
            if (comparision2 == 0) return mid2;
            if (comparision1 < 0)
            {
                result = TenarySearchRecursionPrivate(tList, t, left, mid1 - 1);
            }
            if (comparision2 > 0)
            {
                result = TenarySearchRecursionPrivate(tList, t, mid2 + 1, right);
            }
            if (comparision1 > 0 && comparision2 < 0)
            {
                result = TenarySearchRecursionPrivate(tList, t, mid1 + 1, mid2 - 1);
            }

            return result;
        }



        public static int TenarySearchIterativeWithSorting(T[] tList, T t)
        {
            T[] array = (T[])SortingAlgorithms<T>.QuickSorting(tList);

            int left = 0;
            int right = tList.Length;

            while (!(left > right))
            {
                int partitionSize = (right - left) / 3;
                int mid1 = left + partitionSize;
                int mid2 = right - partitionSize;

                int comparision1 = t.CompareTo(tList[mid1]);
                int comparision2 = t.CompareTo(tList[mid2]);
                if (comparision1 == 0) return mid1;
                if (comparision2 == 0) return mid2;
                if (comparision1 < 0)
                {
                    right = mid1 - 1;
                    continue;
                }
                if (comparision2 > 0)
                {
                    left = mid2 + 1;
                    continue;
                }
                if (comparision1 > 0 && comparision2 < 0)
                {
                    left = mid1 + 1;
                    right = mid2 - 1;
                }
            }
            return -1;
        }

        public static int JumpSearchWithSorting(T[] tList, T t)
        {
            T[] array = (T[])SortingAlgorithms<T>.QuickSorting(tList);

            int blockSize = (int)Math.Sqrt(tList.Length);
            int start = 0;
            int next = start + blockSize;

            while (start < array.Length && tList[next - 1].CompareTo(t) < 0)
            {
                start = next;
                next += blockSize;
                if (next > array.Length - 1)
                {
                    next = array.Length;
                }
            }
            T[] ar = array.Skip(start).Take(blockSize).ToArray();
            var result = LinearSearch(ar, t);

            return result == -1 ? result : result + start;
        }

        public static int ExponentialSearchWithSorting(T[] tList, T t)
        {
            T[] array = (T[])SortingAlgorithms<T>.QuickSorting(tList);

            int i = 1;
            while (i < array.Length && array[i].CompareTo(t) == -1)
            {
                if (i == array.Length - 1) return -1;
                i *= 2;
                //i = i > array.Length - 1 ? array.Length - 1 : i;
                if (i > array.Length-1) i = array.Length-1;
            }

            var result = LinearSearch(array.Skip(i / 2).Take((i / 2)+1).ToArray(), t);

            return result == -1 ? result : result + (i / 2);
        }
    }
}
