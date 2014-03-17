using UnityEngine;
using System.Collections;


public enum Team { White, Black};

public abstract class Piece : MonoBehaviour {
	public Vector3 position{get; protected set;}
	public Vector3 orientation{get; protected set;}
	public Team team{get; private set;}
    protected Board board{get; set;}

	//parameters for controling movement of game objects
	public float moveVel = 1f;
	public float rotateVel = 90;
	private bool isMoving = false;
	private Vector3 direction;
	protected int rotateDirection;
	protected Vector3 target;
	protected int rotTarget;
	private bool isRotating = false;

	public abstract bool Move(Vector3 newPosition);

	/// <summary>
	/// Physically moves the piece object to its new spot. Call from Move
	/// </summary>
	/// <param name="newPosition"Where you are moving the object to.</param>
	protected bool MovePhys(Vector3 newPosition)
	{
		if (!newPosition.Equals(this.transform.position))
		{
			target = newPosition;
			direction = newPosition - this.transform.position;
			isMoving = true;
			return true;
		}

		return false;

	}

	protected bool RotatePhys(int direction)
	{
		rotTarget = (int)this.transform.rotation.z + 90 * direction;
		this.isRotating = true;
		return true;
	}

	void onUpdate()
	{
		if (isMoving)
		{
			this.transform.Translate(moveVel * direction * Time.deltaTime);

			//Check end conditions, and correct if piece has moved past target
			if (direction.x != 0)
			{
				if (direction.x < 0 && this.transform.position.x <= this.target.x)
				{
					this.transform.position = this.target;
					this.isMoving = false;
				}

				else if (direction.x > 0 && this.transform.position.x >= this.target.x)
				{
					this.transform.position = this.target;
					this.isMoving = false;
				}

			}

			else if (direction.y != 0)
			{
				if (direction.y < 0 && this.transform.position.y <= this.target.y)
				{
					this.transform.position = this.target;
					this.isMoving = false;
				}
				
				else if (direction.y > 0 && this.transform.position.y >= this.target.y)
				{
					this.transform.position = this.target;
					this.isMoving = false;
				}
				
			}

			else if (direction.z != 0)
			{
				if (direction.z < 0 && this.transform.position.z <= this.target.z)
				{
					this.transform.position = this.target;
					this.isMoving = false;
				}
				
				else if (direction.z > 0 && this.transform.position.z >= this.target.z)
				{
					this.transform.position = this.target;
					this.isMoving = false;
				}
				
			}

			return;
		}

		if (isRotating)
		{
			this.transform.Rotate(rotateDirection * Vector3.forward * Time.deltaTime);
		}
	}

	public abstract bool Rotate(int direction);
	
}
