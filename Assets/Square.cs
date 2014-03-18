using UnityEngine;
using System.Collections;


public class Square {
	public bool whiteLock = false;
	public bool blackLock = false;
	public Piece piece = null;
		
	/// <summary>
	/// A list of all GamePieces that are
	/// currently located in this Square.
	/// </summary>
	public List<Piece> Pieces;
	
	/// <summary>
	/// The board this Square belongs to.
	/// </summary>
	public Board Board;
	
	/// <summary>
	/// The row in the BoardPlane that this 
	/// Square is located in.
	/// </summary>
	public int Row;
	
	/// <summary>
	/// The column in the BoardPlane that this
	/// Square is located in.
	/// </summary>
	public int Column;
	
	/// <summary>
	/// The vertical level in the GameBoard that this
	/// Square is located in.
	/// </summary>
	public int Level;

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
