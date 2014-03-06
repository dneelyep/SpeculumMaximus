using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCSharp
{
    class Pharoah : GamePiece
    {
        /// <summary>
        /// Attempt to fire this Pharoah's laser in the 
        /// direction it is currently facing.
        /// </summary>
        public void FireLaser()
        {

        }

		public override void Move(BoardSpace space)
		{
			// TODO Fill me in.
		}

		public override List<BoardSpace> GetValidMoves(GameBoard board)
		{
			// TODO This is a hacky way of handling this.
			int rowMax    = board.Planes[0].Spaces.Count - 1;
			int colMax    = board.Planes[0].Spaces.Count - 1;
			int levelsMax = board.Planes.Count - 1;
			// TODO Combine this with GameBoard.getImmediateNeighboringPieces() to make it work.
			return new List<BoardSpace>();
		}

		public override string ToString ()
		{
			return "P";
		}
    }
}
