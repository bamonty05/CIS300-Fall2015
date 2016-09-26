/* UserInterface.cs
 * Author: Jacob Dokos
 * Code: 05 17 21 44
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
using Ksu.Cis300.ImmutableBinaryTrees;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// A GUI for a program that retrieves information about last names in
    /// a sample of US data.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The information on all the names.
        /// </summary>
        private BinaryTreeNode<NameInformation> _names = null;

        /// <summary>
        /// Constructs a new GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Click event on the Open Data File button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _names = GetAllInformation(uxOpenDialog.FileName);
                    new TreeForm(_names, 100).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the Get Statistics button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            NameInformation info = GetInformation(name, _names);
            if (info.Name == null)
            {
                MessageBox.Show("Name not found.");
                uxRank.Text = "";
                uxFrequency.Text = "";
            }
            else
            {
                uxFrequency.Text = info.Frequency.ToString();
                uxRank.Text = info.Rank.ToString();
                return;
            }
        }

        /// <summary>
        /// Reads the given file and forms a binary search tree from its contents.
        /// </summary>
        /// <param name="fn">The name of the file.</param>
        /// <returns>The binary search tree containing all the name information.</returns>
        private BinaryTreeNode<NameInformation> GetAllInformation(string fn)
        {
            BinaryTreeNode<NameInformation> names = null;
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    names = Add(new NameInformation(name, freq, rank), names);
                }
            }
            return names;
        }

        /// <summary>
        /// Gets the information associated with the given name in the given binary search tree.
        /// If the given name is not in the tree, returns a NameInformation with a null name.
        /// </summary>
        /// <param name="name">The name to look for.</param>
        /// <param name="t">The binary search tree to look in.</param>
        /// <returns>The NameInformation containing the given name, or a NameInformation with a null name
        /// if the tree does not contain the name.</returns>
        private NameInformation GetInformation(string name, BinaryTreeNode<NameInformation> t)
        {
            //throw new NotImplementedException();

            if (t == null)
            {
                return new NameInformation();
            }
            else if (t.Data.Name == name)
            {
                return t.Data;
            }
            else
            {
                if (name.CompareTo(t.Data.Name) < 0)
                {
                    return GetInformation(name, t.LeftChild);
                }
                else
                {
                    return GetInformation(name, t.RightChild);
                }
            }
        }

        /// <summary>
        /// Builds the binary search tree that results from adding the given NameInformation to the given tree.
        /// </summary>
        /// <param name="info">The data to add to the tree.</param>
        /// <param name="t">The binary search tree to which the data will be added.</param>
        /// <returns>The resulting tree.</returns>
        private BinaryTreeNode<NameInformation> Add(NameInformation nameInformation, BinaryTreeNode<NameInformation> t)
        {
            //throw new NotImplementedException();

            if (t == null)
            {
                return new BinaryTreeNode<NameInformation>(nameInformation, null, null);
            }
            else if (t.Data.Name == nameInformation.Name)
            {
                throw new Exception();
            }
            else if (nameInformation.Name.CompareTo(t.Data.Name) < 0)
            {
                BinaryTreeNode<NameInformation> newLeft = Add(nameInformation, t.LeftChild);
                return new BinaryTreeNode<NameInformation>(t.Data, newLeft, t.RightChild);
            }
            else //if (nameInformation.Name.CompareTo(t.Data.Name) > 0)
            {
                BinaryTreeNode<NameInformation> newRight = Add(nameInformation, t.RightChild);
                return new BinaryTreeNode<NameInformation>(t.Data, t.LeftChild, newRight);
            }
        }
    }
}
