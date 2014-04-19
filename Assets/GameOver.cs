
using System;
using UnityEngine;


/// <summary>
/// Class to handle displaying of the Game over
/// screen when a team wins a game.
/// </summary>
public class GameOver : MonoBehaviour
{
	private Team? gameWinner = null;
		
	/// <summary>
	/// Signals that the provided Team won the game, and
	/// thus that the Game Over screen should display,
	/// stating that the provided team won.
	/// </summary>
	/// <remarks>
	/// To call this, you can use some variant of the following
	/// at the time it should be called:
	/// FindObjectOfType<GameOver>().signalWinner(team);
	/// </remarks>
	public void signalWinner(Team team)
	{
		gameWinner = team;
	}
	
	void Update()
	{
		if (gameWinner != null)
		{
			if (Input.anyKey)
			{
				Application.LoadLevel("MainMenu");
			}
		}
	}

	public void OnGUI()
	{
		if (gameWinner != null)
		{
			// TODO Make this label display in the center of the screen.
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 100, 100),
			           gameWinner.ToString() + " won the game!");
		}
	}
}


