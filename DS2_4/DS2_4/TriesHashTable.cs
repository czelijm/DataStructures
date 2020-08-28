using System;
using System.Collections.Generic;
using System.Text;

namespace DS2_4
{
    class TriesHashTable
    {

        private Node Root { get; set; }


        public TriesHashTable()
        {
            Root = new Node();
        }

        private class Node
        {
            public char Value { get; set; }
            public Dictionary<char,Node> Children { get; set; }
            public bool IsEndOfWord { get; set; }

            public Node()
            {
                Children = new Dictionary<char, Node>();
            }

            public Node(char c)
            {
                Children = new Dictionary<char, Node>();
                Value = c;
            }

            public bool IsChildernExist(char child)
            {
                return Children.ContainsKey(child);
            }

            public void AddChild(char item)
            {
                Children.Add(item,new Node(item));
            }

            public int HowManyChildren()
            {
                return Children.Count;
            }

        }
        public void InsertLoopVersion(string word)
        {
            InsertHashTableLoopVersion(Root, word);
        }

        private void InsertHashTableLoopVersion(Node root, string word)
        {
            var array = word.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                var item = array[i];
                int index = CalculateIndexOfChild(item);
                if (!root.IsChildernExist(item))
                {
                    root.AddChild(item);
                }
                if (i == array.Length - 1)
                {
                    root.Children[item].IsEndOfWord = true;
                    break;
                }
                root = root.Children[item];
            }

        }

        private int CalculateIndexOfChild(char c)
        {
            return Char.ToLower(c) - 'a';
        }

        public bool Contains(string word)
        {
            if (word is null)
            {
                return false;
            }

            Node root = Root;
            var array = word.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                var item = array[i];
                if (!root.IsChildernExist(item))
                {
                    return false;
                }
                root = root.Children[item];
            }
            
            //if (!(root.IsChildernExist(array[array.Length-1]) && root.Children[array[array.Length - 1]].IsEndOfWord==true ))
            //{
            //    return false;
            //}

            return root.IsEndOfWord;
        }


        public void Delete(string word)
        {
            if (!Contains(word))
            {
                return;
            }
            
            Delete(Root, word);
        }

        private void Delete(Node root, string word)
        {
            //Insert(root.Children[CalculateIndexOfChild(characters[0])], word.Remove(0,1));
            if (word.Length==0)
            {
                root.IsEndOfWord = false;
                return;
            }

            var firstCharacter = word.ToCharArray()[0];
            Delete( root.Children[firstCharacter], word.Remove(0, 1));
            if (root.Children[firstCharacter].HowManyChildren() == 0 && root.Children[firstCharacter].IsEndOfWord==false)
            {
                root.Children.Remove(firstCharacter);
            }

        }

        public List<string> Autocompletion(string word)
        {
            List<string> result = new List<string>();
            //AutocompletionBackWords(Root, word,0,result);
            Autocompletion(Root, word, 0, result);
            return result;
        }

        private void AutocompletionBackWords(Node root, string word, int index, List<string> words)
        {
            
            if (root.IsEndOfWord)
            {
                words.Add(word.Substring(0,index));
            }
            var characters = word.ToCharArray();
            if (index == word.Length)
            {
                return;
            }
            
            if (!root.IsChildernExist(characters[index]))
            {
                return;
            }
           
            AutocompletionBackWords(root.Children[characters[index]], word, index+1, words);

        }

        private void Autocompletion(Node root, string word, int index, List<string> words) 
        {
            var characters = word.ToCharArray();
            if (index<word.Length)
            {
                if (!root.IsChildernExist(characters[index]))
                {
                    return;
                }
                Autocompletion(root.Children[characters[index]], word, index+1, words);

            }
            else
            {
                if (root.IsEndOfWord)
                {
                    words.Add(word.Substring(0, index));
                }

                if (root.Children.Count == 0)
                {
                    return;
                }

                foreach (var item in root.Children)
                {
                    Autocompletion(item.Value, word+item.Key, index + 1, words);
                }
            }
        }

    }
}
