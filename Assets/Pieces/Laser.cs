using UnityEngine;
using System;

public class Laser : Piece {

	public int laserVel = 5;
	public LaserBolt bolt;

	// Use this for initialization
    void Start()
	{

    }


	public override bool Move(Vector3 direction)
	{
		return false;
	}
	
	public void fire()
	{

		bolt = (LaserBolt)Instantiate( Resources.Load("Bolt", typeof(LaserBolt)),this.transform.position,Quaternion.identity);
		switch((int)(this.transform.eulerAngles.y) % 360)
		{
		case 0:
			bolt.direction = new Vector3(0,0,1);
			break;
		case 90:
			bolt.direction = new Vector3(1,0,0);
			break;
		case 180:
			bolt.direction = new Vector3(0,0,-1);
			break;
		case 270:
			bolt.direction = new Vector3(-1,0,0);
			break;
		default:
			throw new Exception("Angle is negative. Fix the code");
		}
	}
	
}
