using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study_abroad_time
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void uxFindDifference_Click(object sender, EventArgs e)
        {
            int time = Convert.ToInt32(uxDifference.Text) + Convert.ToInt32(uxHour1.Text);
            if (time > 12)
            {
                uxText1.Text = "PM: " + time.ToString();
            }
            else
            {
                    uxText1.Text = "AM: " + time.ToString();
            }
        }
    }
}
