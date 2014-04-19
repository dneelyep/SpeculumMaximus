using UnityEngine;
using System.Collections;

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
		bolt.direction = new Vector3(0,0,1);
	}
	
}
