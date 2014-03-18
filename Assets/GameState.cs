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
namespace AssemblyCSharp
{
	/// <summary>
	/// Class that maintains various bits of state needed
	/// for operation of the game.
	/// </summary>
	public static class GameState
	{
		/// <summary>
		/// A list of all states that are possible inside of
		/// the main game.
		/// </summary>
		public enum InGameState
		{
			WaitingForPlayer,
			WaitingForAI,
			FiringLaser
		}

		/// <summary>
		/// The current in-game state.
		/// </summary>
		public static InGameState CurrentState;
	}
}
