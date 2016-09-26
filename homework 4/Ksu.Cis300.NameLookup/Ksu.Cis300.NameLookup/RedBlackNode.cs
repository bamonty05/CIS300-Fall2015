/* RedBlackNode.cs
 * Author: Jacob Dokos
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// Class for each node in a red black tree. Allows the program to fully traverse a tree by knowing the
    /// parent and all children
    /// </summary>
    /// <typeparam name="T">Generic type for input of any type of data</typeparam>
    public class RedBlackNode<T> : ITree, IColorizer
    {
        private T _data { get; set; }
        private RedBlackNode<T> _leftChild { get; set; }
        private RedBlackNode<T> _rightChild { get; set; }
        private RedBlackNode<T> _parent { get; set; }
        private bool _isBlack { get; set; }

        /// <summary>
        /// Data being held in the cell
        /// </summary>
        public T Data
        {
            get
            { 
                return _data; 
            }
            set 
            { 
                _data = value; 
            }
        }

        /// <summary>
        /// The nodes left child in the tree
        /// </summary>
        public RedBlackNode<T> LeftChild
        {
            get
            { 
                return _leftChild; 
            }
            set
            { 
                _leftChild = value;
            }
        }

        /// <summary>
        /// the nodes right child in the tree
        /// </summary>
        public RedBlackNode<T> RightChild
        {
            get
            { 
                return _rightChild;
            }
            set 
            { 
                _rightChild = value;
            }
        }

        /// <summary>
        /// the nodes parent in the tree, allows the traversal up the tree
        /// </summary>
        public RedBlackNode<T> Parent
        {
            get
            { 
                return _parent;
            }
            set
            { 
                _parent = value;
            }
        }

        /// <summary>
        /// determines if the node is black or red if it is true the the node is black
        /// </summary>
        public bool isBlack
        {
            get
            {
                return _isBlack; 
            }
            set
            {
                _isBlack = value;
            }
        }


        /// <summary>
        /// constructor for a redblacknode allows program to set all data (full constructor)
        /// </summary>
        /// <param name="data">data or name being held in the node</param>
        /// <param name="left">the nodes left child in the tree</param>
        /// <param name="right">the nodes right child in the tree</param>
        /// <param name="parent">the nodes parent (oppostie of child)</param>
        /// <param name="black">bool to determine if the red (false) or black (true)</param>
        public RedBlackNode(T data, RedBlackNode<T> left, RedBlackNode<T> right, RedBlackNode<T> parent, bool black)
        {
            _data = data;
            _leftChild = left;
            _rightChild = right;
            _parent = parent;
            _isBlack = black;
        } 


        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        public ITree[] Children
        {
            get
            {
                ITree[] children = new ITree[2];
                children[0] = _leftChild;
                children[1] = _rightChild;
                return children;
            }
        }

        /// <summary>
        /// Gets whether this node is empty. Because empty trees will be represented by
        /// null, it always returns false.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the object to be drawn as the contents of this node.
        /// </summary>
        public object Root
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// returns the color based on the bool held in the node. Allows the tree to draw itself with the correct color
        /// </summary>
        /// <param name="obj">generic object that needs to have it's color found</param>
        /// <returns></returns>
        public Color GetColor(object obj)
        {
            RedBlackNode<T> temp = (RedBlackNode<T>)obj;

            if (temp._isBlack)
            {
                return Color.Black;
            }
            else
            {
                return Color.Red;
            }
        }

        /// <summary>
        /// overrides the tostring method to instead display use the data's tostring method instead of one for the object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _data.ToString();
        }
    }
}
