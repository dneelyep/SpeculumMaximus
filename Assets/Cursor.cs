using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {
	
	//vector representing logical position (row,column,level)
	public Vector3 position = new Vector3(0,0,0);
	
	//the logical positions of the laser for eaach team.
	public Vector3 whiteLaser = new Vector3(0,9,0);
	public Vector3 blackLaser = new Vector3(9,0,0);
	
	//the currently selected piece
	private Piece currentPiece = null;
	
	//holds the main camera. used to move the camera on going to a new level
	private GameObject cam;
	
	// Use this for initialization
	void Start () {
		GameState.currentPlayer = Team.White;
		GameState.CurrentState = GameState.InGameState.Selecting;
		GameState.board = new Board();
		cam = GameObject.Find("mainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
		
		//checks for movement key presses
		if (Input.GetKeyDown(KeyCode.W) && this.position.x < GameState.board.numRows -1)
		{
			this.position.x += 1;
			this.move(1,0,0);
		}
		else if (Input.GetKeyDown(KeyCode.S) && this.position.x > 0)
		{
			this.position.x -= 1;
			this.move(-1,0,0);
		}
		else if (Input.GetKeyDown(KeyCode.A) && this.position.y < GameState.board.numColumns -1)
		{
			this.position.y += 1;
			this.move(0,1,0);
		}
		else if (Input.GetKeyDown(KeyCode.D) && this.position.y > 0)
		{
			this.position.y -= 1;
			this.move(0,-1,0);
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow) && this.position.z < GameState.board.numLevels -1)
		{
			this.position.z += 1;
			this.move(0,0,1);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) && this.position.z > 0)
		{
			this.position.z -= 1;
			this.move(0,0,-1);
		}
		
		//selection/confirmation key press
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			if (GameState.CurrentState == GameState.InGameState.Selecting)
			{
				currentPiece = GameState.board.getSpace(this.position);
				if (currentPiece == null || currentPiece.team != GameState.currentPlayer)
				{
					currentPiece = null;
				}
				else
					GameState.CurrentState = GameState.InGameState.Moving;
			}
			
			else if (GameState.CurrentState == GameState.InGameState.Moving)
			{
				if (currentPiece.Move(position))
					Fire();
					
			}
		}
		
		//rotation
		else if (GameState.CurrentState == GameState.InGameState.Moving && Input.GetKeyDown(KeyCode.LeftArrow))
		{
			currentPiece.Rotate(-1);
			Fire();
		}
		
		else if (GameState.CurrentState == GameState.InGameState.Moving && Input.GetKeyDown(KeyCode.RightArrow))
		{
			currentPiece.Rotate(1);
			Fire();
		}
		
		//cancel move
		else if (Input.GetKeyDown(KeyCode.Escape) && GameState.CurrentState == GameState.InGameState.Moving)
		{
			this.currentPiece = null;
			GameState.CurrentState = GameState.InGameState.Selecting;
		}
	}
	
	/// <summary>
	/// Move the cursor as specifed
	/// </summary>
	/// <param name='delRow'>
	/// number of rows right to move
	/// </param>
	/// <param name='delCol'>
	/// Number of columns up to move.
	/// </param>
	/// <param name='delLevel'>
	/// Number of levels up to move.
	/// </param>
	public void move(int delRow, int delCol, int delLevel)
	{
		this.Transform.translate(new Vector3(delCol, delLevel, delRow));
		if (delLevel != 0)
			this.cam.Transform.translate( new Vector3(0,delLevel,0));
		return;
	}
	
	
	/// <summary>
	/// Fire the current team's laser.
	/// </summary>
	/// <exception cref='Exception'>
	/// Throws an exception when it doesbn't know whose turn it is (should never happen)
	/// </exception>
	public void Fire()
	{
		switch (GameState.currentPlayer)
		{
		case (Team.White):
			((laser)GameState.board.getSpace(this.whiteLaser).piece).Fire();
			break;
		case (Team.Black):
			((laser)GameState.board.getSpace(this.blackLaser).piece).Fire();
			break;
		default:
			throw new Exception("we don't know whose turn it's supposed to be right now");
		}
	}
		
				
}
