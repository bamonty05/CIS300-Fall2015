/* UserInterface.cs
 * Author: Jacob Dokos
   Completion Code: 16 42 49 68
 */
using System;
using System.Collections;
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

        private Stack _editingHistory = new Stack();
        private Stack _undoHistory = new Stack();
        private string _lastText = "";
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
                    //push the last text seen
                    _lastText = uxDisplay.Text;
                    _editingHistory.Clear();
                    _undoHistory.Clear();
                    uxUndo.Enabled = false;
                    uxRedo.Enabled = false;
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

        /// <summary>
        /// Records an edit made by the user.
        /// </summary>
        private void RecordEdit()
        {
            //_editingHistory.Push(uxDisplay.Text);
            uxUndo.Enabled = true;
           // _undoHistory.Clear();
            uxRedo.Enabled = false;

            _editingHistory.Push(IsDeletion(uxDisplay, _lastText));
            _editingHistory.Push(GetEditLocation(uxDisplay, IsDeletion(uxDisplay, _lastText), GetEditLength(uxDisplay, _lastText)));

            _editingHistory.Push(GetEditString(uxDisplay.Text, _lastText, IsDeletion(uxDisplay, _lastText), 
                GetEditLocation(uxDisplay, IsDeletion(uxDisplay, _lastText), GetEditLength(uxDisplay, _lastText)), 
                GetEditLength(uxDisplay, _lastText)));

            _lastText = uxDisplay.Text;
        }

        /// <summary>
        /// Returns whether text was deleted from the given string in order to obtain the contents
        /// of the given TextBox.
        /// </summary>
        /// <param name="editor">The TextBox containing the result of the edit.</param>
        /// <param name="lastContent">The string representing the text prior to the edit.</param>
        /// <returns>Whether the edit was a deletion.</returns>
        private bool IsDeletion(TextBox editor, string lastContent)
        {
            return editor.TextLength < lastContent.Length;
        }

        /// <summary>
        /// Gets the length of the text inserted or deleted.
        /// </summary>
        /// <param name="editor">The TextBox containing the result of the edit.</param>
        /// <param name="lastContent">The string representing the text prior to the edit.</param>
        /// <returns>The length of the edit.</returns>
        private int GetEditLength(TextBox editor, string lastContent)
        {
            return Math.Abs(editor.TextLength - lastContent.Length);
        }

        /// <summary>
        /// Gets the location of the beginning of the edit.
        /// </summary>
        /// <param name="editor">The TextBox containing the result of the edit.</param>
        /// <param name="isDeletion">Indicates whether the edit was a deletion.</param>
        /// <param name="len">The length of the edit string.</param>
        /// <returns>The location of the beginning of the edit.</returns>
        private int GetEditLocation(TextBox editor, bool isDeletion, int len)
        {
            if (isDeletion)
            {
                return editor.SelectionStart;
            }
            else
            {
                return editor.SelectionStart - len;
            }
        }

        /// <summary>
        /// Gets the edit string.
        /// </summary>
        /// <param name="content">The current content of the TextBox.</param>
        /// <param name="lastContent">The string representing the text prior to the edit.</param>
        /// <param name="isDeletion">Indicates whether the edit was a deletion.</param>
        /// <param name="editLocation">The location of the beginning of the edit.</param>
        /// <param name="len">The length of the edit.</param>
        /// <returns>The edit string.</returns>
        private string GetEditString(string content, string lastContent, bool isDeletion, int editLocation, int len)
        {
            if (isDeletion)
            {
                return lastContent.Substring(editLocation, len);
            }
            else
            {
                return content.Substring(editLocation, len);
            }
        }

        /// <summary>
        /// Performs the given edit on the contents of the given TextBox.
        /// </summary>
        /// <param name="editor">The TextBox to edit.</param>
        /// <param name="isDeletion">Indicates whether the edit is a deletion.</param>
        /// <param name="loc">The location of the beginning of the edit.</param>
        /// <param name="text">The text to insert or delete.</param>
        private void DoEdit(TextBox editor, bool isDeletion, int loc, string text)
        {
            if (isDeletion)
            {
                _lastText = editor.Text.Remove(loc, text.Length);
                editor.Text = _lastText;
                editor.SelectionStart = loc;
            }
            else
            {
                _lastText = editor.Text.Insert(loc, text);
                editor.Text = _lastText;
                editor.SelectionStart = loc + text.Length;
            }
        }

        private void uxDisplay_TextChanged(object sender, EventArgs e)
        {
            if (uxDisplay.Modified)
            {
                RecordEdit();
            }
        }

        private void uxUndo_Click(object sender, EventArgs e)
        {
            bool delete;
            int editIndex;
            string stringUndo;

            stringUndo = (string)_editingHistory.Pop();
            editIndex = (int)_editingHistory.Pop();
            delete = (bool)_editingHistory.Pop();

            DoEdit(uxDisplay, !delete, editIndex, stringUndo);

            _undoHistory.Push(delete);
            _undoHistory.Push(editIndex);
            _undoHistory.Push(stringUndo);

            uxRedo.Enabled = true;
            if (_editingHistory.Count > 0)
                uxUndo.Enabled = true;
        }

        private void uxRedo_Click(object sender, EventArgs e)
        {
            bool delete;
            int editIndex;
            string stringUndo;

            stringUndo = (string)_undoHistory.Pop();
            editIndex = (int)_undoHistory.Pop();
            delete = (bool)_undoHistory.Pop();

            DoEdit(uxDisplay, delete, editIndex, stringUndo);

            _editingHistory.Push(delete);
            _editingHistory.Push(editIndex);
            _editingHistory.Push(stringUndo);

            uxUndo.Enabled = true;
            uxUndo.Enabled = _editingHistory.Count > 1;
        }
    }
}
