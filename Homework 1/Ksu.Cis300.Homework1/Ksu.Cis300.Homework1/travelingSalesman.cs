/* travelingSalesman.cs
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

namespace Ksu.Cis300.Homework1
{
    /// <summary>
    /// Finds the minimum tour between all points and returns the results to the user.
    /// </summary>
    public partial class uxTravelingSalesMan : Form
    {
        /// <summary>
        /// Initalizes the class.
        /// </summary>
        public uxTravelingSalesMan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for finding the path between all points. Akin to main method, calls all other methods to 
        /// get their information and return it to the GUI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFind_Click(object sender, EventArgs e)
        {
            Point[] allPoints = uxDrawing.Points;
            if (uxDrawing.Points.Length < 2)
            {
                MessageBox.Show("Must include two or more points.");
                return;
            }
            uxList.Items.Clear();
            uxDrawing.ClearLines();

            int[] minimumPointPath = new int[uxDrawing.Points.Length];
            double[,] distanceToAllPoints = GetDistance(allPoints);
            double totalTourLength = GetMinimumTour(allPoints.Length, distanceToAllPoints, ref minimumPointPath);
            DisplayResults(allPoints,minimumPointPath,totalTourLength);
        }

        /// <summary>
        /// Clears all the points and lines between them to prepare for the next set of user input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxClear_Click(object sender, EventArgs e)
        {
            uxList.Items.Clear();
            uxDrawing.Clear();
        }

        /// <summary>
        /// Gets the distance between all point. 
        /// </summary>
        /// <param name="drawingPoints">Array that gives all the points that a user has entered.</param>
        /// <returns>Array that gives the distance between all points.</returns>
        private double[,] GetDistance(Point[] drawingPoints) 
        {
            double[,] pointDistance = new double[drawingPoints.Length, drawingPoints.Length];

            for (int i = 0; i < drawingPoints.Length; i++)
            {
                for (int j = 0; j < drawingPoints.Length; j++)
                {
                    double temp = ((double) Math.Sqrt(((drawingPoints[i].X - drawingPoints[j].X) * (drawingPoints[i].X - drawingPoints[j].X)) + 
                     ((drawingPoints[i].Y - drawingPoints[j].Y) * (drawingPoints[i].Y - drawingPoints[j].Y))));

                    pointDistance[i, j] = temp;
                }
            }        
            return pointDistance;
        }

        /// <summary>
        /// Find the minimum tour to go between all points
        /// </summary>
        /// <param name="numPoints">Total number of points to find the minimum tour through.</param>
        /// <param name="distances">Array of distances between all points.</param>
        /// <param name="order">Reference variable the is the minimum path between all points.</param>
        /// <returns>Returns the minimum tour total distance.</returns>
        private double GetMinimumTour(int numPoints, double[,] distances, ref int[] order)
        {
            bool[] visited = new bool[numPoints];
            visited[0] = true;
            double shortestPath = Double.PositiveInfinity;

            Stack<int> s = new Stack<int>();
            s.Push(0);

            double tourDistance = 0;
            int currentPoint = 1;
            while (s.Count > 1 || currentPoint < numPoints) 
            {
                //Case 1
                if (s.Count == numPoints)
                {
                    tourDistance += distances[s.Peek(), 0];
                    if (shortestPath > tourDistance)
                    {
                        shortestPath = tourDistance;
                        s.CopyTo(order, 0);                       
                    }
                    tourDistance -= distances[s.Peek(), 0];
                    //backtracking
                    backTrack(ref s, ref visited, ref currentPoint, ref tourDistance, distances);
                }

                //Case 2
                else if (currentPoint >= numPoints)
                {
                    backTrack(ref s, ref visited, ref currentPoint, ref tourDistance, distances);
                }

                //Case 3
                else if (visited[currentPoint] == true)
                {
                    currentPoint++;
                }

                //Case 4
                else
                {
                    tourDistance += distances[s.Peek(), currentPoint];
                    s.Push(currentPoint);
                    visited[s.Peek()] = true;
                    currentPoint = 1;
                }
            }
            return shortestPath;
        } 

        /// <summary>
        /// Displays the results of the optimal point that was found in the other method.
        /// </summary>
        /// <param name="tourPoints">All of all user inputed points and their location.</param>
        /// <param name="optimalRoute">Optimal route between all points to find the shortest path.</param>
        /// <param name="tourLength">Length of the total minimum tour length</param>
        private void DisplayResults(Point[] tourPoints, int[] optimalRoute, double tourLength)
        { 
            for (int i = 0; i < optimalRoute.Length - 1; i++)
            {
                uxList.Items.Add(tourPoints[optimalRoute[i]]);
                uxDrawing.DrawLine(tourPoints[optimalRoute[i]], tourPoints[optimalRoute[i + 1]]); 
            }

            uxDrawing.DrawLine(tourPoints[0], tourPoints[optimalRoute[0]]);
            uxList.Items.Add(tourPoints[optimalRoute[optimalRoute.Length - 1]]);
            uxList.Items.Add(tourPoints[optimalRoute[0]]);
            
            MessageBox.Show("The length of the tour is: " + tourLength);
        }

        /// <summary>
        /// Used to backtrack the tour to the next avaliable point
        /// </summary>
        /// <param name="currentPath">Reference variable that show the current tour (where the program is on the path)</param>
        /// <param name="visitedPoints">Reference variable that shows what points are in the prevoious stack</param>
        /// <param name="currentPoint">Reference variable that show the current point the program is at</param>
        /// <param name="currentPathDistance">Reference variable that shows the total path distance so far.</param>
        /// <param name="distanceBetweenPoints">Distance between all points. Used to remove distance after removing a point from the stack</param>
        private void backTrack(ref Stack<int> currentPath, ref bool[] visitedPoints, ref int currentPoint, ref double currentPathDistance, double[,] distanceBetweenPoints)
        {
            int poppedPoint = currentPath.Pop();

            visitedPoints[poppedPoint] = false;
            currentPathDistance -= distanceBetweenPoints[poppedPoint, currentPath.Peek()];
            currentPoint = poppedPoint + 1;
        }
    }
}
