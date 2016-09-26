/* UserInterface.cs
 * Author: Rod Howell and Jacob Dokos
 * Code: 48 66 12 97
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

namespace Ksu.Cis300.Sort
{
    /// <summary>
    /// A GUI for a simple sorting program.
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
        /// Handles a Click event on the "Sort File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSort_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK && uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                List<int> values = new List<int>();
                try
                {
                    using (StreamReader input = new StreamReader(uxOpenDialog.FileName))
                    {
                        while (!input.EndOfStream)
                        {
                            int value = Convert.ToInt32(input.ReadLine());
                            values.Add(value);
                        }
                    }
                    Sort(values);
                    using (StreamWriter output = new StreamWriter(uxSaveDialog.FileName))
                    {
                        foreach (int i in values)
                        {
                            output.WriteLine("{0,10:D}", i);
                        }
                    }
                    MessageBox.Show("Sorting complete.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.ToString());
                }
            }
        }

        /// <summary>
        /// Swaps the values at the given locations in the given IList.
        /// </summary>
        /// <param name="list">The list of values.</param>
        /// <param name="i">The first location.</param>
        /// <param name="j">The second location.</param>
        private void Swap(IList<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        /// <summary>
        /// Sorts the given IList.
        /// </summary>
        /// <param name="list">The values to sort.</param>
        private void Sort(IList<int> list)
        {
            int position = -1;
            for (int i = 0; i < list.Count - 1; i++)
            {
                int min = list[i];
                position = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (min > list[j])
                    {
                        min = list[j];
                        position = j;
                    }
                }
                Swap(list, i, position);
            }
        }
    }
}
