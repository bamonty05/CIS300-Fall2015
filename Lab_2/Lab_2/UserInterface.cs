/*   UserInterface.cs
 *   Name: Jacob Dokos
 *   Completion Code: 92 58 43 74
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

namespace Lab_2
{
    public partial class Lab2 : Form
    {
        /// <summary>
        /// Constructor for form
        /// </summary>
        public Lab2()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Allows the user to open another file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Can not open file at " + uxOpenDialog.FileName);
            }
        }

        /// <summary>
        /// Allows user to save completed file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSave_Click(object sender, EventArgs e)
        {
            if (uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Can not save file at " + uxSaveDialog.FileName);
            }
        }
    }
}
