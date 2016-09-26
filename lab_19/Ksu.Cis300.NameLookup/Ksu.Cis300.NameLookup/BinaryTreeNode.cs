/* BinaryTreeNode.cs
 * Author: Jacob dokos
 * code: 86 11 91 20*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.ImmutableBinaryTrees
{
    /// <summary>
    /// An immutable generic binary tree node that can draw itself.
    /// </summary>
    /// <typeparam name="T">The type of the elements stored in the tree.</typeparam>
    public class BinaryTreeNode<T> : ITree
    {
        /// <summary>
        /// The data stored in this node.
        /// </summary>
        private T _data;
        private int _treeHeight;

        /// <summary>
        /// Gets the data stored in this node.
        /// </summary>
        public T Data
        {
            get
            {
                return _data;
            }
        }

        /// <summary>
        /// This nodes left child.
        /// </summary>
        private BinaryTreeNode<T> _leftChild;

        /// <summary>
        /// Gets this node's left child.
        /// </summary>
        public BinaryTreeNode<T> LeftChild
        {
            get
            {
                return _leftChild;
            }
        }

        /// <summary>
        /// This node's right child.
        /// </summary>
        private BinaryTreeNode<T> _rightChild;

        /// <summary>
        /// Gets this node's right child.
        /// </summary>
        public BinaryTreeNode<T> RightChild
        {
            get
            {
                return _rightChild;
            }
        }

        /// <summary>
        /// Constructs a BinaryTreeNode with the given data, left child, and right child.
        /// </summary>
        /// <param name="data">The data stored in the node.</param>
        /// <param name="left">The left child.</param>
        /// <param name="right">The right child.</param>
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            _data = data;
            _leftChild = left;
            _rightChild = right;
            //height
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
                return _data; 
            }
        }

        public static int Height(BinaryTreeNode<T> t)
        {
            if (t == null)
            {
                return -1;
            }
            else 
            {
                return t.height;
            }
        }

        public static BinaryTreeNode<T> singleRotateRight (T root, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            BinaryTreeNode<T> newRight = new BinaryTreeNode<T>(root, left.RightChild, right);
            return new BinaryTreeNode<T>(left.Data, left.LeftChild, newRight);
        }

        public static BinaryTreeNode<T> singleRotateLeft (T root, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            BinaryTreeNode<T> newLeft = new BinaryTreeNode<T>(root, left.LeftChild, left);
            return new BinaryTreeNode<T>(right.Data, newleft, right.rightChild);
        }

        public static BinaryTreeNode<T> doubleRotateRight (T root, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            T root = left.rightChild.Data;
            BinaryTreeNode<T> newLeft = new BinaryTreeNode<T>(left.Data, left.leftChild, left.RightChild.LeftChild);
            BinaryTreeNode<T> newRight = new BinaryTreeNode<T>(,left.RightChild.RightChild, right); //need to finish
        }

        public static BinaryTreeNode<T> doubleRotateLeft (T root, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {

        }
    }
}
