/* checker.cs
 * Author: Jacob Dokos
   Completion Code: 05 79 87 28
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

namespace KSU.CIS300.Lab_6
{
    public partial class uxLab6 : Form
    {

        //Stack<char> s = new Stack<char>();

        public uxLab6()
        {
            InitializeComponent();
        }

        private void uxLabel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButton_Click(object sender, EventArgs e)
        {
            string boxtext = uxText.Text;
            Stack<char> s = new Stack<char>();

            foreach (char x in boxtext)
            {
                if (IsOpeningParenthesis(x))
                {
                    s.Push(x);
                }
                else if (IsClosingParenthesis(x))
                    if (s.Count == 0)
                    {
                        ShowError();
                        return;
                    }
                    else
                        if (!Matches(s.Pop(), x))
                        {
                            ShowError();
                            return;
                        }
            }
            if (s.Count != 0)
            {
                ShowError();
                return;
            }
            else
                ShowSuccess();

        }

        /// <summary>
        /// Determines whether the given character is an opening parenthesis.
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <returns>Whether c is an opening parenthesis.</returns>
        private bool IsOpeningParenthesis(char c)
        {
            return c == '(' || c == '[' || c == '{';
        }

        /// <summary>
        /// Determines whether the given character is a closing parenthesis.
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <returns>Whether c is a closing parenthesis.</returns>
        private bool IsClosingParenthesis(char c)
        {
            return c == ')' || c == ']' || c == '}';
        }

        /// <summary>
        /// Determines whether the given characters for a matched pair
        /// of parentheses.
        /// </summary>
        /// <param name="a">The opening character.</param>
        /// <param name="b">The closing character.</param>
        /// <returns>Whether a and b form a matched pair of parentheses.</returns>
        private bool Matches(char a, char b)
        {
            return (a == '(' && b == ')') || (a == '[' && b == ']') ||
                (a == '{' && b == '}');
        }

        /// <summary>
        /// Displays a success message.
        /// </summary>
        private void ShowSuccess()
        {
            MessageBox.Show("The string is matched.");
        }

        /// <summary>
        /// Displays an error message.
        /// </summary>
        private void ShowError()
        {
            MessageBox.Show("The string is not matched.");
        }
    }
}
