using System;
using UnityEngine;

/// <summary>
/// Class that maintains various bits of state needed
/// for operation of the game.
/// </summary>
public static class Game
{
	
		//the logical positions of the laser for eaach team.
	public static Vector3 whiteLaser = new Vector3(0,9,0);
	public static Vector3 blackLaser = new Vector3(9,0,0);
	
	public static GameOver endGame;
	
	/// <summary>
	/// A list of all states that are possible inside of
	/// the main game.
	/// </summary>
	public enum State
	{
		Selecting,
		Moving,
		FiringLaser,
		Victory
	}

	/// <summary>
	/// The current in-game state.
	/// </summary>
	public static State CurrentState = State.Selecting;

	public static Board board;

	public static Team currentPlayer = Team.White;

	public static void changePlayer()
	{
		if (currentPlayer == Team.White)
			currentPlayer = Team.Black;
		else
			currentPlayer = Team.White;
	}
	
		/// <summary>
	/// Fire the current team's laser.
	/// </summary>
	/// <exception cref='Exception'>
	/// Throws an exception when it doesbn't know whose turn it is (should never happen)
	/// </exception>
	public static void Fire()
	{
		switch (currentPlayer)
		{
		case (Team.White):
			((Laser)board.getSpace(whiteLaser).piece).fire();
			break;
		case (Team.Black):
			((Laser)board.getSpace(blackLaser).piece).fire();
			break;
		default:
			throw new Exception("we don't know whose turn it's supposed to be right now");
		}
	}
}

