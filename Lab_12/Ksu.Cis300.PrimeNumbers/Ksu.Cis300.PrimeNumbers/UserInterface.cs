/* UserInterface.cs
 * Author: Rod Howell
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

namespace Ksu.Cis300.PrimeNumbers
{
    /// <summary>
    /// A GUI for a program to find all prime numbers less than a given n.
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
        /// Handles a Click event on the Find Primes button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFindPrimes_Click(object sender, EventArgs e)
        {
            LinkedListCell<int> primes = GetPrimesLessThan((int)uxInput.Value);
            uxPrimes.BeginUpdate();
            uxPrimes.Items.Clear();
            for (LinkedListCell<int> p = primes; p != null; p = p.Next)
            {
                uxPrimes.Items.Add(p.Data);
            }
            uxPrimes.EndUpdate();
        }

        /// <summary>
        /// Gets a linked list containing the values 2 through n - 1.
        /// </summary>
        /// <param name="n">One greater than the largest value to be placed in the list.</param>
        /// <returns>A linked list containing the values 2 through n - 1.</returns>
        private LinkedListCell<int> GetNumbersLessThan(int n)
        {
            LinkedListCell<int> front = null;
            for (int i = n-1; i > 1 ; i--)
            {
                LinkedListCell<int> temp = new LinkedListCell<int>();
                temp.Data = i;
                temp.Next = front;
                front = temp;
            }
            return front;
        }


        /// <summary>
        /// Removes from the given linked list all cells (except the first) containing
        /// values divisible by the given int.  The given cell must not be null.
        /// </summary>
        /// <param name="k">The value whose multiples are to be removed.</param>
        /// <param name="list">The cell containing the divisor.</param>
        private void RemoveMultiples(int k, LinkedListCell<int> list)
        {
            LinkedListCell<int> temp = list;
            while (temp.Next != null)
            {
                if (temp.Next.Data % k == 0)
                {
                    temp.Next = temp.Next.Next;
                }
                else
                {
                    temp = temp.Next;
                }
            }
        }

        /// <summary>
        /// Gets a linked list containing all the primes less than n.
        /// </summary>
        /// <param name="n">The upper bound on the primes (all primes must be less than this value).</param>
        /// <returns>A linked list containing all the primes less than n.</returns>
        private LinkedListCell<int> GetPrimesLessThan(int n)
        {
            LinkedListCell<int> front = GetNumbersLessThan(n);
            LinkedListCell<int> temp = front;

            while (temp.Next != null && (temp.Data * temp.Data < n))
            {
                RemoveMultiples(temp.Data, temp);
                temp = temp.Next;
            }

            return front;
        }
    }
}
