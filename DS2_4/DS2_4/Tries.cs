using System;
using System.Collections.Generic;
using System.Text;

namespace DS2_4
{
    class Tries
    {
        private Node Root { get; set; }


        public Tries()
        {
            Root = new Node();
        }

        private class Node
        {
            public char Value { get; set; }
            public Node[] Children { get; set; }
            public bool IsEndOfWord { get; set; }

            public Node()
            {
                Children = new Node[26];
            }

            public Node(char c) 
            {
                Children = new Node[26];
                Value = c;
            }

        }

        public void Insert(string word)
        {
            Insert(Root, word);
        }

        private void Insert(Node root, string word)
        {
            if (word.Length==0)
            {
                root.IsEndOfWord = true;
                return;
            }
            if (root is null)
            {
                root = new Node();
            }

            var characters = word.ToCharArray();

            if (!IsChildernExist(root, characters[0]))
            {
                root.Children[CalculateIndexOfChild(characters[0])] = new Node(characters[0]);
            }

            Insert(root.Children[CalculateIndexOfChild(characters[0])], word.Remove(0,1));
        }

        public void InsertLoopVersion(string word)
        {
            InsertLoopVersion(Root, word);
        }

        private void InsertLoopVersion(Node root, string word)
        {
            //var last = word.ToCharArray()[word.Length - 1];
            var array = word.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                var item = array[i];
                int index = CalculateIndexOfChild(item);
                if (!IsChildernExist(root, item))
                {
                    root.Children[index] = new Node(item);
                }
                if (i == array.Length - 1)
                {
                    root.Children[index].IsEndOfWord = true;
                    break;
                }
                root = root.Children[index];
            }
        }



        private int CalculateIndexOfChild(char c)
        {
            return Char.ToLower(c) - 'a';
        }

        private bool IsChildernExist(Node root, char child)
        {
            return !(root.Children[CalculateIndexOfChild(child)] is null);
        }
    }


}
