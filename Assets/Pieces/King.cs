using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class King: Piece
{

	/// <summary>
	/// Move the piece to target location.
	/// </summary>
	/// <param name="target">Coordinates of the square piece is moveing to</param>
	/// <returns>bool indicating if the move was successful</returns>
	

	// TODO Do we want to implement this functionality eventually?
	/*public override List<Square> GetValidMoves(Board board)
	{
		// TODO This is a hacky way of handling this.
		int rowMax    = board.Planes[0].Spaces.Count - 1;
		int colMax    = board.Planes[0].Spaces.Count - 1;
		int levelsMax = board.Planes.Count - 1;
		// TODO Combine this with GameBoard.getImmediateNeighboringPieces() to make it work.
		return new List<BoardSpace>();
	}*/

	public override string ToString ()
	{
		return "K";
	}

	void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);

		Destroy(this);
	}

	void OnDestroy()
	{
		switch (this.team)
		{
		case (Team.Black):
			Game.currentPlayer = Team.White;
			break;
		case (Team.White):
			Game.currentPlayer = Team.White;
			break;
		default:
			throw new Exception("An unknown team's King has been destroyed. You broke the game somehow.");
		}
		Game.CurrentState = Game.State.Victory;
	}
	
	public override bool Rotate(int direction)
	{
		//stub code.
		return false;
	}
}