/* UserInterface.cs
 * Author: Jacob Dokos
 * Completion Code: 06 03 68 91
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

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// A GUI for a program that retrieves information about last names in
    /// a sample of US data.
    /// </summary>
    public partial class UserInterface : Form
    {
        private LinkedListCell<NameInformation> _listName = null;

        private LinkedListCell<NameInformation> parseFileToList(string filename)
        {
            LinkedListCell<NameInformation> front = null;

            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    LinkedListCell<NameInformation> temp = new LinkedListCell<NameInformation>();
                    string name = sr.ReadLine();
                    name = name.Trim();
                    float frequency = Convert.ToSingle(sr.ReadLine());
                    int rank = Convert.ToInt32(sr.ReadLine());

                    NameInformation nametemp = new NameInformation(name, frequency, rank);
                    temp.Data = nametemp;

                    temp.Next = front;
                    front = temp;
                }
            }

            return front;

        }
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
            try
            {
                uxOpenDialog.ShowDialog();
                _listName = parseFileToList(uxOpenDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Handles a Click event on the Get Statistics button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            bool found = false;
            string name = uxName.Text.Trim();
            name = name.ToUpper();
            LinkedListCell<NameInformation> temp = _listName;
            try
            {
                do
                {
                    if (temp.Data.Name == name)
                    {
                        found = true;
                    }
                    else
                    {
                        temp = temp.Next;
                    }
                } while (!found || temp == null);
                //MessageBox.Show("DONE WITH LOOP");

                if (temp != null)
                {
                    uxFrequency.Text = temp.Data.Frequency.ToString();
                    uxRank.Text = temp.Data.Rank.ToString();
                }
                else
                {
                    MessageBox.Show("Name not found.");
                    uxFrequency.Text = "";
                    uxRank.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Name not found. - Exception");
                uxFrequency.Text = "";
                uxRank.Text = "";
            }
        }
    }
}
