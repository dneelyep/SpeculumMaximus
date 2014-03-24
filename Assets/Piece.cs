﻿using UnityEngine;
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
	public Vector3 position{ get; protected set; }

	public Vector3 orientation{ get; protected set; }

	public Team team{ get; private set; }

	protected Board board{ get; set; }

	//parameters for controling movement of game objects
	public float moveVel = 1f;
	public float rotateVel = 90;
	private bool isMoving = false;
	private Vector3 direction;
	protected int rotateDirection;
	protected Vector3 target;
	protected int rotTarget;
	private bool isRotating = false;

	public abstract bool Move (Vector3 newPosition);

	/// <summary>
	/// Physically moves the Piece to its new spot. Call from Move
	/// </summary>
	/// <param name="newPosition"Where you are moving the object to.</param>
	protected bool MovePhys (int row, int column, int level)
	{
		
		target = new Vector3 (column, level, row);
		direction = target - this.transform.position;
		isMoving = true;
		return true;
	}

	/// <summary>
	/// Rotates the piece physically
	/// </summary>
	/// <returns>
	/// true
	/// </returns>
	/// <param name='direction'>
	/// 1 for clockwise, -1 for counterclockwise
	/// </param>
	protected bool RotatePhys (int direction)
	{
		rotTarget = (int)this.transform.rotation.y + 90 * direction;
		this.isRotating = true;
		return true;
	}

	void onUpdate ()
	{
		if (isMoving) {
			this.transform.Translate (moveVel * direction * Time.deltaTime);

			//Check end conditions, and correct if piece has moved past target
			if (direction.x != 0) {
				if (direction.x < 0 && this.transform.position.x <= this.target.x) {
					this.transform.position = this.target;
					this.isMoving = false;
				} else if (direction.x > 0 && this.transform.position.x >= this.target.x) {
					this.transform.position = this.target;
					this.isMoving = false;
				}

			} else if (direction.y != 0) {
				if (direction.y < 0 && this.transform.position.y <= this.target.y) {
					this.transform.position = this.target;
					this.isMoving = false;
				} else if (direction.y > 0 && this.transform.position.y >= this.target.y) {
					this.transform.position = this.target;
					this.isMoving = false;
				}
				
			} else if (direction.z != 0) {
				if (direction.z < 0 && this.transform.position.z <= this.target.z) {
					this.transform.position = this.target;
					this.isMoving = false;
				} else if (direction.z > 0 && this.transform.position.z >= this.target.z) {
					this.transform.position = this.target;
					this.isMoving = false;
				}
				
			}

			return;
		}
		
		//code if we are rotating
		if (isRotating) {
			this.transform.Rotate (rotateDirection * Vector3.up * Time.deltaTime);
			//if we've overshot, correct rotation
			if (rotateDirection < 0 && this.transform.rotation.y < this.rotTarget) {
				if (this.rotTarget < 0)
					this.rotTarget += 360;
				this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x,
				                                         rotTarget,
				                                         this.transform.eulerAngles.z);
			} else if (rotateDirection > 0 && this.transform.rotation.y > this.rotTarget) {
				if (this.rotTarget > 360)
					this.rotTarget -= 360;
				this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x,
				                                         rotTarget,
				                                         this.transform.eulerAngles.z);
			}
		}
	}
}
