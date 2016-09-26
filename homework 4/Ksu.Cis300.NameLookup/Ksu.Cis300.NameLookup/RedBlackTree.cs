/* RedBlackTree.cs
 * Author: Jacob Dokos
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// Class to hold the tree to display and hold the redblack tree for the user
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RedBlackTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// root of the redblack tree
        /// </summary>
        private RedBlackNode<T> _root = null;

        /// <summary>
        /// Enables the user to find a node based on the user input, 'val'
        /// </summary>
        /// <param name="val">value that the program is looking for in the tree</param>
        /// <returns></returns>
        public T Find(T val)
        {
            RedBlackNode<T> temp = _root;

            while (temp != null)
            {
                if (temp.Data.CompareTo(val) == 0)
                {
                    return temp.Data;
                }
                else if (temp.Data.CompareTo(val) > 0)
                {
                    temp = temp.RightChild;
                }
                else
                {
                    temp = temp.LeftChild;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Fixes the tree so that it is equal and the colors are right
        /// </summary>
        /// <param name="node">the node for the colors to be fixed (if needed)</param>
        private void FixColors(RedBlackNode<T> node)
        {
            while (node != _root && !node.Parent.isBlack) //while red
            {
                //finding uncle location
                RedBlackNode<T> parent = node.Parent;
                RedBlackNode<T> uncle = null;

                if (node.Parent == null)
                {

                }

                if (node.Parent == node.Parent.Parent.LeftChild)
                {
                    uncle = node.Parent.Parent.RightChild;
                }
                else
                {
                    uncle = node.Parent.Parent.LeftChild;
                }

                if (uncle == null)
                {
                    return;
                }
           

                //uncle is red also check parent
                if (!uncle.isBlack) 
                {
                    node.Parent.isBlack = true;
                    uncle.isBlack = true;
                    node.Parent.Parent.isBlack = false;
                    node = node.Parent.Parent;
                }
                if (uncle.isBlack)
                {
                    RotateRight(node);

                    if (node.Parent.LeftChild == node && node.Parent.Parent.LeftChild == node.Parent) //a
                    {
                        RotateRight(node);
                    }
                    if (node.Parent.RightChild == node && node.Parent.Parent.RightChild == node.Parent) //b
                    {
                        RotateLeft(node);
                    }
                    if (node.Parent.RightChild == node && node.Parent.Parent.LeftChild == node.Parent) //c
                    {
                        RotateLeft(node);
                        RotateRight(node.Parent);
                    }
                    if (node.Parent.LeftChild == node && node.Parent.Parent.RightChild == node.Parent) //d
                    {
                        RotateRight(node.Parent);
                        RotateLeft(node.Parent);
                    }
                }
            }
        }

        /// <summary>
        /// rotates the node to the right based on the inputted node
        /// </summary>
        /// <param name="node">child of the tree that needs to be rotated to be equal on both sides</param>
        private void RotateRight(RedBlackNode<T> node)
        {
            RedBlackNode<T> temp = node.LeftChild;
            node.LeftChild = temp.RightChild;
            if (temp.RightChild != null)
            {
                temp.RightChild.Parent = node;
            }
            if (temp != null)
            {
                temp.Parent = node.Parent;
            }
            if (node.Parent == null)
            {
                _root = temp;
            }
            if (node == node.Parent.RightChild)
            {
                node.Parent.RightChild = temp;
            }
            if (node == node.Parent.LeftChild)
            {
                node.Parent.LeftChild = temp;
            }

            temp.RightChild = node;
            if (node != null)
            {
                node.Parent = temp;
            }
        }

        /// <summary>
        /// rotates the node to the left based on the inputted node
        /// </summary>
        /// <param name="node">child of the tree that needs to be rotated to be equal on both sides</param>
        private void RotateLeft(RedBlackNode<T> node)
        {
            RedBlackNode<T> temp = node.RightChild;
            node.RightChild = temp.LeftChild;
            if (temp.LeftChild != null)
            {
                temp.LeftChild.Parent = node;
            }
            if (temp != null)
            {
                temp.Parent = node.Parent;
            }
            if (node.Parent == null)
            {
                _root = temp;
            }
            if (node == node.Parent.LeftChild)
            {
                node.Parent.LeftChild = temp;
            }
            else
            {
                node.Parent.RightChild = temp;
            }
            temp.LeftChild = node;
            if (node != null)
            {
                node.Parent = temp;
            }
        }

        /// <summary>
        /// Gives the program the ability to add nodes on the tree in the right position
        /// </summary>
        /// <param name="val">value of the node to be added</param>
        public void Add(T val)
        {
            //declaring variables for use in the method
            RedBlackNode<T> node = new RedBlackNode<T>(val, null, null, null, false);
            RedBlackNode<T> temp = _root;
            RedBlackNode<T> newNode = null;

            if (_root == null)
            {
                _root = node;
            }
            else
            {
                while (temp != null)
                {
                    if (temp.Data.CompareTo(val) > 0)
                    {
                        if (temp.LeftChild == null)
                        {
                            temp.LeftChild = node;
                            node.Parent = temp;
                            newNode = temp.LeftChild;
                            break;
                        }
                        else
                        {
                            temp = temp.LeftChild;
                        }
                    }
                    else
                    {
                        if (temp.RightChild == null)
                        {
                            temp.RightChild = node;
                            node.Parent = temp;
                            newNode = temp.RightChild;
                            break;
                        }
                        else
                        {
                            temp = temp.LeftChild;
                        }       
                    }
                }
                FixColors(newNode);
            }
        }

        /// <summary>
        /// Draws the tree for the user
        /// </summary>
        public void DrawTree()
        {
            new TreeForm(_root, 100, _root).Show();
        }
    }
}
