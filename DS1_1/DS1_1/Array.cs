using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DS1_1
{
    class Array<T>
    {
        private T[] Arr = null;
        public int Length { get; private set; }

        public Array() 
        {
            this.Length = 0;
        }
        
        public Array(int length) 
        {
            this.Length = length;
            this.Arr = new T[length];
        }

        public void Add(T t) 
        {

            this.Length++;
            T[] ArrTmp = new T[this.Length];
            if(this.Length>1)
                for (int i = 0; i < Arr.Length; i++)
                {
                    ArrTmp[i] = this.Arr[i];
                }
            ArrTmp[this.Length - 1] = t;
            this.Arr = ArrTmp;
        }

        public void RemoveAt(int index) 
        {
            if (index>=this.Length) { return; }
            this.Length--;
            T[] ArrTmp = new T[this.Length];
            for (int i = 0; i < index; i++)
            {
                ArrTmp[i] = this.Arr[i]; 
            }
            for (int i = index+1; i < this.Length+1; i++)
            {
                ArrTmp[i-1] = this.Arr[i];
            }
            this.Arr = ArrTmp;
        }

        public int IndexOf(T value) 
        {
            int i;
            for (i=0; i < this.Length; i++)
            {
                if (value.Equals(this.Arr[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void print() 
        {
            foreach (var item in this.Arr)
            {
                Console.WriteLine(item);
            }
        }

    }
}
