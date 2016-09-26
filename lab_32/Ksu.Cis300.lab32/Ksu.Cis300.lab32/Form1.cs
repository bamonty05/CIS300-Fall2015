using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ksu.Cis300.Graphs;
using System.IO;

namespace Ksu.Cis300.lab32
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DirectedGraph<string,decimal> readFile(string filename)
        {
            DirectedGraph<string, decimal> temp = new DirectedGraph<string, decimal>();

            using (StreamReader input = new StreamReader(filename))
            {
                input.ReadLine();
                while (input.EndOfStream != true)
                {
                    string[] tempArray = input.ReadLine().ToString().Split(',');

                    temp.AddEdge(tempArray[0], tempArray[1], Convert.ToDecimal(tempArray[2]));
                }
            }

            return temp;
        }

        private decimal findSumofMax(DirectedGraph<string,decimal> dg)
        {
            decimal max = Decimal.MinValue;
            foreach(string node in dg.Nodes)
            {
                decimal temp =0;
	            foreach(Tuple<string,decimal> edge in dg.OutgoingEdges(node))
	            {
                    temp += edge.Item2;
	            }
                if (temp > max)
                {
                    max = temp;
                }
            }
            return max;
        }

        private void uxReadGraph_Click(object sender, EventArgs e)
        {
            try
            {
                if (uxOpenFile.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Maximum is:" + findSumofMax(readFile(uxOpenFile.FileName)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
