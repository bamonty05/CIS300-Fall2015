/* UserInterface.cs
 * Author: Rod Howell
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

namespace Ksu.Cis300.CapitalGainCalculator
{
    /// <summary>
    /// A GUI for a capital gain calculator.
    /// </summary>
    public partial class UserInterface : Form
    {

        private Queue<decimal> decQueue = new Queue<decimal>();
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        private void uxBuy_Click(object sender, EventArgs e)
        {
            decimal sharespurchased = uxNumber.Value;
            decimal cost = uxCost.Value;


            for (int i = 0; i < sharespurchased; i++)
            {
                decQueue.Enqueue(cost);
            }

            uxOwned.Text = Convert.ToString(decQueue.Count);


        }

        private void uxSell_Click(object sender, EventArgs e)
        {
            if ((int)uxNumber.Value > decQueue.Count)
            {
                MessageBox.Show("You can not sell more shares than you own.");
            }
            else
            {
                decimal sharesowned = Convert.ToDecimal(decQueue.Count);

                for (int i = 0; i < ((int)uxNumber.Value); i++)
                {
                    decimal decShare = decQueue.Dequeue();
                    //uxGain.Text += Convert.ToString(Convert.ToDecimal(uxNumber.Text) - decQueue.Dequeue());
                    decimal decGainAmt = Convert.ToDecimal(uxGain.Text);
                    decGainAmt += (Convert.ToDecimal(uxCost.Text) - decShare);
                    uxGain.Text = Convert.ToString(decGainAmt);
                    //uxOwned.Text = Convert.ToString(Convert.ToInt32(uxOwned.Text) - 1);
                }

                uxOwned.Text = Convert.ToString(decQueue.Count);
            }
        }
    }
}
