﻿using UnityEngine;
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
		//TODO: fill this code in
		Debug.Log("TODO Comment this code out to get the build working - fix me!");
		bolt = (LaserBolt) Instantiate( Resources.Load("Bolt",typeof(LaserBolt)),this.transform.position, Quaternion.identity);
		//TODO: customiz this so the bolt goes in the right direction
		bolt.direction = new Vector3(1,0,0);
	}
	
	public override bool Rotate(int direction)
	{
		return true;
	}
}
