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
}
