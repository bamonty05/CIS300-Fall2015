/* UserInterface.cs
 * Author: Jacob Dokos
 * Code: 00 91 82 96
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ksu.Cis300.Sort;
using KansasStateUniversity.TreeViewer2;
using Ksu.Cis300.ImmutableBinaryTrees;

namespace Ksu.Cis300.HuffmanTree
{
    /// <summary>
    /// A GUI for a program to construct and display Huffman trees.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Click event on the "Select a File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectFile_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryTreeNode<byte> t = null;
                    t = makeTree(makeLeaves(buildFrequency(uxOpenDialog.FileName)));
                    // Add code to build the Huffman tree and assign it to t.

                    new TreeForm(t, 100).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private long[] buildFrequency(string filename)
        {
            int k = 0;
            long[] size = new long[256];
            //FileStream input = new FileStream(filename, FileMode.Open);
            using (FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                while ((k = input.ReadByte()) != -1)
                {
                    byte b = (byte) k;
                    size[b]++;
                }
            }
            return size;    
        }

        private MinPriorityQueue<long, BinaryTreeNode<byte>> makeLeaves(long[] size)
        {
            MinPriorityQueue<long, BinaryTreeNode<byte>> min = new MinPriorityQueue<long, BinaryTreeNode<byte>>();

            for (int i = 0; i < size.Length; i ++)
            {
                if (size[i] != 0)
                {
                    BinaryTreeNode<byte> temp = new BinaryTreeNode<byte>((byte) i, null, null);
                    min.Add(temp, size[i]);
                }
            }
            return min;
        }

        private BinaryTreeNode<byte> makeTree(MinPriorityQueue<long, BinaryTreeNode<byte>> min)
        {
            while (min.Count > 1)
            {
                long min1 = min.MininumPriority;
                BinaryTreeNode<byte> temp1 = min.RemoveMinimumPriority();
                long min2 = min.MininumPriority;
                BinaryTreeNode<byte> temp2 = min.RemoveMinimumPriority();
                BinaryTreeNode<byte> root = new BinaryTreeNode<byte>(0, temp1, temp2);
                min.Add(root, (min1 + min2));
            }
            return min.RemoveMinimumPriority();
        }
    }
}
