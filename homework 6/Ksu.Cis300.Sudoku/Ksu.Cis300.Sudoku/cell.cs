/* Cell.cs
 * Author: Jacob Dokos
 */

using System;

/// <summary>
/// Class to hold the row and column along with the data and avaliable colors for each spot in the puzzle
/// </summary>
public class Cell
{
    /// <summary>
    /// Which row the cell is in.
    /// </summary>
    private int _row;

    /// <summary>
    /// Which column the cell is in
    /// </summary>
    private int _column;

    /// <summary>
    /// What the value or 'color' the cell is
    /// </summary>
    private int _color;

    /// <summary>
    /// What colors are avalieble to a cells edges
    /// </summary>
    private bool[] _avaliableColors = new Boolean[10];

    /// <summary>
    /// Default constructor, not used
    /// </summary>
	public Cell()
	{
	}

    /// <summary>
    /// Makes a new cell with the passed in values and sets the array values to true
    /// </summary>
    /// <param name="row">What row the cell is at</param>
    /// <param name="column">What column the row is at</param>
    /// <param name="value">What the starting value of the cell is</param>
    public Cell(int row, int column, int value)
    {
        _row = row;
        _column = column;
        _color = value;

        for (int i = 1; i < _avaliableColors.Length; i++)
        {
            _avaliableColors[i] = true;
        }
    }

    /// <summary>
    /// Getter and setter to return the value in cell
    /// </summary>
    public int Value
    {
        get
        {
            return _color;
            
        }
        set
        {
            _color = value;
        }
    }

    /// <summary>
    /// Returns the row of the cell
    /// </summary>
    public int Row
    {
        get
        {
            return _row;

        }
    }

    /// <summary>
    /// Return the column of the cell
    /// </summary>
    public int Column
    {
        get
        {
            return _column;

        }
    }

    /// <summary>
    /// Gives access to the avalible colors for the cell
    /// </summary>
    public bool[] Moves
    {
        get
        {
            return _avaliableColors;
            
        }
    }

    /// <summary>
    /// Adds a move as avaliable in the cell's array
    /// </summary>
    /// <param name="index">What index to change the property of</param>
    public void AddMove(int index)
    {
        if (index > 9 || index < 1)
        {
            return;
        }
        else
        {
            _avaliableColors[index] = true; 
        }
    }

    /// <summary>
    /// Adds a move as not avaliable in the cell's array
    /// </summary>
    /// <param name="index">What index to change the property of</param>
    public void RemoveMove(int index)
    {
        if (index > 9 || index < 1)
        {
            return;
        }
        else
        {
            _avaliableColors[index] = false;
        }
        
    }
}
