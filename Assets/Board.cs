using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

	public List<BoardPlane> Planes;

	/// <summary>
	/// When started, create a default Board, with a
	/// set of three vertically-stacked 10x10 BoardPlanes.
	/// </summary>
	void Start () {
		Planes = new List<BoardPlane>();
		Console.Out.WriteLine("Board: " + this.ToString());
		Planes.Add(new BoardPlane());
		Console.Out.WriteLine("Board: " + this.ToString());
		Planes.Add(new BoardPlane());
		Console.Out.WriteLine("Board: " + this.ToString());
		Planes.Add(new BoardPlane());
		Console.Out.WriteLine("Board: " + this.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override string ToString()
	{
		string boardString = "";
		
		// Print the planes top-to-bottom, so that the text reflects
		// the planes' vertical level in-game.
		for (int plane = Planes.Count - 1; plane >= 0; plane--)
		{
			// TODO Is this the row or the column?
			foreach (List<BoardSpace> row in Planes[plane].Spaces)
			{
				boardString += "[";
				
				foreach (BoardSpace space in row)
				{
					boardString += space.ToString();
					
					if (space != row[row.Count - 1])
					{
						boardString += ",";
					}
				}
				
				boardString += ("]" + Environment.NewLine);
			}
			
			boardString += Environment.NewLine;
			boardString += Environment.NewLine;
		}
		
		return boardString;
	}
	
	/// <summary>
	/// Retrieves the BoardSpace at the
	/// provided row, column, and level.
	/// </summary>
	public BoardSpace getSpace(int row, int column, int level)
	{
		// TODO This is a hacky way of determining valid positions.
		if (level < Planes.Count &&
		    row < Planes[0].Spaces.Count &&
		    column < Planes[0].Spaces.Count)
		{
			return Planes[level].Spaces[row][column];
		}
		else
		{
			throw new ArgumentOutOfRangeException();
		}
	}
	
	/// <summary>
	/// Gets a list of every BoardSpace that is an immediate neighbor to
	/// the provided space. An immediate neighbor is defined as a BoardSpace
	/// that is one space above, below, left, right, in, or out from the
	/// provided space.
	/// </summary>
	/// <remarks>
	// To solve this problem, we use the following brute-force method:
	// Each * is a space. o is the piece's position.
	// *  *  *
	// *  o  *
	// *  *  *
	// 
	// In a 2D plane, the *s are all immediate neighboring spaces,
	// ignoring when a * lies outside of the board boundaries.
	//
	// To get each of these points, you can use:
	// <o.x-1, o.y-1>,<o.x, o.y-1>,<o.x+1, o.y-1>
	// <o.x-1, o.y>,              ,<o.x+1, o.y>
	// <o.x-1, o.y+1>,<o.x, o.y+1>,<o.x+1, o.y+1>
	//
	// Then, we just repeat this process for z = {o.z-1, o.z, o.z+1}
	/// </remarks>
	public List<BoardSpace> getImmediateNeighboringSpaces(BoardSpace space)
	{
		List<int> levels;
		List<BoardSpace> spaces = new List<BoardSpace>();
		
		// TODO These bounds should be properties or functions of the board.
		// TODO This is a hacky way of calculating this value.
		// The maximum row that exists in the board.
		int rowBound    = this.Planes[0].Spaces.Count-1;
		int columnBound = this.Planes[0].Spaces.Count-1;
		
		
		if (space.Level == 0)      levels = new List<int>(){0, 1};
		else if (space.Level == 1) levels = new List<int>(){0, 1, 2};
		else                       levels = new List<int>(){1, 2};
		
		foreach (int level in levels)
		{
			// TODO Find a nice simple way to do this, rather than a ton of ifs.
			// TODO Put these checks for valid rows into a utility method.
			if (space.Row-1 > -1 && space.Column-1 > -1)
			{
				spaces.Add(this.getSpace(space.Row-1, space.Column-1, level));
			}
			if (space.Column-1 > -1)
			{
				spaces.Add(this.getSpace(space.Row,   space.Column-1, level));
			}
			if (space.Row+1 < rowBound && space.Column-1 > -1)
			{
				spaces.Add(this.getSpace(space.Row+1, space.Column-1, level));
			}
			if (space.Row-1 > -1)
			{
				spaces.Add(this.getSpace(space.Row-1, space.Column,   level));
			}
			
			if (level != space.Level)
			{
				spaces.Add(this.getSpace(space.Row, space.Column, level));
			}
			
			if (space.Row+1 < rowBound)
			{
				spaces.Add(this.getSpace(space.Row+1, space.Column,   level));
			}
			if (space.Row-1 > -1 && space.Column+1 < columnBound)
			{
				spaces.Add(this.getSpace(space.Row-1, space.Column+1, level));
			}
			if (space.Column+1 < columnBound)
			{
				spaces.Add(this.getSpace(space.Row,   space.Column+1, level));
			}
			if (space.Row+1 < rowBound && space.Column+1 < columnBound)
			{
				spaces.Add(this.getSpace(space.Row+1, space.Column+1, level));
			}
		}
		
		return spaces;
	}
}
