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
	public Vector3 oldLoc;
	public Quaternion oldRot;
	
	
	
	void Start()
	{
		
		oldLoc = this.transform.position;
		print (oldLoc);
		print ("oldLoc set");
		target = oldLoc;
		oldRot = this.transform.rotation;
		rotTarget = oldRot;

	}
	
	
	public virtual bool Move (Vector3 newPosition)
	{
		//check if the target position is not too far away
		//since the max valid distanct is SQRT(3), and the min invalid distance is 2, this comparison works
		if ((newPosition-this.position).magnitude >= 2)
		{
			Debug.Log(string.Format("Move from {0} to {1} failed: too far",this.position, newPosition));
			return false;
		}
		//check if space is occupied
		else if (Game.board.getSpace(newPosition).piece != null)
		{
			Debug.Log(string.Format("Move from {0} to {1} failed: space occupied",this.position, newPosition));
			return false;
		}
		
		else
		{
			Debug.Log(string.Format("Move from {0} to {1} successful",this.position, newPosition));

			this.MovePhys(newPosition);
			Game.board.getSpace(this.position).piece = null;
			Game.board.getSpace(newPosition).piece = this;
			this.position = newPosition;
			return true;
		}
		return false;
		
	}
	
	public virtual bool Rotate(int direction)
	{
		Debug.Log("rotating");
		oldLoc = this.transform.position;
		oldRot =this.transform.rotation;
		this.RotatePhys(direction);
		return true;
	}

	/// <summary>
	/// move the piece in world space
	/// </summary>
	/// <param name='newPosition'>
	/// New logical position.
	/// </param>
	protected void MovePhys (Vector3 newPosition)
	{
		//get the new position
		target = new Vector3(this.transform.position.x + newPosition.y - this.position.y, this.transform.position.y + newPosition.z - this.position.z, this.transform.position.z + newPosition.x - this.position.x);
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
		target = this.transform.position;
		Debug.Log( System.String.Format("OldLoc:{0}  NewLoc:{1}",oldLoc,target));
		rotTarget = Quaternion.Euler(0,90 * direction,0) * this.transform.rotation;
		t = 0;
		Game.CurrentState = Game.State.FiringLaser;
		return;
	}

	void Update ()
	{
		if (t < 1.0)
		{
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
