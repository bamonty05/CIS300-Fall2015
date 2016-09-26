/* UserInterface.cs
 * Author: Julie Thornton and Jacob Dokos
 */

using System;
using System.CodeDom.Compiler;
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

namespace Ksu.Cis300.Sudoku
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The size of the Sudoku puzzle
        /// </summary>
        private int _gridSize = 9;

        /// <summary>
        /// The size of a cell on the Sudoku grid
        /// </summary>
        private const int _cellSize = 40;

        /// <summary>
        /// Directed graph used to solve the board
        /// </summary>
        private DirectedGraph<Cell, int> _graph = null;

        /// <summary>
        /// Array of cells used to hold the underlying data for the board.
        /// </summary>
        private Cell[,] _cellArray = new Cell[9,9]; //row col

        /// <summary>
        /// Tells whether the graph has been updated since the last time the solve method was called.
        /// </summary>
        private bool _isEdited = true;

        /// <summary>
        /// Constructs the GUI
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();

            for (int i = 0; i < _gridSize; i++)
            {
                DataGridViewTextBoxColumn txCol = new DataGridViewTextBoxColumn();
                txCol.MaxInputLength = 1;   
                uxGrid.Columns.Add(txCol);
                uxGrid.Columns[i].Name = "Col " + (i + 1).ToString();
                uxGrid.Columns[i].Width = _cellSize;
                uxGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                DataGridViewRow row = new DataGridViewRow();
                row.Height = _cellSize;
                uxGrid.Rows.Add(row);
            }
            //marks the 3x3 grids
            uxGrid.Columns[2].DividerWidth = 2;
            uxGrid.Columns[5].DividerWidth = 2;
            uxGrid.Rows[2].DividerHeight = 2;
            uxGrid.Rows[5].DividerHeight = 2;

            //initialize the underlying array
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    uxGrid.Rows[i].Cells[j].Value = "";
                    _cellArray[i, j] = new Cell(i, j, -1);
                }
            }
        }

        /// <summary>
        /// Sets the value of a grid cell
        /// </summary>
        /// <param name="row">A row in the grid</param>
        /// <param name="col">A column in the grid</param>
        /// <param name="value">The value to place at that position</param>
        public void SetCell(int row, int col, int value)
        {
            if (value == -1)
            {
                uxGrid.Rows[row].Cells[col].Value = "";
            }
            else
            {
                uxGrid.Rows[row].Cells[col].Value = value;
            }
        }
    
        /// <summary>
        /// Adds in each node to the directed graph thens adds all of the node's edges.
        /// Next solves the board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSolve_Click(object sender, EventArgs e)
        {
            //makes a new graph each time
            _graph = new DirectedGraph<Cell, int>();

            //add each one as a node into the graph
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _graph.AddNode(_cellArray[i,j]);
                }
            }

            // i/row col/j 
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int rowNum = (row / 3) * 3;
                    int colNum = (col / 3) * 3;

                    addCellEdges(_cellArray[row, col], colNum, rowNum);
                }
            }

            if (SolveSudoku(81, null))
            {
                //updating grid to be the same as the underlying array
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        SetCell(i, j, _cellArray[i, j].Value);
                    }
                }
                return;
            }
            else
            {
                if (!_isEdited)
                {
                    MessageBox.Show("Initial puzzle does not follow Sudoku rules.");
                }
                _isEdited = true;
            }  
        }

        /// <summary>
        /// Adds the edges of the cell to each node in the Directed Graph
        /// </summary>
        /// <param name="source">The source cell that all edges will be added onto.</param>
        /// <param name="col">The left bound of the 3x3 matrix that the source cell is a part of.</param>
        /// <param name="row">Upper row of the 3x3 matrix that the cell is a part of</param>
        private void addCellEdges(Cell source, int col, int row)
        {
            //start at row and go to row + 2, same for col
            int sourceRow = source.Row;
            int sourceCol = source.Column;

            for (int i = row; i <= row + 2; i ++)
            {
                for (int j = col; j <= col + 2; j++)
                {
                    if (j != sourceCol && i != sourceRow)
                    {
                        _graph.AddEdge(source, _cellArray[i, j], 0);

                        if (source.Value != -1)
                        {
                            _cellArray[i, j].RemoveMove(source.Value);
                        }
                    }
                }
            }

            //add column edges
            for (int i = 0; i < 9; i++) //row
            {
                if (i != sourceRow)
                {
                    _graph.AddEdge(source, _cellArray[i, sourceCol], 0);

                    if (source.Value != -1)
                    {
                        _cellArray[i, sourceCol].RemoveMove(source.Value);
                    }
                }
            }

            //add row edges
            for (int i = 0; i < 9; i++) //col
            {
                if (i != sourceCol)
                {
                    _graph.AddEdge(source, _cellArray[sourceRow, i], 0);

                    if (source.Value != -1)
                    {
                        _cellArray[sourceRow, i].RemoveMove(source.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Loads in a new board from the file. If there is an error the operation halts. The board is not updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLoad_Click(object sender, EventArgs e)
        {
            try
            {          
                Cell[,] temp = new Cell[9, 9];
                uxOpenfileDialog.Filter = "Text|*.txt|All|*.*";
                if (uxOpenfileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(uxOpenfileDialog.FileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                String[] line = sr.ReadLine().Split();

                                for (int j = 0; j < 9; j++)
                                {
                                    int value;
                                    if (line[j] == "_")
                                    {
                                        value = -1;
                                    }
                                    else
                                    {
                                        value = Convert.ToInt32(line[j]);
                                    }
                                    temp[i, j] = new Cell(i, j, value);
                                }
                            }
                        }
                    }
                    //if no errors
                    _cellArray = temp;

                    //update all cells
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            SetCell(i, j, _cellArray[i, j].Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            _isEdited = true;
        }

        /// <summary>
        /// Once the cell is edited this method add the enterred data to the underlying array. It also verifies that the given data is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Idenity of which cell is being edited</param>
        private void uxGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (uxGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || uxGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "" )
            {
                Cell temp = new Cell(e.RowIndex, e.ColumnIndex, -1);
                _cellArray[e.RowIndex, e.ColumnIndex] = temp;
            }
            else if ((uxGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().All(char.IsDigit))) //check to see if it is a number
            {
                int value = Convert.ToInt32(uxGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (value >= 1 && value <= 9) // now check to see if it is in the accepted range
                {
                    Cell temp = new Cell(e.RowIndex, e.ColumnIndex, value);
                    _cellArray[e.RowIndex, e.ColumnIndex] = temp;
                }
                else
                {
                    MessageBox.Show("Please enter a valid number (1-9) or leave the cell blank.");
                    uxGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    _cellArray[e.RowIndex, e.ColumnIndex] = new Cell(e.RowIndex, e.ColumnIndex, -1);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number (1-9) or leave the cell blank.");
                uxGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                _cellArray[e.RowIndex, e.ColumnIndex] = new Cell(e.RowIndex, e.ColumnIndex, -1);
            }
            _isEdited = false;
        }

        /// <summary>
        /// Recursively finds the sol;ution to the suodoku problem
        /// </summary>
        /// <param name="uncolored">Number of uncolored nodes left</param>
        /// <param name="recent">Most recently colored nodes</param>
        /// <returns>If a solution had been found</returns>
        private bool SolveSudoku(int uncolored, Cell recent)
        {
            try
            {
                if (recent == null)
                {
                    recent = _cellArray[0, 0];
                }

                if (uncolored == 0)
                {
                    return true;
                }

                Cell n = findNextCell();

                //Step 1 
                for (int i = 1; i < n.Moves.Length; i++)
                {
                    if (n.Moves[i] == true)
                    {
                        n.Value = i;
                        List<Cell> cellList = new List<Cell>();

                        foreach (Tuple<Cell, int> edge in _graph.OutgoingEdges(n)) //step 2
                        {
                            if (edge.Item1.Moves[n.Value] == true)
                            {
                                edge.Item1.RemoveMove(n.Value); //step 2a
                                cellList.Add(edge.Item1); //steps 2b
                            }
                        }

                        if (SolveSudoku(findUncoloredNodes(), n)) //step 3
                        {
                            return true;
                        }

                        //step 4 
                        foreach (Cell sr in cellList)
                        {
                            if (sr.Moves[n.Value] == false) //it should since we made it false in the previous foreach loop
                            {
                                sr.AddMove(n.Value);
                            }
                        }
                        n.Value = -1;
                    }
                }
                //step 5
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }    
        }

        /// <summary>
        /// Finds all uncolored nodes left in array.
        /// </summary>
        /// <returns>Number of uncolored nodes left in the array</returns>
        private int findUncoloredNodes()
        {
            int uncolored = 0;

            foreach (Cell sr in _graph.Nodes)
            {
                if (sr.Value == -1)
                {
                    uncolored++;
                }
            }
            return uncolored;
        }

        /// <summary>
        /// Finds the next avaliable uncolored cell
        /// </summary>
        /// <returns>The next uncolored cell</returns>
        private Cell findNextCell()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_cellArray[i,j].Value == -1)
                    {
                        return _cellArray[i, j];
                    }
                }
            }
            return null;
        }
    }
}
