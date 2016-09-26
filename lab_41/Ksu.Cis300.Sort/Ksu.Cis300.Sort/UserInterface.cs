/* UserInterface.cs
 * Author: Rod Howell and Jacob Dokos
 * code: 69 32 54 47 
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
                List<string> values = new List<string>();
                try
                {
                    using (StreamReader input = new StreamReader(uxOpenDialog.FileName))
                    {
                        while (!input.EndOfStream)
                        {
                            string value = input.ReadLine();
                            values.Add(value);
                        }
                    }
                    Sort(values);
                    using (StreamWriter output = new StreamWriter(uxSaveDialog.FileName))
                    {
                        foreach (string i in values)
                        {
                            output.WriteLine(i);
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
        private void Swap(IList<string> list, int i, int j)
        {
            string temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        /// <summary>
        /// Sorts the given IList.
        /// </summary>
        /// <param name="list">The values to sort.</param>
        private void Sort(IList<string> list)
        {
            QuickSort(list, 0, list.Count, 0);
        }

        /// <summary>
        /// Sorts the given portion of the given list.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="start">The index of the first element of the portion to sort.</param>
        /// <param name="len">The number of elements to sort.</param>
        /// <param name="k">identical prefixes</param>
        private void QuickSort(IList<string> list, int start, int len, int k)
        {
            while (len > 1)
            {
                int pivot = MedianOfThree(CharacterAt(list[start], k), CharacterAt(list[start + len / 2], k), CharacterAt(list[start + len - 1], k));
                int afterLess = start;
                int beforeEqual = start + len - 1;
                int beforeGreater = beforeEqual;
                while (afterLess <= beforeEqual)
                {
                    if (CharacterAt(list[beforeEqual], k) < pivot)
                    {
                        Swap(list, afterLess, beforeEqual);
                        afterLess++;
                    }
                    else if (CharacterAt(list[beforeEqual], k) == pivot)
                    {
                        beforeEqual--;
                    }
                    else
                    {
                        Swap(list, beforeEqual, beforeGreater);
                        beforeEqual--;
                        beforeGreater--;
                    }
                }
                QuickSort(list, start, afterLess - start, k);
                QuickSort(list, beforeGreater + 1, start + len - beforeGreater - 1, k);
                if (pivot == -1)
                {
                    break;
                }
                	start = beforeEqual+1;
	                len = beforeGreater-beforeEqual;
                    k++;
            }
        }

        private int CharacterAt(string s, int i)
        {        
            if (s.Length <= i)
            {
                return -1;
            }
            return s[i];
        }

        /// <summary>
        /// Finds the median of the given values.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The median of a, b, and c.</returns>
        private int MedianOfThree(int a, int b, int c)
        {
            if (a < b)
            {
                if (b < c)
                {
                    return b;
                }
                else if (a < c)
                {
                    return c;
                }
                else
                {
                    return a;
                }
            }
            else if (a < c)
            {
                return a;
            }
            else if (b < c)
            {
                return c;
            }
            else
            {
                return b;
            }
        }
    }
}
