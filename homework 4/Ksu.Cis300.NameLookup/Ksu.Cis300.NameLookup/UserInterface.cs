/* UserInterface.cs
 * Author: Rod Howell and Jacob Dokos
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
        private RedBlackTree<NameInformation> _names = new RedBlackTree<NameInformation>();

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
                    _names.DrawTree();
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
            NameInformation temp = _names.Find(new NameInformation(uxName.Text.Trim().ToUpper(), 0, 0));

            if (temp.Name == null)
            {
                MessageBox.Show("Name not found.");
                uxRank.Text = "";
                uxFrequency.Text = "";
            }
            else
            {
                uxFrequency.Text = temp.Frequency.ToString();
                uxRank.Text = temp.Rank.ToString();
                return;
            }
        }

        /// <summary>
        /// Reads the given file and forms a binary search tree from its contents.
        /// </summary>
        /// <param name="fn">The name of the file.</param>
        /// <returns>The binary search tree containing all the name information.</returns>
        private RedBlackTree<NameInformation> GetAllInformation(string fn)
        {
            RedBlackTree<NameInformation> names = new RedBlackTree<NameInformation>();
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim().ToUpper();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    names.Add(new NameInformation(name, freq, rank));
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
            if (t == null)
            {
                return new NameInformation();
            }
            else
            {
                int comp = name.CompareTo(t.Data.Name);
                if (comp == 0)
                {
                    return t.Data;
                }
                else if (comp < 0)
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
        /// Allows the user to add another person to the tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = uxName.Text.Trim();
                float freq = Convert.ToSingle(uxFrequency.Text.Trim());
                int rank = Convert.ToInt32(uxRank.Text.Trim());
                _names.Add(new NameInformation(name, freq, rank));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter all the required information before pressing the 'Add' button");
            }
            _names.DrawTree();
        }
    }
}
