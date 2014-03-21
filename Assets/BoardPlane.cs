using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class BoardPlane
{
	/// <summary>
	/// A 2D-array of each BoardSpace that makes up this BoardPlane.
	/// </summary>
	public List<List<Square>> Spaces = new List<List<Square>>();

	/// <summary>
	/// Create a default BoardPlane, with a 10x10 grid of Spaces.
	/// </summary>
	public BoardPlane()
	{
	    for (int row = 0; row < 10; row++)
	    {
	        Spaces.Add(new List<Square>(10));

	        for (int column = 0; column < 10; column++)
	        {
	            Spaces[Spaces.Count-1].Add(new Square());
	        }
	    }
	}
}

