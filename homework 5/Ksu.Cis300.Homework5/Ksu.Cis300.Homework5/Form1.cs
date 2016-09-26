/* form1.cs
 * Author: Jacob Dokos
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Ksu.Cis300.Homework5
{
    /// <summary>
    /// Holds and initializes the form and funs the program
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes the form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the first button to get which file should be read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxText1_Click(object sender, EventArgs e)
        {
            uxOpenfile.Filter = "Text|*.txt|All|*.*";
            if (uxOpenfile.ShowDialog() == DialogResult.OK)
            {
                uxFilePath1.Text = uxOpenfile.FileName;
            }
            hasTwoFile(); 
        }

        /// <summary>
        /// Event handler for the second button to get which file should be read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxText2_Click(object sender, EventArgs e)
        {
            uxOpenfile.Filter = "Text|*.txt|All|*.*";
            if (uxOpenfile.ShowDialog() == DialogResult.OK) 
            {
                uxFilePath2.Text = uxOpenfile.FileName;
            }
            hasTwoFile(); 
        }

        /// <summary>
        /// Runs the program once both files have been read in. Parses the file then finds the 
        /// frequency difference
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAnalyzeText_Click(object sender, EventArgs e)
        {
            Dictionary<string, Occurences> dict = new Dictionary<string, Occurences>();
            MinPriorityQueue<float, Frequency> queue = new MinPriorityQueue<float, Frequency>();
            int[] totalWords = new int[2];
            totalWords[0] = processFile(uxFilePath1.Text, ref dict, 0);
            totalWords[1] = processFile(uxFilePath2.Text, ref dict, 1);

            findhighestFrequency(ref dict, ref queue, totalWords);
            float fileDifference = findDifference(queue);
            MessageBox.Show("The difference is " + fileDifference.ToString());
        }

        /// <summary>
        /// Finds if boith files have been read into the program
        /// </summary>
        private void hasTwoFile()
        {
            if (uxFilePath1.Text != "" && uxFilePath2.Text != "")
            {
                uxAnalyzeText.Enabled = true;
            }
        }

        /// <summary>
        /// Processes the file and creates occurences for all words in the file and then 
        /// puts them into a dictionary
        /// </summary>
        /// <param name="filename">filesname of the file to be read</param>
        /// <param name="dictionary">Dictionary for the occurence objects to be read into</param>
        /// <param name="fileNumber">Which files is being read</param>
        /// <returns>Word count</returns>
        private int processFile(string filename, ref Dictionary<string, Occurences> dictionary, int fileNumber) //return total # of word in that file
        {
            int totalWords = 0;
            string temp = "";
            using (StreamReader input = new StreamReader(filename))
            {
                while (input.EndOfStream != true)
                {
                    temp = input.ReadLine();
                    temp = temp.ToLower();
                    string[] result = Regex.Split(temp, "[^abcdefghijklmnopqrstuvwxyz]+");

                    for (int i = 0; i < result.Length; i++)
                    {
                        Occurences outResult;
                        if (result[i] != "")
                        {
                            totalWords++;
                            if (!dictionary.TryGetValue(result[i], out outResult))
                            {
                                Occurences tempOcc = new Occurences(result[i], 2);
                                dictionary.Add(result[i], tempOcc);
                            }
                            dictionary[result[i]].incrementOccurences(fileNumber);
                        }
                    }
                }
            }
            return totalWords;
        }

        /// <summary>
        /// find the highest frequency word in the two files
        /// </summary>
        /// <param name="dictionary">Where all the occurence object are stored to find the highest frequency</param>
        /// <param name="queue">Queue where the objects are put and then removed if they are the lowest frequency</param>
        /// <param name="totalwords">the total amount of words in each file</param>
        private void findhighestFrequency(ref Dictionary<string, Occurences> dictionary, ref MinPriorityQueue<float, Frequency> queue, int[] totalwords)
        {
            foreach (Occurences occ in dictionary.Values)
            {
                Frequency temp = new Frequency(occ, totalwords);

                float combinedFrequency = 0;
                for (int i = 0; i < totalwords.Length; i++)
                {
                    combinedFrequency += temp[i];
                }
                queue.Add(temp, combinedFrequency);
            }

            while (queue.Count > 50)
            {
                queue.RemoveMinimumPriority();
            }
        }

        /// <summary>
        /// finds the difference measurement between the two files of the frequency of the top 50 words
        /// </summary>
        /// <param name="queue">Queue that the Frequencies are removed from to find the total difference between the files</param>
        /// <returns>the difference measurement</returns>
        private float findDifference(MinPriorityQueue<float, Frequency> queue)
        {
            float result = 0;
            while (queue.Count != 0)
            {
                Frequency temp = queue.RemoveMinimumPriority();
                result += ((temp[0] - temp[1]) * (temp[0] - temp[1]));
            }
            result = (float) Math.Sqrt(result);
            result *= 100;
            return result;
        }
    }
}
