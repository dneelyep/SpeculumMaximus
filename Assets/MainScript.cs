using UnityEngine;
using System.Collections;
using System;

namespace AssemblyCSharp
{
    public class MainScript : MonoBehaviour
    {
		private Board board;

        // Use this for initialization
        void Start()
        {
			try {
            	board = new Board();
			} catch (Exception ex) {
				Console.Out.WriteLine(ex.StackTrace);
			}

			Debug.Log(board.ToString());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
