//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;

namespace AssemblyCSharp
{
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
		/// FindObjectOfType<AssemblyCSharp.GameOver>().signalWinner(team);
		/// </remarks>
		public void signalWinner(Team team)
		{
			gameWinner = team;
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
}

