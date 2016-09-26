/* UserInterface.cs
 * Author: Rod Howell and Jacob Dokos
 * Code: 96 03 75 53
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
            //int n = list.Count;
            //for (int i = 1; i < n; i++)
            //{
            //    int temp = list[i];
            //    int j = i;
            //    while (j > 0 && list[j - 1] > temp)
            //    {
            //        list[j] = list[j - 1];
            //        j--;
            //    }
            //    list[j] = temp;
            //}
            Sort(list, 0, list.Count);
        }

        private void Merge(IList<int> list, int start, int len1, int len2)
        {
            int pos1 = start; //position in 1st section
            int pos2 = start + len1; //pos in 2nd section

            int last1 = pos1 + len1 - 1; //last spot in 1st
            int last2 = pos2 + len2 - 1; //last spot in 2nd

            int[] temp = new int[len1 + len2];

            int cur = 0;

            while (pos1 <= last1 && pos2 <= last2)
            {
                if (list[pos1] > list[pos2])
                {
                    temp[cur] = list[pos2];
                    pos2++;
                    cur++;
                }
                else
                {
                    temp[cur] = list[pos1];
                    pos1++;
                    cur++;
                }
            }
            for (int i = pos1; i <= last1; i++)
            {
                temp[cur] = list[i];
                cur++;
            }
            for (int i = pos2; i <= last2; i++)
            {
                temp[cur] = list[i];
                cur++;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                int copyIndex = start + i;
                list[copyIndex] = temp[i];
            }
        }

        private void Sort(IList<int> list, int start, int len)
        {
            if (len > 1)
            {
                int center = start + (len / 2);
                Sort(list, start, center - start);
                Sort(list, center, len - (center - start));
                Merge(list, start, center - start, len - (center - start));
            }
        }
    }
}
