using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS1_5
{
    public class HashTable
    {
        private class HashTableItem
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }

        private int Size { get; set; }

        private LinkedList<HashTableItem>[] ArrayOfLists;

        public HashTable()
        {
            Size = 7;
            ArrayOfLists = new LinkedList<HashTableItem>[Size];
        }

        public void Put(int k, string s) 
        {
            int hashValue = HashValue(k);
            if (ArrayOfLists[hashValue] == null) 
            {
                ArrayOfLists[hashValue] = new LinkedList<HashTableItem>();
            }
            var result = ArrayOfLists[hashValue].FirstOrDefault(i => i.Key == k);
            if (result==null)
            {
                ArrayOfLists[hashValue].AddLast(new HashTableItem { Key = k, Value = s });
            }
            else 
            {
                result.Value = s;
            }
        }

        public string Get(int k) 
        {
            int hashValue = HashValue(k);
            var result = ArrayOfLists[hashValue].FirstOrDefault(i=> i.Key == k);

            return result==null? null : result.Value;
        }

        public void Remove(int k) 
        {
            int hashValue = HashValue(k);
            var result = ArrayOfLists[hashValue].FirstOrDefault(i => i.Key == k);
            if (result == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                ArrayOfLists[hashValue].Remove(result);
            }

        }

        private int HashValue(int k) {return k % Size; }

        private LinkedList<HashTableItem> getBucket(int index) 
        {
            return ArrayOfLists[HashValue(index)];
        }

     
    }


}
