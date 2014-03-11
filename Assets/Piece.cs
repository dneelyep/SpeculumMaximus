using UnityEngine;
using System.Collections;


public enum Team { White, Black};

public abstract class Piece : MonoBehaviour {
	public Vector3 position{get; private set;}
	public Vector3 orientation{get; private set;}
	public Team team{get; private set;}

	private Vector3 target{get;set;}

	public abstract bool Move(Vector3 direction);

	public abstract bool Rotate(int direction);
	
}
