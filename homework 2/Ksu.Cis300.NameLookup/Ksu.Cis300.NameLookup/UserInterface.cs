/* UserInterface.cs
 * Author: Jacob Dokos 
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
    /// a sample of US data. It is able to find the most common starting initial for a given list. It can also find how many occurences there are for a given letter based on user input.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The information on all the names.
        /// </summary>
        private LinkedListCell<NameInformation>[] _names = null;

        /// <summary>
        /// Constructs a new GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Click event on the Open Data File button. Opens a files and calls a method to read it into the linked list array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //_names = GetAllInformation(uxOpenDialog.FileName);
                    _names = new LinkedListCell<NameInformation>[26];
                    GetAllInformation(uxOpenDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the Get Statistics button. Finds if the name entered exists in the linked list array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            int index = getIndexPosition(name[0]);
            LinkedListCell<NameInformation> p = _names[index];
            while (p != null)
            {
                if (p.Data.Name == name)
                {
                    uxFrequency.Text = p.Data.Frequency.ToString();
                    uxRank.Text = p.Data.Rank.ToString();
                    return;
                }
                p = p.Next;
            }
            MessageBox.Show("Name not found.");
            uxRank.Text = "";
            uxFrequency.Text = "";
        }

        /// <summary>
        /// Reads the given file and forms a linked list from its contents.
        /// </summary>
        /// <param name="fn">The name of the file.</param>
        /// <returns>The linked list containing all the name information.</returns>
        private void GetAllInformation(string fn)
        {        
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    LinkedListCell<NameInformation> newCell = new LinkedListCell<NameInformation>();
                    newCell.Data = new NameInformation(name, freq, rank);

                    int index = getIndexPosition(newCell.Data.Name[0]);
                    LinkedListCell<NameInformation> currentCell = _names[index];

                    if (_names[index] == null)
                    {
                        _names[index] = newCell;
                        continue;
                    }

                    if (newCell.Data.Name.CompareTo(currentCell.Data.Name) < 0)
                    {
                        newCell.Next = _names[index];
                        _names[index] = newCell;

                        continue;
                    }

                    while (currentCell.Next != null)
                    {
                        if (newCell.Data.Name.CompareTo(currentCell.Data.Name) > 0 && newCell.Data.Name.CompareTo(currentCell.Next.Data.Name) < 0)
                        {
                            newCell.Next = currentCell.Next;
                            currentCell.Next = newCell;
                            break;
                        }
                        else
                        {
                            currentCell = currentCell.Next;
                        }
                    }
                    if (currentCell.Next == null)
                    {
                        currentCell.Next = newCell;
                    }
                }
            }
        }

        /// <summary>
        /// Outputs the contents of the linked list array to a file in alphabetical order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOutputFile_Click(object sender, EventArgs e)
        {
            LinkedListCell<NameInformation> temp = new LinkedListCell<NameInformation>();

            if (uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter output = new StreamWriter(uxSaveDialog.FileName))
                {
                    for (int i = 0; i < _names.Length; i++)
                    {
                        temp = _names[i];

                        while (temp != null)
                        {
                            output.Write(temp.Data.Name + Environment.NewLine);
                            output.Write(temp.Data.Frequency.ToString() + Environment.NewLine);
                            output.Write(temp.Data.Rank.ToString() + Environment.NewLine);
                            temp = temp.Next;
                        }
                    }               
                }
            }

        }

        /// <summary>
        /// Counts the number of occurences with a given letter based on input from the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCountLetter_Click(object sender, EventArgs e)
        {
            if (uxFirstLetter.Text.Length != 0)
            {
                int index = getIndexPosition(uxFirstLetter.Text[0]);
                LinkedListCell<NameInformation> temp = _names[index];

                int count = 0;
                while (temp != null)
                {
                    count++;
                    temp = temp.Next;
                }
                uxLetterResult.Text = count.ToString() + " names begin with " + char.ToUpper(uxFirstLetter.Text[0]);
            }
            else
            {
                MessageBox.Show("I can not find the amount of occurences for _");
            }
        }

        /// <summary>
        /// Finds the most common letter for the start of a name in the entire array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFindCommonLetter_Click(object sender, EventArgs e)
        {
            try
            {
                int[] letterAmount = new int[_names.Length];

                for (int i = 0; i < _names.Length; i++)
                {
                    LinkedListCell<NameInformation> temp = _names[i];

                    int count = 0;
                    while (temp != null)
                    {
                        count++;
                        temp = temp.Next;
                    }
                    letterAmount[i] = count;
                }
                int maxNumber = letterAmount.Max();
                int letterPosition = Array.IndexOf(letterAmount, maxNumber); //find position of max number, now I need to convert back to a char
                char maxLetter = (char)(letterPosition + 'A');
                uxCommonLetterResult.Text = "Most frequent first letter: " + char.ToUpper(maxLetter);
            }
            catch (Exception ex)
            {
               if (MessageBox.Show("Must read a file in first, press 'OK' for a more detailed exception.","Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        /// <summary>
        /// Changes a char into an integer based on the char's letter
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private int getIndexPosition(char x)
        {
            x = Char.ToUpper(x);
            int index = x - 'A';
            return index;
        }
    }
}
