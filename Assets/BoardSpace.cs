using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCSharp
{
    class BoardSpace
    {
		/// <summary>
		/// A list of all GamePieces that are
		/// currently located in this BoardSpace.
		/// </summary>
		public List<GamePiece> Pieces;

		/// <summary>
		/// The board this BoardSpace belongs to.
		/// </summary>
		public GameBoard Board;

		/// <summary>
		/// The row in the BoardPlane that this 
		/// BoardSpace is located in.
		/// </summary>
		public int Row;
		
		/// <summary>
		/// The column in the BoardPlane that this
		/// BoardSpace is located in.
		/// </summary>
		public int Column;
		
		/// <summary>
		/// The vertical level in the GameBoard that this
		/// BoardSpace is located in.
		/// </summary>
		public int Level;

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
}
