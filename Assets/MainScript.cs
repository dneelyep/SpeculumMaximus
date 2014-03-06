using UnityEngine;
using System.Collections;
using System;

namespace AssemblyCSharp
{
    public class MainScript : MonoBehaviour
    {
		private GameBoard board;

        // Use this for initialization
        void Start()
        {
			try {
            	board = new GameBoard();
			} catch (Exception ex) {
				Console.Out.WriteLine(ex.StackTrace);
			}

			Debug.Log(board.ToString());

			LoadStandardBoardLayout(board);
			Debug.Log(board.ToString());

			Debug.Log(board.getImmediateNeighboringSpaces(board.Planes[0].Spaces[0][0]));
			Debug.Log(board.getImmediateNeighboringSpaces(board.Planes[0].Spaces[0][0]));
            Debug.Log(board.getImmediateNeighboringSpaces(board.Planes[0].Spaces[0][0]));
        }

        // Update is called once per frame
        void Update()
        {

        }

		/// <summary>
		/// Load a set of GamePieces into position to begin a
		/// standard game of Speculum Maximus.
		/// </summary>
		/// <param name="board">
		/// The GameBoard which should be loaded with GamePieces.
		/// </param>
		private void LoadStandardBoardLayout(GameBoard board)
		{
			board.getSpace(9, 9, 0).Pieces.Add(new Pharoah());
		}
    }
}
