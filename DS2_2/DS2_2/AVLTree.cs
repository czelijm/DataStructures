using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace DS2_2
{
    public class AVLTree
    {
        private class AVLNode
        {
            public AVLNode LeftChild { get; set; }
            public AVLNode RigthChild { get; set; }
            public Object Value { get; set; }
            public int Height { get; set; }
        }

        private AVLNode Root { get; set; }

        public AVLTree()
        {
            //Root = new AVLNode();
        }
        private int HeightOfNode(AVLNode n)
        {
            return n is null ? -1 : n.Height;
        }

        public void Insert(IComparable v)
        {
            var tmpVal = Root;
            tmpVal = Insert(ref tmpVal, v);
            Root = tmpVal;
        }
        private AVLNode Insert(ref AVLNode n, IComparable v)
        {
            if (n is null)
            {
                AVLNode aVLNode = new AVLNode() { Value = v };
                aVLNode.Height = 0;
                n = aVLNode;
                return n;
            }
            //if (n.LeftChild is null && n.RigthChild is null)
            //{
            //    n.Value = v;
            //    return;
            //}
            if (v.CompareTo((IComparable)n.Value) > 0)
            {
                var tmpVal = n.RigthChild;
                Insert(ref tmpVal, v);
                n.RigthChild = tmpVal;
            }
            else
            {
                var tmpVal = n.LeftChild;
                Insert(ref tmpVal, v);
                n.LeftChild = tmpVal;
            }
            var tmpVarL = HeightOfNode(n.LeftChild);
            var tmpVarR = HeightOfNode(n.RigthChild);

            n.Height = Math.Max(tmpVarL, tmpVarR) + 1;

            n = Balance(n);
            //Console.WriteLine(balancedFactor);
            return n;
        }

        private AVLNode Balance(AVLNode n)
        {
            //var balancedFactor = CalculateBalancedFactor(n);
            if (IsLeftHeavy(n))
            {
                if (CalculateBalancedFactor(n.LeftChild) < 0)
                {
                    //Console.WriteLine("Left rotation of " + n.LeftChild.Value);
                    n = RotateLeft(n);
                }
                n = RotateRigth(n);
                //Console.WriteLine("Right rotation of " + n.Value);

                Console.WriteLine("Is left heavy");
            }
            else if (IsRigthHeavy(n))
            {
                if (CalculateBalancedFactor(n.RigthChild) > 0)
                {
                    //Console.WriteLine("Right rotation of " + n.RigthChild.Value);
                    n = RotateRigth(n);
                }
                //Console.WriteLine("Left rotation of " + n.Value);
                n = RotateLeft(n);
                Console.WriteLine("Is right heavy");
            }
            Console.WriteLine(IsRigthHeavy(n));
            Console.WriteLine(IsLeftHeavy(n));
            Console.WriteLine(CalculateBalancedFactor(n));
            return n;
        }

        private int CalculateBalancedFactor(AVLNode n)
        {
            return n is null ? 0 : HeightOfNode(n.LeftChild) - HeightOfNode(n.RigthChild);
        }

        private bool IsRigthHeavy(AVLNode n)
        {
            return CalculateBalancedFactor(n) < -1 ? true : false;
        }
        private bool IsLeftHeavy(AVLNode n)
        {
            return CalculateBalancedFactor(n) > 1 ? true : false;
        }
        private int CalulateHeigthOfNode(AVLNode n) 
        {
            var tmpVarL = HeightOfNode(n.LeftChild);
            var tmpVarR = HeightOfNode(n.RigthChild);
            return Math.Max(tmpVarL, tmpVarR) + 1;
        }

        private AVLNode RotateLeft(AVLNode n)
        {
            var tmpNode = n;
            n = n.RigthChild;
            tmpNode.RigthChild = n.LeftChild;
            n.LeftChild = tmpNode;
            n.LeftChild.Height = 0;
            return n;
            //return n;
        }

        private AVLNode RotateRigth(AVLNode n)
        {
            var tmpNode = n;
            if (!(n.LeftChild is null) && !(n.LeftChild.RigthChild is null))
            {
                n.LeftChild.RigthChild.LeftChild = n.LeftChild;
                n.LeftChild = n.LeftChild.RigthChild;
                n.LeftChild.LeftChild.RigthChild = null;
                //n.LeftChild.LeftChild.Height = 0;
                n.LeftChild.LeftChild.Height = CalulateHeigthOfNode(n.LeftChild.LeftChild);
                n.LeftChild.Height = CalulateHeigthOfNode(n.LeftChild);

            }
            else if (!(n.RigthChild is null) && !(n.RigthChild.LeftChild is null))
            {
                n.RigthChild.LeftChild.RigthChild = n.RigthChild;
                n.RigthChild = n.RigthChild.LeftChild;
                n.RigthChild.RigthChild.LeftChild = null;
                n.RigthChild.RigthChild.Height = CalulateHeigthOfNode(n.RigthChild.RigthChild);
                n.RigthChild.Height = CalulateHeigthOfNode(n.RigthChild);
            }
            
            //n = n.LeftChild;
            //tmpNode.LeftChild = n.RigthChild;
            //n.RigthChild = tmpNode;
            //n.RigthChild.Height = 0;
            return n;
        }
    }
}
