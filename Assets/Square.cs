using UnityEngine;
using System.Collections;


public class Square {
	public bool whiteLock = false;
	public bool blackLock = false;
	public Piece piece = null;

	public Vector3 position;

	public Square(int row, int column, int level)
	{
		position = new Vector3(column,row,level);
	}

	/// <summary>
	/// Checks if the given team is allowed into the space
	/// </summary>
	/// <returns><c>true</c>, if entry is permitted, <c>false</c> otherwise.</returns>
	/// <param name="team">the team the piece is on</param>
	public bool canEnter(Team team)
	{
		if (team == Team.White && !whiteLock)
			return true;
		else if (team == Team.Black && !blackLock)
			return true;
		else
			return false;
	}

	//probably not neccessary. We can just pass the object around directly. No need to serialize it.
	public override string ToString()
	{
		// TODO This needs to be updated to reflect moving Pieces to a list rather than a single object.
		// TODO This should be dependent on the Piece present in this board.
		//      This is just a stub for now. Or it might be better to implement
		//      this as part of the GamePiece itself.
		if (this.Pieces.Count > 0 &&
		    this.Pieces[0] == null)
		{
			return "*";
		}
		else
		{
			return this.Pieces[0].ToString();
		}
	}
}
