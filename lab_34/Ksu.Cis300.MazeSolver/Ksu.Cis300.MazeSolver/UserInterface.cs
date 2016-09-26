/* UserInterface.cs
 * Author: Rod Howell and Jacob Dokos   
 * Code: 01 27 19 79
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
using Ksu.Cis300.MazeLibrary;
using Ksu.Cis300.Graphs;

namespace Ksu.Cis300.MazeSolver
{
    /// <summary>
    /// A user interface for a maze solver.
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
        /// Handles a New event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNew_Click(object sender, EventArgs e)
        {
            uxMaze.Generate();
        }

        /// <summary>
        /// Handes a MouseClick event on the maze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMaze_MouseClick(object sender, MouseEventArgs e)
        {
            Cell cell = uxMaze.GetCellFromPixel(e.Location);
            if (uxMaze.IsInMaze(cell))
            {
                uxMaze.EraseAllPaths();
                DirectedGraph<Cell, Direction> graph = GetGraph(uxMaze);
                Dictionary<Cell, Cell> paths;
                Cell exit = FindPath(graph, cell, uxMaze, out paths);
                if (exit == new Cell(0, 0))
                {
                    MessageBox.Show("There is no path from this cell.");
                }
                else
                {
                    DisplayPath(cell, exit, uxMaze, paths, graph);
                }
                uxMaze.Invalidate();
            }
        }

        /// <summary>
        /// Gets a graph representing the given maze. The Direction associated with each edge
        /// is the direction from the source to the destination.
        /// </summary>
        /// <param name="maze">The maze to be represented.</param>
        /// <returns>The graph representation.</returns>
        private DirectedGraph<Cell, Direction> GetGraph(Maze maze)
        {
            DirectedGraph<Cell, Direction> graph = new DirectedGraph<Cell, Direction>();
            for (int i = 0; i < maze.MazeHeight; i++)
            {
                for (int j = 0; j < maze.MazeWidth; j++)
                {
                    Cell cell = new Cell(i, j);
                    if (!graph.ContainsNode(cell))
                    {
                        graph.AddNode(cell);
                    }
                    for (Direction d = Direction.North; d <= Direction.West; d++)
                    {
                        if (maze.IsClear(cell, d))
                        {
                            graph.AddEdge(cell, maze.Step(cell, d), d);
                        }
                    }
                }
            }
            return graph;
        }

        /// <summary>
        /// Finds a shortest path from the given cell to an exit.
        /// </summary>
        /// <param name="graph">The graph representation of the maze.</param>
        /// <param name="u">The starting cell.</param>
        /// <param name="maze">The maze.</param>
        /// <param name="paths">All of the path information found. The value associated with a cell is the predecessor
        /// of that cell on a shortest path from u to that cell.</param>
        /// <returns>The cell just past the exit taken by the shortest path.</returns>
        private Cell FindPath(DirectedGraph<Cell, Direction> graph, Cell u, Maze maze, out Dictionary<Cell, Cell> paths)
        {
            //throw new NotImplementedException();
            Queue<Tuple<Cell, Cell>> que = new Queue<Tuple<Cell, Cell>>();
            paths = new Dictionary<Cell, Cell>();
            paths.Add(u, u);
            //que.Enqueue(new Tuple<Cell, Cell>(u, u));

            //add all outgoing edges from u
            foreach (Tuple<Cell, Direction> edge in graph.OutgoingEdges(u))
            {
                //add this edge to priority queue
                que.Enqueue(new Tuple<Cell, Cell>(u, edge.Item1));
            }

            while (que.Count != 0)
            {
                //decimal priority = q.MininumPriority;

                Tuple<Cell, Cell> edge = que.Dequeue();

                Cell x = edge.Item1;
                Cell w = edge.Item2;

                if (!paths.ContainsKey(w))
                {
                    paths.Add(w, x);

                    if (!maze.IsInMaze(w))
                    {
                        return w;
                    }
                    foreach (Tuple<Cell, Direction> edge2 in graph.OutgoingEdges(w))
                    {
                        //add this edge to priority queue
                        que.Enqueue(new Tuple<Cell, Cell>(w, edge2.Item1));
                    }

                }
            }
            //return -1;
            Cell temp = new Cell(0, 0);
            return temp;
        }

        /// <summary>
        /// Displays a shortest path from u to v on the maze.
        /// </summary>
        /// <param name="u">The starting cell.</param>
        /// <param name="v">The ending cell.</param>
        /// <param name="maze">The maze.</param>
        /// <param name="paths">The path information. The value associated with a cell is the predecessor
        /// of that cell on a shortest path from u to that cell.</param>
        /// <param name="graph">The graph representation of the maze.</param>
        private void DisplayPath(Cell u, Cell v, Maze maze, Dictionary<Cell, Cell> paths, DirectedGraph<Cell, Direction> graph)
        {
            Cell cur = v;

            while (cur != u)
            {
                Cell prev = paths[cur];
                Direction dir;

                graph.TryGetEdge(prev, cur, out dir);
                maze.DrawPath(prev, dir);
                cur = prev;
            }
        }
    }
}
