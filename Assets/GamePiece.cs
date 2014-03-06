using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCSharp
{
    /// <summary>
    /// Base class for the individual Pieces that players can move in the game.
    /// </summary>
    abstract class GamePiece
    {
		/// <summary>
		/// The BoardSpace this GamePiece is currently located
		/// on in the GameBoard.
		/// </summary>
		public BoardSpace Space;

        public void Rotate()
        {
            // TODO Fill me in later.
        }

        /// <summary>
        /// Attempt to move this GamePiece to the provided BoardSpace.
        /// </summary>
        /// <param name="space">
        /// The space to move to.
        /// </param>
        public abstract void Move(BoardSpace space);

		/// <summary>
		/// Get a list of every position that this GamePiece 
		/// can validly move to on the provided GameBoard.
		/// </summary>
		public abstract List<BoardSpace> GetValidMoves(GameBoard board);
    }
}