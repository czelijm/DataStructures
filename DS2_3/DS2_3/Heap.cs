using System;
using System.Collections.Generic;
using System.Text;

namespace DS2_3
{
    class Heap
    {
        public IComparable[] Array { get; set; }
        private int Length { get; set; }
        private int PowOf2 { get; set; }

        public Heap()
        {
            Length = 0;
            PowOf2 = 0;
            Array = new IComparable[(int)Math.Pow(2, PowOf2)];
        }

        public void Insert(IComparable v) 
        {
            if (Length>=(int)Math.Pow(2,PowOf2))
            {
                PowOf2++;
                IComparable[] tmpArray = new IComparable[Array.Length+(int)Math.Pow(2, PowOf2)];
                for (int i = 0; i < Length; i++)
                {
                    tmpArray[i] = Array[i];
                }

                Array = tmpArray;
            }

            Array[Length] = v;

            int rootIndex = GetParentIndex(Length);
            Length++;
            BubbleUp(Length-1, rootIndex);
            
        }

        private IComparable[] InsertItem(IComparable item)
        {
            return new IComparable[5];
        }

        private int GetParentIndex(int childsIndex)
        {
            return childsIndex==0?-1:(childsIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int rootIndex)
        {
            return (rootIndex*2)+1<Length?(rootIndex * 2) + 1: rootIndex;
        }
        private int GetRigthChildIndex(int rootIndex)
        {
            return (rootIndex*2)+2<Length? (rootIndex * 2) + 2:rootIndex;
        }

        private void BubbleUp(int childIndex, int rootIndex) 
        {
            if (GetParentIndex(childIndex) < 0 || childIndex==rootIndex)
            {
                return;
            }

            if (CanMakeUpdate(childIndex,rootIndex))
            {
                var tmpVal=Array[childIndex];
                Array[childIndex] = Array[rootIndex];
                Array[rootIndex] = tmpVal;
            }

            if (GetParentIndex(rootIndex) != -1)
                BubbleUp(rootIndex, GetParentIndex(rootIndex));
            //if(GetRigthChildIndex(childIndex)!= childIndex)
            //    BubbleUp(GetRigthChildIndex(childIndex),childIndex);
            //if (GetLeftChildIndex(childIndex) != childIndex)
            //    BubbleUp(GetLeftChildIndex(childIndex), childIndex);
        }

        private bool CanMakeUpdate(int childIndex, int rootIndex) 
        {
            return childIndex<Length && Array[childIndex].CompareTo(Array[rootIndex]) > 0;
        }



        private void BubbleDown(int childIndex, int rootIndex) 
        {
            if (GetLeftChildIndex(childIndex) >= Length || Array[GetLeftChildIndex(childIndex)] is null)
            {
                return;
            }

            if (Array[childIndex].CompareTo(Array[rootIndex]) > 0)
            {
                var tmpVal = Array[childIndex];
                Array[childIndex] = Array[rootIndex];
                Array[rootIndex] = tmpVal;
            }
            if (GetLeftChildIndex(childIndex) != childIndex)
                BubbleDown(GetLeftChildIndex(childIndex), childIndex);
            if (GetRigthChildIndex(childIndex) != childIndex)
                BubbleDown(GetRigthChildIndex(childIndex), childIndex);


        }

        public IComparable Remove() 
        {
            var result = Array[0];
            Array[0] = Array[Length - 1];
            Array[Length - 1] = null;
            BubbleDown(1,0);
            BubbleDown(2,0);
            Length--;
            return result;
        }



    }
}
