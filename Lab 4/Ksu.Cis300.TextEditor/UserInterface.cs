/* UserInterface.cs
 * Author: Jacob Dokos
   Completion Code: 01 93 70 22 
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

namespace Ksu.Cis300.TextEditor
{
    /// <summary>
    /// A GUI for a simple text editor.
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
        /// Handles an "Open . . ." event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    uxDisplay.Text = File.ReadAllText(uxOpenDialog.FileName);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Handles a "Save As . . ." event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSaveAs_Click(object sender, EventArgs e)
        {
            if (uxSaveAsDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(uxSaveAsDialog.FileName, uxDisplay.Text);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Displays the given exception in an error message.
        /// </summary>
        /// <param name="e"></param>
        private void ShowError(Exception e)
        {
            MessageBox.Show("The following error occurred: " + e.ToString());
        }

        /// <summary>
        /// Rotates the given character c n positions through the alphabet whose first
        /// letter is firstLetter and whose number of letters is alphabetLen. alphabetLen
        /// must be positive.
        /// </summary>
        /// <param name="c">The character to rotate.</param>
        /// <param name="n">The number of positions to rotate c.</param>
        /// <param name="firstLetter">The first letter of the alphabet.</param>
        /// <param name="alphabetLen">The number of letters in the alphabet.</param>
        /// <returns>The result of the rotation.</returns>
        private char Rotate(char c, int n, char firstLetter, int alphabetLen)
        {
            return (char)(firstLetter + (c - firstLetter + n) % alphabetLen);
        }

        /// <summary>
        /// Encrypts the user entered string one character at a time
        /// </summary>
        /// <param name="letter"> Character that is being entered to be encrypted</param>
        /// <returns></returns>
        private char EncryptChar(char letter)
        {
            char result = ' ';
            if (letter >= 'a' && letter <= 'z')
            {
                result = Rotate(letter, 13, 'a', 26);
            }
            else if (letter >= 'A' && letter <= 'Z')
            {
                result = Rotate(letter, 13, 'A', 26);
            }

            return result;
        }

        /// <summary>
        /// On click tell the program to encrypt the string in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxString_Click(object sender, EventArgs e)
        {
            string textBoxContents = uxDisplay.Text;
            string result = "";

            foreach (char c in textBoxContents)
            {
                result += EncryptChar(c);
            }
            uxDisplay.Text = result;
        }


        /// <summary>
        /// Tells the program to encrypt the string using a string builder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxStringbuilder_Click(object sender, EventArgs e)
        {
            string textBoxContents = uxDisplay.Text;
            StringBuilder build = new StringBuilder();

            foreach (char c in textBoxContents)
            {
                build.Append(EncryptChar(c));
            }
            uxDisplay.Text = build.ToString();
        }
    }
}
