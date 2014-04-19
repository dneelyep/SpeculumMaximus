using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board{

	public Square[,,] board;
	public int numRows = 10;
	public int numColumns = 10;
	public int numLevels = 3;

	/// <summary>
	/// When started, create a default Board, with a
	/// set of three vertically-stacked 10x10 BoardPlanes.
	/// </summary>
	public Board()
	{
		board = new Square[numRows,numColumns,numLevels];
		for (int i = 0; i < numRows; i++)
		{
			for (int j= 0; j < numColumns; j++)
			{
				for (int k = 0; k < numLevels; k++)
				{
					board[i,j,k] = new Square(i,j,k);
				}
			}
		}

		//get pieces from the physical board and put them into the logical board
		List<Piece> pieces = new List<Piece>((Piece[])Object.FindObjectsOfType(typeof(Piece)));
		Vector3 pos;
		foreach(Piece piece in pieces)
		{
			Debug.Log(piece.ToString());
			pos = piece.position;
			board[(int) pos.y, (int) pos.x, (int) pos.z].piece = piece;
		}
		
		Debug.Log("board loaded");
	}
	//commenting this out since it is not used anywhere.
	/*
	public override string ToString()
		string boardString = "";
		
		// Print the planes top-to-bottom, so that the text reflects
		// the planes' vertical level in-game.
		for (int plane = Planes.Count - 1; plane >= 0; plane--)
		{
			// TODO Is this the row or the column?
			foreach (List<Sqaure> row in Planes[plane].Spaces)
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
*/

	//this can now be accessed through GameState.board.board[col,row,level]
	/// <summary>
	/// Retrieves the BoardSpace at the
	/// provided row, column, and level.
	/// </summary>
	public Square getSpace(int row, int column, int level)
	{
		// TODO This is a hacky way of determining valid positions.
		return this.board[row,column,level];
	}
	
	/// <summary>
	/// Gets the square at the specfied position
	/// </summary>
	/// <returns>
	/// A square object
	/// </returns>
	/// <param name='position'>
	/// Position.
	/// </param>
	public Square getSpace(Vector3 position)
	{
		return this.board[(int) position.x,
		                  (int) position.y,
		                  (int) position.z];
	}

	//might be more readable if we make a lsit of neighboring coordinates and use
	//List.removeAll(predicate) to get rid of the ones that don't eist
	
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
	public List<Square> getImmediateNeighboringSpaces(Square space)
	{
		List<int> levels;
		List<Square> spaces = new List<Square>();

		// TODO Replace this with simpler logic.
		/*
		// TODO These bounds should be properties or functions of the board.
		// TODO This is a hacky way of calculating this value.
		// The maximum row that exists in the board.
		int rowBound    = this.Planes[0].Spaces.Count-1;
		int columnBound = this.Planes[0].Spaces.Count-1;
		
		
		if (space.position.z == 0)      levels = new List<int>(){0, 1};
		else if (space.position.z == 1) levels = new List<int>(){0, 1, 2};
		else                       levels = new List<int>(){1, 2};
		
		foreach (int level in levels)
		{
			// TODO Find a nice simple way to do this, rather than a ton of ifs.
			// TODO Put these checks for valid rows into a utility method.
			if (space.position.x-1 > -1 && space.position.y-1 > -1)
			{
//				spaces.Add(GameState.board.board  this.getSpace(space.position.x-1, space.position.y-1, level));
			}
			if (space.position.x-1 > -1)
			{
				spaces.Add(this.getSpace(space.position.y,   space.position.x-1, level));
			}
			if (space.position.y+1 < rowBound && space.position.x-1 > -1)
			{
				spaces.Add(this.getSpace(space.position.y+1, space.position.x-1, level));
			}
			if (space.position.y-1 > -1)
			{
				spaces.Add(this.getSpace(space.position.y-1, space.position.x,   level));
			}
			
			if (level != space.position.z)
			{
				spaces.Add(this.getSpace(space.position.y, space.position.x, level));
			}
			
			if (space.position.y+1 < rowBound)
			{
				spaces.Add(this.getSpace(space.position.y+1, space.position.x,   level));
			}
			if (space.position.y-1 > -1 && space.position.x+1 < columnBound)
			{
				spaces.Add(this.getSpace(space.position.y-1, space.position.x+1, level));
			}
			if (space.position.x+1 < columnBound)
			{
				spaces.Add(this.getSpace(space.position.y,   space.position.x+1, level));
			}
			if (space.position.y+1 < rowBound && space.position.x+1 < columnBound)
			{
				spaces.Add(this.getSpace(space.position.y+1, space.position.x+1, level));
			}
		} */
		
		return spaces;
	}
}
