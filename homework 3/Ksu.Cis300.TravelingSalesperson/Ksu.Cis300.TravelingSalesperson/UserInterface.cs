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


namespace Ksu.Cis300.TravelingSalesperson
{
    /// <summary>
    /// A GUI for a program that solves the Traveling Salesperson Problem using brute force algorithim with pruning.
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
        /// Handles a Clear event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxClear_Click(object sender, EventArgs e)
        {
            uxPanel.Clear();
            uxTourPoints.Items.Clear();
        }

        /// <summary>
        /// Handles a Find Tour event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFindTour_Click(object sender, EventArgs e)
        {
            Point[] points = uxPanel.Points;
            uxTourPoints.Items.Clear();
            uxPanel.ClearLines();
            if (points.Length < 2)
            {
                MessageBox.Show("You must plot at least 2 points.");
                return;
            }
            double[,] distances = GetDistances(points);
            bool[] tour = new bool[points.Length];
            int n = points.Length;
            LinkedListCell<int> bestTourFinish;

            double tourLen = ComputeMinumumLengthTour(0, 0.0, tour, distances, 0, Double.PositiveInfinity, out bestTourFinish);
            DisplayResults(points, bestTourFinish, tourLen);
        }

        /// <summary>
        /// Displays the minimum tour information.
        /// </summary>
        /// <param name="points">Array of points entered by the user</param>
        /// <param name="tour">Linked list of the optimal tour for the points</param>
        /// <param name="tourLen">How long the optimal tour is</param>
        private void DisplayResults(Point[] points, LinkedListCell<int> tour, double tourLen)
        {
            int first = tour.Data;
            uxTourPoints.Items.Add(points[first]);
            while (tour.Next != null)
            {
                uxPanel.DrawLine(points[tour.Data], points[tour.Next.Data]);
                if (tour.Data != 0)
                {
                    uxTourPoints.Items.Add(points[tour.Data]);
                }
                tour = tour.Next;
            }
            uxPanel.DrawLine(points[tour.Data], points[first]);
            uxTourPoints.Items.Add(points[tour.Data]);
            uxTourPoints.Items.Add(points[first]);
            MessageBox.Show("Tour length: " + tourLen);
        }

        /// <summary>
        /// Finds the minimum-length tour.
        /// </summary>
        /// <param name="curPoint">What point the function is currently at</param>
        /// <param name="pathLentoCur">Current path length for the current path</param>
        /// <param name="visited">Array to tell if the point has been visited before</param>
        /// <param name="distances">2d Array that shows the distance between all points</param>
        /// <param name="pointsInCurPath">Amount of points in the current path</param>
        /// <param name="minTour">The minimum tour length as found by the algorithim</param>
        /// <param name="bestTourFinish">Linkedlist cell linking to the optimal path</param>
        /// <returns></returns>
        private double ComputeMinumumLengthTour(int curPoint, double pathLentoCur, bool[] visited, double[,] distances, int pointsInCurPath, double minTour, out LinkedListCell<int> bestTourFinish)
        {
            bestTourFinish = null;
            LinkedListCell<int> currentTour = new LinkedListCell<int>(); 

            if (pointsInCurPath == visited.Length)
            {
                pathLentoCur += distances[0, curPoint];
                LinkedListCell<int> tempcell = new LinkedListCell<int>();
                tempcell.Data = curPoint;              
                bestTourFinish = tempcell;
                return pathLentoCur;  
            }
            if (minTour < pathLentoCur)
            {              
                bestTourFinish = null;
                return Double.PositiveInfinity;
            }
            else
            {
                for (int i = 0; i < visited.Length; i++)
                {
                    if (visited[i] == false)
                    {
                        visited[i] = true;
                        LinkedListCell<int> outLinked;
                        double temp = ComputeMinumumLengthTour(i, pathLentoCur + distances[curPoint, i], visited, distances, pointsInCurPath + 1, minTour, out outLinked);
                        visited[i] = false;

                        if (temp < minTour)
                        {
                            minTour = temp;
                            currentTour = outLinked;
                        }
                    }
                }              
            }
            LinkedListCell<int> tempCell = new LinkedListCell<int>();
            tempCell.Data = curPoint;
            tempCell.Next = currentTour;
            bestTourFinish = tempCell;
            return minTour;    
        }

        /// <summary>
        /// Produces an array of distances between the given points.
        /// </summary>
        /// <param name="points">The points between which the distances are needed.</param>
        /// <returns>An array such that element [i,j] gives the distance from points[i] to points[j].</returns>
        private double[,] GetDistances(Point[] points)
        {
            double[,] distances = new double[points.Length, points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    double xDiff = points[i].X - points[j].X;
                    double yDiff = points[i].Y - points[j].Y;
                    distances[i, j] = Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
                }
            }
            return distances;
        }
    }
}
