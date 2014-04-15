using UnityEngine;
using System.Collections;

/// <summary>
/// A list of the different teams that can play the game.
/// </summary>
public enum Team
{
	White,
	Black
};

public abstract class Piece : MonoBehaviour
{
	public Vector3 position;

	public Vector3 orientation;

	public Team team;

	protected Board board{ get; set; }

	//parameters for controling movement of game objects
	public static float moveRate = 1f;
	protected Vector3 target;
	protected Quaternion rotTarget;
	private float t=1.0f;
	private Vector3 oldLoc;
	private Quaternion oldRot;
	
	
	
	void Start()
	{
		Debug.Log (this.transform.position);
		oldLoc = this.transform.position;
		target = oldLoc;
		oldRot = this.transform.rotation;
		rotTarget = oldRot;

	}
	
	
	public abstract bool Move (Vector3 newPosition);
	
	public abstract bool Rotate(int direction);

	/// <summary>
	/// Move the piece in world space
	/// </summary>
	/// <param name='row'>
	/// New row
	/// </param>
	/// <param name='column'>
	/// New Column
	/// </param>
	/// <param name='level'>
	/// New Level
	/// </param>
	protected void MovePhys (Vector3 newPosition)
	{
		//get the new position
		target = new Vector3(this.transform.position.x + newPosition.y - this.position.y, this.transform.position.y + newPosition.z - this.position.z, this.position.z + newPosition.x - this.position.x);
		t = 0;
		Game.CurrentState = Game.State.FiringLaser;
		return;
	}

	/// <summary>
	/// Rotates the piece physically
	/// </summary>
	/// <param name='direction'>
	/// 1 for clockwise, -1 for counterclockwise
	/// </param>
	protected void RotatePhys (int direction)
	{
		rotTarget = Quaternion.Euler(0,90 * direction,0) * this.transform.rotation;
		t = 0;
		Game.CurrentState = Game.State.FiringLaser;
		return;
	}

	void Update ()
	{
		if (t < 1.0)
		{
			Debug.Log("moving");
			t+= Time.deltaTime * moveRate;
			this.transform.position = Vector3.Lerp(this.oldLoc,this.target, t);
			this.transform.rotation = Quaternion.Slerp(this.oldRot, this.rotTarget, t);
		 	
			if (t>= 1)
			{
				oldLoc = this.transform.position;
				oldRot = this.transform.rotation;

				Game.Fire();
			}
			
		}
		return;
	}
}
